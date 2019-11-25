using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassDAO;

namespace WebCatalogacionApp
{
    public partial class Catalogar : System.Web.UI.Page
    {
        public String coneccion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        public String pError = "";
        public Operacion_DB_General dbconsultas = new Operacion_DB_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddropdowns();
                // loadGrid_all();
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


        }

        public void loadGrid_all()
        {

            if (DrClase.SelectedValue != "" && DrModificador.SelectedValue != "")
            {
                GridInfoEn.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_Clase_Modificador_En", "  Unspsc, [Modifier Name ], [Modifier  Short Name], [Class Name], [Class Short Name]", " Id_Clase=" + DrClase.SelectedValue + " AND Id_Modificador=" + DrModificador.SelectedValue);
                GridInfoEn.DataBind();
                GridInfoEs.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_Clase_Modificador_Es", "Unspsc, [Nombre Modificador], [Nombre Corto Modificador], [Nombre Clase], [Nombre Corto Clase]", " Id_Clase=" + DrClase.SelectedValue + " AND Id_Modificador=" + DrModificador.SelectedValue);
                GridInfoEs.DataBind();
                GridCaracteristicas.DataSource = dbconsultas.Consultar(coneccion, ref pError, " Ct_view_all_data", "Id_Caracteristica, Nom_Caracteristica_es ", " Id_Clase =" + DrClase.SelectedValue + " AND Id_Modificador=" + DrModificador.SelectedValue + " GROUP BY Id_Caracteristica, Nom_Caracteristica_es");
                GridCaracteristicas.DataBind();

            }
        }

        protected void DrClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrModificador.DataTextField = "Nombre_es";
            DrModificador.DataValueField = "Id";
            DrModificador.DataSource = dbconsultas.Consultar(coneccion, ref pError, "[Ct_view_clase_modificador]", "Nombre_es,Id", " Id_Clase=" + DrClase.SelectedValue + " Group by Id,Nombre_es Order by Nombre_es");
            DrModificador.DataBind();



        }

        protected void DrModificador_SelectedIndexChanged(object sender, EventArgs e)
        {

            loadGrid_all();

        }



        protected void GridCaracteristicas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList DropDownList1 = (e.Row.FindControl("DropDownList1") as DropDownList);

                DropDownList1.DataSource = dbconsultas.Consultar(coneccion, ref pError, "Ct_view_all_data", "Id_Denomi, Nom_Denomi_es", " Id_Caracteristica=" + DataBinder.Eval(e.Row.DataItem, "Id_Caracteristica") + "AND Id_Clase =" + DrClase.SelectedValue + " AND Id_Modificador=" + DrModificador.SelectedValue + " GROUP BY   Id_Denomi, Nom_Denomi_es");


                DropDownList1.DataTextField = "Nom_Denomi_es";
                DropDownList1.DataValueField = "Id_Denomi";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("--Seleccione--", "0"));


            }
        }

        protected void btnCatalogar_Click(object sender, EventArgs e)
        {

            DataTable resultClase = new DataTable();
            DataTable resultModificador = new DataTable();
            DataTable resultCaracteristica = new DataTable();
            DataTable resultDenominacion = new DataTable();

            int catalogacionid = Convert.ToInt32(dbconsultas.Consultar(coneccion, ref pError, "[Ct_Catalogacion]", "max(Id_Catalogacion)").Rows[0][0])+1;
            resultClase = dbconsultas.Consultar(coneccion, ref pError, "Ct_Clases", "Id,Nombre_Es, Nombre_En, Nombre_Corto_Es, Nombre_Corto_En", "Id=" + DrClase.SelectedValue);
            resultModificador = dbconsultas.Consultar(coneccion, ref pError, "Ct_Modificadores", "Id,Nombre_Es, Nombre_En, Nombre_Corto_Es, Nombre_Corto_En", "Id=" + DrModificador.SelectedValue);
            lblcalaogado_En.Text = resultClase.Rows[0][1] + "," + resultModificador.Rows[0][1];
            lblcalaogado_Es.Text = resultClase.Rows[0][2] + "," + resultModificador.Rows[0][2];
            lblnombrecorto.Text = resultClase.Rows[0][3] + "," + resultModificador.Rows[0][3];

            foreach (GridViewRow row in GridCaracteristicas.Rows)
            {
                string iddenomi= ((DropDownList)row.FindControl("DropDownList1")).SelectedItem.Value;
                if (iddenomi != "0") {
                    resultCaracteristica = dbconsultas.Consultar(coneccion, ref pError, "Ct_Caracteristicas", "Id,Nombre_Es, Nombre_En", "Nombre_Es='" + row.Cells[1].Text + "'");
                    resultDenominacion = dbconsultas.Consultar(coneccion, ref pError, "Ct_Denominacion", "Id,Nombre_Es, Nombre_En, Abreviado", "Id=" + iddenomi);
                    lblnombrecorto.Text = lblnombrecorto.Text + " , " + resultDenominacion.Rows[0][3];
                    lblcalaogado_En.Text = lblcalaogado_En.Text + " , " + resultCaracteristica.Rows[0][2] + ":" + resultDenominacion.Rows[0][2];
                    lblcalaogado_Es.Text = lblcalaogado_Es.Text + " , " + resultCaracteristica.Rows[0][1] + ":" + resultDenominacion.Rows[0][1];


                    dbconsultas.insertar(coneccion
                        , "[Ct_Catalogacion]"
                        , "Id_Catalogacion,Id_Clase, Clase_Nombre_Es, Clase_Nombre_En, Clase_Nombre_Corto_Es, Clase_Nombre_Corto_En,Id_Modificador, Modificador_Nombre_Es, Modificador_Nombre_En, Modificador_Nombre_Corto_Es, Modificador_Nombre_Corto_En,Id_Caracteristica, Caracteristica_Nombre_Es, Caracteristica_Nombre_En,Id_Denominacion, Denominacion_Nombre_Es, Denominacion_Nombre_En,Denominacion_Abreviado, Id_user"
                        , catalogacionid + "," + DrClase.SelectedValue + ",'" + resultClase.Rows[0][2] + "','" + resultClase.Rows[0][1] + "','" + resultClase.Rows[0][3] + "','" + resultClase.Rows[0][4] +
                        "'," + DrModificador.SelectedValue + ",'" + resultModificador.Rows[0][2] + "','" + resultModificador.Rows[0][1] + "','" + resultModificador.Rows[0][3] + "','" + resultModificador.Rows[0][4] +
                        "'," + resultCaracteristica.Rows[0][0] + ",'" + resultCaracteristica.Rows[0][1] + "','" + resultCaracteristica.Rows[0][2] +
                        "'," + resultDenominacion.Rows[0][0] + ",'" + resultDenominacion.Rows[0][1] + "','" + resultDenominacion.Rows[0][2] + "','" + resultDenominacion.Rows[0][3] +
                        "'," + Session["pIdUser"]
                        , ref pError);
                }

            }
        }
    }
}