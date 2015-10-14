using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MedicalManagement.Models.DTO;
using MedicalManagement.Models;

namespace MedicalManagement
{
    public partial class RegistroAgenda : System.Web.UI.Page
    {
        int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);

        string fecha_actual = "";

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
                string valornombrepagina = "Agenda.aspx";
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

                    Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Agenda'</p>";
                    Response.Redirect("MenuInicial.aspx");
                }

            }

            if (!IsPostBack)
            {
                ddlUsuarios.DataSource = FichaDAO.GetAll();
                ddlUsuarios.DataBind();
                DateTime hoy = DateTime.Now;
                fecha_actual = hoy.ToString("dd-MM-yyyy HH:mm:ss");
                DropDownDiaComienzo.SelectedValue = hoy.Day.ToString();
                DropDownMesComienzo.SelectedIndex = (hoy.Month) - 1;
                DropDownAnioComienzo.SelectedValue = hoy.Year.ToString();

                DropDownDiaFinal.SelectedValue = hoy.Day.ToString();
                DropDownMesFinal.SelectedIndex = (hoy.Month) - 1;
                DropDownAnioFinal.SelectedValue = hoy.Year.ToString();
                rbNormal.Checked = true;
                LlenarCMBCategoria();
                if (Id_Agenda != 0)
                {
                    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                    SqlConnection cnn;
                    cnn = new SqlConnection(conexion);
                    cnn.Open();
                    SqlCommand comando = new SqlCommand("SP_Registro_Agenda", cnn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Opcion", "ENCONTRAR");
                    comando.Parameters.AddWithValue("@Id_Agenda", Id_Agenda);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        txtaltaagenda.Value = reader.GetDateTime(reader.GetOrdinal("Fecha_Agenda")).ToString();

                        DateTime inicioagenda = reader.GetDateTime(reader.GetOrdinal("Inicio_Agenda"));
                        txtDiaComienzo.Value = inicioagenda.ToString();
                        DropDownDiaComienzo.SelectedValue = inicioagenda.Day.ToString();
                        DropDownMesComienzo.SelectedIndex = (inicioagenda.Month) - 1;
                        DropDownAnioComienzo.SelectedValue = inicioagenda.Year.ToString();
                        DropDownHoraComienzo.SelectedValue = inicioagenda.ToString("%h");
                        DropDownMinutoComienzo.SelectedValue = inicioagenda.ToString("mm");
                        DropDowndiatardeComienzo.SelectedValue = inicioagenda.ToString("tt");

                        string prioridad = reader.GetString(reader.GetOrdinal("Prioridad_Agenda")).Trim();

                        if (prioridad == "Normal")
                        {
                            rbNormal.Checked = true;
                            rbUrgente.Checked = false;
                        }
                        else if (prioridad == "Urgente")
                        {
                            rbUrgente.Checked = true;
                            rbNormal.Checked = false;
                        }

                        DropDownEstadoCitas.SelectedValue = reader.GetString(reader.GetOrdinal("EstadoCitas_Agenda")).ToString().Trim();

                        DateTime finagenda = reader.GetDateTime(reader.GetOrdinal("Fin_Agenda"));
                        txtDiaFinal.Value = finagenda.ToString();
                        DropDownDiaFinal.SelectedValue = finagenda.Day.ToString();
                        DropDownMesFinal.SelectedIndex = (finagenda.Month) - 1;
                        DropDownAnioFinal.SelectedValue = finagenda.Year.ToString();
                        DropDownHoraFinal.SelectedValue = finagenda.ToString("%h");
                        DropDownMinutoFinal.SelectedValue = finagenda.ToString("mm");
                        DropDowndiatardeFinal.SelectedValue = finagenda.ToString("tt");

                        txtasunto.Text = reader.GetString(reader.GetOrdinal("Asunto_Agenda")).ToString().Trim();
                        txtdescripcionagenda.Text = reader.GetString(reader.GetOrdinal("Descripcion_Agenda")).ToString();
                        ddlCategoria.SelectedIndex = reader.GetInt32(reader.GetOrdinal("Id_Categoria"));



                    }
                }

                if (Id_FichaIdentificacion != 0)
                {
                    txtidfichaidentificacion.Text = Id_FichaIdentificacion.ToString();
                    txtnombrecompleto.Text = NombreCompleto.ToString();
                }

            }
            if (txtaltaagenda.Value == "")
            {
                txtaltaagenda.Value = DateTime.Now.ToString();
            }
        }

        protected void btnRegresar_FichaIdentificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Agenda.aspx");
        }

        public void GrabarAgenda(object sender, EventArgs eventArgs)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand comando = new SqlCommand("SP_Registro_Agenda", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            var overlap = checkOverlap();
            if (overlap)
            {
                //SCRIPT MANAGER
                string script = "llamaralerta();";
                ScriptManager.RegisterStartupScript(this, GetType(),"ServerControlScript", script, true);
                return;
            }
            DateTime hoy = DateTime.Now;
            fecha_actual = hoy.ToString("dd-MM-yyyy HH:mm:ss");
            DateTime fecha_actual1 = hoy;
            if (txtaltaagenda.Value != "")
            {
                fecha_actual1 = Convert.ToDateTime(txtaltaagenda.Value);
            }
            bool validConsulta = false;
            if (Id_Agenda == 0)
            {
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                validConsulta = true;
            }
            else
            {
                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Agenda", Id_Agenda);
            }


            //string fechaAgendaComienzo = DropDownAnioComienzo.SelectedValue + "/" + DropDownMesComienzo.SelectedValue + "/" + DropDownDiaComienzo.SelectedValue+" "+DropDownHoraComienzo.SelectedValue+":"+DropDownMinutoComienzo.SelectedValue+" "+DropDowndiatardeComienzo.SelectedValue;
            DateTime fechaAgendaComienzo1 = Convert.ToDateTime(txtDiaComienzo.Value);
            //string fechaAgendaFinal = Convert.ToDateTime(DropDownAnioFinal.SelectedValue + "/" + DropDownMesFinal.SelectedValue + "/" + DropDownDiaFinal.SelectedValue+" "+DropDownHoraFinal.SelectedValue+":"+DropDownMinutoFinal.SelectedValue+" "+DropDowndiatardeFinal.SelectedValue).ToString("yyyy/MM/dd hh:mm tt");
            DateTime fechaAgendaFinal1 = Convert.ToDateTime(txtDiaFinal.Value);
            fechaAgendaFinal1 = fechaAgendaComienzo1.Date + fechaAgendaFinal1.TimeOfDay;
            string prioridad = "";

            if (rbNormal.Checked == true)
            {
                prioridad = rbNormal.Text.Trim();
            }
            if (rbUrgente.Checked == true)
            {
                prioridad = rbUrgente.Text.Trim();
            }

            comando.Parameters.AddWithValue("@Fecha_Agenda", fecha_actual1);
            comando.Parameters.AddWithValue("@Inicio_Agenda", fechaAgendaComienzo1);
            comando.Parameters.AddWithValue("@Fin_Agenda", fechaAgendaFinal1);
            comando.Parameters.AddWithValue("@Id_FichaIdentificacion", ddlUsuarios.SelectedItem.Value);
            comando.Parameters.AddWithValue("@Id_Categoria", ddlCategoria.SelectedValue);
            comando.Parameters.AddWithValue("@Descripcion_Agenda", txtdescripcionagenda.Text.Trim());
            comando.Parameters.AddWithValue("@Asunto_Agenda", txtasunto.Text.Trim());
            comando.Parameters.AddWithValue("@Prioridad_Agenda", prioridad);
            comando.Parameters.AddWithValue("@EstadoCitas_Agenda", DropDownEstadoCitas.SelectedValue);
            var oneConsulta = new Tabla_Registro_ConsultaDTO();


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
            if (validConsulta)
            {
                grabarConsulta();
            }
            Response.Redirect("MenuInicial.aspx?name=ok");
        }

        private void grabarConsulta()
        {
            string query = @"insert into Tabla_Registro_Consulta(Id_Agenda,Fecha_Consulta, Id_FichaIdentificacion)
  values((SELECT top 1 (Id_Agenda) FROM [Tabla_Registro_Agenda] ORDER BY Id_Agenda DESC), (SELECT top 1 (Fecha_Agenda) FROM [Tabla_Registro_Agenda] ORDER BY Id_Agenda DESC), @Id_FichaIdentificacion)";
            Tabla_Registro_ConsultaDTO oneCons = new Tabla_Registro_ConsultaDTO();
            oneCons.Id_FichaIdentificacion = Convert.ToInt32(ddlUsuarios.SelectedItem.Value);
            oneCons.Fecha_Consulta = Convert.ToDateTime(txtaltaagenda.Value);
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneCons);
        }

        public void LlenarCMBCategoria()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
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

      
        protected void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNormal.Checked == true)
            {
                rbUrgente.Checked = false;
            }
        }

        protected void rbUrgente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUrgente.Checked == true)
            {
                rbNormal.Checked = false;
            }
        }

        protected bool checkOverlap()
        {
            if (txtDiaFinal.Value == "" || txtDiaComienzo.Value == "") return true;
            var lAgendas = AgendaDAO.GetAll();
            var actual = new Tabla_Registro_AgendaDTO();
            actual.Inicio_Agenda = Convert.ToDateTime(txtDiaComienzo.Value);
            DateTime fechaAgendaFinal1 = Convert.ToDateTime(txtDiaFinal.Value);
            actual.Fin_Agenda = actual.Inicio_Agenda.Date + fechaAgendaFinal1.TimeOfDay;
            var tEndB = actual.Fin_Agenda;
            var tStartB = actual.Inicio_Agenda;
            foreach (var y in lAgendas)
            {
                var tStartA = y.Inicio_Agenda;
                var tEndA = y.Fin_Agenda;
                var overlap = tStartA < tEndB && tStartB < tEndA;
                if (overlap)
                {
                    return true;
                }
            }
            return false;
        }
    }
}