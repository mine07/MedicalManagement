﻿using System;
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
    public partial class FarmaciaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        
        {

            
            if (!IsPostBack)
            {
                //LlenarGridMedicamento();
            }


        }
        protected void AccessDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.Parameters["Descripcion"].Value = "des";
        }
        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            //GuardarDiagnosticos();
            //LlenarGridMedicamento();
            txtBuscar_Medicamento.Focus();
        }

        protected void btnGuardar_Producto(object sender, EventArgs e)
        {
            //GuardarDiagnosticos();
            //System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Datos modificados');</script>");
            Response.Redirect("AgregarProducto.aspx");

        }
        protected void Grid_Medicamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            //GuardarDiagnosticos();
            GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataBind();
            LlenarGridMedicamento();
        }

        protected void Grid_Medicamento_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {

        }
        public void LlenarGridMedicamento()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_ProductosFarmacia", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (!(txtBuscar_Medicamento.Text == ""))
            {
                string s = txtBuscar_Medicamento.Text;
                string[] palabras = s.Split(' ');
                int i = 0;
                foreach (string palabra in palabras)
                {
                    if (i <= 4)
                    {
                        string NDescripcion = "@Descripcion" + i;
                        comando.Parameters.AddWithValue(NDescripcion, palabra);
                        i++;
                        Console.WriteLine(palabra);
                    }
                }

            }
            else
            {
                comando.Parameters.AddWithValue("@Descripcion", "");
            }
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            GridView1.Visible = true;
            GridView1.DataSource = ds;
            GridView1.Columns[0].Visible = true;
            GridView1.Columns[1].Visible = true;
            GridView1.Columns[2].Visible = true;
            GridView1.Columns[3].Visible = true;
            GridView1.Columns[4].Visible = true;
            GridView1.Columns[5].Visible = true;
           
            //GridView1.DataBind();
            ds.Dispose();
            da.Dispose();
            txtBuscar_Medicamento.Focus();
        }
    }
}