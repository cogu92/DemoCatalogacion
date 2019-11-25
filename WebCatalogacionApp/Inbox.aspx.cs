using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassDAO;

namespace WebCatalogacionApp
{
    public partial class Inbox : System.Web.UI.Page
    {
        public String coneccion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        public String pError = "";
        public Operacion_DB_General dbconsultas = new Operacion_DB_General();
        public String IdSolicitud = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pIdRol"].ToString() != "2")
                    divmail.Visible = false;

             

                loaddropdowns();
                loadGrid_all();
            }
        }
        public void Clean()
        {


            DrEstado.SelectedIndex = 1;
            txtdescrip.Text = "";
            txtobserv.Text = "";


        }

        public void loaddropdowns()
        {


            DrEstado.DataTextField = "Description";
            DrEstado.DataValueField = "Id";
            DrEstado.DataSource = dbconsultas.Consultar_todo(coneccion, ref pError, "Ct_Estados_Solicitud", "");
            DrEstado.DataBind();


        }
        public void loadGrid_all()
        {

            if (Session["pIdRol"].ToString() == "2")
                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "[Ct_view_Inbox]", "TOP(50) Numero_Solicitud as [No.Solicitud], [Solicitud],[Descripcion],CONVERT(VARCHAR(10),[Fecha_Solicitud], 103) as Fecha_Solicitud,[nombre],[apellido],[Description]  as Estaso", "Es_ERP=0 AND Id=5 order by 1 desc");
            else
                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "[Ct_view_Inbox]", "TOP(50) Numero_Solicitud as [No.Solicitud], [Solicitud],[Descripcion],CONVERT(VARCHAR(10),[Fecha_Solicitud], 103) as Fecha_Solicitud,[nombre],[apellido],[Description] as Estaso", "Es_ERP=0 AND Id_user=" + Session["pIdUser"] + " order by 1 desc");


            GridInfo.DataBind();

        }



        protected void GridInfo_SelectedIndexChanged(object sender, EventArgs e)
        {


            String soliciud = "Gestionando Solicitud No." + GridInfo.Rows[GridInfo.SelectedRow.RowIndex].Cells[1].Text + " Referente a " + GridInfo.Rows[GridInfo.SelectedRow.RowIndex].Cells[2].Text;
            Session["IdSolicitud"] = GridInfo.Rows[GridInfo.SelectedRow.RowIndex].Cells[1].Text;
            lblseleccion.Text = soliciud;
            lblexitoso.Visible = false;
        }
        public void Enviar_mail(String IdUsuario)
        {
            DataTable dt = new DataTable();
            dt = dbconsultas.Consultar(coneccion, ref pError, "Ct_Usuarios", "email, nombre", "Id=" + IdUsuario);

            foreach (DataRow row in dt.Rows)
            {
                var fromAddress = new MailAddress("catalogaciontest@gmail.com", "catalogaciontest");
                var toAddress = new MailAddress(row[0].ToString(), row[1].ToString());
                const string fromPassword = "Col2018_";
                string subject = txtdescrip.Text + " Estado:" + DrEstado.SelectedItem;
                string body = txtobserv.Text;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

            }


        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            if (Session["IdSolicitud"].ToString() != "")
            {
                String IdUsuario = dbconsultas.Consultar(coneccion, ref pError, "[Ct_view_Inbox]", "Id_user", "Numero_Solicitud=" + Session["IdSolicitud"].ToString() + "").Rows[0].ItemArray[0].ToString();


                if (IdUsuario != "" || IdUsuario != null)
                {
                    dbconsultas.Modificar(coneccion, "Ct_Solicitud", "Estado=" + DrEstado.SelectedValue, "Id=" + Session["IdSolicitud"].ToString(), ref pError);

                    Enviar_mail(IdUsuario);
                    lblexitoso.Visible = true;
                    loadGrid_all();
                    Clean();
                }
            }

        }

        protected void GridInfo_DataBound(object sender, EventArgs e)
        {
            try
            {

                if (Session["pIdRol"].ToString() != "2")
                    GridInfo.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
            }
        }

        protected void GridInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridInfo.PageIndex = e.NewPageIndex;
            loadGrid_all();
        }

     
    }
}
