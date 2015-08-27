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
    public partial class PermisosPerfil : System.Web.UI.Page
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
                string valornombrepagina = "PermisoPerfil2.aspx";
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

                    Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Permisos por Perfil'</p>";
                    Response.Redirect("MenuInicial.aspx");
                }

            }

            if (!IsPostBack)
            {
                LlenarCMBPerfiles();
            }

            estatuspermiso = false;
            Session["estatuspermiso"] = false;

        }

        protected void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {


            LlenarGridPermisos2();


        }

        public void LlenarCMBPerfiles()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Perfil", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            //Session["combo"] = dt;

            ddl_Id_Perfil.DataTextField = "Descripcion_Perfil";
            ddl_Id_Perfil.DataValueField = "Id_Perfil";
            ddl_Id_Perfil.DataSource = dt;
            ddl_Id_Perfil.DataBind();
            ddl_Id_Perfil.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            ddl_Id_Perfil.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }

        protected void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {


        }



        public void LlenarGridPermisos2()
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            int numeroidperfil2 = Convert.ToInt32(ddl_Id_Perfil.SelectedValue);


            SqlCommand comando = new SqlCommand("SP_Catalgo_Permisos2", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            comando.Parameters.AddWithValue("@Id_Perfil", numeroidperfil2);

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            //Session["usuario"] = ds;

            Grid_Permisos.Visible = true;
            Grid_Permisos.DataSource = ds;
            Grid_Permisos.Columns[0].Visible = true;
            Grid_Permisos.Columns[1].Visible = true;
            Grid_Permisos.Columns[2].Visible = true;
            Grid_Permisos.DataBind();


            CheckBox chseleccionado;

            foreach (GridViewRow row in Grid_Permisos.Rows)
            {
                bool valorcheck = false;
                valorcheck = Convert.ToBoolean(row.Cells[2].Text);
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                if (valorcheck == true)
                {
                    chseleccionado.Checked = true;

                }
                else
                {
                    chseleccionado.Checked = false;
                }
            }

            Grid_Permisos.Columns[0].Visible = false;
            Grid_Permisos.Columns[2].Visible = false;
            ds.Dispose();
            da.Dispose();
            cnn.Close();



        }



        protected void Grid_Permisos_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_Permisos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridPermisos2();
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {



            }
            if (e.CommandName == "Delete")
            {

            }

        }

        protected void RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }




        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }






        protected void btnelegir_Click(object sender, EventArgs e)
        {
            int numeroidperfil = Convert.ToInt32(ddl_Id_Perfil.SelectedValue);
            CheckBox chseleccionado;

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            foreach (GridViewRow row in Grid_Permisos.Rows)
            {
                bool varlorcheck = false;
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                if (chseleccionado.Checked == true)
                {
                    varlorcheck = true;
                }
                else
                {
                    varlorcheck = false;
                }

                SqlCommand comando = new SqlCommand("SP_Registro_Permisos_Perfil", cnn);
                comando.CommandType = CommandType.StoredProcedure;

                int numeroidmodulo = Convert.ToInt32(row.Cells[0].Text);

                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                comando.Parameters.AddWithValue("@Id_Perfil", numeroidperfil);
                comando.Parameters.AddWithValue("@Id_Modulo", numeroidmodulo);
                comando.Parameters.AddWithValue("@Estatus_Permiso", varlorcheck);

                comando.ExecuteNonQuery();


            }
            cnn.Close();
            System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Datos modificados');</script>");
            LlenarGridPermisos2();


        }

    }
}