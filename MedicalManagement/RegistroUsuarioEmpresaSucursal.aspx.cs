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
    public partial class RegistroUsuarioEmpresaSucursal : System.Web.UI.Page
    {

        int Id_Usuario = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Usuario"]);
        string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);



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

                    Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Usuarios'</p>";
                    Response.Redirect("MenuInicial.aspx");
                }
                estatuspermiso = false;
                Session["estatuspermiso"] = false;
            }


            if (!IsPostBack)
            {
                LlenarGridUsuarioEmpresaSucursal();
                NombreCompletoR.Text = NombreCompleto;
            }

        }

        public void LlenarGridUsuarioEmpresaSucursal()
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Consulta_Usuarios_Empresas_Sucursal", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);


            /*
                0  Id_Empresa
                1  Comercial_Nombre_Empresa
                2  Id_Sucursal
                3  Comercial_Nombre_Sucursal
                4  Activo
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_UsuariosEmpresaSucursal.Visible = true;
            Grid_UsuariosEmpresaSucursal.DataSource = ds;
            Grid_UsuariosEmpresaSucursal.Columns[0].Visible = true;
            Grid_UsuariosEmpresaSucursal.Columns[1].Visible = true;
            Grid_UsuariosEmpresaSucursal.Columns[2].Visible = true;
            Grid_UsuariosEmpresaSucursal.Columns[3].Visible = true;
            Grid_UsuariosEmpresaSucursal.Columns[4].Visible = true;
            Grid_UsuariosEmpresaSucursal.Columns[5].Visible = true;
            Grid_UsuariosEmpresaSucursal.DataBind();
            Grid_UsuariosEmpresaSucursal.Columns[0].Visible = false;
            Grid_UsuariosEmpresaSucursal.Columns[1].Visible = false;
            Grid_UsuariosEmpresaSucursal.Columns[2].Visible = false;
            ds.Dispose();
            da.Dispose();


        }

        protected void Grid_UsuariosEmpresaSucursal_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_UsuariosEmpresaSucursal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridUsuarioEmpresaSucursal();
        }


        protected void btnRegresar_UsuarioEmpresaSucursal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = Grid_UsuariosEmpresaSucursal.Rows[index];

                /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);

                cnn.Open();
                SqlCommand comando = new SqlCommand("SP_Registro_Usuarios_Empresas_Sucursal", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(selectedRow.Cells[0].Text));
                comando.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(selectedRow.Cells[1].Text));
                comando.Parameters.AddWithValue("@Id_Territorio", Convert.ToInt32(selectedRow.Cells[2].Text));
                comando.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Close();
                comando = null;
                cnn.Close();




            }
        }

        protected void Grid_UsuariosEmpresaSucursal_RowEditing(object sender, GridViewEditEventArgs e)
        {

            Grid_UsuariosEmpresaSucursal.PageIndex = e.NewEditIndex;
            LlenarGridUsuarioEmpresaSucursal();


        }


        protected void RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }


    }
}