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
    public partial class AgendaElegirFicha : System.Web.UI.Page
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
                this.LlenarGridFichaIdentificacion();
            }

            estatuspermiso = false;
            Session["estatuspermiso"] = false;
        }

        /////////////////////////////////////////////////////////////////////////


        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridFichaIdentificacion();
        }



        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid_FichaIdentificacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void Grid_FichaIdentificacion_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnSelectionChanged(object sender, EventArgs e)
        {
           
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void btnRegresar_FichaIdentificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Agenda.aspx");
        }
        
        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_FichaIdentificacion.Rows[index];


                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroAgenda.aspx?Id_FichaIdentificacion=" + selectedRow.Cells[0].Text + "&NombreCompleto="+selectedRow.Cells[1].Text);


            }
        }

        public void LlenarGridFichaIdentificacion()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_FichaIdentificacion", cnn);
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
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_FichaIdentificacion.Visible = true;
            Grid_FichaIdentificacion.DataSource = ds;
            Grid_FichaIdentificacion.Columns[0].Visible = true;
            Grid_FichaIdentificacion.Columns[1].Visible = true;
            Grid_FichaIdentificacion.DataBind();
            Grid_FichaIdentificacion.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
            Grid_FichaIdentificacion.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
            Grid_FichaIdentificacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            ds.Dispose();
            da.Dispose();
            cnn.Close();

        }

    }
}