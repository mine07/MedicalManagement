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
    public partial class AnalisisClinicoPaquetes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //bool estatuspermiso = false;
            //estatuspermiso = Convert.ToBoolean(Session["estatuspermiso"]);
            //int usuario = Convert.ToInt32(Session["inicio"]);

            //if (Session["inicio"] == null || usuario == 0)
            //{
            //    Response.Redirect("Default.aspx");
            //}


            //else if (estatuspermiso == false)
            //{
            //    string valornombrepagina = "AnalisisClinico.aspx";///////////////////////////
            //    string consulta;
            //    SqlCommand comando;
            //    int numeroidmodulo = 0;
            //    string consulta2;
            //    SqlCommand comando2;
            //    int valoridperfildeusuario = 0;
            //    valoridperfildeusuario = Convert.ToInt32(Session["inicioidperfil"]);

            //    string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            //    SqlConnection cnn;
            //    cnn = new SqlConnection(conexion);
            //    cnn.Open();

            //    consulta = "Select Id_Modulo from Tabla_Catalogo_Modulo where Programa_Modulo='" + valornombrepagina + "'";

            //    comando = new SqlCommand(consulta, cnn);

            //    numeroidmodulo = Convert.ToInt32(comando.ExecuteScalar());

            //    consulta2 = "select Estatus_Permiso from Tabla_Registro_Permisos_Perfil where Id_Modulo=" + numeroidmodulo + " and Id_Perfil=" + valoridperfildeusuario + "";
            //    comando2 = new SqlCommand(consulta2, cnn);

            //    estatuspermiso = Convert.ToBoolean(comando2.ExecuteScalar());

            //    cnn.Close();

            //    if (estatuspermiso == true)
            //    {

            //    }
            //    else
            //    {
            //        //System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Este usuario no tiene acceso a la pagina solicitada');</script>");

            //        Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Analisis Clinico'</p>";
            //        Response.Redirect("MenuInicial.aspx");
            //    }

            //}

            if (!IsPostBack)
            {
                LlenarGridAnalisisClinicoPaquetes();
            }

            //estatuspermiso = false;
            //Session["estatuspermiso"] = false;


        }


        ///////////////////////////////////////////////////////////////////////////////////////

        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridAnalisisClinicoPaquetes();
        }



        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid_AnalisisClinicoPaquetes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridAnalisisClinicoPaquetes();

            Grid_AnalisisClinicoPaquetes.PageIndex = e.NewPageIndex;
            Grid_AnalisisClinicoPaquetes.DataBind();
        }

        protected void Grid_AnalisisClinicoPaquetes_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {

        }

        protected void Grid_AnalisisClinicoIncluidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string analisisclinicopaquete = Convert.ToString(Session["AnalisisClinicoPaquete"]);
            Mostrar(analisisclinicopaquete);

            Grid_AnalisisClinicoIncluidos.PageIndex = e.NewPageIndex;
            Grid_AnalisisClinicoIncluidos.DataBind();
        }

        protected void Grid_AnalisisClinicoIncluidos_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void btnAgregarAnalisisClinicoPaquetes_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroAnalisisClinicoPaquetes.aspx");
        }


        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Mostrar")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_AnalisisClinicoPaquetes.Rows[index];
                Session["AnalisisClinicoPaquete"] = Convert.ToString(selectedRow.Cells[0].Text);
                

                Mostrar(Convert.ToString(selectedRow.Cells[0].Text));               

            }


            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_AnalisisClinicoPaquetes.Rows[index];


                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroAnalisisClinicoPaquetes.aspx?Id_AnalisisClinicoPaquetes=" + selectedRow.Cells[0].Text);


            }

            if (e.CommandName == "Delete")
            {

                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRowE = Grid_AnalisisClinicoPaquetes.Rows[index];
                try
                {
                    Response.Write("<script language=javascript>confirm('Esta seguro que quiere eliminar Analisis Clinico?');</script>");
                }
                catch (Exception ex)
                {

                }
                Eliminar(Convert.ToString(selectedRowE.Cells[0].Text));
                LlenarGridAnalisisClinicoPaquetes();
            }
        }

        protected void Mostrar(string Id_AnalisisClinicoPaquetes)
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            string sentencia = @"select a.Id_AnalisisClinico,b.Descripcion_AnalisisClinico from Tabla_Registro_AnalisisClinicoPaquetes a
                               join Tabla_Catalogo_AnalisisClinico b on a.Id_AnalisisClinico=b.Id_AnalisisClinico
                               where Id_AnalisisClinicoPaquetes=" + Id_AnalisisClinicoPaquetes + "and a.Estatus_AnalisisClinicoPaquetes=1";

            SqlCommand comando = new SqlCommand(sentencia, cnn);
            comando.CommandType = CommandType.Text;


            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_AnalisisClinicoIncluidos.Visible = true;
            Grid_AnalisisClinicoIncluidos.DataSource = ds;
            Grid_AnalisisClinicoIncluidos.Columns[0].Visible = true;
            Grid_AnalisisClinicoIncluidos.Columns[1].Visible = true;
            Grid_AnalisisClinicoIncluidos.DataBind();
            ds.Dispose();
            da.Dispose();

            cnn.Close();

        }

        protected void Eliminar(string Id_AnalisisClinicoPaquetes)
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            SqlCommand command = new SqlCommand("SP_Catalogo_AnalisisClinicoPaquetes", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_AnalisisClinicoPaquetes", Id_AnalisisClinicoPaquetes);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Catalogo_AnalisisClinicoPaquetes"
                                            + "@Opcion" + " = " + "BAJA"
                                            + "@Id_AnalisisClinico" + " = " + Convert.ToString(Id_AnalisisClinicoPaquetes).Trim();

            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja AnalisisClinico Paquetes nuevo");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();

        }

        public void LlenarGridAnalisisClinicoPaquetes()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_AnalisisClinicoPaquetes", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (txtBuscar_AnalisisClinicoPaquetes.Text == "")
            {
                comando.Parameters.AddWithValue("@Descripcion_AnalisisClinicoPaquetes", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Descripcion_AnalisisClinicoPaquetes", txtBuscar_AnalisisClinicoPaquetes.Text);
            }
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_AnalisisClinicoPaquetes.Visible = true;
            Grid_AnalisisClinicoPaquetes.DataSource = ds;
            Grid_AnalisisClinicoPaquetes.Columns[0].Visible = true;
            Grid_AnalisisClinicoPaquetes.Columns[1].Visible = true;
            Grid_AnalisisClinicoPaquetes.DataBind();
            ds.Dispose();
            da.Dispose();
        }
    }
}