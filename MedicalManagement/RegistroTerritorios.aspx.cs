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
    public partial class RegistroTerritorios : System.Web.UI.Page
    {

        int Id_Territorio = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Territorio"]);




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
                 string valornombrepagina = "EstadoCivil.aspx";
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

                     Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'EstadoCivil'</p>";
                     Response.Redirect("MenuInicial.aspx");
                 }

             }
                 if (!IsPostBack)
                 {


                     LlenarCMBEmpresas();
                     LlenarCMBSucursales();

                     if (Id_Territorio != 0)
                     {

                         /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                         string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                         SqlConnection cnn;
                         cnn = new SqlConnection(conexion);
                         cnn.Open();
                         SqlCommand comando = new SqlCommand("SP_Catalogo_Territorio", cnn);
                         comando.CommandType = CommandType.StoredProcedure;
                         comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                         comando.Parameters.AddWithValue("@Id_Territorio", Id_Territorio);
                         SqlDataReader reader = comando.ExecuteReader();
                         if (reader.Read())
                         {
                             Nombre_Territorio.Text = reader.GetString(reader.GetOrdinal("Nombre_Territorio")).Trim();
                             Direccion_Calle_Territorio.Text = reader.GetString(reader.GetOrdinal("Direccion_Calle_Territorio")).Trim();
                             Direccion_NoInt_Territorio.Text = reader.GetString(reader.GetOrdinal("Direccion_NoInt_Territorio")).Trim();
                             Direccion_NoExt_Territorio.Text = reader.GetString(reader.GetOrdinal("Direccion_NoExt_Territorio")).Trim();
                             Direccion_Colonia_Territorio.Text = reader.GetString(reader.GetOrdinal("Direccion_Colonia_Territorio")).Trim();
                             Direccion_Ciudad_Territorio.Text = reader.GetString(reader.GetOrdinal("Direccion_Ciudad_Territorio")).Trim();
                             Direccion_Municipio_Territorio.Text = reader.GetString(reader.GetOrdinal("Direccion_Municipio_Territorio")).Trim();
                             Direccion_CP_Territorio.Text = reader.GetString(reader.GetOrdinal("Direccion_CP_Territorio")).Trim();
                             Direccion_Estado_Territorio.Text = reader.GetString(reader.GetOrdinal("Direccion_Estado_Territorio")).Trim();
                             Direccion_Pais_Territorio.Text = reader.GetString(reader.GetOrdinal("Direccion_Pais_Territorio")).Trim();
                             Facturas_Serie_Territorio.Text = reader.GetString(reader.GetOrdinal("Facturas_Serie_Territorio")).Trim();
                             NCredito_Serie_Territorio.Text = reader.GetString(reader.GetOrdinal("NCredito_Serie_Territorio")).Trim();
                             NCargo_Serie_Territorio.Text = reader.GetString(reader.GetOrdinal("NCargo_Serie_Territorio")).Trim();
                             Id_Empresa.SelectedValue = Convert.ToString(reader.GetInt32(reader.GetOrdinal("Id_Empresa"))).Trim();
                             Id_Sucursal.SelectedValue = Convert.ToString(reader.GetInt32(reader.GetOrdinal("Id_Sucursal"))).Trim();
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

        public void LlenarCMBSucursales()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Sucursal", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            Id_Sucursal.DataTextField = "Comercial_Nombre_Sucursal";
            Id_Sucursal.DataValueField = "Id_Sucursal";
            Id_Sucursal.DataSource = dt;
            Id_Sucursal.DataBind();
            Id_Sucursal.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            Id_Sucursal.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
        }




        protected void btnRegresar_Territorio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Territorios.aspx");
        }

        protected void GrabaTerritorio()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Territorio", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Territorio == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Territorio", Id_Territorio);
            }
            comando.Parameters.AddWithValue("@Nombre_Territorio", Nombre_Territorio.Text);
            comando.Parameters.AddWithValue("@Direccion_Calle_Territorio", Direccion_Calle_Territorio.Text);
            comando.Parameters.AddWithValue("@Direccion_NoInt_Territorio", Direccion_NoInt_Territorio.Text);
            comando.Parameters.AddWithValue("@Direccion_NoExt_Territorio", Direccion_NoExt_Territorio.Text);
            comando.Parameters.AddWithValue("@Direccion_Colonia_Territorio", Direccion_Colonia_Territorio.Text);
            comando.Parameters.AddWithValue("@Direccion_Ciudad_Territorio", Direccion_Ciudad_Territorio.Text);
            comando.Parameters.AddWithValue("@Direccion_Municipio_Territorio", Direccion_Municipio_Territorio.Text);
            comando.Parameters.AddWithValue("@Direccion_CP_Territorio", Direccion_CP_Territorio.Text);
            comando.Parameters.AddWithValue("@Direccion_Estado_Territorio", Direccion_Estado_Territorio.Text);
            comando.Parameters.AddWithValue("@Direccion_Pais_Territorio", Direccion_Pais_Territorio.Text);
            comando.Parameters.AddWithValue("@Facturas_Serie_Territorio", Facturas_Serie_Territorio.Text);
            comando.Parameters.AddWithValue("@NCredito_Serie_Territorio", NCredito_Serie_Territorio.Text);
            comando.Parameters.AddWithValue("@NCargo_Serie_Territorio", NCargo_Serie_Territorio.Text);
            comando.Parameters.AddWithValue("@Id_Empresa", Id_Empresa.SelectedValue);
            comando.Parameters.AddWithValue("@Id_Sucursal", Id_Sucursal.SelectedValue);

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_Territorio == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Territorio"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Nombre_Territorio" + " = " + Nombre_Territorio.Text
                                                + "@Direccion_Calle_Territorio" + " = " + Direccion_Calle_Territorio.Text
                                                + "@Direccion_NoInt_Territorio" + " = " + Direccion_NoInt_Territorio.Text
                                                + "@Direccion_NoExt_Territorio" + " = " + Direccion_NoExt_Territorio.Text
                                                + "@Direccion_Colonia_Territorio" + " = " + Direccion_Colonia_Territorio.Text
                                                + "@Direccion_Ciudad_Territorio" + " = " + Direccion_Ciudad_Territorio.Text
                                                + "@Direccion_Municipio_Territorio" + " = " + Direccion_Municipio_Territorio.Text
                                                + "@Direccion_CP_Territorio" + " = " + Direccion_CP_Territorio.Text
                                                + "@Direccion_Estado_Territorio" + " = " + Direccion_Estado_Territorio.Text
                                                + "@Direccion_Pais_Territorio" + " = " + Direccion_Pais_Territorio.Text
                                                + "@Facturas_Serie_Territorio" + " = " + Facturas_Serie_Territorio.Text
                                                + "@NCredito_Serie_Territorio" + " = " + NCredito_Serie_Territorio.Text
                                                + "@Id_Empresa" + " = " + Convert.ToString(Id_Empresa.SelectedValue)
                                                + "@Id_Sucursal" + " = " + Convert.ToString(Id_Sucursal.SelectedValue)
                                                + "@NCargo_Serie_Territorio" + " = " + NCargo_Serie_Territorio.Text;
                Descripcion_Bitacora = "Inserta Territorio nuevo";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Territorio"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Territorio" + " = " + Convert.ToString(Id_Territorio).Trim()
                                                + "@Nombre_Territorio" + " = " + Nombre_Territorio.Text
                                                + "@Direccion_Calle_Territorio" + " = " + Direccion_Calle_Territorio.Text
                                                + "@Direccion_NoInt_Territorio" + " = " + Direccion_NoInt_Territorio.Text
                                                + "@Direccion_NoExt_Territorio" + " = " + Direccion_NoExt_Territorio.Text
                                                + "@Direccion_Colonia_Territorio" + " = " + Direccion_Colonia_Territorio.Text
                                                + "@Direccion_Ciudad_Territorio" + " = " + Direccion_Ciudad_Territorio.Text
                                                + "@Direccion_Municipio_Territorio" + " = " + Direccion_Municipio_Territorio.Text
                                                + "@Direccion_CP_Territorio" + " = " + Direccion_CP_Territorio.Text
                                                + "@Direccion_Estado_Territorio" + " = " + Direccion_Estado_Territorio.Text
                                                + "@Direccion_Pais_Territorio" + " = " + Direccion_Pais_Territorio.Text
                                                + "@Facturas_Serie_Territorio" + " = " + Facturas_Serie_Territorio.Text
                                                + "@NCredito_Serie_Territorio" + " = " + NCredito_Serie_Territorio.Text
                                                + "@Id_Empresa" + " = " + Convert.ToString(Id_Empresa.SelectedValue)
                                                + "@Id_Sucursal" + " = " + Convert.ToString(Id_Sucursal.SelectedValue)
                                                + "@NCargo_Serie_Territorio" + " = " + NCargo_Serie_Territorio.Text;
                Descripcion_Bitacora = "Actualizar Territorio";
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





            Response.Redirect("Territorios.aspx");

        }
        protected void btnGuardar_Territorio_Click(object sender, EventArgs e)
        {

            Alerta.InnerHtml = "";

            if (Nombre_Territorio.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Nombre del Territorio</p>";
            }
            else
            {
                if (Direccion_Calle_Territorio.Text.Length == 0)
                {
                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Calle del Territorio</p>";
                }
                else
                {
                    if (Direccion_NoInt_Territorio.Text.Length == 0)
                    {
                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El No. Int. del Territorio</p>";
                    }
                    else
                    {
                        if (Direccion_NoExt_Territorio.Text.Length == 0)
                        {
                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El No. Ext. del Territorio</p>";
                        }
                        else
                        {
                            if (Direccion_Colonia_Territorio.Text.Length == 0)
                            {
                                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Colonia del Territorio</p>";
                            }
                            else
                            {
                                if (Direccion_Ciudad_Territorio.Text.Length == 0)
                                {
                                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Ciudad del Territorio</p>";
                                }
                                else
                                {
                                    if (Direccion_Municipio_Territorio.Text.Length == 0)
                                    {
                                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Municipio del Territorio</p>";
                                    }
                                    else
                                    {
                                        if (Direccion_CP_Territorio.Text.Length == 0)
                                        {
                                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El CP del Territorio</p>";
                                        }
                                        else
                                        {
                                            if (Direccion_Estado_Territorio.Text.Length == 0)
                                            {
                                                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Estado del Territorio</p>";
                                            }
                                            else
                                            {
                                                if (Direccion_Pais_Territorio.Text.Length == 0)
                                                {
                                                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar El Pais del Territorio</p>";
                                                }
                                                else
                                                {
                                                    if (Facturas_Serie_Territorio.Text.Length == 0)
                                                    {
                                                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La serie del Territorio</p>";
                                                    }
                                                    else
                                                    {
                                                        if (NCredito_Serie_Territorio.Text.Length == 0)
                                                        {
                                                            Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar La Serie de Nota de Credito</p>";
                                                        }
                                                        else
                                                        {
                                                            if (NCargo_Serie_Territorio.Text.Length == 0)
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
                                                                    if (Id_Sucursal.SelectedValue == "" || Id_Sucursal.SelectedValue == "0")
                                                                    {
                                                                        Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Seleccionar la Sucursal</p>";
                                                                    }
                                                                    else
                                                                    {

                                                                        GrabaTerritorio();
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
}