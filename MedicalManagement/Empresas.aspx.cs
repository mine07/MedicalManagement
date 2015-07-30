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

namespace MedicalManagement
{
    public partial class Empresas : System.Web.UI.Page
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

                string valornombrepagina = "Empresas.aspx";
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
                    Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Empresas'</p>";
                    Response.Redirect("MenuInicial.aspx");
                }
            }

            if (estatuspermiso == true)
            {
                if (!IsPostBack)
                {
                    LlenarGridEmpresas();
                }
            }

            estatuspermiso = false;
            Session["estatuspermiso"] = false;
        }

      
  
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
     
      
        protected void txt_OnTextChanged(object sender, EventArgs e)
        {            
            LlenarGridEmpresas();
        }

        protected void Grid_Empresas_PageIndexChanged(object sender, EventArgs e)
        {

        }
               
        
        protected void Grid_Empresas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridEmpresas();
        }

        protected void RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }

        
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////      

        protected void btnAgregarEmpresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroEmpresas.aspx");

        }
               
          
            
        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Empresas.Rows[index];

            
                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroEmpresas.aspx?Id_Empresa=" + selectedRow.Cells[0].Text);


            }
            if (e.CommandName == "Delete")
            {
            
                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRowE = Grid_Empresas.Rows[index];
                try
                {
                    Response.Write("<script language=javascript>confirm('Esta seguro que quiere eliminar la Empresa?');</script>");
                }
                catch (Exception ex)
                {

                }
                Eliminar(Convert.ToString(selectedRowE.Cells[0].Text));
                LlenarGridEmpresas();
            }

        }

        protected void Eliminar(string id_Empresa)
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();
            

            SqlCommand command = new SqlCommand("SP_Catalogo_Empresas", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_Empresa", id_Empresa);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Catalogo_Empresas"
                                            + "@Opcion" + " = " + "BAJA"
                                            + "@Id_Empresa" + " = " + Convert.ToString(id_Empresa).Trim();
            
            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal",Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario",Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora",Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora","Baja Empresa nueva");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();

        }

                       

        

        public void LlenarGridEmpresas()
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            /* SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/


            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_Empresas", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (txtBuscar_Empresa.Text == "")
            {
                comando.Parameters.AddWithValue("@Comercial_Nombre_Empresa", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Comercial_Nombre_Empresa", txtBuscar_Empresa.Text);
            }
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Empresas.Visible = true;
            Grid_Empresas.DataSource = ds;
            Grid_Empresas.Columns[0].Visible = true;
            Grid_Empresas.Columns[1].Visible = true;
            Grid_Empresas.DataBind();
            ds.Dispose();
            da.Dispose();


        }
    }
}