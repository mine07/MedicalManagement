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

namespace prototipo
{
    public partial class RegistroUsuarios : System.Web.UI.Page
    {

        int Id_Usuario = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Usuario"]);
        

        protected void Page_Load(object sender, EventArgs e)
        {
            bool estatuspermiso = false;
            estatuspermiso = Convert.ToBoolean(Session["estatuspermiso"]);
            int usuario = Convert.ToInt32(Session["inicio"]);

             if (Session["inicio"] == null || usuario == 0)
             {
                 Response.Redirect("Default.aspx");
             }


             else if (estatuspermiso == false)
             {
                 string valornombrepagina = "Usuarios.aspx";
                 string consulta;
                 SqlCommand comando;
                 int numeroidmodulo = 0;
                 string consulta2;
                 SqlCommand comando2;
                 int valoridperfildeusuario = 0;
                 valoridperfildeusuario = Convert.ToInt32(Session["inicioidperfil"]);

                 string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                 SqlConnection cnn;
                 cnn = new SqlConnection(conexion);
                 cnn.Open();

                 consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + valornombrepagina + "'";

                 comando = new SqlCommand(consulta, cnn);

                 numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                 consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                 comando2 = new SqlCommand(consulta2, cnn);

                 estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                 cnn.Close();

                 if (estatuspermiso == true)
                 {

                 }
                 else
                 {
                     //System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                     Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Usuarios'</p>";
                     Response.Redirect("MenuInicial.aspx");
                 }
             }

                 if (!IsPostBack)
                 {


                     LlenarCMBPerfiles();


                     if (Id_Usuario != 0)
                     {

                         /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                         string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                         SqlConnection cnn;
                         cnn = new SqlConnection(conexion);
                         cnn.Open();
                         SqlCommand comando = new SqlCommand("SP_Catalogo_Usuario", cnn);
                         comando.CommandType = CommandType.StoredProcedure;
                         comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                         comando.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
                         SqlDataReader reader = comando.ExecuteReader();
                         if (reader.Read())
                         {
                             Nombre_Usuario.Text = reader.GetString(reader.GetOrdinal("Nombre_Usuario")).Trim();
                             Apellido_Paterno_Usuario.Text = reader.GetString(reader.GetOrdinal("Apellido_Paterno_Usuario")).Trim();
                             Apellido_Materno_Usuario.Text = reader.GetString(reader.GetOrdinal("Apellido_Materno_Usuario")).Trim();
                             Cuenta_Usuario.Text = reader.GetString(reader.GetOrdinal("Cuenta_Usuario")).Trim();
                             PWD_Usuario.Text = reader.GetString(reader.GetOrdinal("PWD_Usuario")).Trim();
                             Correo_Usuario.Text = reader.GetString(reader.GetOrdinal("Correo_Usuario")).Trim();
                             Id_Perfil.SelectedValue = Convert.ToString(reader.GetInt32(reader.GetOrdinal("Id_Perfil"))).Trim();
                         }
                         //reader.GetString(reader.GetOrdinal("Comercial_Nombre_Empresa"))

                         reader.Close();
                         comando = null;
                         cnn.Close();


                     }

                 }
             
        }


        public void LlenarCMBPerfiles()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Perfil", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            Id_Perfil.DataTextField = "Descripcion_Perfil";
            Id_Perfil.DataValueField = "Id_Perfil";
            Id_Perfil.DataSource = dt;
            Id_Perfil.DataBind();
            Id_Perfil.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            Id_Perfil.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();


        }


        protected void btnRegresar_Usuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void GrabaUsuario()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Usuario", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Usuario == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
            }
            comando.Parameters.AddWithValue("@Nombre_Usuario", Nombre_Usuario.Text);
            comando.Parameters.AddWithValue("@Apellido_Paterno_Usuario", Apellido_Paterno_Usuario.Text);
            comando.Parameters.AddWithValue("@Apellido_Materno_Usuario", Apellido_Materno_Usuario.Text);
            comando.Parameters.AddWithValue("@Cuenta_Usuario", Cuenta_Usuario.Text);
            comando.Parameters.AddWithValue("@PWD_Usuario", PWD_Usuario.Text);
            comando.Parameters.AddWithValue("@Correo_Usuario", Correo_Usuario.Text);
            comando.Parameters.AddWithValue("@Id_Perfil", Id_Perfil.SelectedValue);


            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_Usuario == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Usuario"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Nombre_Usuario" + " = " + Nombre_Usuario.Text
                                                + "@Apellido_Paterno_Usuario" + " = " + Apellido_Paterno_Usuario.Text
                                                + "@Apellido_Materno_Usuario" + " = " + Apellido_Materno_Usuario.Text
                                                + "@Cuenta_Usuario" + " = " + Cuenta_Usuario.Text
                                                + "@PWD_Usuario" + " = " + PWD_Usuario.Text
                                                + "@Correo_Usuario" + " = " + Correo_Usuario.Text
                                                + "@Id_Perfil" + " = " + Convert.ToString(Id_Perfil.SelectedValue);
                Descripcion_Bitacora = "Inserta Usuario";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Usuario"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Usuario" + " = " + Convert.ToString(Id_Usuario).Trim()
                                                + "@Nombre_Usuario" + " = " + Nombre_Usuario.Text
                                                + "@Apellido_Paterno_Usuario" + " = " + Apellido_Paterno_Usuario.Text
                                                + "@Apellido_Materno_Usuario" + " = " + Apellido_Materno_Usuario.Text
                                                + "@Cuenta_Usuario" + " = " + Cuenta_Usuario.Text
                                                + "@PWD_Usuario" + " = " + PWD_Usuario.Text
                                                + "@Correo_Usuario" + " = " + Correo_Usuario.Text
                                                + "@Id_Perfil" + " = " + Convert.ToString(Id_Perfil.SelectedValue); Descripcion_Bitacora = "Actualizar Usuario";
            }
            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", Descripcion_Bitacora);

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();





            Response.Redirect("Usuarios.aspx");

        }
        protected void btnGuardar_Usuario_Click(object sender, EventArgs e)
        {

            Alerta.InnerHtml = "";

            if ((Nombre_Usuario.Text.Trim()).Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Nombre del Usuario</p>";
            }
            else
            {
                if ((Apellido_Paterno_Usuario.Text.Trim()).Length == 0)
                {
                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Apellido Paterno del Usuario</p>";
                }
                else
                {
                    if ((Apellido_Materno_Usuario.Text.Trim()).Length == 0)
                    {
                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Apellido Paterno del Usuario</p>";
                    }
                    else
                    {
                        if ((Cuenta_Usuario.Text.Trim()).Length == 0)
                        {
                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Cuenta del Usuario </p>";
                        }
                        else
                        {
                            if ((PWD_Usuario.Text.Trim()).Length == 0)
                            {
                                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Contraseña del Usuario</p>";
                            }
                            else
                            {
                                if ((Correo_Usuario.Text.Trim()).Length == 0)
                                {
                                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Correo Electrónico del Usuario</p>";
                                }
                                else
                                {
                                                                if (Id_Perfil.SelectedValue == "" || Id_Perfil.SelectedValue == "0")
                                                                {
                                                                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Seleccionar el Perfil del Usuario</p>";
                                                                }
                                                                else
                                                                {

                                                                    GrabaUsuario();
                                                                }

                                }
                            }
                        }
                    }
                }
            }


        }
    }
}