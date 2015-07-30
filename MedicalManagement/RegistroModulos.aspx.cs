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
    public partial class RegistroModulos : System.Web.UI.Page
    {

        int Id_Modulo = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Modulo"]);

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
                 string valornombrepagina = "Modulos.aspx";
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

                     Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Modulos'</p>";
                     Response.Redirect("MenuInicial.aspx");
                 }

             }

                 if (!IsPostBack)
                 {

                     if (Id_Modulo != 0)
                     {

                         /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                         string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                         SqlConnection cnn;
                         cnn = new SqlConnection(conexion);

                         cnn.Open();
                         SqlCommand comando = new SqlCommand("SP_Catalogo_Modulos", cnn);
                         comando.CommandType = CommandType.StoredProcedure;
                         comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                         comando.Parameters.AddWithValue("@Id_Modulo", Id_Modulo);
                         SqlDataReader reader = comando.ExecuteReader();
                         if (reader.Read())
                         {
                             Identificador_Modulo.Text = reader.GetString(reader.GetOrdinal("Identificador_Modulo")).Trim();
                             Nombre_Modulo.Text = reader.GetString(reader.GetOrdinal("Nombre_Modulo")).Trim();
                             Programa_Modulo.Text = reader.GetString(reader.GetOrdinal("Programa_Modulo")).Trim();
                             Depende_Id_Modulo.Text = reader.GetString(reader.GetOrdinal("Depende_Id_Modulo")).Trim();

                         }
                         //reader.GetString(reader.GetOrdinal("Comercial_Nombre_Empresa"))

                         reader.Close();
                         comando = null;
                         cnn.Close();


                     }

                 }
             
        }

        protected void btnRegresar_Modulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modulos.aspx");
        }

        protected void GrabaModulo()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Modulos", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Modulo == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");

            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Modulo", Id_Modulo);
            }
            comando.Parameters.AddWithValue("@Identificador_Modulo", Identificador_Modulo.Text);
            comando.Parameters.AddWithValue("@Nombre_Modulo", Nombre_Modulo.Text);
            comando.Parameters.AddWithValue("@Programa_Modulo", Programa_Modulo.Text);
            comando.Parameters.AddWithValue("@Depende_Id_Modulo", Depende_Id_Modulo.Text);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;
            
            
            String Registro_Operacion_Btacora = "";
            String Descripcion_Bitacora = "";
            if (Id_Modulo == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Modulos"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Identificador_Modulo" + " = " + Identificador_Modulo.Text
                                                + "@Nombre_Modulo" + " = " + Nombre_Modulo.Text
                                                + "@Programa_Modulo" + " = " + Programa_Modulo.Text
                                                + "@Depende_Id_Modulo" + " = " + Depende_Id_Modulo.Text;

                Descripcion_Bitacora = "Inserta Modulo nuevo";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Modulos"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Modulo" + " = " + Convert.ToString(Id_Modulo).Trim()
                + "@Identificador_Modulo" + " = " + Identificador_Modulo.Text
                + "@Nombre_Modulo" + " = " + Nombre_Modulo.Text
                + "@Programa_Modulo" + " = " + Programa_Modulo.Text
                + "@Depende_Id_Modulo" + " = " + Depende_Id_Modulo.Text;

                Descripcion_Bitacora = "Actualizar Modulo";
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

            cnn.Open();

            if (Id_Modulo == 0)
            {
                string consulta2 = "select COUNT(Id_Perfil) from Tabla_Catalogo_Perfil";
                SqlCommand comando2 = new SqlCommand(consulta2, cnn);
                int cantidadperfiles = Convert.ToInt32(comando2.ExecuteScalar());

                string consulta3 = "select Id_Modulo from Tabla_Catalogo_Modulo where Nombre_Modulo='" + Nombre_Modulo.Text + "'";
                SqlCommand comando3 = new SqlCommand(consulta3, cnn);
                int idmodulo = Convert.ToInt32(comando3.ExecuteScalar());

                for (int i = 1; i <= cantidadperfiles; i++)
                {
                    string consulta4 = "insert into Tabla_Registro_Permisos_Perfil (Id_Perfil,Id_Modulo,Estatus_Permiso)values(" + i + "," + idmodulo + "," + 0 + ")";
                    SqlCommand comando4 = new SqlCommand(consulta4, cnn);
                    comando4.ExecuteNonQuery();
                }

            }

            cnn.Close();

            Response.Redirect("Modulos.aspx");

        }
        protected void btnGuardar_Modulo_Click(object sender, EventArgs e)
        {

            Alerta.InnerHtml = "";

            if (Identificador_Modulo.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Identificador del Modulo</p>";
            }
            else
            {
                if (Nombre_Modulo.Text.Length == 0)
                {
                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Nombre del Modulo</p>";
                }
                else
                {
                    if (Programa_Modulo.Text.Length == 0)
                    {
                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Programa del Modulo</p>";
                    }
                    else
                    {
                        if (Depende_Id_Modulo.Text.Length == 0)
                        {
                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar de que Depende el Modulo</p>";
                        }
                        else
                        {

                            GrabaModulo();
                        }
                    }
                }

            }
        }
    }
}