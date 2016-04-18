using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        int Id_Clientes = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Clientes"]);

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
                string valornombrepagina = "AgregarCliente.aspx";
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

                    Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'FichaIdentificacion'</p>";
                    Response.Redirect("MenuInicial.aspx");
                }
            }



            if (!IsPostBack)
            {
                LlenarCMBEmpresas();
                LlenarCMBSucursal();
                LlenarCMBSexo();
                LlenarCMBEdoCivil();
                LlenarCMBOcupacion();
                LlenarCMBEscolaridad();
                LlenarCMBEmpresaConvenio();
                LlenarCMBReferidoPor();
                LlenarCMBAseguradora();
                LlenarCmbDiaMesAnio();
                LlenarTxtFechas();
                Session["imagen"] = "";

                if (Id_Clientes != 0)
                {

                    /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                    SqlConnection cnn;
                    cnn = new SqlConnection(conexion);
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_Catalogo_Clientes", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando.Parameters.AddWithValue("@Id_Clientes", Id_Clientes);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        txtClaveIdent.Text = reader.GetInt32(reader.GetOrdinal("Id_Clientes")).ToString();
                        txtFechaIdent.Value = reader.GetDateTime(reader.GetOrdinal("Fecha")).ToString("dd/MM/yyyy");
                        string fechaficha = reader.GetDateTime(reader.GetOrdinal("Fecha")).ToShortDateString();
                        DateTime fechaficha1 = Convert.ToDateTime(fechaficha);
                        txtNombreIdent.Text = reader.GetString(reader.GetOrdinal("Nombre")).Trim();
                        txtRFC.Text = reader.GetString(reader.GetOrdinal("RFC")).Trim();
                        //txtApMaIdent.Text = reader.GetString(reader.GetOrdinal("ApMaterno_FichaIdentificacion")).Trim();
                        //txtLugarNaIdent.Text = reader.GetString(reader.GetOrdinal("LugarNacimiento_FichaIdentificacion")).Trim();
                        //txtFechaNaIdent.Value = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento_FichaIdentificacion")).ToString("dd/MM/yyyy");
                        //string fechanaci = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")).ToShortDateString();
                        //DateTime fechanaci1 = Convert.ToDateTime(fechanaci);
                        //txtFechaPriIdent.Value = reader.GetDateTime(reader.GetOrdinal("FechaPrimeraVisita")).ToString("dd/MM/yyyy");
                        //string fechaPrimera = reader.GetDateTime(reader.GetOrdinal("FechaPrimeraVisita")).ToShortDateString();
                        //DateTime fechaPrimera1 = Convert.ToDateTime(fechaPrimera);

                        txtTelCaIdent.Text = reader.GetString(reader.GetOrdinal("Telefono")).Trim();
                        //txtTelOfiIdent.Text = reader.GetString(reader.GetOrdinal("TelefonoOfinica")).Trim();
                        //txtTelMovIndent.Text = reader.GetString(reader.GetOrdinal("TelefonoMovil")).Trim();
                        txtCorreoIdent.Text = reader.GetString(reader.GetOrdinal("CorreoElectronico")).Trim();
                        //txtCasoEmeIdent.Text = reader.GetString(reader.GetOrdinal("CasoEmergencia")).Trim();
                        //string imagen = reader.GetString(reader.GetOrdinal("Foto")).Trim();
                        //imagen = imagen.Trim();
                        //Session["imagen"] = imagen;
                        //Image1.ImageUrl = "ImagenesFicha/" + imagen + "";

                        txtCalleIdent.Text = reader.GetString(reader.GetOrdinal("DomicilioFiscal_Calle")).Trim();
                        //txtNuIntIdent.Text = reader.GetString(reader.GetOrdinal("DomicilioFiscal_NoInt")).Trim();
                        txtNuExtIdent.Text = reader.GetString(reader.GetOrdinal("DomicilioFiscal_NoEx")).Trim();
                        txtColoIdent.Text = reader.GetString(reader.GetOrdinal("DomicilioFiscal_Colonia")).Trim();
                        txtMuniIdent.Text = reader.GetString(reader.GetOrdinal("DomicilioFiscal_Municipio")).Trim();
                        txtEstIdent.Text = reader.GetString(reader.GetOrdinal("DomicilioFiscal_Estado")).Trim();
                        txtPaisIdent.Text = reader.GetString(reader.GetOrdinal("DomicilioFiscal_Pais")).Trim();
                        txtCoPosIdent.Text = reader.GetString(reader.GetOrdinal("DomicilioFiscal_CP")).Trim();

                        //ddlEmpresa.SelectedValue = reader.GetInt32(reader.GetOrdinal("Id_Empresa")).ToString();
                        //ddlSucursal.SelectedValue = reader.GetInt32(reader.GetOrdinal("Id_Sucursal")).ToString();
                        //ddlSexo.SelectedValue = reader.GetInt32(reader.GetOrdinal("Id_Sexo")).ToString();
                        //ddlEdoCivil.SelectedValue = reader.GetInt32(reader.GetOrdinal("Id_EdoCivil")).ToString();
                        //ddlOcupacion.SelectedValue = reader.GetInt32(reader.GetOrdinal("Id_Ocupacion")).ToString();
                        //ddlEscolaridad.SelectedValue = reader.GetInt32(reader.GetOrdinal("Id_Escolaridad")).ToString();
                        //ddlEmpresaConvenio.SelectedValue = reader.GetInt32(reader.GetOrdinal("Id_EmpresaConvenio")).ToString();
                        //ddlReferidoPor.SelectedValue = reader.GetInt32(reader.GetOrdinal("Id_ReferidoPor")).ToString();
                        //ddlAseguradora.SelectedValue = reader.GetInt32(reader.GetOrdinal("Id_Aseguradora")).ToString();
                    }

                    reader.Close();
                    comando = null;
                    cnn.Close();


                }

            }



        }

        protected void btnRegresar_FichaIdentificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonasMorales.aspx");
        }



        protected void btnGuardar_FichaIdentificacion_Click(object sender, EventArgs e)
        {
            //Para verificar el correo electronico
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            //if (Regex.IsMatch(txtCorreoIdent.Text.Trim(), expresion))
            //{
            if (!(Regex.Replace(txtCorreoIdent.Text.Trim(), expresion, String.Empty).Length == 0))
            {

            }
            else
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Correo Electronico correctamente</p>";
                goto etiqueta;
            }
            //}
            //else
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Correo Electronico correctamente</p>";
            //    goto etiqueta;
            //}
            ////////////////////////////////////////////
            //Para verificar formato fotografia
            if (FileUpload1.HasFile)
            {
                string fileExt =
                   System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".png")
                {

                }
                else
                {
                    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado: Solo se pueden seleccionar imagenes con extensiones .jpg, .jpeg o .png</p>";
                    goto etiqueta;
                }
            }


            /* if (txtClaveIdent.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Clave de Indentificacion</p>";
            }
            */
            else if (txtFechaIdent.Value.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Fecha de Identificacion</p>";
            }
            if (txtNombreIdent.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Nombre</p>";
            }

            else if (txtRFC.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el RFC</p>";
            }

            //else if (txtApMaIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Apellido Materno</p>";
            //}
            //else if (txtLugarNaIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Lugar de Nacimiento</p>";
            //}

            //else if (txtFechaNaIdent.Value.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Fecha de Nacimiento</p>";
            //}
            //else if (txtFechaPriIdent.Value.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Fecha de Primera Visita</p>";
            //}
            /*
            else if (txtTelCaIdent.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Telefono de Casa</p>";
            }
            
            else if (txtTelOfiIdent.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Telefono de Oficina</p>";
            }*/
            //else if (txtTelMovIndent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Celular</p>";
            //}


            //else if (txtCorreoIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Correo Electronico</p>";
            //}
            //else if (txtCasoEmeIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Telefono en caso de emergencia</p>";
            //}
            //else if (txtCalleIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Calle</p>";
            //}

            //else if (txtNuIntIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Numero de calle interior</p>";
            //}
            //else if (txtNuExtIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Numero de calle exterior</p>";
            //}
            //else if (txtColoIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Colonia</p>";
            //}
            //else if (txtMuniIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Municipio</p>";
            //}
            //else if (txtPaisIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Pais</p>";
            //}
            //else if (txtCoPosIdent.Text.Length == 0)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Codigo Postal</p>";
            //}
            //else if(!FileUpload1.HasFile)
            //{
            //    Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Es necesario seleccionar una fila para la foto.</p>"; 
            //}
            else
            {
                GrabafichaIdentificacion();
            }
        etiqueta:
            string variable = "";

        }
        protected void GrabafichaIdentificacion()
        {
            string nombrefila = "";

            if (FileUpload1.HasFile)
            {
                string guardarPath = HttpContext.Current.Server.MapPath("ImagenesFicha/");
                nombrefila = FileUpload1.FileName;
                string checarpath = guardarPath + nombrefila;
                string nombrefilachecar = "";

                if (System.IO.File.Exists(checarpath))
                {
                    int contador = 2;
                    while (System.IO.File.Exists(checarpath))
                    {
                        nombrefilachecar = contador.ToString() + nombrefila;
                        checarpath = guardarPath + nombrefilachecar;
                        contador++;
                    }

                    nombrefila = nombrefilachecar.Trim();

                    //Alerta2.Text = "A file with the same name already exists." +
                    //    "<br />Your file was saved as " + nombrefila;
                }
                //else
                //{
                //    Alerta2.Text = "Your file was uploaded successfully.";
                //}

                guardarPath = guardarPath + nombrefila;
                FileUpload1.SaveAs(guardarPath);
            }
            else
            {
                //nombrefila = Session["imagen"].ToString();
                //Session["imagen"] = null;
            }


            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Clientes", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Clientes == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Clientes", Id_Clientes);
            }

            string fechafichaidentificacion = txtFechaIdent.Value;




            //comando.Parameters.AddWithValue("@Cve_FichaIdentificacion", txtClaveIdent.Text.Trim());
            comando.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fechafichaidentificacion));
            comando.Parameters.AddWithValue("@Nombre", txtNombreIdent.Text.Trim());
            comando.Parameters.AddWithValue("@RFC", txtRFC.Text.Trim());
            //comando.Parameters.AddWithValue("@ApMaterno_FichaIdentificacion", txtApMaIdent.Text.Trim());
            //comando.Parameters.AddWithValue("@LugarNacimiento_FichaIdentificacion", txtLugarNaIdent.Text.Trim());
            //comando.Parameters.AddWithValue("@FechaNacimiento_FichaIdentificacion", Convert.ToDateTime(txtFechaNaIdent.Value));
            //comando.Parameters.AddWithValue("@FechaPrimeraVisita_FichaIdentificacion", Convert.ToDateTime(txtFechaPriIdent.Value));
            //Convert.ToDateTime(txtDiaComienzo.Value);
            comando.Parameters.AddWithValue("@Telefono", txtTelCaIdent.Text.Trim());
            //comando.Parameters.AddWithValue("@TelefonoOfinica_FichaIdentificacion", txtTelOfiIdent.Text.Trim());
            //comando.Parameters.AddWithValue("@TelefonoMovil_FichaIdentificacion", txtTelMovIndent.Text.Trim());
            comando.Parameters.AddWithValue("@CorreoElectronico", txtCorreoIdent.Text.Trim());
            //comando.Parameters.AddWithValue("@CasoEmergencia_FichaIdentificacion", txtCasoEmeIdent.Text.Trim());
            ////////////PENDIENTE////////////////
            /////////////////////////////////////
            //comando.Parameters.AddWithValue("@Foto_FichaIdentificacion", nombrefila.Trim());

            comando.Parameters.AddWithValue("@DomicilioFiscal_Calle", txtCalleIdent.Text.Trim());
            //comando.Parameters.AddWithValue("@DomicilioFiscal_NoInt_FichaIdentificacion", txtNuIntIdent.Text.Trim());
            comando.Parameters.AddWithValue("@DomicilioFiscal_NoEx", txtNuExtIdent.Text.Trim());
            comando.Parameters.AddWithValue("@DomicilioFiscal_Colonia", txtColoIdent.Text.Trim());
            comando.Parameters.AddWithValue("@DomicilioFiscal_Municipio", txtMuniIdent.Text.Trim());
            comando.Parameters.AddWithValue("@DomicilioFiscal_Estado", txtEstIdent.Text.Trim());
            comando.Parameters.AddWithValue("@DomicilioFiscal_Pais", txtPaisIdent.Text.Trim());
            comando.Parameters.AddWithValue("@DomicilioFiscal_CP", txtCoPosIdent.Text.Trim());

            //comando.Parameters.AddWithValue("@ddlEmpresa", ddlEmpresa.SelectedValue);
            //comando.Parameters.AddWithValue("@ddlSucursal", Convert.ToInt32(ddlSucursal.SelectedValue));
            //comando.Parameters.AddWithValue("@ddlSexo", ddlSexo.SelectedValue);
            //comando.Parameters.AddWithValue("@ddlEdoCivil", ddlEdoCivil.SelectedValue);
            //comando.Parameters.AddWithValue("@ddlOcupacion", ddlOcupacion.SelectedValue);
            //comando.Parameters.AddWithValue("@ddlEscolaridad", ddlEscolaridad.SelectedValue);
            //comando.Parameters.AddWithValue("@ddlEmpresaConvenio", ddlEmpresaConvenio.SelectedValue);
            //comando.Parameters.AddWithValue("@ddlReferidoPor", ddlReferidoPor.SelectedValue);
            //comando.Parameters.AddWithValue("@ddlAseguradora", ddlAseguradora.SelectedValue);

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_Clientes == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Clientes"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_EdoCivil" + " = " + txtNombreIdent.Text;
                Descripcion_Bitacora = "Inserta FichaIdentificacion nueva";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Clientes"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Clientes" + " = " + Convert.ToString(Id_Clientes).Trim()
                + "@Descripcion_EdoCivil" + " = " + txtNombreIdent.Text;

                Descripcion_Bitacora = "Actualizar FichaIdentificacion";
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
            //var oneFicha = ClientesDAO.GetLast();
            //string pathToCreate = "~/Pacientes/" + oneFicha.Id_Clientes;
            //if (!Directory.Exists(Server.MapPath(pathToCreate)))
            //{
            //    Directory.CreateDirectory(Server.MapPath(pathToCreate));
            //}
            Response.Redirect("PersonasMorales.aspx");
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
            //ddlEmpresa.DataTextField = "Comercial_Nombre_Empresa";
            //ddlEmpresa.DataValueField = "Id_Empresa";
            //ddlEmpresa.DataSource = dt;
            //ddlEmpresa.DataBind();
            //ddlEmpresa.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //ddlEmpresa.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        public void LlenarCMBSucursal()
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
            //ddlSucursal.DataTextField = "Comercial_Nombre_Sucursal";
            //ddlSucursal.DataValueField = "Id_Sucursal";
            //ddlSucursal.DataSource = dt;
            //ddlSucursal.DataBind();
            //ddlSucursal.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //ddlSucursal.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        public void LlenarCMBSexo()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Sexo", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            //ddlSexo.DataTextField = "Descripcion_Sexo";
            //ddlSexo.DataValueField = "Id_Sexo";
            //ddlSexo.DataSource = dt;
            //ddlSexo.DataBind();
            //ddlSexo.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //ddlSexo.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        public void LlenarCMBEdoCivil()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_EdoCivil", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            //ddlEdoCivil.DataTextField = "Descripcion_EdoCivil";
            //ddlEdoCivil.DataValueField = "Id_EdoCivil";
            //ddlEdoCivil.DataSource = dt;
            //ddlEdoCivil.DataBind();
            //ddlEdoCivil.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //ddlEdoCivil.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        public void LlenarCMBOcupacion()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Ocupacion", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            //ddlOcupacion.DataTextField = "Descripcion_Ocupacion";
            //ddlOcupacion.DataValueField = "Id_Ocupacion";
            //ddlOcupacion.DataSource = dt;
            //ddlOcupacion.DataBind();
            //ddlOcupacion.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //ddlOcupacion.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        public void LlenarCMBEscolaridad()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Escolaridad", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            //ddlEscolaridad.DataTextField = "Descripcion_Escolaridad";
            //ddlEscolaridad.DataValueField = "Id_Escolaridad";
            //ddlEscolaridad.DataSource = dt;
            //ddlEscolaridad.DataBind();
            //ddlEscolaridad.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //ddlEscolaridad.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        public void LlenarCMBEmpresaConvenio()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_EmpresaConvenio", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            //ddlEmpresaConvenio.DataTextField = "RazonSocial_EmpresaConvenio";
            //ddlEmpresaConvenio.DataValueField = "Id_EmpresaConvenio";
            //ddlEmpresaConvenio.DataSource = dt;
            //ddlEmpresaConvenio.DataBind();
            //ddlEmpresaConvenio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //ddlEmpresaConvenio.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        public void LlenarCMBReferidoPor()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_ReferidoPor", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            //ddlReferidoPor.DataTextField = "Descripcion_ReferidoPor";
            //ddlReferidoPor.DataValueField = "Id_ReferidoPor";
            //ddlReferidoPor.DataSource = dt;
            //ddlReferidoPor.DataBind();
            //ddlReferidoPor.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //ddlReferidoPor.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        public void LlenarCMBAseguradora()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Aseguradora", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            //ddlAseguradora.DataTextField = "RazonSocial_Aseguradora";
            //ddlAseguradora.DataValueField = "Id_Aseguradora";
            //ddlAseguradora.DataSource = dt;
            //ddlAseguradora.DataBind();
            //ddlAseguradora.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            //ddlAseguradora.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        public void LlenarCmbDiaMesAnio()
        {
            var listadia = new List<Int32>();
            for (int i = 1; i <= 31; i++)
            {
                listadia.Add(i);

            }


            //var listames = new List<Int32>();
            //for (int i = 1; i <= 12; i++)
            //{
            //    listames.Add(i);

            //}
            //DropDownMes.DataSource = listames;
            //DropDownMes.DataBind();

            var listaanio = new List<Int32>();
            for (int i = 1900; i <= 2100; i++)
            {
                listaanio.Add(i);

            }

            DateTime hoy = DateTime.Today;



        }

        public void LlenarTxtFechas()// Llena los txtbox por default que sirven para fechas "FechaDeIdentificacion","FechaNacimiento","Fechaprimeravisita"
        {
            DateTime hoy = DateTime.Today;
            string hoy1 = hoy.ToShortDateString();

            txtFechaIdent.Value = hoy1;
            //txtFechaNaIdent.Value = hoy1;
            //txtFechaPriIdent.Value = hoy1;
        }


        void GuardarFila(HttpPostedFile fila)
        {
            // Specify the path to save the uploaded file to.
            // File.Exists(HttpContext.Current.Server.MapPath("ImagenesFicha/" + empresa.Trim() + "datosdispositivo.XLS")))
            string guardarPath = HttpContext.Current.Server.MapPath("ImagenesFicha/");

            // Get the name of the file to upload.
            string nombrefila = FileUpload1.FileName;

            // Create the path and file name to check for duplicates.
            string checarpath = guardarPath + nombrefila;

            // Create a temporary file name to use for checking duplicates.
            string nombrefilachecar = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(checarpath))
            {
                int contador = 2;
                while (System.IO.File.Exists(checarpath))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    nombrefilachecar = contador.ToString() + nombrefila;
                    checarpath = guardarPath + nombrefilachecar;
                    contador++;
                }

                nombrefila = nombrefilachecar;

                // Notify the user that the file name was changed.
                //Alerta2.Text = "A file with the same name already exists." +
                //    "<br />Your file was saved as " + nombrefila;
            }
            //else
            //{
            //    // Notify the user that the file was saved successfully.
            //    Alerta2.Text = "Your file was uploaded successfully.";
            //}

            // Append the name of the file to upload to the path.
            guardarPath = guardarPath + nombrefila;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            FileUpload1.SaveAs(guardarPath);

        }


        void GuardarFila2(HttpPostedFile fila)
        {
            string guardarPath = HttpContext.Current.Server.MapPath("ImagenesFicha/");
            string nombrefila = FileUpload1.FileName;
            string checarpath = guardarPath + nombrefila;
            string nombrefilachecar = "";

            if (System.IO.File.Exists(checarpath))
            {
                int contador = 2;
                while (System.IO.File.Exists(checarpath))
                {
                    nombrefilachecar = contador.ToString() + nombrefila;
                    checarpath = guardarPath + nombrefilachecar;
                    contador++;
                }

                nombrefila = nombrefilachecar;

                //Alerta2.Text = "A file with the same name already exists." +
                //    "<br />Your file was saved as " + nombrefila;
            }
            //else
            //{
            //    Alerta2.Text = "Your file was uploaded successfully.";
            //}

            guardarPath = guardarPath + nombrefila;
            FileUpload1.SaveAs(guardarPath);

        }





    }
}