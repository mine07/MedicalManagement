﻿using System;
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
    public partial class RegistroSexo : System.Web.UI.Page
    {

        int Id_Sexo = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Sexo"]);

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
                 string valornombrepagina = "Sexo.aspx";
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

                     Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Sexo'</p>";
                     Response.Redirect("MenuInicial.aspx");
                 }

             }
                 if (!IsPostBack)
                 {


                     if (Id_Sexo != 0)
                     {

                         /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                         string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                         SqlConnection cnn;
                         cnn = new SqlConnection(conexion);
                         cnn.Open();
                         SqlCommand comando = new SqlCommand("SP_Catalogo_Sexo", cnn);
                         comando.CommandType = CommandType.StoredProcedure;
                         comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                         comando.Parameters.AddWithValue("@Id_Sexo", Id_Sexo);
                         SqlDataReader reader = comando.ExecuteReader();
                         if (reader.Read())
                         {
                             Descripcion_Sexo.Text = reader.GetString(reader.GetOrdinal("Descripcion_Sexo")).Trim();
                             txtNombreCorto_Sexo.Text = reader.GetString(reader.GetOrdinal("NombreCorto_Sexo")).Trim();
                         }

                         reader.Close();
                         comando = null;
                         cnn.Close();


                     }

                 }
             

        }

        protected void btnRegresar_Sexo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sexo.aspx");
        }

        protected void GrabaSexo()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Sexo", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            if (Id_Sexo == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Sexo", Id_Sexo);
            }
            comando.Parameters.AddWithValue("@Descripcion_Sexo", Descripcion_Sexo.Text);
            comando.Parameters.AddWithValue("@NombreCorto_Sexo", txtNombreCorto_Sexo.Text);

            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_Sexo == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Sexo"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_Sexo" + " = " + Descripcion_Sexo.Text;
                Descripcion_Bitacora = "Inserta Sexo nueva";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_Sexo"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_Sexo" + " = " + Convert.ToString(Id_Sexo).Trim()
                + "@Descripcion_Sexo" + " = " + Descripcion_Sexo.Text;

                Descripcion_Bitacora = "Actualizar Sexo";
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

            Response.Redirect("Sexo.aspx");

        }

        protected void btnGuardar_Sexo_Click(object sender, EventArgs e)
        {

            Alerta.InnerHtml = "";

            if (Descripcion_Sexo.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Descripción del Sexo</p>";
            }

            else if (txtNombreCorto_Sexo.Text.Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar un nombre corto para Sexo</p>";
            }
            else
            {
                GrabaSexo();
            }



        }

    }
}