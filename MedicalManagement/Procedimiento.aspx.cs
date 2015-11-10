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
    public partial class Procedimiento : System.Web.UI.Page
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
                string valornombrepagina = "Procedimiento.aspx";
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

                    Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Procedimiento'</p>";
                    Response.Redirect("MenuInicial.aspx");
                }

            }
            //Buscar.Focus();

            if (!IsPostBack)
            {
                LlenarGridProcedimiento();
            }

            //estatuspermiso = false;
            Session["estatuspermiso"] = false;

        }


        //////////////////////////////////////////////////////////////////////////////////////

        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridProcedimiento();
        }



        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid_Procedimiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridProcedimiento();

            Grid_Procedimiento.PageIndex = e.NewPageIndex;
            Grid_Procedimiento.DataBind();
        }

        protected void Grid_Procedimiento_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void btnAgregarProcedimiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroProcedimiento.aspx");
        }


        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Procedimiento.Rows[index];


                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroProcedimiento.aspx?Id_Procedimiento=" + selectedRow.Cells[0].Text);


            }

            if (e.CommandName == "Delete")
            {

                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRowE = Grid_Procedimiento.Rows[index];
                try
                {
                    Response.Write("<script language=javascript>confirm('Esta seguro que quiere eliminar Procedimiento?');</script>");
                }
                catch (Exception ex)
                {

                }
                Eliminar(Convert.ToString(selectedRowE.Cells[0].Text));
                LlenarGridProcedimiento();
            }
        }

        protected void Eliminar(string Id_Procedimiento)
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            SqlCommand command = new SqlCommand("SP_Catalogo_Procedimiento", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_Procedimiento", Id_Procedimiento);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Catalogo_Procedimiento"
                                            + "@Opcion" + " = " + "BAJA"
                                            + "@Id_Procedimiento" + " = " + Convert.ToString(Id_Procedimiento).Trim();

            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja Procedimiento nuevo");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();

        }

        public void LlenarGridProcedimiento()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_Procedimiento", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (!(txtBuscar_Procedimiento.Text == ""))
            {
                string s = txtBuscar_Procedimiento.Text;
                string[] palabras = s.Split(' ');
                string primera = palabras[0];
                string segunda = palabras[1];
                //string tercera = palabras[2];
                //string cuarta = palabras[3];
                // string quinta = palabras[4];

                comando.Parameters.AddWithValue("@Descripcion_Procedimiento", primera);
                comando.Parameters.AddWithValue("@Descripcion_Procedimiento1", segunda);
               // comando.Parameters.AddWithValue("@Descripcion_Procedimiento", txtBuscar_Procedimiento.Text);
              //  comando.Parameters.AddWithValue("@Descripcion_Procedimiento", txtBuscar_Procedimiento.Text);
              //  comando.Parameters.AddWithValue("@Descripcion_Procedimiento", txtBuscar_Procedimiento.Text);
            }
            else
            {
                comando.Parameters.AddWithValue("@Descripcion_Procedimiento", "");
            }
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Procedimiento.Visible = true;
            Grid_Procedimiento.DataSource = ds;
            Grid_Procedimiento.Columns[0].Visible = true;
            Grid_Procedimiento.Columns[1].Visible = true;
            Grid_Procedimiento.DataBind();
            ds.Dispose();
            da.Dispose();
            txtBuscar_Procedimiento.Focus();
           
        }
    }
}