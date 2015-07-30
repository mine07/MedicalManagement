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
    public partial class Agenda : System.Web.UI.Page
    {


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

                consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + valornombrepagina +
                           "'";

                comando = new SqlCommand(consulta, cnn);

                numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

                consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" +
                            numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
                comando2 = new SqlCommand(consulta2, cnn);

                estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

                cnn.Close();

                if (estatuspermiso == true)
                {

                }
                else
                {
                    //System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

                    Session["alerta"] =
                        "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Agenda'</p>";
                    Response.Redirect("MenuInicial.aspx");
                }
            }

            if (!IsPostBack)
            {
                LlenarGridAgenda();
            }

            estatuspermiso = false;
            Session["estatuspermiso"] = false;
        }


        /////////////////////////////////////////////////////////////////////////


        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridAgenda();
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[7].Text.Trim() == "1")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#D41818"); //rojo
            }
            else if (e.Row.Cells[7].Text.Trim() == "2")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7FA5F"); //amarillo
            }
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid_Agenda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridAgenda();
        }

        protected void Grid_Agenda_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnSelectionChanged(object sender, EventArgs e)
        {
            LlenarGridAgenda();
        }

        protected void rdbtodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtodos.Checked == true)
            {
                rdbnormal.Checked = false;
                rdburgente.Checked = false;
                LlenarGridAgenda();
            }
        }

        protected void rdbnormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbnormal.Checked == true)
            {
                rdbtodos.Checked = false;
                rdburgente.Checked = false;
                LlenarGridAgenda();
            }
        }

        protected void rdburgente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdburgente.Checked == true)
            {
                rdbnormal.Checked = false;
                rdbtodos.Checked = false;
                LlenarGridAgenda();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void btnAgregarAgenda_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgendaElegirFicha.aspx");
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Agenda.Rows[index];


                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroAgenda.aspx?Id_Agenda=" +
                                                                 selectedRow.Cells[0].Text + "&Id_FichaIdentificacion=" +
                                                                 selectedRow.Cells[1].Text + "&NombreCompleto=" +
                                                                 selectedRow.Cells[2].Text);


            }
            if (e.CommandName == "Delete")
            {

                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRowE = Grid_Agenda.Rows[index];
                try
                {
                    Response.Write(
                        "<script language=javascript>confirm('Esta seguro que quiere eliminar la Ficha Identificacion?');</script>");
                }
                catch (Exception ex)
                {

                }
                Eliminar(Convert.ToString(selectedRowE.Cells[0].Text));
                LlenarGridAgenda();
            }

        }

        public void Eliminar(string id_Agenda)
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            SqlCommand command = new SqlCommand("SP_Registro_Agenda", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_Agenda", id_Agenda);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Registro_Agenda"
                                                + "@Opcion" + " = " + "BAJA"
                                                + "@Id_Agenda" + " = " + Convert.ToString(id_Agenda).Trim();

            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja Agenda nueva");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();

        }


        public void LlenarGridAgenda()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Registro_Agenda", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (txtBuscar_FichaIdentificacion.Text == "")
            {
                comando.Parameters.AddWithValue("@Nombre_FichaIdentificacion", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Nombre_FichaIdentificacion", txtBuscar_FichaIdentificacion.Text);
            }

            string prioridad = "";
            string prioridad2 = "";

            if (rdbtodos.Checked == true)
            {
                prioridad = "Normal";
                prioridad2 = "Urgente";
            }

            else if (rdbnormal.Checked == true)
            {
                prioridad = "Normal";
            }
            else if (rdburgente.Checked == true)
            {
                prioridad = "Urgente";
            }

            DateTime fechainicio;
            string fechaverificar = "1/1/1753";
            DateTime fechaverifcar1 = Convert.ToDateTime(fechaverificar);

            fechainicio = Calendar1.SelectedDate;

            if (fechainicio >= fechaverifcar1)
            {
            }

            else
            {
                fechainicio = DateTime.Today;
            }
            comando.Parameters.AddWithValue("@Inicio_Agenda", fechainicio);

            DateTime fechafinal = fechainicio.AddDays(1);
            comando.Parameters.AddWithValue("@Fin_Agenda", fechafinal);
            comando.Parameters.AddWithValue("@Prioridad_Agenda", prioridad);
            comando.Parameters.AddWithValue("@Prioridad_Agenda2", prioridad2);
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Agenda.Visible = true;
            Grid_Agenda.DataSource = ds;
            Grid_Agenda.Columns[0].Visible = true;
            Grid_Agenda.Columns[1].Visible = true;
            Grid_Agenda.Columns[7].Visible = true;

            Grid_Agenda.DataBind();


            Grid_Agenda.Columns[0].Visible = false;
            Grid_Agenda.Columns[1].Visible = false;
            Grid_Agenda.Columns[7].Visible = false;
            ds.Dispose();
            da.Dispose();
            cnn.Close();

        }

        protected void btncitasmes_Click(object sender, EventArgs e)
        {
            LlenarGridAgenda2();

        }

        public void LlenarGridAgenda2()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            SqlCommand comando = new SqlCommand("SP_Registro_Agenda", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO_MES");

            string fechainicio = "";


            DateTime fechahoy = DateTime.Today;
            int anio = fechahoy.Year;
            int mes = (ddlmes.SelectedIndex + 1);

            int mesfinal;
            int aniofinal;

            if (ddlmes.SelectedIndex == 11)
            {
                mesfinal = 1;
                aniofinal = anio + 1;

            }
            else
            {
                mesfinal = mes + 1;
                aniofinal = anio;
            }

            fechainicio = "" + anio + "/" + mes + "/1";
            DateTime fechainicio1 = Convert.ToDateTime(fechainicio);

            comando.Parameters.AddWithValue("@Inicio_Agenda", fechainicio1);

            string fechafinal = "" + aniofinal + "/" + mesfinal + "/1";
            DateTime fechafinal1 = Convert.ToDateTime(fechafinal);
            comando.Parameters.AddWithValue("@Fin_Agenda", fechafinal1);

            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Agenda.Visible = true;
            Grid_Agenda.DataSource = ds;
            Grid_Agenda.Columns[0].Visible = true;
            Grid_Agenda.Columns[1].Visible = true;
            Grid_Agenda.Columns[7].Visible = true;

            Grid_Agenda.DataBind();


            Grid_Agenda.Columns[0].Visible = false;
            Grid_Agenda.Columns[1].Visible = false;
            Grid_Agenda.Columns[7].Visible = false;
            ds.Dispose();
            da.Dispose();
            cnn.Close();
        }

     

    }



}