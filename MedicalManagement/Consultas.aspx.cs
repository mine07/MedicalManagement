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
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridAgenda();
            }
        }

       
        ///////////////////////////////////////////////////////////////////////////////////
        
        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridAgenda();
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

        
         /////////////////////////////////////////////////////////////////////////////////////

        protected void btnAgregarAgenda_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgendaElegirFicha.aspx");
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            if (e.CommandName == "ConsultaMenu")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Agenda.Rows[index];


                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                System.Web.HttpContext.Current.Response.Redirect("ConsultaMenu.aspx?Id_Agenda=" + selectedRow.Cells[0].Text + "&Id_FichaIdentificacion=" + selectedRow.Cells[1].Text + "&NombreCompleto=" + selectedRow.Cells[2].Text);
            }

            if (e.CommandName == "HistorialConsultas")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Agenda.Rows[index];


                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                System.Web.HttpContext.Current.Response.Redirect("ConsultasAnteriores.aspx?Id_Agenda=" + selectedRow.Cells[0].Text + "&Id_FichaIdentificacion=" + selectedRow.Cells[1].Text + "&NombreCompleto=" + selectedRow.Cells[2].Text);
                
            }
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
          
            Grid_Agenda.DataBind();

            Grid_Agenda.Columns[0].Visible = false;
            Grid_Agenda.Columns[1].Visible = false;
            ds.Dispose();
            da.Dispose();
            cnn.Close();

        }
    }
}