using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Convert.ToString(Session["NombreUsuario"]);
                checkPermission();
            }
        }

        private void checkPermission()
        {
            var link = this.Page.Request.FilePath;
            link = link.Remove(0, 1);
            var onePerfil = (PerfilDTO)Session["Perfil"];
            PerfilDAO GetOne = new PerfilDAO();
            onePerfil = GetOne.onePerfil(onePerfil);
            if (onePerfil == null)
            {
                HttpContext.Current.Response.Redirect("Login.aspx", true);
            }
            var lPermisos = onePerfil.lPermisos;
            try
            {
            var onePermiso = lPermisos.Single(x => x.oneModulo.Programa_Modulo == link);
            if (!onePermiso.Estatus_Permiso)
            {
                HttpContext.Current.Response.Redirect("MenuInicial.aspx?Forbidden", true);
            }
            }
            catch
            {

            }
        }

        protected void menuclick(object sender, MenuEventArgs e)
        {
            int valoridperfildeusuario = 0;
            valoridperfildeusuario = Convert.ToInt32(Session["inicioidperfil"]);

            string valornombrepagina = e.Item.Value;

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();


            if (e.Item.Value == "Salir")
            {
                string cadena = e.Item.ValuePath;
                Session["inicio"] = null;
                Session["inicionombre"] = null;
                Session["iniciocuenta"] = null;
                Session["NombreUsuario"] = null;
                Response.Redirect("login.aspx");
            }
            cnn.Close();
        }

        protected void logout(object sender, EventArgs e)
        {
            Session["inicio"] = null;
            Session["inicionombre"] = null;
            Session["iniciocuenta"] = null;
            Session["NombreUsuario"] = null;
            Response.Redirect("login.aspx");
            Session["Perfil"] = null;
        }
    }
}
