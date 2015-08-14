using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MedicalManagement
{
    public partial class RegistroRecetaPrevia : System.Web.UI.Page
    {
        int Id_ConsultaRecetaPrevia = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_ConsultaRecetaPrevia"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Id_ConsultaRecetaPrevia != 0)
                {

                    /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                    SqlConnection cnn;
                    cnn = new SqlConnection(conexion);
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_Catalogo_ConsultaRecetaPrevia", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando.Parameters.AddWithValue("@Id_ConsultaRecetaPrevia", Id_ConsultaRecetaPrevia);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        txtNombre_ConsultaRecetaPrevia.Text = reader.GetString(reader.GetOrdinal("Nombre_ConsultaRecetaPrevia")).Trim();
                        txtmedicamento_consultareceta.Text = reader.GetString(reader.GetOrdinal("Medicamento_ConsultaReceta")).Trim();
                        txtdosis_consultareceta.Text = reader.GetString(reader.GetOrdinal("Dosis_ConsultaReceta")).Trim();
                        txtnotas_consultareceta.Text = reader.GetString(reader.GetOrdinal("Notas_ConsultaReceta")).Trim();
                    }

                    reader.Close();
                    comando = null;
                    cnn.Close();


                }

            }

        }

        protected void btnRegresar_RecetaPrevia_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecetaPrevia.aspx");
        }

        protected void GrabaRecetaPrevia()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_ConsultaRecetaPrevia", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_ConsultaRecetaPrevia == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_ConsultaRecetaPrevia", Id_ConsultaRecetaPrevia);
            }
            comando.Parameters.AddWithValue("@Nombre_ConsultaRecetaPrevia", txtNombre_ConsultaRecetaPrevia.Text.Trim());
            comando.Parameters.AddWithValue("@Medicamento_ConsultaReceta", txtmedicamento_consultareceta.Text.Trim());
            comando.Parameters.AddWithValue("@Dosis_ConsultaReceta", txtdosis_consultareceta.Text.Trim());
            comando.Parameters.AddWithValue("@Notas_ConsultaReceta", txtnotas_consultareceta.Text.Trim());

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_ConsultaRecetaPrevia == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_ConsultaRecetaPrevia"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Nombre_ConsultaRecetaPrevia" + " = " + txtNombre_ConsultaRecetaPrevia.Text;
                Descripcion_Bitacora = "Inserta RecetaPrevia nueva";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_ConsultaRecetaPrevia"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_ConsultaRecetaPrevia" + " = " + Convert.ToString(Id_ConsultaRecetaPrevia).Trim()
                + "@Nombre_ConsultaRecetaPrevia" + " = " + txtNombre_ConsultaRecetaPrevia.Text;

                Descripcion_Bitacora = "Actualizar Receta Previa";
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

            Response.Redirect("RecetaPrevia.aspx");

        }

        protected void btnGuardar_Categoria_Click(object sender, EventArgs e)
        {

            Alerta.InnerHtml = "";

            if ((txtmedicamento_consultareceta.Text.Trim()).Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Descripción del medicamento</p>";
            }

            else if ((txtNombre_ConsultaRecetaPrevia.Text.Trim()).Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Descripción del Nombre de la Receta Previa</p>";
            }

            else if ((txtdosis_consultareceta.Text.Trim()).Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Descripción de la Dosis</p>";
            }
            else
            {
                GrabaRecetaPrevia();
            }



        }
    }
}