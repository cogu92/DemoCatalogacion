using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassDAO;

namespace WebCatalogacionApp
{
    public partial class CatalogoERP : System.Web.UI.Page
    {
        public String coneccion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        public String pError = "";
        public Operacion_DB_General dbconsultas = new Operacion_DB_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                loadGrid_all();
            }

        }
        public void loadGrid_all()
        {


                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_View_ERP_Data", " Cod_ERP, Nombre_Producto as Nombre, Descripcion, Tipo", "");


            GridInfo.DataBind();

        }
        protected void BtnSolicitud_Click(object sender, EventArgs e)
        {
            Session["Catalogo"] = 1;

            Response.Redirect("Nueva_Solicitud.aspx");
        }
        protected void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_View_ERP_Data", " Cod_ERP, Nombre_Producto as Nombre, Descripcion, Tipo", "Cod_ERP like '" + txtbuscar.Text + "' or Nombre_Producto like'" + txtbuscar.Text + "'"); GridInfo.DataBind();
            }
            else
                loadGrid_all();


        }
        protected void GridInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //  GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_all_data", " Unspsc,Nom_Clase_es as Clase, Nom_Modificador_es As Modificador,Jerarquia, Nom_Caracteristica_es Caracteristica ,Nom_Denomi_es As Denominacion", " Id_Clase=" + DrClase.SelectedValue + " ADN Id_Modificador=" + DrModificador.SelectedValue + "  AND Id_Caracteristica=" + DrCaracteristica.SelectedValue + "  AND Id_Denomi=" + DrDenominacion.SelectedValue);
            GridInfo.PageIndex = e.NewPageIndex;
            loadGrid_all();
        }
    }
}