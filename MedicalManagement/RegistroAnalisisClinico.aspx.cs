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
    public partial class RegistroAnalisisClinico : System.Web.UI.Page
    {
        int Id_AnalisisClinico = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_AnalisisClinico"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Id_AnalisisClinico != 0)
                {

                    /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                    SqlConnection cnn;
                    cnn = new SqlConnection(conexion);
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_Catalogo_AnalisisClinico", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando.Parameters.AddWithValue("@Id_AnalisisClinico", Id_AnalisisClinico);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        Descripcion_AnalisisClinico.Text = reader.GetString(reader.GetOrdinal("Descripcion_AnalisisClinico")).Trim();
                        
                    }

                    reader.Close();
                    comando = null;
                    cnn.Close();


                }

            }
        }

        protected void btnRegresar_AnalisisClinico_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnalisisClinico.aspx");
        }

        protected void GrabaAnalisisClinico()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_AnalisisClinico", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_AnalisisClinico == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_AnalisisClinico", Id_AnalisisClinico);
            }
            comando.Parameters.AddWithValue("@Descripcion_AnalisisClinico", Descripcion_AnalisisClinico.Text);
            

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_AnalisisClinico == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_AnalisisClinico"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_Sexo" + " = " + Descripcion_AnalisisClinico.Text;
                Descripcion_Bitacora = "Inserta AnalisisClinico nuevo";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_AnalisisClinico"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_AnalisisClinico" + " = " + Convert.ToString(Id_AnalisisClinico).Trim()
                + "@Descripcion_AnalisisClinico" + " = " + Descripcion_AnalisisClinico.Text;

                Descripcion_Bitacora = "Actualizar AnalisisClinico";
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

            Response.Redirect("AnalisisClinico.aspx");
        }

        protected void btnGuardar_AnalisisClinico_Click(object sender, EventArgs e)
        {
            GrabaAnalisisClinico();
        }

    }
}