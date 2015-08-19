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
    public partial class RegistroConsulta : System.Web.UI.Page
    {
        int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);
        int Id_Consulta = 0;

        string fecha_actual = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            
            
            if (!IsPostBack)
            {

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();

                string consulta = "select Id_Consulta from Tabla_Registro_Consulta where Id_Agenda=" + Id_Agenda + "";
                SqlCommand comando = new SqlCommand(consulta, cnn);
                Id_Consulta = Convert.ToInt32(comando.ExecuteScalar());
                Session ["Id_Consultas"] = Id_Consulta;

                if (Id_Consulta != 0)
                {
                    
                    SqlCommand comando2 = new SqlCommand("SP_Registro_Consultas", cnn);
                    comando2.CommandType = CommandType.StoredProcedure;
                    comando2.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando2.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
                    SqlDataReader reader = comando2.ExecuteReader();
                    if (reader.Read())
                    {
                        txtnombre.Text = NombreCompleto;
                        txtfechaconsulta.Text = reader.IsDBNull(reader.GetOrdinal("Fecha_Consulta")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("Fecha_Consulta")).ToString();
                        txtsubjetivo.Text = reader.IsDBNull(reader.GetOrdinal("Subjetivo_Consulta")) ? "Sin Datos en Nota Clinica" : reader.GetString(reader.GetOrdinal("Subjetivo_Consulta")).ToString().Trim();
                        txtobjetivo.Text = reader.IsDBNull(reader.GetOrdinal("Objetivo_Consulta")) ? "Sin Datos en Nota Clinica" : reader.GetString(reader.GetOrdinal("Objetivo_Consulta")).ToString().Trim();
                        //txtdiagnostico.Text = reader.GetString(reader.GetOrdinal("Diagnostico_Consulta")).ToString().Trim(); Se elimino el txtdiagnostico
                        txtSearch.Text = reader.IsDBNull(reader.GetOrdinal("Diagnostico_Consulta")) ? "" : reader.GetString(reader.GetOrdinal("Diagnostico_Consulta")).ToString().Trim();
                        txtanalisis.Text = reader.IsDBNull(reader.GetOrdinal("Analisis_Consulta")) ? "Sin Datos en Nota Clinica" : reader.GetString(reader.GetOrdinal("Analisis_Consulta")).ToString().Trim();
                        txtplan.Text = reader.IsDBNull(reader.GetOrdinal("Plan_Consulta")) ? "Sin Datos en Nota Clinica" : reader.GetString(reader.GetOrdinal("Plan_Consulta")).ToString().Trim();
                        LinkDiagnostico.Visible = true;
                        LinkProcedimiento.Visible = true;
                        Session["Fechaconsulta"] = reader.GetDateTime(reader.GetOrdinal("Fecha_Consulta")).ToString();
                    }
                }
                else
                {
                    DateTime hoy = DateTime.Now;
                    fecha_actual = hoy.ToString("dd-MM-yyyy HH:mm:ss");
                    txtfechaconsulta.Text = fecha_actual;
                    txtnombre.Text = NombreCompleto;
                    Session["Fechaconsulta"] = fecha_actual;
                }
                cnn.Close();
                
            }
        }

        protected void btnRegresar_Consulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }
                

        protected void btnGuardar_Consulta_Click(object sender, EventArgs e)
        {
            GrabarConsulta();
            Response.Redirect("ConsultaMenu.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + " &NombreCompleto=" + NombreCompleto + "");
        }


        public void GrabarConsulta()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Registro_Consultas", cnn);
            comando.CommandType = CommandType.StoredProcedure;

            DateTime hoy = DateTime.Now;
            fecha_actual = hoy.ToString("dd-MM-yyyy HH:mm:ss");
            DateTime fecha_actual1 = Convert.ToDateTime(fecha_actual);
            Session["Fechaconsulta"] = fecha_actual;

            Id_Consulta =Convert.ToInt32( Session["Id_Consultas"]);
                        
            if (Id_Consulta == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
            }


            comando.Parameters.AddWithValue("@Fecha_Consulta", fecha_actual1);

            comando.Parameters.AddWithValue("@Id_Agenda", Id_Agenda);            
            comando.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
            comando.Parameters.AddWithValue("@Diagnostico_Consulta", txtSearch.Text.Trim());
            comando.Parameters.AddWithValue("@Subjetivo_Consulta", txtsubjetivo.Text.Trim());
            comando.Parameters.AddWithValue("@Objetivo_Consulta", txtobjetivo.Text.Trim());
            //comando.Parameters.AddWithValue("@Diagnostico_Consulta", txtdiagnostico.Text.Trim());  Se elimino el txtdiagnostico
            comando.Parameters.AddWithValue("@Analisis_Consulta", txtanalisis.Text.Trim());
            comando.Parameters.AddWithValue("@Plan_Consulta", txtplan.Text.Trim());


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

            LinkDiagnostico.Visible = true;
            Response.Redirect("ConsultaMenu.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + " &NombreCompleto=" + NombreCompleto + "&Id_Consulta="+Id_Consulta+"");
            
        }

        protected void LinkDiagnostico_Click(object sender, EventArgs e)
        {
            Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);
            fecha_actual = Convert.ToString(Session["Fechaconsulta"]);
            Response.Redirect("ConsultaDiagnostico.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "&Fecha_Consulta="+fecha_actual+"");
        }

        protected void LinkProcedimiento_Click(object sender, EventArgs e)
        {
            Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);
            fecha_actual = Convert.ToString(Session["Fechaconsulta"]);
            Response.Redirect("ConsultaProcedimiento.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "&Fecha_Consulta=" + fecha_actual + "");
        }

        //protected void btnreceta_Click(object sender, EventArgs e)
        //{
        //    Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);

        //    Response.Redirect("ConsultaReceta.aspx?Id_Consulta=" + Id_Consulta + " &Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "");
        //    //Response.Redirect("ConsultaReceta.aspx?Id_Consulta=" + Id_Consulta + "");
        //}

        //protected void btnanalisis_Click(object sender, EventArgs e)
        //{
        //    Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);
        //    Response.Redirect("ConsultaAnalisisClinico.aspx?Id_Consulta=" + Id_Consulta + " &Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + " &NombreCompleto=" + NombreCompleto + "");
        //}

              
    }
}