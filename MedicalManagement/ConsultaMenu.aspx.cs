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
using MedicalManagement.Models;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class ConsultaMenu : System.Web.UI.Page
    {
        public int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        public int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        public string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);
        int Id_Consulta = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Consulta"]);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            if (!IsPostBack)
            {
                loadPacientes();
                if (Id_FichaIdentificacion != 0)
                {
                    ddlFichas.SelectedValue = Id_FichaIdentificacion.ToString();
                    loadUsuario();
                    llenarconsultas();
                    SqlConnection cnn;
                    cnn = new SqlConnection(conexion);
                    cnn.Open();
                    string consulta = "select Id_Consulta from Tabla_Registro_Consulta where Id_Agenda=" + Id_Agenda +
                                      "";
                    SqlCommand comando = new SqlCommand(consulta, cnn);
                    Id_Consulta = Convert.ToInt32(comando.ExecuteScalar());
                    Session["Id_Consultas"] = Id_Consulta;
                }
            }
        }

        private void loadPacientes()
        {
            ddlFichas.DataSource = FichaDAO.GetAll();
            ddlFichas.DataBind();
        }

        /////////////LINKS DEL MENU CONSULTAS/////////////////////////////////////////////////////////////////////

        protected void LinkNotaClinica_Click(object sender, EventArgs e)
        {
            loadUsuario();
            Response.Redirect("RegistroConsulta.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "");
        }

        protected void LinkReceta_Click(object sender, EventArgs e)
        {
            loadUsuario();
            Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);
            Response.Redirect("ConsultaReceta.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "");
        }

        protected void LinkAnalisisClinico_Click(object sender, EventArgs e)
        {
            loadUsuario();
            Id_Consulta = Convert.ToInt32(Session["Id_Consultas"]);
            Response.Redirect("ConsultaAnalisisClinico.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + "&NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "");
        }


        ////////////CHECKBOXS DEL MENU CONSULTAS///////////////////////////////////////////
        

        
        //////////////////////////////////////////////////////////////////////////////////


        public void llenarconsultas()//REFERENTE AL HISTORIAL DEL PACIENTE
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            DataTable dt = new DataTable();
            //SqlCommand comando = new SqlCommand("SP_Registro_Agenda", cnn);select * from Tabla_Registro_Consulta
            //comando.CommandType = CommandType.StoredProcedure;
            SqlCommand comando = new SqlCommand(@"select distinct a.Fecha_Consulta, a.Id_FichaIdentificacion, a.Id_Consulta,a.Subjetivo_Consulta,a.Objetivo_Consulta,
                   a.Diagnostico_Consulta,a.Analisis_Consulta,a.Plan_Consulta,b.Medicamento_ConsultaReceta,b.Dosis_ConsultaReceta,
                   b.Notas_ConsultaReceta,c.Observaciones_ConsultaDiagnostico, d.Id_Agenda
                   from Tabla_Registro_Consulta a
                   left join Tabla_Registro_ConsultaReceta b on (a.Id_Consulta=b.Id_Consulta) 
                   left join Tabla_Registro_ConsultaDiagnostico c on (a.Id_Consulta=c.Id_Consulta)
                   left join Tabla_Registro_Agenda d on (a.Id_Agenda = d.Id_Agenda)
                   where a.Id_FichaIdentificacion=" + Id_FichaIdentificacion + "order by Fecha_Consulta desc", cnn);




            //comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            //comando.Parameters.AddWithValue("@Nombre_FichaIdentificacion", "");


            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            DateTime fechaconsulta;
            string subjetivo = "";
            string objetivo = "";
            string diagnostico = "";
            string procedimiento = "";
            string analisis = "";
            string plan = "";
            string medicamento = "";
            string dosis = "";
            string notas = "";
            string observaciones = "";

            string cadena = "<table >";
            cadena = cadena + "<tr><td><strong>" + NombreCompleto + "</strong></td></tr>";
            cadena = cadena + "<tr><td><br></Td></tr>";
            var lAnteriores = NotaClinicaDAO.GetAllByFicha(new NotaClinicaDTO { Id_FichaIdentificacion = Id_FichaIdentificacion });
            foreach (var y in lAnteriores)
            {
                y.lDiagnosticos = loadDiagnosticos(y);
            }
            lAnteriores = lAnteriores.Where(x => x.Id_Agenda != Id_Agenda && x.Id_Consulta != Id_Consulta).ToList();
            rptAnteriores.DataSource = lAnteriores;
            rptAnteriores.DataBind();
            comando = new SqlCommand(@"select distinct a.Fecha_Consulta, a.Id_FichaIdentificacion, a.Id_Consulta,a.Subjetivo_Consulta,a.Objetivo_Consulta,
                   a.Diagnostico_Consulta,a.Procedimiento_Consulta,a.Analisis_Consulta,a.Plan_Consulta,b.Medicamento_ConsultaReceta,b.Dosis_ConsultaReceta,
                   b.Notas_ConsultaReceta,c.Observaciones_ConsultaDiagnostico, d.Id_Agenda
                   from Tabla_Registro_Consulta a
                   left join Tabla_Registro_ConsultaReceta b on (a.Id_Consulta=b.Id_Consulta) 
                   left join Tabla_Registro_ConsultaDiagnostico c on (a.Id_Consulta=c.Id_Consulta)
                   left join Tabla_Registro_Agenda d on (a.Id_Agenda = d.Id_Agenda)
                   where a.Id_Agenda =" + Id_Agenda + "order by Fecha_Consulta desc", cnn);
            DataTable dtB = new DataTable();
            da = new SqlDataAdapter(comando);
            //da.Fill(dtB);
            var lNotas = NotaClinicaDAO.GetOneByConsulta(new NotaClinicaDTO { Id_Consulta = Id_Agenda, Id_Agenda = Id_Agenda });
            if (lNotas.Count != 0)
            {
                lNotas[0].lDiagnosticos = loadDiagnosticos();
            }
            rptActual.DataSource = lNotas;
            rptActual.DataBind();
            foreach (DataRow row in ds.Rows)
            {
                fechaconsulta = Convert.ToDateTime(row["Fecha_Consulta"]);
                subjetivo = Convert.ToString(row["Subjetivo_Consulta"]);
                objetivo = Convert.ToString(row["Objetivo_Consulta"]);
                diagnostico = Convert.ToString(row["Diagnostico_Consulta"]);
                //procedimiento = Convert.ToString(row["Procedimiento_Consulta"]);
                analisis = Convert.ToString(row["Analisis_Consulta"]);
                plan = Convert.ToString(row["Plan_Consulta"]);
                medicamento = Convert.ToString(row["Medicamento_ConsultaReceta"]);
                dosis = Convert.ToString(row["Dosis_ConsultaReceta"]);
                notas = Convert.ToString(row["Notas_ConsultaReceta"]);
                observaciones = Convert.ToString(row["Observaciones_ConsultaDiagnostico"]);

                cadena = cadena + "<Tr><td><font color=Blue><strong>FechaConsulta:</strong></font></Td></tr>";
                cadena = cadena + "<tr><td>" + fechaconsulta + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Subjetivo:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + subjetivo + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Objetivo:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + objetivo + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Diagnostico:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + diagnostico + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Procedimiento:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + procedimiento + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Analisis:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + analisis + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Plan:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + plan + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Medicamento:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + medicamento + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Dosis:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + dosis + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Notas:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + notas + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td><font color=Blue><strong>Observaciones:</strong></font></Td></Tr>";
                cadena = cadena + "<Tr><td>" + observaciones + "</Td></Tr>";

                cadena = cadena + "<Tr><td>___________________________________________________________</Td></Tr>";
            }
            cadena = cadena + "<table>";
            consultasanteriores.InnerHtml = cadena;
            comando = null;
            cnn.Close();

        }

        private List<ConsultaDiagnosticoDTO> loadDiagnosticos()
        {
            var oneConsultadia = new ConsultaDiagnosticoDTO();
            oneConsultadia.Id_FichaIdentificacion = Id_FichaIdentificacion;
            return ConsultaDiagnosticoDAO.GetAllByPaciente(oneConsultadia).Where(x => x.Id_Consulta == Id_Agenda).ToList();
        }

        private List<ConsultaDiagnosticoDTO> loadDiagnosticos(NotaClinicaDTO oneNota)
        {
            var oneConsultadia = new ConsultaDiagnosticoDTO();
            oneConsultadia.Id_FichaIdentificacion = Id_FichaIdentificacion;
            return ConsultaDiagnosticoDAO.GetAllByPaciente(oneConsultadia).Where(x => x.Id_Consulta == oneNota.Id_Agenda).ToList();
        }

        private List<ConsultaProcedimientoDTO> loadProcedimiento()
        {
            var oneConsultapro = new ConsultaProcedimientoDTO();
            oneConsultapro.Id_FichaIdentificacion = Id_FichaIdentificacion;
            return ConsultaProcedimientoDAO.GetAllByPaciente(oneConsultapro).Where(x => x.Id_Consulta == Id_Agenda).ToList();
        }

        private List<ConsultaProcedimientoDTO> loadProcedimientos(NotaClinicaDTO oneNota)
        {
            var oneConsultapro = new ConsultaProcedimientoDTO();
            oneConsultapro.Id_FichaIdentificacion = Id_FichaIdentificacion;
            return ConsultaProcedimientoDAO.GetAllByPaciente(oneConsultapro).Where(x => x.Id_Consulta == oneNota.Id_Agenda).ToList();
        }



        /////////////////////////////////////////////////////////////////////


        public void loadUsuario()
        {
            string query = "select * from Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
            Helpers h = new Helpers();
            var oneFicha = h.GetAllParametized(query, new Tabla_Catalogo_FichaIdentificacionDTO { Id_FichaIdentificacion = Id_FichaIdentificacion })[0];
            
            NombreCompleto = oneFicha.Nombre_FichaIdentificacion.Trim() + " " + oneFicha.ApPaterno_FichaIdentificacion.Trim() + " " + oneFicha.ApMaterno_FichaIdentificacion.Trim();
        }
      
        public string testbind(object myValue)
        {
            if (myValue == null)
            {
                var strValue = "";
                if (strValue == "")
                {
                    return " ";
                }
            }
            return myValue.ToString();
        }

        protected string porConsultar(object myValue)
        {
            if (myValue == null)
            {
                var strValue = "";
                if (strValue == "")
                {
                    return " ";
                }
            }
            return myValue.ToString();
        }

        
        protected void changePaciente(object sender, EventArgs e)
        {
            Id_FichaIdentificacion = Convert.ToInt32(ddlFichas.SelectedItem.Value);
            var oneFicha =
                FichaDAO.GetOne(new Tabla_Catalogo_FichaIdentificacionDTO
                {
                    Id_FichaIdentificacion = Id_FichaIdentificacion
                });

            Response.Redirect("ConsultaMenu.aspx?Id_Agenda=0&Id_FichaIdentificacion=" + Id_FichaIdentificacion);
        }
    }

    public class FileDTO
    {
        public string Nombre { get; set; }
        public string Download { get; set; }
    }
}