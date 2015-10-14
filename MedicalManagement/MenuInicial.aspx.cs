using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalManagement
{
    public partial class MenuInicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string success = Request.QueryString["name"];

            string script2 = "llamaralerta2();";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
            //SCRIPT MANAGER
            /*if (success=="ok")
            {
                string script2 = "llamaralerta2();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
            }*/


            Alerta.InnerHtml = Convert.ToString(Session["alerta"]);
            Session["alerta"] = null;

            int usuario = Convert.ToInt32(Session["inicio"]);
            if (Session["inicio"] == null || usuario == 0)
            {
                Response.Redirect("Login.aspx");
            }

            else
            {

                if (!IsPostBack)
                {
                    
                }
            }

        }
    }
}