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
    public partial class ConsultaDiagnostico : System.Web.UI.Page
    {
        int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);
        string Fecha_Consulta = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["Fecha_Consulta"]);

        int Id_Consulta = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Consulta"]);

      //  protected System.Web.UI.WebControls.Button Button2;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Buscar.Focus();
            // Button2 = FindControl("Button2") as Button;
            if (!IsPostBack)
            {
                
                LlenarGridDiagnostico();
            }

            //if (!Page.IsPostBack)
           // {
              //  this.Form.DefaultButton = Button2.UniqueID;
           // }

        }


        ///////////////////////////////////////////////////////////////////////////////////////

        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            //GuardarDiagnosticos();
            LlenarGridDiagnostico();
        }



        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid_Diagnostico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            //GuardarDiagnosticos();
            Grid_Diagnostico.PageIndex = e.NewPageIndex;
            Grid_Diagnostico.DataBind();
            LlenarGridDiagnostico();
        }

        protected void Grid_Diagnostico_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void btnRegresar_ConsultasDiagnostico_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = Grid_Diagnostico.Rows[index];


                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                System.Web.HttpContext.Current.Response.Redirect("RegistroDiagnostico.aspx?Id_Diagnostico=" + selectedRow.Cells[0].Text);


            }

            if (e.CommandName == "Delete")
            {

                /*
                    0  Id_Empresa
                    1  Comercial_Nombre_Empresa
                 */

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRowE = Grid_Diagnostico.Rows[index];

                try
                {
                    Response.Write("<script language=javascript>confirm('Esta seguro que quiere eliminar Procedimiento?');</script>");
                }
                catch (Exception ex)
                {

                }
                Eliminar(Convert.ToString(selectedRowE.Cells[0].Text));
                Response.Redirect("ConsultaDiagnostico.aspx");
            }
        }

        protected void Eliminar(string Id_Procedimiento)
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            SqlCommand command = new SqlCommand("SP_Catalogo_Diagnostico", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_Diagnostico", Id_Procedimiento);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Catalogo_Diagnostico"
                                            + "@Opcion" + " = " + "BAJA"
                                            + "@Id_Diagnostico" + " = " + Convert.ToString(Id_Procedimiento).Trim();

            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja Diagnostico nuevo");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();
            //LlenarGridProcedimiento();
        }


        protected void btnGuardar_ConsultaDiagnostico_Click(object sender, EventArgs e)
        {
            //GuardarDiagnosticos();
            System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Datos modificados');</script>");
            Response.Redirect("RegistroDiagnostico.aspx");

        }

        public void GuardarDiagnosticos()
        {
            CheckBox chseleccionado;
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            bool varlorcheck;

            foreach (GridViewRow row in Grid_Diagnostico.Rows)
            {
                varlorcheck = false;
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;

                if (chseleccionado.Checked == true)
                {
                    varlorcheck = true;
                    SqlCommand comando = new SqlCommand("SP_Registro_ConsultasDiagnostico", cnn);
                    comando.CommandType = CommandType.StoredProcedure;

                    int numeroiddiagnostico = Convert.ToInt32(row.Cells[0].Text);

                    SqlCommand comando2 = new SqlCommand("select Id_consulta,Id_Diagnostico,Id_FichaIdentificacion,Fecha_ConsultaDiagnostico from Tabla_Registro_ConsultaDiagnostico", cnn);
                    DataTable datos = new DataTable();
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando2);
                    adaptador.Fill(datos);

                    if (datos.Rows.Count == 0)
                    {
                        comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                        comando.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
                        comando.Parameters.AddWithValue("@Id_Diagnostico", numeroiddiagnostico);
                        comando.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
                        comando.Parameters.AddWithValue("@Estatus_ConsultaDiagnostico", varlorcheck);
                        comando.Parameters.AddWithValue("@Fecha_ConsultaDiagnostico", Convert.ToDateTime(Fecha_Consulta));

                        comando.ExecuteNonQuery();
                    }
                    else
                    {
                        bool insertar = false;

                        foreach (DataRow dtRow in datos.Rows)
                        {
                            int valoridconsulta = 0;
                            valoridconsulta = Convert.ToInt32(dtRow["Id_consulta"]);

                            int valoriddiagnostico = 0;
                            valoriddiagnostico = Convert.ToInt32(dtRow["Id_Diagnostico"]);

                            int valoridfichaidentificacion = 0;
                            valoridfichaidentificacion = Convert.ToInt32(dtRow["Id_FichaIdentificacion"]);

                            insertar = true;

                            if ((valoriddiagnostico == numeroiddiagnostico) && (valoridconsulta == Id_Consulta) && (valoridfichaidentificacion == Id_FichaIdentificacion))
                            {
                                insertar = false;
                                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                                comando.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
                                comando.Parameters.AddWithValue("@Id_Diagnostico", numeroiddiagnostico);
                                comando.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
                                comando.Parameters.AddWithValue("@Estatus_ConsultaDiagnostico", varlorcheck);
                                comando.Parameters.AddWithValue("@Fecha_ConsultaDiagnostico", Convert.ToDateTime(Fecha_Consulta));
                                comando.ExecuteNonQuery();
                                break;
                            }


                        }



                        if (insertar == true)
                        {


                            comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                            comando.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
                            comando.Parameters.AddWithValue("@Id_Diagnostico", numeroiddiagnostico);
                            comando.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
                            comando.Parameters.AddWithValue("@Estatus_ConsultaDiagnostico", varlorcheck);
                            comando.Parameters.AddWithValue("@Fecha_ConsultaDiagnostico", Convert.ToDateTime(Fecha_Consulta));
                            comando.ExecuteNonQuery();
                        }
                    }

                }
                else
                {
                    varlorcheck = false;
                }

            }
            cnn.Close();
            
            //LlenarGridAnalisisClinico();

        }


        public void LlenarGridDiagnostico()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_Diagnostico", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            
            if (!(txtBuscar_Diagnostico.Text == ""))
            {
                string s = txtBuscar_Diagnostico.Text;
                string[] palabras = s.Split(' ');
                int i = 0;
                foreach (string palabra in palabras)
                {
                    if (i <= 4)
                    {
                        string NDescripcion = "@Descripcion_Diagnostico" + i;
                        comando.Parameters.AddWithValue(NDescripcion, palabra);
                        i++;
                        Console.WriteLine(palabra);
                    }

                }


            }
            else
            {
                comando.Parameters.AddWithValue("@Descripcion_Diagnostico1", "");
            }
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Diagnostico.Visible = true;
            Grid_Diagnostico.DataSource = ds;
            Grid_Diagnostico.Columns[0].Visible = true;
            Grid_Diagnostico.Columns[1].Visible = true;
            Grid_Diagnostico.DataBind();
            ds.Dispose();
            da.Dispose();
            txtBuscar_Diagnostico.Focus();
        }
    }
}

