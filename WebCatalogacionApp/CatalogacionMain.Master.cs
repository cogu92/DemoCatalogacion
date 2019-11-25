using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCatalogacionApp
{
    public partial class CatalogacionMain : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { }
        }


        protected void btnInbox_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inbox.aspx");


        }

        protected void btnCatalogoErp_Click(object sender, EventArgs e)
        {
            Response.Redirect("CatalogoERP.aspx");


        }

        protected void btnSolicitudERP_Click(object sender, EventArgs e)
        {
            Response.Redirect("InboxERP.aspx");


        }

        protected void btnCatalogar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogar.aspx");

        }
        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductFilter.aspx");
        }

        protected void btnCatalogado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogado.aspx");
        }
    }
}