using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace prototipo
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool estatuspermiso=false;
            estatuspermiso = Convert.ToBoolean(Session["estatuspermiso"]);
            int usuario = Convert.ToInt32(Session["inicio"]);

            if (Session["inicio"] == null || usuario == 0)
            {
                Response.Redirect("Default.aspx");
            }

            else if (estatuspermiso == false)
            {               

                string valornombrepagina = "Usuarios.aspx";
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
                    
                    Session["alerta"] =  "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Usuarios'</p>";
                    Response.Redirect("MenuInicial.aspx");
                }
            }

            
                if (!IsPostBack)
                {
                    this.LlenarGridUsuarios();
                }
            
            estatuspermiso = false;
            Session["estatuspermiso"]=false;
            
        }

        public void LlenarGridUsuarios()
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_Usuario", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (Buscar_Usuario.Text == "")
            {
                comando.Parameters.AddWithValue("@NombreCompleto_Usuario", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@NombreCompleto_Usuario", Buscar_Usuario.Text);
            }
            /*
                0  Id_Usuario
                1  NombreCompleto
                2  Descripcion_Perfil
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Usuarios.Visible = true;
            Grid_Usuarios.DataSource = ds;
            Grid_Usuarios.Columns[0].Visible = true;
            Grid_Usuarios.Columns[1].Visible = true;
            Grid_Usuarios.Columns[2].Visible = true;
            Grid_Usuarios.DataBind();
            Grid_Usuarios.Columns[0].Visible = false;
            ds.Dispose();
            da.Dispose();
            cnn.Close();
            Buscar_Usuario.Focus();

        }
        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridUsuarios();
        }
        protected void Grid_Usuarios_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_Usuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridUsuarios();
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Update")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Usuarios.Rows[index];

                /*
                    0  Id_Usuario
                    1  NombreCompleto
                    2  Descripcion_Perfil
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroUsuarioEmpresaSucursal.aspx?Id_Usuario=" + selectedRow.Cells[0].Text + "&NombreCompleto=" + selectedRow.Cells[1].Text);


            }

            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Usuarios.Rows[index];

                /*
                    0  Id_Usuario
                    1  NombreCompleto
                    2  Descripcion_Perfil
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroUsuarios.aspx?Id_Usuario=" + selectedRow.Cells[0].Text);


            }
            if (e.CommandName == "Delete")
            {

                /*
                    0  Id_Usuario
                    1  NombreCompleto
                    2  Descripcion_Perfil
                 */


                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRowE = Grid_Usuarios.Rows[index];
                try
                {
                    Response.Write("<script language=javascript>confirm('Esta seguro que quiere eliminar el Usuario?');</script>");
                }
                catch (Exception ex)
                {

                }
                Eliminar(Convert.ToString(selectedRowE.Cells[0].Text));
                LlenarGridUsuarios();
            }

        }

        protected void Eliminar(string Id_Usuario)
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            SqlCommand command = new SqlCommand("SP_Catalogo_Usuario", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Catalogo_Usuario"
                                            + "@Opcion" + " = " + "BAJA"
                                            + "@Id_Usuario" + " = " + Convert.ToString(Id_Usuario).Trim();

            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja Usuario");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();

        }

        protected void RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroUsuarios.aspx");

        }


    }
}