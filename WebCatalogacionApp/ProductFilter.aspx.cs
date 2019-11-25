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
    public partial class ProductFilter : System.Web.UI.Page
    {
        public String coneccion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        public String pError = "";
        public Operacion_DB_General dbconsultas = new Operacion_DB_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddropdowns();
                loadGrid_all();
            }
        }

        public void loaddropdowns()
        {

            DrClase.DataTextField = "Nombre_Es";
            DrClase.DataValueField = "Id";
            DrClase.DataSource = dbconsultas.Consultar_todo(coneccion, ref pError, "Ct_Clases", "Estado=1");

            DrClase.DataBind();




            DrModificador.DataTextField = "Nombre_Es";
            DrModificador.DataValueField = "Id";
            DrModificador.DataSource = dbconsultas.Consultar_todo(coneccion, ref pError, "Ct_Modificadores", "Estado=1");
            DrModificador.DataBind();




            DrCaracteristica.DataTextField = "Nombre_Es";
            DrCaracteristica.DataValueField = "Id";
            DrCaracteristica.DataSource = dbconsultas.Consultar_todo(coneccion, ref pError, "Ct_Caracteristicas", "Estado=1");
            DrCaracteristica.DataBind();




            DrDenominacion.DataTextField = "Nombre_Es";
            DrDenominacion.DataValueField = "Id";
            DrDenominacion.DataSource = dbconsultas.Consultar_todo(coneccion, ref pError, "Ct_Denominacion", "Estado=1");
            DrDenominacion.DataBind();




            //  loadGrid();
        }

        public void loadGrid_all()
        {


            if (DrClase.SelectedValue != "" && DrModificador.SelectedValue != "" && DrCaracteristica.SelectedValue != "" && DrDenominacion.SelectedValue != "")
                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_all_data", "Unspsc,Nom_Clase_es as Clase, Nom_Modificador_es As Modificador,Jerarquia, Nom_Caracteristica_es Caracteristica ,Nom_Denomi_es As Denominacion", " Id_Clase=" + DrClase.SelectedValue + " AND Id_Modificador=" + DrModificador.SelectedValue + "  AND Id_Caracteristica=" + DrCaracteristica.SelectedValue + "  AND Id_Denomi=" + DrDenominacion.SelectedValue);

            else if (DrClase.SelectedValue != "" && DrModificador.SelectedValue != "" && DrCaracteristica.SelectedValue != "")
                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_all_data", " Unspsc,Nom_Clase_es as Clase, Nom_Modificador_es As Modificador,Jerarquia, Nom_Caracteristica_es Caracteristica ,Nom_Denomi_es As Denominacion", " Id_Clase=" + DrClase.SelectedValue + " AND Id_Modificador=" + DrModificador.SelectedValue + "  AND Id_Caracteristica=" + DrCaracteristica.SelectedValue);

            else if (DrClase.SelectedValue != "" && DrModificador.SelectedValue != "")
                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_all_data", " Unspsc,Nom_Clase_es as Clase, Nom_Modificador_es As Modificador,Jerarquia, Nom_Caracteristica_es Caracteristica ,Nom_Denomi_es As Denominacion", " Id_Clase=" + DrClase.SelectedValue + " AND Id_Modificador=" + DrModificador.SelectedValue);
            else if (DrClase.SelectedValue != "")
                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_all_data", " Unspsc,Nom_Clase_es as Clase, Nom_Modificador_es As Modificador,Jerarquia, Nom_Caracteristica_es Caracteristica ,Nom_Denomi_es As Denominacion", " Id_Clase=" + DrClase.SelectedValue);
            else
                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_all_data", " Unspsc,Nom_Clase_es as Clase, Nom_Modificador_es As Modificador,Jerarquia, Nom_Caracteristica_es Caracteristica ,Nom_Denomi_es As Denominacion", "");


            GridInfo.DataBind();

        }
  
        protected void DrClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrModificador.DataTextField = "Nombre_es";
            DrModificador.DataValueField = "Id";
            DrModificador.DataSource = dbconsultas.Consultar(coneccion, ref pError, "[Ct_view_clase_modificador]", "Nombre_es,Id", " Id_Clase=" + DrClase.SelectedValue + " Group by Id,Nombre_es Order by Nombre_es");
            DrModificador.DataBind();

            loadGrid_all();
            DrCaracteristica.SelectedValue   = "";
            DrDenominacion.SelectedValue = "";
            DrModificador.SelectedValue = "";
        }

        protected void DrModificador_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrCaracteristica.DataTextField = "Nombre_es";
            DrCaracteristica.DataValueField = "Id";
            DrCaracteristica.DataSource = dbconsultas.Consultar(coneccion, ref pError, "[Ct_view_modificador_caracteristica]", "Nombre_es,Id", " Id_Modificador=" + DrModificador.SelectedValue + " Group by  Nombre_es, Id  Order by Nombre_es");
            DrCaracteristica.DataBind();
            DrCaracteristica.SelectedValue = "";
            DrDenominacion.SelectedValue = "";
            loadGrid_all();

        }

        protected void DrCaracteristica_SelectedIndexChanged(object sender, EventArgs e)
        {

            DrDenominacion.DataTextField = "Nom_Denomi_es";
            DrDenominacion.DataValueField = "Id_Denomi";
            DrDenominacion.DataSource = dbconsultas.Consultar(coneccion, ref pError, "[Ct_view_all_data]", "Nom_Denomi_es,Id_Denomi", " Id_Modificador=" + DrModificador.SelectedValue + " AND   Id_Clase=" + DrClase.SelectedValue + " And Id_Caracteristica=" + DrCaracteristica.SelectedValue + " Group By Id_Denomi,Nom_Denomi_es order by Nom_Denomi_es");
            DrDenominacion.DataBind();
          
            loadGrid_all();

        }

        protected void DrDenominacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGrid_all();

        }

        protected void BtnSolicitud_Click(object sender, EventArgs e)
        {
            Session["Catalogo"] = 0;

            Response.Redirect("Nueva_Solicitud.aspx");
        }

        protected void GridInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //  GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_all_data", " Unspsc,Nom_Clase_es as Clase, Nom_Modificador_es As Modificador,Jerarquia, Nom_Caracteristica_es Caracteristica ,Nom_Denomi_es As Denominacion", " Id_Clase=" + DrClase.SelectedValue + " ADN Id_Modificador=" + DrModificador.SelectedValue + "  AND Id_Caracteristica=" + DrCaracteristica.SelectedValue + "  AND Id_Denomi=" + DrDenominacion.SelectedValue);
            GridInfo.PageIndex = e.NewPageIndex;
            loadGrid_all();
        }


    }
}