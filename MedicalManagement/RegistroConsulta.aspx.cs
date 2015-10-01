using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class RegistroConsulta : System.Web.UI.Page
    {
        public Tabla_Catalogo_FichaIdentificacionDTO oneUser { get; set; }
        public int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);
        int Id_Consulta = 0;

        string fecha_actual = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            oneUser =
                    FichaDAO.GetOne(new Tabla_Catalogo_FichaIdentificacionDTO
                    {
                        Id_FichaIdentificacion = Id_FichaIdentificacion
                    });
            if (!IsPostBack)
            {
                loadCategoria();
                loadDiagnosticos();
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
                        txtnombrecompleto.Text = NombreCompleto;
                        txtfechaconsulta.Text = reader.IsDBNull(reader.GetOrdinal("Fecha_Consulta")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("Fecha_Consulta")).ToString();
                        txtsubjetivo.Text = reader.IsDBNull(reader.GetOrdinal("Subjetivo_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Subjetivo_Consulta")).ToString().Trim();
                        txtobjetivo.Text = reader.IsDBNull(reader.GetOrdinal("Objetivo_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Objetivo_Consulta")).ToString().Trim();
                        //txtdiagnostico.Text = reader.GetString(reader.GetOrdinal("Diagnostico_Consulta")).ToString().Trim(); Se elimino el txtdiagnostico
                        txtSearch.Text = reader.IsDBNull(reader.GetOrdinal("Diagnostico_Consulta")) ? "" : reader.GetString(reader.GetOrdinal("Diagnostico_Consulta")).ToString().Trim();
                        txtanalisis.Text = reader.IsDBNull(reader.GetOrdinal("Analisis_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Analisis_Consulta")).ToString().Trim();
                        txtplan.Text = reader.IsDBNull(reader.GetOrdinal("Plan_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Plan_Consulta")).ToString().Trim();
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
            
        }


        public void GrabarConsulta()
        {
            NotaClinicaDTO oneNota = new NotaClinicaDTO();
            oneNota.Id_Agenda = Id_Agenda;
            oneNota.Id_Consulta = Id_Agenda;
            oneNota.Id_FichaIdentificacion = Id_FichaIdentificacion;
            oneNota.Subjetivo_Consulta = txtsubjetivo.Text.Trim();
            oneNota.OBjetivo_Consulta = txtobjetivo.Text.Trim();
            oneNota.Analisis_Consulta = txtanalisis.Text.Trim();
            oneNota.Plan_consulta = txtplan.Text.Trim();
            NotaClinicaDAO Update = new NotaClinicaDAO();
            Update.Update(oneNota);
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

        public void loadCategoria()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Categoria", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            ddlCategoria.DataTextField = "Descripcion_Categoria";
            ddlCategoria.DataValueField = "Id_Categoria";
            ddlCategoria.DataSource = dt;
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            ddlCategoria.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();
        }

        protected void btnSave(object sender, EventArgs e)
        {
            string prioridad = "Normal";
            if (rbUrgente.Checked)
            {
                prioridad = "Urgente";
            }
            Tabla_Registro_AgendaDTO oneAgenda = new Tabla_Registro_AgendaDTO();
            oneAgenda.Id_FichaIdentificacion = Id_FichaIdentificacion;
            oneAgenda.Asunto_Agenda = txtasunto.Text;
            oneAgenda.Id_Categoria = Convert.ToInt32(ddlCategoria.SelectedItem.Value);
            oneAgenda.Prioridad_Agenda = prioridad;
            oneAgenda.Fecha_Agenda = DateTime.Now;
            oneAgenda.Inicio_Agenda = Convert.ToDateTime(txtDiaComienzo.Value);
            oneAgenda.Fin_Agenda = Convert.ToDateTime(txtDiaFinal.Value);
            oneAgenda.Descripcion_Agenda = txtdescripcionagenda.Text;
            oneAgenda.EstadoCitas_Agenda = DropDownEstadoCitas.SelectedItem.Text;
            AgendaDAO Insert = new AgendaDAO();
            Insert.Insert(oneAgenda);
            oneAgenda = Insert.GetLastById_Ficha(oneAgenda);
            NotaClinicaDTO oneConsulta = new NotaClinicaDTO();
            oneConsulta.Id_Agenda = oneAgenda.Id_Agenda;
            oneConsulta.Id_FichaIdentificacion = oneAgenda.Id_FichaIdentificacion;
            oneConsulta.Fecha_Consulta = DateTime.Now;
            NotaClinicaDAO InsertConsulta = new NotaClinicaDAO();
            InsertConsulta.Insert(oneConsulta);
        }

        protected void addDiagnostico(object sender, EventArgs e)
        {
            var oneDiagnostico = new Tabla_Catalogo_DiagnosticoDTO();
            oneDiagnostico.Descripcion_Diagnostico = txtSearch.Text;
            oneDiagnostico = DiagnosticoDAO.GetOneByName(oneDiagnostico);
            ConsultaDiagnosticoDTO oneConsultaDiag = new ConsultaDiagnosticoDTO();
            oneConsultaDiag.Id_ConsultaDiagnostico = Id_Agenda;
            oneConsultaDiag.Id_Consulta = Id_Agenda;
            oneConsultaDiag.Fecha_ConsultaDiagnostico = DateTime.Now;
            oneConsultaDiag.Id_FichaIdentificacion = Id_FichaIdentificacion;
            oneConsultaDiag.Estatus_ConsultaDiagnostico = true;
            oneConsultaDiag.Id_Diagnostico = oneDiagnostico.Id_Diagnostico;
            oneConsultaDiag.Observaciones_ConsultaDiagnostico = "";
            ConsultaDiagnosticoDAO Insert = new ConsultaDiagnosticoDAO();
            Insert.Insert(oneConsultaDiag);
            loadDiagnosticos();
        }

        private void loadDiagnosticos()
        {
            var oneConsultadia = new ConsultaDiagnosticoDTO();
            oneConsultadia.Id_FichaIdentificacion = Id_FichaIdentificacion;
            var lConsultasDiag = ConsultaDiagnosticoDAO.GetAllByPaciente(oneConsultadia).Where(x => x.Id_Consulta == Id_Agenda).ToList();
            rptDiag.DataSource = lConsultasDiag;
            rptDiag.DataBind();
        }

        protected void deleteDiag(object sender, EventArgs e)
        {
            var Id = ((LinkButton) sender).CommandArgument;
            var oneConsultadia = new ConsultaDiagnosticoDTO();
            oneConsultadia.Id_ConsultaDiagnostico = Convert.ToInt32(Id);
            ConsultaDiagnosticoDAO Delete = new ConsultaDiagnosticoDAO();
            Delete.Delete(oneConsultadia);
            loadDiagnosticos();
        }
    }
}