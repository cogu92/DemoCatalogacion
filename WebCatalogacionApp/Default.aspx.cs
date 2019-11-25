using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCatalogacionApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            divError.Visible = false;
            try
            {
                lblError.Text = "";
                Boolean pRespuesta = true;
                if (txtUsuario.Text.Trim().Equals(""))
                {
                    divError.Visible = true;
                    lblError.Text = "Usuario no válido...";
                    txtUsuario.Focus();
                    pRespuesta = false;
                }
                if (txtClave.Text.Trim().Equals(""))
                {
                    divError.Visible = true;
                    lblError.Text = "Contraseña no válida....";
                    txtClave.Focus();
                    pRespuesta = false;
                }
                if (pRespuesta)
                {
                    Session.RemoveAll();
                    ClassDAO.cl_Usuarios pUser = new ClassDAO.cl_Usuarios();
                    String pConexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
                    String pError = "";
                    DataTable dtUser = pUser.ValidarUsuario(pConexion, txtUsuario.Text, txtClave.Text, ref pError);
                    if (dtUser.Rows.Count > 0)
                    {
                        AsignarVariables(txtUsuario.Text, dtUser);
                        Response.Redirect("Inbox.aspx");
                    }
                    else
                    {
                        divError.Visible = true;
                        lblError.Text = "Usuario invalido....";
                        pRespuesta = false;
                        txtUsuario.Focus();
                    }
                }
            }
            catch (Exception error)
            {
                divError.Visible = true;
                lblError.Text = "Usuario invalido...";
                lblError.ToolTip = error.Message;
                txtUsuario.Focus();
            }
        }

        public void AsignarVariables(String pUsuario, DataTable pDtUsuarios)
        {
            Session["Valid"] = 1;
            Session["pUser"] = pUsuario;
            Session["pFullName"] = pDtUsuarios.Rows[0]["Nombre"].ToString() + "  " + pDtUsuarios.Rows[0]["Apellido"].ToString();
            Session["pEmail"] = pDtUsuarios.Rows[0]["Email"].ToString();
            Session["pIdUser"] = pDtUsuarios.Rows[0]["Id"].ToString();
            Session["pIdRol"] = pDtUsuarios.Rows[0]["IdRol"].ToString();
        }
    }
}