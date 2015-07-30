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
    public partial class Sucursales : System.Web.UI.Page
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
                 string valornombrepagina = "Sucursales.aspx";
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

                     Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Consultorios'</p>";
                     Response.Redirect("MenuInicial.aspx");
                 }


             }


             if (!IsPostBack)
             {
                 LlenarGridSucursales();
                 LlenarCMBEmpresas();
             }

        }

        public void LlenarCMBEmpresas()
        {
            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();
            SqlCommand objsqlcommand = new SqlCommand("SP_Catalogo_Empresas", cnn);
            objsqlcommand.CommandType = CommandType.StoredProcedure;
            objsqlcommand.Parameters.AddWithValue("@Opcion", "COMBO");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(objsqlcommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            Id_Empresa.DataTextField = "Comercial_Nombre_Empresa";
            Id_Empresa.DataValueField = "Id_Empresa";
            Id_Empresa.DataSource = dt;
            Id_Empresa.DataBind();
            Id_Empresa.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            Id_Empresa.SelectedIndex = 0;
            objsqlcommand.ExecuteNonQuery();


        }
        protected void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        public void LlenarGridSucursales()
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_Sucursal", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (Buscar_Sucursal.Text == "")
            {
                comando.Parameters.AddWithValue("@Comercial_Nombre_Sucursal", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Comercial_Nombre_Sucursal", Buscar_Sucursal.Text);
            }
            /*
                0  Id_Sucursal
                1  Nombre_Sucursal
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Sucursales.Visible = true;
            Grid_Sucursales.DataSource = ds;
            Grid_Sucursales.Columns[0].Visible = true;
            Grid_Sucursales.Columns[1].Visible = true;
            Grid_Sucursales.Columns[2].Visible = true;
            Grid_Sucursales.DataBind();
            Grid_Sucursales.Columns[0].Visible = false;
            ds.Dispose();
            da.Dispose();


        }
        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridSucursales();
        }
        protected void Grid_Sucursales_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_Sucursales_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridSucursales();
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Sucursales.Rows[index];


                /*
                    0  Id_Sucursal
                    1  Comercial_Nombre_Sucursal
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroSucursales.aspx?Id_Sucursal=" + selectedRow.Cells[1].Text);


            }
            if (e.CommandName == "Delete")
            {

                /*
                    0  Id_Sucursal
                    1  Comercial_Nombre_Sucursal
                 */

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRowE = Grid_Sucursales.Rows[index];
                try
                {
                    Response.Write("<script language=javascript>confirm('Esta seguro que quiere eliminar la Sucursal?');</script>");
                }
                catch (Exception ex)
                {

                }
                Eliminar(Convert.ToString(selectedRowE.Cells[1].Text));
                LlenarGridSucursales();
            }

        }

        protected void Eliminar(string id_Sucursal)
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            SqlCommand command = new SqlCommand("SP_Catalogo_Sucursal", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_Sucursal", id_Sucursal);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Catalogo_Sucursal"
                                            + "@Opcion" + " = " + "BAJA"
                                            + "@Id_Sucursal" + " = " + Convert.ToString(id_Sucursal).Trim();

            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja Sucursal nueva");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();

        }

        protected void RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void btnAgregarSucursal_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroSucursales.aspx");

        }


    }
}