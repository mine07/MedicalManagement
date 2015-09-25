using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //string consulta = "select count(*) from Tabla_Catalogo_Usuario where Cuenta_Usuario='" + txtusuario.Text + "' and PWD_Usuario='" + txtcontrasena.Text + "'";
            string consulta = @"select count(*) from Tabla_Catalogo_Usuario where Cuenta_Usuario= @user AND PWD_Usuario = @pass";
            DataTable midatatable = new DataTable();
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand cmd = new SqlCommand(consulta, cnn);
            cmd.Parameters.AddWithValue("@user", txtusuario.Text.Trim());
            cmd.Parameters.AddWithValue("@pass", txtcontrasena.Text.Trim());
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            
                      
            
            Session["inicio"] = count;

            if (count!= 0)
            {
                string consulta2 = "select Id_perfil from Tabla_Catalogo_Usuario where Cuenta_Usuario='" + txtusuario.Text + "' and PWD_Usuario='" + txtcontrasena.Text + "'";
                SqlCommand comando2 = new SqlCommand(consulta2, cnn);
                int numeroidperfil = Convert.ToInt32(comando2.ExecuteScalar());
                var getOne = new PerfilDAO();
                var onePerfil = getOne.onePerfil(new PerfilDTO {Id_Perfil = numeroidperfil});
                Session["Perfil"] = onePerfil;
                Session["inicioidperfil"] = numeroidperfil;

                string consulta4 = "select Id_Usuario from Tabla_Catalogo_Usuario where Cuenta_Usuario='" + txtusuario.Text + "' and PWD_Usuario='" + txtcontrasena.Text + "'";
                SqlCommand comando4 = new SqlCommand(consulta4, cnn);
                int numeroidUsuario = Convert.ToInt32(comando4.ExecuteScalar());

                string consulta3 = "select LTRIM(RTRIM(a.Nombre_Usuario)) + ' ' + LTRIM(RTRIM(a.Apellido_Paterno_Usuario)) + ' ' + LTRIM(RTRIM(a.Apellido_Materno_Usuario)) as NombreCompleto from Tabla_Catalogo_Usuario as a where Id_Usuario=" + numeroidUsuario + "";
                SqlCommand comando3 = new SqlCommand(consulta3, cnn);
                string nombreusuario = Convert.ToString(comando3.ExecuteScalar());
                Session["NombreUsuario"] = nombreusuario;
            }
  
            cnn.Close();

            if (count == 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Error de usuario o contraseña');</script>");
            }

            else
            {
                Response.Redirect("MenuInicial.aspx");
            }                    
                                              
            
        }
    }
}