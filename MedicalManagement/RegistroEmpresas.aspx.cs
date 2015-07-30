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
    public partial class RegistroEmpresas : System.Web.UI.Page
    {

        int Id_Empresa = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Empresa"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            bool estatuspermiso = false;
            estatuspermiso = Convert.ToBoolean(Session["estatuspermiso"]);
            int usuario = Convert.ToInt32(Session["inicio"]);

             if (Session["inicio"] == null || usuario == 0)
             {
                 Response.Redirect("Default.aspx");
             }


             else if(estatuspermiso == false)
             {
                 string valornombrepagina = "Empresas.aspx";
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

                     Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Empresas'</p>";
                     Response.Redirect("MenuInicial.aspx");
                 }

             }
                 if (!IsPostBack)
                 {

                     if (Id_Empresa != 0)
                     {

                         /* SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection")); */
                         string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                         SqlConnection cnn;
                         cnn = new SqlConnection(conexion);

                         cnn.Open();
                         SqlCommand comando = new SqlCommand("SP_Catalogo_Empresas", cnn);
                         comando.CommandType = CommandType.StoredProcedure;
                         comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                         comando.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);

                         SqlDataReader reader = comando.ExecuteReader();
                         if (reader.Read())
                         {
                             txtComercial_Nombre_Empresa.Text = reader.GetString(reader.GetOrdinal("Comercial_Nombre_Empresa")).Trim();
                             txtFiscal_Nombre_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Nombre_Empresa")).Trim();
                             txtFiscal_Direccion_Calle_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Calle_Empresa")).Trim();
                             txtFiscal_Direccion_NoInt_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_NoInt_Empresa")).Trim();
                             txtFiscal_Direccion_NoExt_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_NoExt_Empresa")).Trim();
                             txtFiscal_Direccion_Colonia_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Colonia_Empresa")).Trim();
                             txtFiscal_Direccion_Ciudad_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Ciudad_Empresa")).Trim();
                             txtFiscal_Direccion_Municipio_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Municipio_Empresa")).Trim();
                             txtFiscal_Direccion_CP_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_CP_Empresa")).Trim();
                             txtFiscal_Direccion_Estado_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Estado_Empresa")).Trim();
                             txtFiscal_Direccion_Pais_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_Direccion_Pais_Empresa")).Trim();
                             txtFiscal_General_Regimen_Empresa.Text = reader.GetString(reader.GetOrdinal("Fiscal_General_Regimen_Empresa")).Trim();
                             txtGeneral_URL_Empresa.Text = reader.GetString(reader.GetOrdinal("General_URL_Empresa")).Trim();

                         }
                         //reader.GetString(reader.GetOrdinal("Comercial_Nombre_Empresa"))

                         reader.Close();
                         comando = null;
                         cnn.Close();


                     }

                 }
             
        }


        protected void btnRegresar_Empresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empresas.aspx");
        }


        protected void GrabaEmpresa()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Empresas", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Empresa == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Empresa", Id_Empresa);
            }
            comando.Parameters.AddWithValue("@Comercial_Nombre_Empresa",txtComercial_Nombre_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Nombre_Empresa",txtFiscal_Nombre_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Calle_Empresa",txtFiscal_Direccion_Calle_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_NoInt_Empresa",txtFiscal_Direccion_NoInt_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_NoExt_Empresa",txtFiscal_Direccion_NoExt_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Colonia_Empresa",txtFiscal_Direccion_Colonia_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Ciudad_Empresa",txtFiscal_Direccion_Ciudad_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Municipio_Empresa",txtFiscal_Direccion_Municipio_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_CP_Empresa",txtFiscal_Direccion_CP_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Estado_Empresa",txtFiscal_Direccion_Estado_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_Direccion_Pais_Empresa",txtFiscal_Direccion_Pais_Empresa.Text);
            comando.Parameters.AddWithValue("@Fiscal_General_Regimen_Empresa",txtFiscal_General_Regimen_Empresa.Text);
            comando.Parameters.AddWithValue("@General_URL_Empresa", txtGeneral_URL_Empresa.Text);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            String Descripcion_Bitacora = "";
            if (Id_Empresa == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Empresas"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Comercial_Nombre_Empresa" + " = " + txtComercial_Nombre_Empresa.Text
                                                + "@Fiscal_Nombre_Empresa" + " = " + txtFiscal_Nombre_Empresa.Text
                                                + "@Fiscal_Direccion_Calle_Empresa" + " = " + txtFiscal_Direccion_Calle_Empresa.Text
                                                + "@Fiscal_Direccion_NoInt_Empresa" + " = " + txtFiscal_Direccion_NoInt_Empresa.Text
                                                + "@Fiscal_Direccion_NoExt_Empresa" + " = " + txtFiscal_Direccion_NoExt_Empresa.Text
                                                + "@Fiscal_Direccion_Colonia_Empresa" + " = " + txtFiscal_Direccion_Colonia_Empresa.Text
                                                + "@Fiscal_Direccion_Ciudad_Empresa" + " = " + txtFiscal_Direccion_Ciudad_Empresa.Text
                                                + "@Fiscal_Direccion_Municipio_Empresa" + " = " + txtFiscal_Direccion_Municipio_Empresa.Text
                                                + "@Fiscal_Direccion_CP_Empresa" + " = " + txtFiscal_Direccion_CP_Empresa.Text
                                                + "@Fiscal_Direccion_Estado_Empresa" + " = " + txtFiscal_Direccion_Estado_Empresa.Text
                                                + "@Fiscal_Direccion_Pais_Empresa" + " = " + txtFiscal_Direccion_Pais_Empresa.Text
                                                + "@Fiscal_General_Regimen_Empresa" + " = " + txtFiscal_General_Regimen_Empresa.Text
                                                + "@General_URL_Empresa" + " = " + txtGeneral_URL_Empresa.Text;

                Descripcion_Bitacora = "Inserta Empresa nueva";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Empresas"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Empresa" + " = " + Convert.ToString(Id_Empresa).Trim()
                +"@Comercial_Nombre_Empresa" + " = " + txtComercial_Nombre_Empresa.Text
                + "@Fiscal_Nombre_Empresa" + " = " + txtFiscal_Nombre_Empresa.Text
                + "@Fiscal_Direccion_Calle_Empresa" + " = " + txtFiscal_Direccion_Calle_Empresa.Text
                + "@Fiscal_Direccion_NoInt_Empresa" + " = " + txtFiscal_Direccion_NoInt_Empresa.Text
                + "@Fiscal_Direccion_NoExt_Empresa" + " = " + txtFiscal_Direccion_NoExt_Empresa.Text
                + "@Fiscal_Direccion_Colonia_Empresa" + " = " + txtFiscal_Direccion_Colonia_Empresa.Text
                + "@Fiscal_Direccion_Ciudad_Empresa" + " = " + txtFiscal_Direccion_Ciudad_Empresa.Text
                + "@Fiscal_Direccion_Municipio_Empresa" + " = " + txtFiscal_Direccion_Municipio_Empresa.Text
                + "@Fiscal_Direccion_CP_Empresa" + " = " + txtFiscal_Direccion_CP_Empresa.Text
                + "@Fiscal_Direccion_Estado_Empresa" + " = " + txtFiscal_Direccion_Estado_Empresa.Text
                + "@Fiscal_Direccion_Pais_Empresa" + " = " + txtFiscal_Direccion_Pais_Empresa.Text
                + "@Fiscal_General_Regimen_Empresa" + " = " + txtFiscal_General_Regimen_Empresa.Text
                + "@General_URL_Empresa" + " = " + txtGeneral_URL_Empresa.Text;


                Descripcion_Bitacora = "Actualizar Empresa";
            }
            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal",Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario",Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora",Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora",Descripcion_Bitacora);

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();
            

            Response.Redirect("Empresas.aspx");

        }


        protected void btnGuardar_Empresa_Click(object sender, EventArgs e)
        {
            
            Alerta.InnerHtml = "";

            if (txtComercial_Nombre_Empresa.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Nombre Comercial de la Empresa</p>";
            }
            else
            {
                if (txtFiscal_Nombre_Empresa.Text.Length == 0)
                {
                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Nombre Fiscal de la Empresa</p>";
                }
                else
                {
                    if (txtFiscal_Direccion_Calle_Empresa.Text.Length == 0)
                    {
                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Calle Fiscal de la Empresa</p>";
                    }
                    else
                    {
                        if (txtFiscal_Direccion_NoInt_Empresa.Text.Length == 0)
                        {
                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El No. Int. de la Empresa</p>";
                        }
                        else
                        {
                            if (txtFiscal_Direccion_NoExt_Empresa.Text.Length == 0)
                            {
                                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El No. Ext. de la Empresa</p>";
                            }
                            else
                            {
                                if (txtFiscal_Direccion_Colonia_Empresa.Text.Length == 0)
                                {
                                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Colonia Fiscal de la Empresa</p>";
                                }
                                else
                                {
                                    if (txtFiscal_Direccion_Ciudad_Empresa.Text.Length == 0)
                                    {
                                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Ciudad Fiscal de la Empresa</p>";
                                    }
                                    else
                                    {
                                        if (txtFiscal_Direccion_Municipio_Empresa.Text.Length == 0)
                                        {
                                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Municipio Fiscal de la Empresa</p>";
                                        }
                                        else
                                        {
                                            if (txtFiscal_Direccion_CP_Empresa.Text.Length == 0)
                                            {
                                                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El CP de la Empresa</p>";
                                            }
                                            else
                                            {
                                                if (txtFiscal_Direccion_Estado_Empresa.Text.Length == 0)
                                                {
                                                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Estado Fiscal de la Empresa</p>";
                                                }
                                                else
                                                {
                                                    if (txtFiscal_Direccion_Pais_Empresa.Text.Length == 0)
                                                    {
                                                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Pais Fiscal de la Empresa</p>";
                                                    }
                                                    else
                                                    {
                                                        if (txtFiscal_General_Regimen_Empresa.Text.Length == 0)
                                                        {
                                                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Regimen Fiscal de la Empresa</p>";
                                                        }
                                                        else
                                                        {
                                                            if (txtGeneral_URL_Empresa.Text.Length == 0)
                                                            {
                                                                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La URL de la Empresa</p>";
                                                            }
                                                            else
                                                            {


                                                                GrabaEmpresa();


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