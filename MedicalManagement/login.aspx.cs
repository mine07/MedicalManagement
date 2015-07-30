using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MedicalManagement
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string consulta = "select count(*) from Tabla_Catalogo_Usuario where Cuenta_Usuario='"+txtusuario.Text+"' and PWD_Usuario='"+txtcontrasena.Text+"'";
            
            DataTable midatatable = new DataTable();

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            SqlDataAdapter midataadapter = new SqlDataAdapter(consulta, cnn);
            midataadapter.Fill(midatatable);

            //string ultimaactualizacion = (string)midatatable.Rows[0][0];
            int contador = (int)midatatable.Rows[0][0];


            Session["inicio"] = contador;

            if (contador != 0)
            {
                string consulta2 = "select Id_perfil from Tabla_Catalogo_Usuario where Cuenta_Usuario='" + txtusuario.Text + "' and PWD_Usuario='" + txtcontrasena.Text + "'";
                SqlCommand comando2 = new SqlCommand(consulta2, cnn);
                int numeroidperfil = Convert.ToInt32(comando2.ExecuteScalar());
                Session["inicioidperfil"] = numeroidperfil;

                string consulta4 = "select Id_Usuario from Tabla_Catalogo_Usuario where Cuenta_Usuario='" + txtusuario.Text + "' and PWD_Usuario='" + txtcontrasena.Text + "'";
                SqlCommand comando4 = new SqlCommand(consulta4, cnn);
                int numeroidUsuario = Convert.ToInt32(comando4.ExecuteScalar());

                string consulta3 = "select LTRIM(RTRIM(a.Nombre_Usuario)) + ' ' + LTRIM(RTRIM(a.Apellido_Paterno_Usuario)) + ' ' + LTRIM(RTRIM(a.Apellido_Materno_Usuario)) as NombreCompleto from Tabla_Catalogo_Usuario as a where Id_Usuario=" + numeroidUsuario + "";
                SqlCommand comando3 = new SqlCommand(consulta3, cnn);
                string nombreusuario = Convert.ToString(comando3.ExecuteScalar());
                Session["NombreUsuario"] = nombreusuario;
            }

            //if (contador != 0)
            //{
            //    string consulta2 = "select Nombre_Usuario,Apellido_Paterno_Usuario,Apellido_Materno_Usuario,Cuenta_Usuario from Tabla_Catalogo_Usuario where Cuenta_Usuario='" + txtusuario.Text + "' and PWD_Usuario='" + txtcontrasena.Text + "'";
            //    string consulta3 = "select usuario,empresa from iniciosesion where usuario ='" + txtusuario.Text + "' and contraseña ='" + txtcontrasena.Text + "'";

            //    SqlDataAdapter midataadapter2 = new SqlDataAdapter(consulta2, cnn);
            //    DataTable midatatable2 = new DataTable();
            //    midataadapter2.Fill(midatatable2);
            //    string usuarionombre = (string)midatatable2.Rows[0]["Nombre_Usuario"] + (string)midatatable2.Rows[0]["Apellido_Paterno_Usuario"] + (string)midatatable2.Rows[0]["Apellido_Materno_Usuario"];
            //    string usuariocuenta = (string)midatatable2.Rows[0]["Cuenta_Usuario"];

            //    Session["inicionombre"] = usuarionombre;
            //    Session["iniciocuenta"] = usuariocuenta;

            //}

            cnn.Close();

            if (contador == 0)
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