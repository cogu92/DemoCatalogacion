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
    public partial class Catalogado : System.Web.UI.Page
    {
        public String coneccion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        public String pError = "";
        public Operacion_DB_General dbconsultas = new Operacion_DB_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                GridInfo.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_Catalogacion", @" Id_Catalogacion, Clase_Nombre_Es, Clase_Nombre_En, Clase_Nombre_Corto_Es, Clase_Nombre_Corto_En, Modificador_Nombre_Es, Modificador_Nombre_En, Modificador_Nombre_Corto_Es, 
                         Modificador_Nombre_Corto_En, Caracteristica_Nombre_Es, Caracteristica_Nombre_En, Denominacion_Nombre_Es, Denominacion_Nombre_En, Denominacion_Abreviado, Fecha_Creacion"," 1=1 order by 1");
                GridInfo.DataBind();
            }
        }
    }
}