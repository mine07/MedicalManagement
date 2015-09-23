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

namespace prototipo
{
    public partial class RegistroPerfiles : System.Web.UI.Page
    {

        int Id_Perfil = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Perfil"]);




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
                 string valornombrepagina = "Perfles.aspx";
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

                     Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Perfiles'</p>";
                     Response.Redirect("MenuInicial.aspx");
                 }

             }
                 if (!IsPostBack)
                 {


                     if (Id_Perfil != 0)
                     {

                         /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                         string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                         SqlConnection cnn;
                         cnn = new SqlConnection(conexion);
                         cnn.Open();
                         SqlCommand comando = new SqlCommand("SP_Catalogo_Perfil", cnn);
                         comando.CommandType = CommandType.StoredProcedure;
                         comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                         comando.Parameters.AddWithValue("@Id_Perfil", Id_Perfil);
                         SqlDataReader reader = comando.ExecuteReader();
                         if (reader.Read())
                         {
                             Descripcion_Perfil.Text = reader.GetString(reader.GetOrdinal("Descripcion_Perfil")).Trim();
                         }

                         reader.Close();
                         comando = null;
                         cnn.Close();


                     }

                 }
             
        }


        protected void btnRegresar_Perfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfles.aspx");
        }

        protected void GrabaPerfil()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Perfil", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Perfil == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Perfil", Id_Perfil);
            }
            string dato = Descripcion_Perfil.Text;
            comando.Parameters.AddWithValue("@Descripcion_Perfil", Descripcion_Perfil.Text);

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            
            string consulta = "Select Id_perfil from Tabla_Catalogo_Perfil where Descripcion_Perfil=" + Descripcion_Perfil.Text + "";
            SqlCommand comando4 = new SqlCommand("Select Id_perfil from Tabla_Catalogo_Perfil where Descripcion_Perfil='" + Descripcion_Perfil.Text + "'  and Estatus_Perfil=1", cnn);
            SqlCommand comando5 = new SqlCommand("Select max(Id_perfil) from Tabla_Catalogo_Perfil where Descripcion_Perfil='" + Descripcion_Perfil.Text + "'  and Estatus_Perfil=1", cnn);
            int numeroidperfil;
            numeroidperfil = Convert.ToInt32(comando5.ExecuteScalar());
            
             
            SqlCommand comando2 = new SqlCommand("Select Id_Modulo from Tabla_Catalogo_Modulo", cnn);
            SqlDataAdapter da = new SqlDataAdapter(comando2);
                        
            DataTable ds = new DataTable();
            da.Fill(ds);

            if (Id_Perfil == 0)
            {
                foreach (DataRow dr in ds.Rows)
                {
                    int valormodulo = 0;
                    valormodulo = Convert.ToInt32(dr["Id_Modulo"]);
                    SqlCommand comando3 = new SqlCommand("Insert into Tabla_Registro_Permisos_Perfil(Id_Modulo,Id_Perfil,Estatus_Permiso)" +
                                                         "values(" + valormodulo + "," + numeroidperfil + ",0)", cnn); //numeroidperfil


                    comando3.ExecuteNonQuery();
                }

            }
            else
            {

            }

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_Perfil == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Perfil"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_Perfil" + " = " + Descripcion_Perfil.Text;
                Descripcion_Bitacora = "Inserta Perfil nueva";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Perfil"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Perfil" + " = " + Convert.ToString(Id_Perfil).Trim()
                + "@Descripcion_Perfil" + " = " + Descripcion_Perfil.Text;

                Descripcion_Bitacora = "Actualizar Perfil";
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
                        
            Response.Redirect("Perfles.aspx");

        }
        protected void btnGuardar_Perfil_Click(object sender, EventArgs e)
        {

            Alerta.InnerHtml = "";

            if (Descripcion_Perfil.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Descripción del Perfil</p>";
            }
            else
            {
                GrabaPerfilB();
            }
            
        }

        public void GrabaPerfilB()
        {
            var onePerfil = new PerfilDTO{Descripcion_Perfil = Descripcion_Perfil.Text.Trim(), Estatus_Perfil = true};
            var Insert = new PerfilDAO();
            Insert.Create(onePerfil);
            Response.Redirect("Perfles.aspx");
        }
    }
}