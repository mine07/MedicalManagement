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
    public partial class ConsultaAnalisisClinico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void LlenarGridAnalisisClinico()
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
                comando.Parameters.AddWithValue("@Descripcion_Diagnostico", txtBuscar_AnalisisClinico.Text);
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