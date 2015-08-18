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
            if (!IsPostBack)
            {
                LlenarGridAnalisisClinico();
            }

        }


        ///////////////////////////////////////////////////////////////////////////////////////

        protected void btnRegresar_ConsultasDiagnostico_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }


        protected void btnGuardar_ConsultaDiagnostico_Click(object sender, EventArgs e)
        {
        }

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

        protected void CheckBoxelegir_CheckedChanged(object sender, EventArgs e)
        {
            
            DataTable ds = new DataTable();
            ds.Columns.Add("Id_AnalisisClinico", typeof(Int32));
            ds.Columns.Add("Descripcion_AnalisisClinico", typeof(String));

            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();
            

            CheckBox chseleccionado;

            foreach (GridViewRow row in Grid_AnalisisClinico.Rows)
            {
                bool valorcheck = false;
               
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;
                valorcheck =chseleccionado.Checked;
                if (valorcheck == true)
                {
                    int Id_analisisclinico = Convert.ToInt32(row.Cells[0].Text);
                    string Descripcion_AnalisisClinico = Convert.ToString(row.Cells[1].Text);
                    
                    
//                    string sentencia = @"select Id_AnalisisClinico,Descripcion_AnalisisClinico from Tabla_Catalogo_AnalisisClinico 
//                                        where Id_AnalisisClinico="+Id_analisisclinico+"";

//                    SqlCommand comando = new SqlCommand(sentencia, cnn);

//                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    

                    DataRow fila = ds.NewRow();
                    fila["Id_AnalisisClinico"] = Id_analisisclinico;
                    fila["Descripcion_AnalisisClinico"] = Descripcion_AnalisisClinico;

                    ds.Rows.Add(fila);                
                                 

                }
                else
                {
                    //chseleccionado.Checked = false;
                }
            }

            Grid_AnalisisClinicoSeleccionado.Visible = true;
            Grid_AnalisisClinicoSeleccionado.DataSource = ds;
            //Grid_AnalisisClinicoSeleccionado.Columns[0].Visible = true;
            //Grid_AnalisisClinicoSeleccionado.Columns[1].Visible = true;
            //Grid_AnalisisClinicoSeleccionado.Columns[2].Visible = true;
            Grid_AnalisisClinicoSeleccionado.DataBind();

            cnn.Close();

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