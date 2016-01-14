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
    public partial class Historial : System.Web.UI.Page
    {
        public decimal Subtotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            sumar();
            if (!IsPostBack)
            {
                sumar();
                //LlenarGridMedicamento();
            }


        }

        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            //GuardarDiagnosticos();
            //LlenarGridMedicamento();
            txtBuscar_Medicamento.Focus();
            sumar();

        }

        protected void btnGuardar_Producto(object sender, EventArgs e)
        {
            //GuardarDiagnosticos();
            //System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Datos modificados');</script>");
            Response.Redirect("AgregarProducto.aspx");

        }
        public void sumar()
        {
            try
            {
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();

                //string consulta = "select sum(Costo) from Tabla_Catalogo_TicketTemp where Id_Ticket =" + Id_Ticket + "";
                string consulta = "select sum(Costo) from Tabla_Catalogo_Ticket where No_Tiket = " + Convert.ToInt32(txtBuscar_Medicamento.Text);
                SqlCommand comando = new SqlCommand(consulta, cnn);
                //Subtotal = Convert.ToInt32(comando.ExecuteScalar());
                Subtotal = Convert.ToDecimal(comando.ExecuteScalar());
                Label1.Text = Subtotal.ToString();

                cnn.Close();
            }
            catch { }

        }
            
            
        public void LlenarGridMedicamento()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Tabla_Catalogo_Ticket", cnn);
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
                        string NDescripcion = "@NombreMedicamento_" + i;
                        comando.Parameters.AddWithValue(NDescripcion, palabra);
                        i++;
                        Console.WriteLine(palabra);
                    }
                }

            }
            else
            {
                comando.Parameters.AddWithValue("@NombreMedicamento", "");
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

            GridView1.DataBind();
            ds.Dispose();
            da.Dispose();
            txtBuscar_Medicamento.Focus();
            sumar();
        }
    }
}