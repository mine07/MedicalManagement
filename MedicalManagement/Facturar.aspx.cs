using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalManagement
{
    public partial class Facturar : System.Web.UI.Page
    {
        int No_tiket = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["No_Tiket"]);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarRFC_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCliente.aspx");
        }
    }
}