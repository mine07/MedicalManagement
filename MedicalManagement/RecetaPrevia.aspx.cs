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
    public partial class RecetaPrevia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridRecetaPrevia();
            }
            

        }

        /////////////////////////////////////////////////////////////////////////


        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridRecetaPrevia();
        }



        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid_RecetaPrevia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridRecetaPrevia();
        }

        protected void Grid_RecetaPrevia_PageIndexChanged(object sender, EventArgs e)
        {

        }



        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void btnAgregarRecetaPrevia_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroRecetaPrevia.aspx");
        }


        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_RecetaPrevia.Rows[index];


                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroRecetaPrevia.aspx?Id_ConsultaRecetaPrevia=" + selectedRow.Cells[0].Text);


            }
            if (e.CommandName == "Delete")
            {

                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRowE = Grid_RecetaPrevia.Rows[index];
                try
                {
                    Response.Write("<script language=javascript>confirm('Esta seguro que quiere eliminar la RecetaPrevia?');</script>");
                }
                catch (Exception ex)
                {

                }
                Eliminar(Convert.ToString(selectedRowE.Cells[0].Text));
                LlenarGridRecetaPrevia();
            }

        }

        protected void Eliminar(string id_consultarecetaprevia)
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            SqlCommand command = new SqlCommand("SP_Catalogo_ConsultaRecetaPrevia", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_ConsultaRecetaPrevia", id_consultarecetaprevia);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Catalogo_ConsultaRecetaPrevia"
                                            + "@Opcion" + " = " + "BAJA"
                                            + "@Id_ConsultaRecetaPrevia" + " = " + Convert.ToString(id_consultarecetaprevia).Trim();

            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja RecetaPrevia nueva");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();

        }

        public void LlenarGridRecetaPrevia()
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            /* SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/


            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_ConsultaRecetaPrevia", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (txtBuscar_RecetaPrevia.Text == "")
            {
                comando.Parameters.AddWithValue("@Nombre_ConsultaRecetaPrevia", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Nombre_ConsultaRecetaPrevia", txtBuscar_RecetaPrevia.Text);
            }
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_RecetaPrevia.Visible = true;
            Grid_RecetaPrevia.DataSource = ds;
            Grid_RecetaPrevia.Columns[0].Visible = true;
            Grid_RecetaPrevia.Columns[1].Visible = true;
            Grid_RecetaPrevia.DataBind();
            ds.Dispose();
            da.Dispose();


        }
    }
}