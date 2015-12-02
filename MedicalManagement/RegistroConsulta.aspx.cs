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
        public int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        public string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);
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
                loadProcedimiento();
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
                        txtnombre.Text = NombreCompleto;
                        txtnombrecompleto.Text = NombreCompleto;
                        txtfechaconsulta.Text = reader.IsDBNull(reader.GetOrdinal("Fecha_Consulta")) ? String.Empty : reader.GetDateTime(reader.GetOrdinal("Fecha_Consulta")).ToString();
                        txtsubjetivo.Text = reader.IsDBNull(reader.GetOrdinal("Subjetivo_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Subjetivo_Consulta")).ToString().Trim();
                        txtobjetivo.Text = reader.IsDBNull(reader.GetOrdinal("Objetivo_Consulta")) ? " " : reader.GetString(reader.GetOrdinal("Objetivo_Consulta")).ToString().Trim();
                        //txtdiagnostico.Text = reader.GetString(reader.GetOrdinal("Diagnostico_Consulta")).ToString().Trim(); Se elimino el txtdiagnostico
                        //txtSearch.Text = reader.IsDBNull(reader.GetOrdinal("Diagnostico_Consulta")) ? "" : reader.GetString(reader.GetOrdinal("Diagnostico_Consulta")).ToString().Trim();
                        //txtProc.Text = reader.IsDBNull(reader.GetOrdinal("Procedimiento_Consulta")) ? "" : reader.GetString(reader.GetOrdinal("Procedimiento_Consulta")).ToString().Trim();
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
            Response.Redirect("ConsultaMenu.aspx?Id_Agenda=" + Id_Agenda + " &Id_FichaIdentificacion=" + Id_FichaIdentificacion + " &NombreCompleto=" + NombreCompleto + "&Id_Consulta=" + Id_Consulta + "");

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

        protected void saveTo(object sender, EventArgs e)
        {

            if (!Existe(txtSearch.Text))
            {
                //registro no existe
                string script = @"<script type ='text/javascript'>
                                EjecutarModalDiag();
                                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocafuncion", script, false);

            }

            else

            {
                //registro si existe
                addDiagnostico();
            }

        }

        public bool Existe(string Diagnostico)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            string sql = "select count(*)from Tabla_Catalogo_Diagnostico where Descripcion_Diagnostico=@Descripcion_Diagnostico";
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                SqlCommand query = new SqlCommand(sql, conn);
                query.Parameters.AddWithValue("@Descripcion_Diagnostico", txtSearch.Text);


                int count = Convert.ToInt32(query.ExecuteScalar());
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

        protected void InsertarDiagnostico(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Diagnostico", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            comando.Parameters.AddWithValue("@Descripcion_Diagnostico", txtSearch.Text);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();
            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";

                Registro_Operacion_Btacora = "SP_Catalogo_Diagnostico"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_Diagnostico" + " = " + txtSearch.Text;
                Descripcion_Bitacora = "Inserta Diagnostico nuevo";

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

            addDiagnostico();
            /*NOTA
            Tiene un refresh
            por que el modal no se cierra por completo y queda inhabilitado todo la pagina*/
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void addDiagnostico()
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
            txtSearch.Text="";
            loadDiagnosticos();
            return;
  
        }

        private void loadDiagnosticos()
        {
            var oneConsultadia = new ConsultaDiagnosticoDTO();
            oneConsultadia.Id_FichaIdentificacion = Id_FichaIdentificacion;
            var lConsultasDiag = ConsultaDiagnosticoDAO.GetAllByPaciente(oneConsultadia).Where(x => x.Id_Consulta == Id_Agenda).ToList();
            rptDiag.DataSource = lConsultasDiag;
            rptDiag.DataBind();
            loadCategoria();
        }

        protected void deleteDiag(object sender, EventArgs e)
        {
            var Id = ((LinkButton)sender).CommandArgument;
            var oneConsultadia = new ConsultaDiagnosticoDTO();
            oneConsultadia.Id_ConsultaDiagnostico = Convert.ToInt32(Id);
            ConsultaDiagnosticoDAO Delete = new ConsultaDiagnosticoDAO();
            Delete.Delete(oneConsultadia);
            loadDiagnosticos();
        }

        /////////////////////////////////////////////
        //////////// PROCEDIMIENTO //////////////////
        /////////////////////////////////////////////
        protected void saveToPro(object sender, EventArgs e)
        {

            if (!ExistePro(txtProc.Text))
            {
                //registro no existe
                string script = @"<script type ='text/javascript'>
                                EjecutarModalProc();
                                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocafuncion", script, false);

            }

            else

            {
                //registro si existe
               // addProcedimiento();
            }

        }

        public bool ExistePro(string Procedimiento)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            string sql = "select count(*)from Tabla_Catalogo_Procedimiento where Descripcion_Procedimiento=@Descripcion_Procedimiento";
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                SqlCommand query = new SqlCommand(sql, conn);
                query.Parameters.AddWithValue("@Descripcion_Procedimiento", txtProc.Text);


                int count2 = Convert.ToInt32(query.ExecuteScalar());
                if (count2 == 0)
                    return false;
                else
                    return true;
            }
        }
        protected void InsertarProcedimeinto(object sender, EventArgs e)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Catalogo_Procedimiento", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
            comando.Parameters.AddWithValue("@Descripcion_Procedimiento", txtProc.Text);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            reader.Close();

            comando = null;

            String Registro_Operacion_Btacora = "";
            string Descripcion_Bitacora = "";

                Registro_Operacion_Btacora = "SP_Catalogo_Procedimiento"
                                                + "@Opcion" + " = " + "INSERTAR"
                                                + "@Descripcion_Procedimiento" + " = " + txtProc.Text;
                Descripcion_Bitacora = "Inserta Procedimiento nuevo";

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
            addProcedimiento();
            /*NOTA
            Tiene un refresh
            por que el modal no se cierra por completo y queda inhabilitado todo la pagina*/
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        protected void addProcedimiento()
        {
            
            var oneProcedimiento = new Tabla_Catalogo_ProcedimientoDTO();
            oneProcedimiento.Descripcion_Procedimiento = txtProc.Text;
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
            txtProc.Text = "";
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
    }
}