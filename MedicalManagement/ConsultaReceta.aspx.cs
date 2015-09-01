using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MedicalManagement
{
    public partial class ConsultaReceta : System.Web.UI.Page
    {
        int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);

        int Id_Consulta = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Consulta"]);
        int Id_ConsultaReceta = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            if (!IsPostBack)
            {
                MostrarGridRecetaPrevia();
                

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();

                string consulta = "select Id_ConsultaReceta from Tabla_Registro_ConsultaReceta where Id_Consulta=" + Id_Consulta + "";
                SqlCommand comando = new SqlCommand(consulta, cnn);
                Id_ConsultaReceta = Convert.ToInt32(comando.ExecuteScalar());
                Session["Id_ConsultasRecetas"] = Id_ConsultaReceta;

                if (Id_ConsultaReceta != 0)
                {

                    SqlCommand comando2 = new SqlCommand("SP_Registro_ConsultasRecetas", cnn);
                    comando2.CommandType = CommandType.StoredProcedure;
                    comando2.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando2.Parameters.AddWithValue("@Id_ConsultaReceta", Id_ConsultaReceta);
                    SqlDataReader reader = comando2.ExecuteReader();
                    if (reader.Read())
                    {   
                     
                        txtmedicamento.Text = reader.GetString(reader.GetOrdinal("Medicamento_ConsultaReceta")).ToString();
                        txtdosis.Text = reader.GetString(reader.GetOrdinal("Dosis_ConsultaReceta")).ToString().Trim();
                        txtnotas.Text = reader.GetString(reader.GetOrdinal("Notas_ConsultaReceta")).ToString().Trim();
                                             
                    }
                }
                else
                {

                    DateTime hoy = DateTime.Now;
                    //fecha_actual = hoy.ToString("dd-MM-yyyy HH:mm:ss");
                    //txtfechaconsulta.Text = fecha_actual;
                    //txtnombre.Text = NombreCompleto;

                }
                cnn.Close();

            }
        }

        /////////////////////////////////////////////////////////////////////////

        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            MostrarGridRecetaPrevia();
        }
        /////////////////////////////////////////////////////////////////////////
        protected void btnRegresar_ConsultasRecetas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }
        
        protected void btnGuardar_ConsultasRecetas_Click(object sender, ImageClickEventArgs e)
        {
            GrabarConsultaReceta();
        }

               
        public void GrabarConsultaReceta()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Registro_ConsultasRecetas", cnn);
            comando.CommandType = CommandType.StoredProcedure;

            DateTime hoy = DateTime.Now;
            //fecha_actual = hoy.ToString("dd-MM-yyyy HH:mm:ss");
            //DateTime fecha_actual1 = Convert.ToDateTime(fecha_actual);

            Id_ConsultaReceta = Convert.ToInt32(Session["Id_ConsultasRecetas"]);
            
            if (Id_ConsultaReceta == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_ConsultaReceta", Id_ConsultaReceta);
            }


            //comando.Parameters.AddWithValue("@Fecha_Consulta", fecha_actual1);

            //comando.Parameters.AddWithValue("@Id_Agenda", Id_Agenda);
            //comando.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);

            comando.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
            comando.Parameters.AddWithValue("@Medicamento_ConsultaReceta", txtmedicamento.Text.Trim());
            comando.Parameters.AddWithValue("@Dosis_ConsultaReceta", txtdosis.Text.Trim());
            comando.Parameters.AddWithValue("@Notas_ConsultaReceta", txtnotas.Text.Trim());

            
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            /*
            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";
            if (Id_FichaIdentificacion == 0)
            {
                Registro_Operacion_Btacora = "SP_Catalogo_FichaIdentificacion"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_EdoCivil" + " = " + txtasunto.Text;
                Descripcion_Bitacora = "Inserta FichaIdentificacion nueva";
            }
            else
            {
                Registro_Operacion_Btacora = "SP_Catalogo_FichaIdentificacion"
                                                + "@Opcion" + " = " + "ACTUALIZAR"
                                                + "@Id_FichaIdentificacion" + " = " + Convert.ToString(Id_FichaIdentificacion).Trim()
                + "@Descripcion_EdoCivil" + " = " + txtasunto.Text;

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
            */
            cnn.Close();

            Response.Redirect("ConsultaMenu.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + " &NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "");
            
        }

        ////////////DETALLES DE RECETA PREVIA///////////////////////////////////////////////////////////////////////////////////////////

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Elegir")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = GridViewRecetaPrevia.Rows[index];

                string Id_ConsultaRecetaPrevia = selectedRow.Cells[0].Text;

                string consulta = @"select Nombre_ConsultaRecetaPrevia,Medicamento_ConsultaReceta,Dosis_ConsultaReceta,Notas_ConsultaReceta
                                  from Tabla_Catalogo_ConsultaRecetaPrevia
                                  where Id_ConsultaRecetaPrevia=" + Id_ConsultaRecetaPrevia + "";
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();

                SqlCommand comando = new SqlCommand(consulta, cnn);
                comando.CommandType = CommandType.Text;

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    txtmedicamento.Text = reader.GetString(reader.GetOrdinal("Medicamento_ConsultaReceta")).Trim();
                    txtdosis.Text = reader.GetString(reader.GetOrdinal("Dosis_ConsultaReceta")).Trim();
                    txtnotas.Text = reader.GetString(reader.GetOrdinal("Notas_ConsultaReceta")).Trim();
                }

                reader.Close();
                comando = null;
                cnn.Close();

            }

        }

        protected void LinkRecetaPrevia_Click(object sender, EventArgs e)
        {
            if ((Txtnombrerecetaprevia.Text.Trim()).Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar el Nombre de 'Receta Previa'</p>";
            }
            else if ((txtmedicamento.Text.Trim()).Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Descripción del Medicamento Receta </p>";
            }
            else if ((txtdosis.Text.Trim()).Length == 0)
            {
                Alerta.InnerHtml = "<p style=\"color: white;background-color: red\">Cuidado:Favor de Capturar la Descripción de la Dosis de la Receta </p>";
            }
            else
            {
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();


                SqlCommand comando = new SqlCommand("SP_Catalogo_ConsultaRecetaPrevia", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                comando.Parameters.AddWithValue("@Nombre_ConsultaRecetaPrevia", Txtnombrerecetaprevia.Text.Trim());
                comando.Parameters.AddWithValue("@Medicamento_ConsultaReceta", txtmedicamento.Text.Trim());
                comando.Parameters.AddWithValue("@Dosis_ConsultaReceta", txtdosis.Text.Trim());                
                comando.Parameters.AddWithValue("@Notas_ConsultaReceta", txtnotas.Text.Trim());


                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                reader.Close();
                comando = null;

                Alerta.InnerHtml = "<p style=\"color: white;background-color: White\"></p>";
                cnn.Close();
                MostrarGridRecetaPrevia();
            }
        }

        public void MostrarGridRecetaPrevia()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            //            SqlCommand comando = new SqlCommand(@"select Id_ConsultaRecetaPrevia, Nombre_ConsultaRecetaPrevia from 
            //                                                  Tabla_Catalogo_ConsultaRecetaPrevia", cnn);

            //            comando.CommandType = CommandType.Text;

            SqlCommand comando = new SqlCommand("SP_Catalogo_ConsultaRecetaPrevia", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");


            if (txtBuscar_Receta.Text.Trim() == "")
            {
                comando.Parameters.AddWithValue("@Nombre_ConsultaRecetaPrevia", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Nombre_ConsultaRecetaPrevia", txtBuscar_Receta.Text.Trim());
            }

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridViewRecetaPrevia.Visible = true;
            GridViewRecetaPrevia.DataSource = ds;
            GridViewRecetaPrevia.Columns[0].Visible = true;

            GridViewRecetaPrevia.DataBind();

            GridViewRecetaPrevia.Columns[0].Visible = false;

            ds.Dispose();
            da.Dispose();
            cnn.Close();
        }
    }
}