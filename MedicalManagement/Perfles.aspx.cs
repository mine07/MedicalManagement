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
    public partial class Perfiles : System.Web.UI.Page
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
                 string valornombrepagina = "Perfles.aspx";
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

                     Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Perfiles'</p>";
                     Response.Redirect("MenuInicial.aspx");
                 }

             }

             if (!IsPostBack)
             {
                 LlenarGridPerfiles();
             }

             estatuspermiso = false;
             Session["estatuspermiso"] = false;

        }

        public void LlenarGridPerfiles()
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_Perfil", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (!(Buscar_Perfil.Text == ""))
            {

                string s = Buscar_Perfil.Text;
                string[] palabras = s.Split(' ');
                int i = 0;
                foreach (string palabra in palabras)
                {
                    if (i <= 1)
                    {
                        string NDescripcion = "@Descripcion_Perfil" + i;
                        comando.Parameters.AddWithValue(NDescripcion, palabra);
                        i++;
                        Console.WriteLine(palabra);
                    }
                }
            }
            else
            {
                comando.Parameters.AddWithValue("@Descripcion_Perfil0", "");
            }
            /*
                0  Id_Perfil
                1  Descripcion_Perfil
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Perfiles.Visible = true;
            Grid_Perfiles.DataSource = ds;
            Grid_Perfiles.Columns[0].Visible = true;
            Grid_Perfiles.Columns[1].Visible = true;
            Grid_Perfiles.DataBind();
            ds.Dispose();
            da.Dispose();
            Buscar_Perfil.Focus();

        }
        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridPerfiles();
        }
        protected void Grid_Perfiles_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_Perfiles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridPerfiles();
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Perfiles.Rows[index];


                /*
                    0  Id_Perfil
                    1  Descripcion_Perfil
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroPerfiles.aspx?Id_Perfil=" + selectedRow.Cells[0].Text);


            }
            if (e.CommandName == "Delete")
            {

                /*
                    0  Id_Perfil
                    1  Descripcion_Perfil
                 */

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRowE = Grid_Perfiles.Rows[index];
                try
                {
                    Response.Write("<script language=javascript>confirm('Esta seguro que quiere eliminar el Perfil?');</script>");
                }
                catch (Exception ex)
                {

                }
                Eliminar(Convert.ToString(selectedRowE.Cells[0].Text));
                LlenarGridPerfiles();
            }

        }

        protected void Eliminar(string Id_Perfil)
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            SqlCommand command = new SqlCommand("SP_Catalogo_Perfil", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_Perfil", Id_Perfil);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Catalogo_Perfil"
                                            + "@Opcion" + " = " + "BAJA"
                                            + "@Id_Perfil" + " = " + Convert.ToString(Id_Perfil).Trim();

            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja Perfil");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();

        }

        protected void RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void btnAgregarPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroPerfiles.aspx");

        }


    }
}