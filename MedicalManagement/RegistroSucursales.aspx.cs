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
    public partial class RegistroSucursales : System.Web.UI.Page
    {

        int Id_Sucursal = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Sucursal"]);



        
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
                 string valornombrepagina = "Sucursales.aspx";
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

                     Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Consultorios'</p>";
                     Response.Redirect("MenuInicial.aspx");
                 }
             }

                 if (!IsPostBack)
                 {


                     LlenarCMBEmpresas();


                     if (Id_Sucursal != 0)
                     {

                         /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                         string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                         SqlConnection cnn;
                         cnn = new SqlConnection(conexion);
                         cnn.Open();
                         SqlCommand comando = new SqlCommand("SP_Catalogo_Sucursal", cnn);
                         comando.CommandType = CommandType.StoredProcedure;
                         comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                         comando.Parameters.AddWithValue("@Id_Sucursal", Id_Sucursal);
                         SqlDataReader reader = comando.ExecuteReader();
                         if (reader.Read())
                         {
                             Comercial_Nombre_Sucursal.Text = reader.GetString(reader.GetOrdinal("Comercial_Nombre_Sucursal")).Trim();
                             Fiscal_Direccion_Calle_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Calle_Sucursal")).Trim();
                             Fiscal_Direccion_NoInt_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_NoInt_Sucursal")).Trim();
                             Fiscal_Direccion_NoExt_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_NoExt_Sucursal")).Trim();
                             Fiscal_Direccion_Colonia_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Colonia_Sucursal")).Trim();
                             Fiscal_Direccion_Ciudad_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Ciudad_Sucursal")).Trim();
                             Fiscal_Direccion_Municipio_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Municipio_Sucursal")).Trim();
                             Fiscal_Direccion_CP_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_CP_Sucursal")).Trim();
                             Fiscal_Direccion_Estado_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Estado_Sucursal")).Trim();
                             Fiscal_Direccion_Pais_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Pais_Sucursal")).Trim();
                             Fiscal_Facturas_Serie_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_Facturas_Serie_Sucursal")).Trim();
                             Fiscal_NCredito_Serie_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_NCredito_Serie_Sucursal")).Trim();
                             Fiscal_NCargo_Serie_Sucursal.Text = reader.GetString(reader.GetOrdinal("Fiscal_NCargo_Serie_Sucursal")).Trim();
                             Id_Empresa.SelectedValue = Convert.ToString(reader.GetInt32(reader.GetOrdinal("Id_Empresa"))).Trim();
                         }
                         //reader.GetString(reader.GetOrdinal("Comercial_Nombre_Empresa"))

                         reader.Close();
                         comando = null;
                         cnn.Close();


                     }

                 }
             
        }


        public void LlenarCMBEmpresas()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Empresas", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            Id_Empresa.DataTextField = "Comercial_Nombre_Empresa";
            Id_Empresa.DataValueField = "Id_Empresa";
            Id_Empresa.DataSource = dt;
            Id_Empresa.DataBind();
            Id_Empresa.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            Id_Empresa.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();


        }


        protected void btnRegresar_Sucursal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sucursales.aspx");
        }

        protected void GrabaSucursal()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Sucursal", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Sucursal == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Sucursal", Id_Sucursal);
            }
            comando.Parameters.AddWithValue("@Comercial_Nombre_Sucursal", Comercial_Nombre_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Calle_Sucursal", Fiscal_Direccion_Calle_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_NoInt_Sucursal", Fiscal_Direccion_NoInt_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_NoExt_Sucursal", Fiscal_Direccion_NoExt_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Colonia_Sucursal", Fiscal_Direccion_Colonia_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Ciudad_Sucursal", Fiscal_Direccion_Ciudad_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Municipio_Sucursal", Fiscal_Direccion_Municipio_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_CP_Sucursal", Fiscal_Direccion_CP_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Estado_Sucursal", Fiscal_Direccion_Estado_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Pais_Sucursal", Fiscal_Direccion_Pais_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_Facturas_Serie_Sucursal", Fiscal_Facturas_Serie_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_NCredito_Serie_Sucursal", Fiscal_NCredito_Serie_Sucursal.Text);
            comando.Parameters.AddWithValue("@Fiscal_NCargo_Serie_Sucursal", Fiscal_NCargo_Serie_Sucursal.Text);
            comando.Parameters.AddWithValue("@Id_Empresa", Id_Empresa.SelectedValue);


            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_Sucursal == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Sucursal"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Comercial_Nombre_Sucursal" + " = " + Comercial_Nombre_Sucursal.Text
                                                + "@Fiscal_Direccion_Calle_Sucursal" + " = " + Fiscal_Direccion_Calle_Sucursal.Text
                                                + "@Fiscal_Direccion_NoInt_Sucursal" + " = " + Fiscal_Direccion_NoInt_Sucursal.Text
                                                + "@Fiscal_Direccion_NoExt_Sucursal" + " = " + Fiscal_Direccion_NoExt_Sucursal.Text
                                                + "@Fiscal_Direccion_Colonia_Sucursal" + " = " + Fiscal_Direccion_Colonia_Sucursal.Text
                                                + "@Fiscal_Direccion_Ciudad_Sucursal" + " = " + Fiscal_Direccion_Ciudad_Sucursal.Text
                                                + "@Fiscal_Direccion_Municipio_Sucursal" + " = " + Fiscal_Direccion_Municipio_Sucursal.Text
                                                + "@Fiscal_Direccion_CP_Sucursal" + " = " + Fiscal_Direccion_CP_Sucursal.Text
                                                + "@Fiscal_Direccion_Estado_Sucursal" + " = " + Fiscal_Direccion_Estado_Sucursal.Text
                                                + "@Fiscal_Direccion_Pais_Sucursal" + " = " + Fiscal_Direccion_Pais_Sucursal.Text
                                                + "@Fiscal_Facturas_Serie_Sucursal" + " = " + Fiscal_Facturas_Serie_Sucursal.Text
                                                + "@Fiscal_NCredito_Serie_Sucursal" + " = " + Fiscal_NCredito_Serie_Sucursal.Text
                                                + "@Id_Empresa" + " = " + Convert.ToString(Id_Empresa.SelectedValue)
                                                + "@Fiscal_NCargo_Serie_Sucursal" + " = " + Fiscal_NCargo_Serie_Sucursal.Text;
                Descripcion_Bitacora = "Inserta Sucursal nueva";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Sucursal"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Sucursal" + " = " + Convert.ToString(Id_Sucursal).Trim()
                + "@Comercial_Nombre_Sucursal" + " = " + Comercial_Nombre_Sucursal.Text
                + "@Fiscal_Direccion_Calle_Sucursal" + " = " + Fiscal_Direccion_Calle_Sucursal.Text
                + "@Fiscal_Direccion_NoInt_Sucursal" + " = " + Fiscal_Direccion_NoInt_Sucursal.Text
                + "@Fiscal_Direccion_NoExt_Sucursal" + " = " + Fiscal_Direccion_NoExt_Sucursal.Text
                + "@Fiscal_Direccion_Colonia_Sucursal" + " = " + Fiscal_Direccion_Colonia_Sucursal.Text
                + "@Fiscal_Direccion_Ciudad_Sucursal" + " = " + Fiscal_Direccion_Ciudad_Sucursal.Text
                + "@Fiscal_Direccion_Municipio_Sucursal" + " = " + Fiscal_Direccion_Municipio_Sucursal.Text
                + "@Fiscal_Direccion_CP_Sucursal" + " = " + Fiscal_Direccion_CP_Sucursal.Text
                + "@Fiscal_Direccion_Estado_Sucursal" + " = " + Fiscal_Direccion_Estado_Sucursal.Text
                + "@Fiscal_Direccion_Pais_Sucursal" + " = " + Fiscal_Direccion_Pais_Sucursal.Text
                + "@Fiscal_Facturas_Serie_Sucursal" + " = " + Fiscal_Facturas_Serie_Sucursal.Text
                + "@Fiscal_NCredito_Serie_Sucursal" + " = " + Fiscal_NCredito_Serie_Sucursal.Text
                + "@Id_Empresa" + " = " + Convert.ToString(Id_Empresa.SelectedValue)
                + "@Fiscal_NCargo_Serie_Sucursal" + " = " + Fiscal_NCargo_Serie_Sucursal.Text;

                Descripcion_Bitacora = "Actualizar Sucursal";
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





            Response.Redirect("Sucursales.aspx");

        }
        protected void btnGuardar_Sucursal_Click(object sender, EventArgs e)
        {

            Alerta.InnerHtml = "";

            if (Comercial_Nombre_Sucursal.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Nombre Comercial de la Sucursal</p>";
            }
            else
            {
                    if (Fiscal_Direccion_Calle_Sucursal.Text.Length == 0)
                    {
                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Calle Fiscal de la Sucursal</p>";
                    }
                    else
                    {
                        if (Fiscal_Direccion_NoInt_Sucursal.Text.Length == 0)
                        {
                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El No. Int. de la Sucursal</p>";
                        }
                        else
                        {
                            if (Fiscal_Direccion_NoExt_Sucursal.Text.Length == 0)
                            {
                                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El No. Ext. de la Sucursal</p>";
                            }
                            else
                            {
                                if (Fiscal_Direccion_Colonia_Sucursal.Text.Length == 0)
                                {
                                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Colonia Fiscal de la Sucursal</p>";
                                }
                                else
                                {
                                    if (Fiscal_Direccion_Ciudad_Sucursal.Text.Length == 0)
                                    {
                                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Ciudad Fiscal de la Sucursal</p>";
                                    }
                                    else
                                    {
                                        if (Fiscal_Direccion_Municipio_Sucursal.Text.Length == 0)
                                        {
                                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Municipio Fiscal de la Sucursal</p>";
                                        }
                                        else
                                        {
                                            if (Fiscal_Direccion_CP_Sucursal.Text.Length == 0)
                                            {
                                                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El CP de la Sucursal</p>";
                                            }
                                            else
                                            {
                                                if (Fiscal_Direccion_Estado_Sucursal.Text.Length == 0)
                                                {
                                                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Estado Fiscal de la Sucursal</p>";
                                                }
                                                else
                                                {
                                                    if (Fiscal_Direccion_Pais_Sucursal.Text.Length == 0)
                                                    {
                                                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Pais Fiscal de la Sucursal</p>";
                                                    }
                                                    else
                                                    {
                                                        if (Fiscal_Facturas_Serie_Sucursal.Text.Length == 0)
                                                        {
                                                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La serie de Factura</p>";
                                                        }
                                                        else
                                                        {
                                                            if (Fiscal_NCredito_Serie_Sucursal.Text.Length == 0)
                                                            {
                                                                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Serie de Nota de Credito</p>";
                                                            }
                                                            else
                                                            {
                                                                if (Fiscal_NCargo_Serie_Sucursal.Text.Length == 0)
                                                                {
                                                                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Serie de Nota de Cargo</p>";
                                                                }
                                                                else
                                                                {
                                                                    if (Id_Empresa.SelectedValue == "" || Id_Empresa.SelectedValue == "0")
                                                                    {
                                                                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Seleccionar la Empresa</p>";
                                                                    }
                                                                    else
                                                                    {

                                                                        GrabaSucursal();
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
                            }
                        }
                    }
                }
            

        }
    }
}