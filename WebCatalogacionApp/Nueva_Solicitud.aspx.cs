using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using ClassDAO;
using System.Configuration;
using System.Data;

namespace WebCatalogacionApp
{
    public partial class Nueva_Solicitud : System.Web.UI.Page
    {
        public String coneccion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        public String pError = "";
        public Operacion_DB_General dbconsultas = new Operacion_DB_General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
            }
        }
        public void Enviar_mail() {
            DataTable dt = new DataTable();
            dt = dbconsultas.Consultar_todo(coneccion, ref pError, "Ct_view_emails_catalogadores");

            foreach (DataRow row in dt.Rows)
            {
                var fromAddress = new MailAddress("catalogaciontest@gmail.com", "catalogaciontest");
                var toAddress = new MailAddress(row[1].ToString(), row[0].ToString());
                const string fromPassword = "Col2018_";
                 string subject = "Solicitud Catalogacion "+txtdescrip.Text;
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

            if (dbconsultas.insertar(coneccion, "[Ct_Solicitud]", "[Id_user],[Solicitud],[Descripcion],[Estado],[Es_ERP]", Session["pIdUser"].ToString() + ",'" + txtdescrip.Text + "','" + txtobserv.Text + "',5," + Session["Catalogo"].ToString(), ref pError))
            {
                Enviar_mail(); 
                lblexitoso.Visible = true;
                txtdescrip.Text = "";
                txtobserv.Text = "";
            }



        }
    }
}