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
             int usuario = Convert.ToInt32(Session["inicio"]);
             if (Session["inicio"] == null || usuario == 0)
             {
                 Response.Redirect("Default.aspx");
             }


             else
             {


                 if (!IsPostBack)
                 {
                     LlenarGridPermisos();
                     LlenarCMBPerfiles();
                 }
             }

        }

        protected void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {


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
            Id_Perfil.DataTextField = "Descripcion_Perfil";
            Id_Perfil.DataValueField = "Id_Perfil";
            Id_Perfil.DataSource = dt;
            Id_Perfil.DataBind();
            Id_Perfil.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            Id_Perfil.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();
            cnn.Close();

        }
        protected void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        public void LlenarGridPermisos()
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalgo_Permisos", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Permisos.Visible = true;
            Grid_Permisos.DataSource = ds;
            Grid_Permisos.Columns[0].Visible = true;
            Grid_Permisos.Columns[1].Visible = true;
            Grid_Permisos.DataBind();
            Grid_Permisos.Columns[0].Visible = false;
            ds.Dispose();
            da.Dispose();


        }
        protected void Grid_Permisos_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_Permisos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridPermisos();
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




    }
}