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
using MedicalManagement.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace MedicalManagement
{
    public partial class ImprimirNotaClinica : System.Web.UI.Page
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
                loadDiagnosticos();
                loadProcedimiento();
                loadUsuario();
                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();

                string consulta = "select Id_Consulta from Tabla_Registro_Consulta where Id_Agenda=" + Id_Agenda + "";
                SqlCommand comando = new SqlCommand(consulta, cnn);
                Id_Consulta = Convert.ToInt32(comando.ExecuteScalar());
                Session["Id_Consultas"] = Id_Consulta;

                if (Id_Consulta != 0)
                {

                    SqlCommand comando2 = new SqlCommand("SP_Registro_Consultas", cnn);
                    comando2.CommandType = CommandType.StoredProcedure;
                    comando2.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando2.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
                    SqlDataReader reader = comando2.ExecuteReader();
                    if (reader.Read())
                    {
                        lblNombre.Text = NombreCompleto;
                        //lblNombrecompleto.Text = NombreCompleto;
                        lblfechaconsulta.Text = reader.IsDBNull(reader.GetOrdinal("Fecha_Consulta")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("Fecha_Consulta")).ToString();
                        lblsubjetivo.Text = reader.IsDBNull(reader.GetOrdinal("Subjetivo_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Subjetivo_Consulta")).ToString().Trim();
                        lblobjetivo.Text = reader.IsDBNull(reader.GetOrdinal("Objetivo_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Objetivo_Consulta")).ToString().Trim();
                        //txtdiagnostico.Text = reader.GetString(reader.GetOrdinal("Diagnostico_Consulta")).ToString().Trim(); Se elimino el txtdiagnostico
                        //txtSearch.Text = reader.IsDBNull(reader.GetOrdinal("Diagnostico_Consulta")) ? "" : reader.GetString(reader.GetOrdinal("Diagnostico_Consulta")).ToString().Trim();
                        //txtProc.Text = reader.IsDBNull(reader.GetOrdinal("Procedimiento_Consulta")) ? "" : reader.GetString(reader.GetOrdinal("Procedimiento_Consulta")).ToString().Trim();
                        lblanalisis.Text = reader.IsDBNull(reader.GetOrdinal("Analisis_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Analisis_Consulta")).ToString().Trim();
                        lblplan.Text = reader.IsDBNull(reader.GetOrdinal("Plan_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Plan_Consulta")).ToString().Trim();
                        Session["Fechaconsulta"] = reader.GetDateTime(reader.GetOrdinal("Fecha_Consulta")).ToString();
                    }
                }
                else
                {
                    DateTime hoy = DateTime.Now;
                    fecha_actual = hoy.ToString("dd-MM-yyyy HH:mm:ss");
                    lblfechaconsulta.Text = fecha_actual;
                    lblNombre.Text = NombreCompleto;
                    Session["Fechaconsulta"] = fecha_actual;
                }
                cnn.Close();
            }
        }

        protected void btnRegresar_Consulta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }

        protected void LinkDiagnostico_Click(object sender, EventArgs e)
        {
            Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);
            fecha_actual = Convert.ToString(Session["Fechaconsulta"]);
            Response.Redirect("ConsultaDiagnostico.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "&Fecha_Consulta=" + fecha_actual + "");
        }

        protected void LinkProcedimiento_Click(object sender, EventArgs e)
        {
            Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);
            fecha_actual = Convert.ToString(Session["Fechaconsulta"]);
            Response.Redirect("ConsultaProcedimiento.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "&Fecha_Consulta=" + fecha_actual + "");
        }

        

        protected void addDiagnostico(object sender, EventArgs e)
        {
            var oneDiagnostico = new Tabla_Catalogo_DiagnosticoDTO();
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
            loadUsuario();
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
            var Id = ((LinkButton)sender).CommandArgument;
            var oneConsultadia = new ConsultaDiagnosticoDTO();
            oneConsultadia.Id_ConsultaDiagnostico = Convert.ToInt32(Id);
            ConsultaDiagnosticoDAO Delete = new ConsultaDiagnosticoDAO();
            Delete.Delete(oneConsultadia);
            loadDiagnosticos();
            loadUsuario();
        }

        /////////////////////////////////////////////
        //////////// PROCEDIMIENTO //////////////////
        /////////////////////////////////////////////

        protected void addProcedimiento(object sender, EventArgs e)
        {
            var oneProcedimiento = new Tabla_Catalogo_ProcedimientoDTO();
            oneProcedimiento = ProcedimientoDAO.GetOneByName(oneProcedimiento);
            ConsultaProcedimientoDTO oneConsultaPro = new ConsultaProcedimientoDTO();
            oneConsultaPro.Id_ConsultaProcedimiento = Id_Agenda;
            oneConsultaPro.Id_Consulta = Id_Agenda;
            oneConsultaPro.Fecha_ConsultaProcedimiento = DateTime.Now;
            oneConsultaPro.Id_FichaIdentificacion = Id_FichaIdentificacion;
            oneConsultaPro.Estatus_ConsultaProcedimiento = true;
            oneConsultaPro.Id_Procedimiento = oneProcedimiento.Id_Procedimiento;
            oneConsultaPro.Observaciones_ConsultaProcedimiento = "";
            ConsultaProcedimientoDAO Insert = new ConsultaProcedimientoDAO();
            Insert.Insert(oneConsultaPro);
            loadProcedimiento();
        }

        private void loadProcedimiento()
        {
            var oneConsultaPro = new ConsultaProcedimientoDTO();
            oneConsultaPro.Id_FichaIdentificacion = Id_FichaIdentificacion;
            var lConsultasPro = ConsultaProcedimientoDAO.GetAllByPaciente(oneConsultaPro).Where(x => x.Id_Consulta == Id_Agenda).ToList();
            rptProc1.DataSource = lConsultasPro;
            rptProc1.DataBind();
        }

        protected void deleteProc(object sender, EventArgs e)
        {
            var Id = ((LinkButton)sender).CommandArgument;
            var oneConsultapro = new ConsultaProcedimientoDTO();
            oneConsultapro.Id_ConsultaProcedimiento = Convert.ToInt32(Id);
            ConsultaProcedimientoDAO Delete = new ConsultaProcedimientoDAO();
            Delete.Delete(oneConsultapro);
            loadProcedimiento();
        }

        public void loadUsuario()
        {
            string query = "select * from Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
            Helpers h = new Helpers();
            var oneFicha = h.GetAllParametized(query, new Tabla_Catalogo_FichaIdentificacionDTO { Id_FichaIdentificacion = Id_FichaIdentificacion })[0];
            lblNombre.Text = oneFicha.Nombre_FichaIdentificacion.Trim() + " " + oneFicha.ApPaterno_FichaIdentificacion.Trim() + " " + oneFicha.ApMaterno_FichaIdentificacion.Trim();
            NombreCompleto = oneFicha.Nombre_FichaIdentificacion.Trim() + " " + oneFicha.ApPaterno_FichaIdentificacion.Trim() + " " + oneFicha.ApMaterno_FichaIdentificacion.Trim();
        }
    }
}