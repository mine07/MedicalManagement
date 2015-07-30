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

namespace MedicalManagement
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Convert.ToString(Session["NombreUsuario"]);            
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

          /*
            string consulta;
            SqlCommand comando;
            int numeroidmodulo = 0;
            string consulta2;
            SqlCommand comando2;
            bool estatuspermiso = false;
            Session["estatuspermiso"] = false;

            switch (valornombrepagina)
            {
                case "Empresas.aspx":

                    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + e.Item.Value + "'";

                    comando = new SqlCommand(consulta, cnn);

                    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                    comando2 = new SqlCommand(consulta2, cnn);

                    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                    if (estatuspermiso == true)
                    {
                        Response.Redirect("Empresas.aspx");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                    }

                    break;


                case "Sucursales.aspx":

                    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + e.Item.Value + "'";

                    comando = new SqlCommand(consulta, cnn);
                    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                    comando2 = new SqlCommand(consulta2, cnn);

                    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                    if (estatuspermiso == true)
                    {
                        Response.Redirect("Sucursales.aspx");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                    }

                    break;

                case "Perfles.aspx":

                    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + e.Item.Value + "'";

                    comando = new SqlCommand(consulta, cnn);
                    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                    comando2 = new SqlCommand(consulta2, cnn);

                    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                    if (estatuspermiso == true)
                    {
                        Response.Redirect("Perfles.aspx");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                    }

                    break;

                case "Usuarios.aspx":

                    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + e.Item.Value + "'";

                    comando = new SqlCommand(consulta, cnn);
                    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                    comando2 = new SqlCommand(consulta2, cnn);

                    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                    if (estatuspermiso == true)
                    {
                        Session["estatuspermiso"] = estatuspermiso;
                        Response.Redirect("Usuarios.aspx");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                    }

                    break;

                case "Modulos.aspx":

                    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + e.Item.Value + "'";

                    comando = new SqlCommand(consulta, cnn);
                    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                    comando2 = new SqlCommand(consulta2, cnn);

                    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                    if (estatuspermiso == true)
                    {
                        Response.Redirect("Modulos.aspx");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                    }

                    break;

                case "Permisos.aspx":

                    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + e.Item.Value + "'";

                    comando = new SqlCommand(consulta, cnn);
                    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                    comando2 = new SqlCommand(consulta2, cnn);

                    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                    if (estatuspermiso == true)
                    {
                        Response.Redirect("Permisos.aspx");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                    }

                    break;

                case "PermisoPerfil2.aspx":

                    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + e.Item.Value + "'";

                    comando = new SqlCommand(consulta, cnn);
                    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                    comando2 = new SqlCommand(consulta2, cnn);

                    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                    if (estatuspermiso == true)
                    {
                        Response.Redirect("PermisoPerfil2.aspx");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                    }

                    break;

                case "Bitacora.aspx":

                    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + e.Item.Value + "'";

                    comando = new SqlCommand(consulta, cnn);
                    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                    comando2 = new SqlCommand(consulta2, cnn);

                    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                    if (estatuspermiso == true)
                    {
                        Response.Redirect("Bitacora.aspx");
                    }
                    else 
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");
                        //Response.Redirect("MenuInicial.aspx");
                    }                                       

                    break;
            }
                        
           */
            cnn.Close();
        }

        protected void logout(object sender, EventArgs e)
        {
            Session["inicio"] = null;
            Session["inicionombre"] = null;
            Session["iniciocuenta"] = null;
            Session["NombreUsuario"] = null;
            Response.Redirect("login.aspx");
        }
    }
}
