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
    public partial class AnalisisClinico : System.Web.UI.Page
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
            //    string valornombrepagina = "AnalisisClinico.aspx";
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
                LlenarGridAnalisisClinico();
            }

            //estatuspermiso = false;
            //Session["estatuspermiso"] = false;

        }

///////////////////////////////////////////////////////////////////////////////////////

        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridAnalisisClinico();
        }



        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid_AnalisisClinico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridAnalisisClinico();

            Grid_AnalisisClinico.PageIndex = e.NewPageIndex;
            Grid_AnalisisClinico.DataBind();
        }

        protected void Grid_AnalisisClinico_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {
            
        }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

         protected void btnAgregarSexo_Click(object sender, EventArgs e)
         {
            Response.Redirect("RegistroAnalisisClinico.aspx");
         }


         protected void RowCommand(object sender, GridViewCommandEventArgs e)
         {
             if (e.CommandName == "Edit")
             {

                 int index = Convert.ToInt32(e.CommandArgument);

                 GridViewRow selectedRow = Grid_AnalisisClinico.Rows[index];


                 /*
                     0  Id_Empresa
                     1  Comercial_Nombre_Empresa
                  */

                 System.Web.HttpContext.Current.Response.Redirect("RegistroAnalisisClinico.aspx?Id_AnalisisClinico=" + selectedRow.Cells[0].Text);


             }

             if (e.CommandName == "Delete")
             {

                 /*
                     0  Id_Empresa
                     1  Comercial_Nombre_Empresa
                  */

                 int index = Convert.ToInt32(e.CommandArgument);
                 GridViewRow selectedRowE = Grid_AnalisisClinico.Rows[index];
                 try
                 {
                     Response.Write("<script language=javascript>confirm('Esta seguro que quiere eliminar Analisis Clinico?');</script>");
                 }
                 catch (Exception ex)
                 {

                 }
                 Eliminar(Convert.ToString(selectedRowE.Cells[0].Text));
                 LlenarGridAnalisisClinico();
             }
         }

         protected void Eliminar(string Id_AnalisisClinico)
         {

             /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
             string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

             SqlConnection cnn;
             cnn = new SqlConnection(conexion);

             cnn.Open();


             SqlCommand command = new SqlCommand("SP_Catalogo_AnalisisClinico", cnn);
             command.CommandType = CommandType.StoredProcedure;
             command.Parameters.AddWithValue("@Opcion", "BAJA");
             command.Parameters.AddWithValue("@Id_AnalisisClinico", Id_AnalisisClinico);
             command.ExecuteNonQuery();
             command = null;

             String Registro_Operacion_Btacora = "SP_Catalogo_AnalisisClinico"
                                             + "@Opcion" + " = " + "BAJA"
                                             + "@Id_AnalisisClinico" + " = " + Convert.ToString(Id_AnalisisClinico).Trim();

             SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
             comandoBitacora.CommandType = CommandType.StoredProcedure;
             comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
             comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
             comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
             comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
             comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja AnalisisClinico nuevo");

             SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
             readerBitacora.Read();
             readerBitacora.Close();
             comandoBitacora = null;

             cnn.Close();

         }

         public void LlenarGridAnalisisClinico()
         {
             string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

             SqlConnection cnn;
             cnn = new SqlConnection(conexion);

             cnn.Open();

             SqlCommand comando = new SqlCommand("SP_Catalogo_AnalisisClinico", cnn);
             comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("@Opcion", "LISTADO");
             if (txtBuscar_AnalisisClinico.Text == "")
             {
                 comando.Parameters.AddWithValue("@Descripcion_AnalisisClinico", "");
             }
             else
             {
                 comando.Parameters.AddWithValue("@Descripcion_AnalisisClinico", txtBuscar_AnalisisClinico.Text);
             }
             /*
                 0  Id_Empresa
                 1  Nombre_Empresa
              */

             SqlDataAdapter da = new SqlDataAdapter(comando);
             DataTable ds = new DataTable();
             da.Fill(ds);
             Grid_AnalisisClinico.Visible = true;
             Grid_AnalisisClinico.DataSource = ds;
             Grid_AnalisisClinico.Columns[0].Visible = true;
             Grid_AnalisisClinico.Columns[1].Visible = true;
             Grid_AnalisisClinico.DataBind();
             ds.Dispose();
             da.Dispose();
         }
    }
}