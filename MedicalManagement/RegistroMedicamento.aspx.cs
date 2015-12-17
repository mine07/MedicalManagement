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
    public partial class RegistroMedicamento : System.Web.UI.Page
    {
        int Id_Medicamento = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Medicamento"]);

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                //bool estatuspermiso = false;
                //estatuspermiso = Convert.ToBoolean(Session["estatuspermiso"]);
                //int usuario = Convert.ToInt32(Session["inicio"]);

                //if (Session["inicio"] == null || usuario == 0)
                //{
                //    Response.Redirect("Default.aspx");
                //}


                //else if (estatuspermiso == false)
                //{
                //    string valornombrepagina = "Medicamento.aspx";
                //    string consulta;
                //    SqlCommand comando;
                //    int numeroidmodulo = 0;
                //    string consulta2;
                //    SqlCommand comando2;
                //    int valoridperfildeusuario = 0;
                //    valoridperfildeusuario = Convert.ToInt32(Session["inicioidperfil"]);

                //    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                //    SqlConnection cnn;
                //    cnn = new SqlConnection(conexion);
                //    cnn.Open();

                //    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + valornombrepagina + "'";

                //    comando = new SqlCommand(consulta, cnn);

                //    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                //    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                //    comando2 = new SqlCommand(consulta2, cnn);

                //    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                //    cnn.Close();

                //    if (estatuspermiso == true)
                //    {

                //    }
                //    else
                //    {
                //        //System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                //        Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Medicamento'</p>";
                //        Response.Redirect("MenuInicial.aspx");
                //    }
                //}

                if (Id_Medicamento != 0)
                {

                    /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                    SqlConnection cnn;
                    cnn = new SqlConnection(conexion);
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_Catalogo_Medicamento", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando.Parameters.AddWithValue("@Id_Medicamento", Id_Medicamento);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        Descripcion_Medicamento.Text = reader.GetString(reader.GetOrdinal("Descripcion_Medicamento")).Trim();
                        Existencia.Text = reader.GetInt32(reader.GetOrdinal("Existencia")).ToString();
                        PrecioCosto.Text = reader.GetDouble(reader.GetOrdinal("PrecioCosto")).ToString();
                        PrecioVenta.Text = reader.GetDouble(reader.GetOrdinal("PrecioVenta")).ToString();
                        Minimo.Text = reader.GetInt32(reader.GetOrdinal("Minimo")).ToString();

                    }

                    reader.Close();
                    comando = null;
                    cnn.Close();


                }

            }


        }

        protected void btnRegresar_Medicamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicamento.aspx");
        }

        protected void GrabaMedicamento()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Medicamento", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Medicamento == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Medicamento", Id_Medicamento);
            }
            comando.Parameters.AddWithValue("@Descripcion_Medicamento", Descripcion_Medicamento.Text);
            comando.Parameters.AddWithValue("@Existencia", Existencia.Text);
            comando.Parameters.AddWithValue("@PrecioCosto", PrecioCosto.Text);
            comando.Parameters.AddWithValue("@PrecioVenta", PrecioVenta.Text);
            comando.Parameters.AddWithValue("@Minimo", Minimo.Text);

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_Medicamento== 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Medicamento"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_Medicamento" + " = " + Descripcion_Medicamento.Text;
                Descripcion_Bitacora = "Inserta Medicamento nuevo";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Medicamento"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Medicamento" + " = " + Convert.ToString(Id_Medicamento).Trim()
                + "@Descripcion_Medicamento" + " = " + Descripcion_Medicamento.Text;

                Descripcion_Bitacora = "Actualizar Medicamento";
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

            Response.Redirect("Medicamento.aspx");
        }

        protected void btnGuardar_Medicamento_Click(object sender, EventArgs e)
        {
            GrabaMedicamento();
        }
    }
}