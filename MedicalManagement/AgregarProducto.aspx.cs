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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        int Id_Productos = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Productos"]);

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {


                if (Id_Productos != 0)
                {

                    /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                    SqlConnection cnn;
                    cnn = new SqlConnection(conexion);
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_Catalogo_ProductosFarmaciao", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando.Parameters.AddWithValue("@Id_Productos", Id_Productos);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        NombreProducto.Text = reader.GetString(reader.GetOrdinal("Nombre")).Trim();
                        Descripcion.Text = reader.GetString(reader.GetOrdinal("Descripcion")).Trim();
                        PrecioCompra.Text = reader.GetDouble(reader.GetOrdinal("PrecioCompra")).ToString();
                        Existencias.Text = reader.GetInt32(reader.GetOrdinal("Existencias")).ToString();
                        PrecioVenta.Text = reader.GetDouble(reader.GetOrdinal("PrecioVenta")).ToString();


                    }

                    reader.Close();
                    comando = null;
                    cnn.Close();


                }

            }

        }

        protected void btnRegresar_Sexo_Click(object sender, EventArgs e)
        {
            Response.Redirect("FarmaciaProductos.aspx");
        }

        protected void GrabaProducto()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_ProductosFarmacia", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Productos == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Productos", Id_Productos);
            }
            comando.Parameters.AddWithValue("@Nombre", NombreProducto.Text);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion.Text);
            comando.Parameters.AddWithValue("@PrecioCompra", PrecioCompra.Text);
            comando.Parameters.AddWithValue("@Existencias", Existencias.Text);
            comando.Parameters.AddWithValue("@PrecioVenta", PrecioVenta.Text);
            comando.Parameters.AddWithValue("@Minimo", Minimo.Text);

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_Productos == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Diagnostico"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_Diagnostico" + " = " + Descripcion.Text;
                Descripcion_Bitacora = "Inserta Diagnostico nuevo";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Diagnostico"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Productos" + " = " + Convert.ToString(Id_Productos).Trim()
                + "@Descripcion_Diagnostico" + " = " + Descripcion.Text;

                Descripcion_Bitacora = "Actualizar Diagnostico";
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

            //Response.Redirect("Diagnosticos.aspx");
            Response.Redirect("FarmaciaProductos.aspx");
        }

        protected void btnGuardar_Sexo_Click(object sender, EventArgs e)
        {
            GrabaProducto();
        }

    }
}