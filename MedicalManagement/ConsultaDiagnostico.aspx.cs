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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridDiagnostico();
            }

        }


        ///////////////////////////////////////////////////////////////////////////////////////

        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            //GuardarDiagnosticos();
            //LlenarGridDiagnostico();
        }



        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid_Diagnostico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GuardarDiagnosticos();
            Grid_Diagnostico.PageIndex = e.NewPageIndex;
            Grid_Diagnostico.DataBind();
            LlenarGridDiagnostico();
        }

        protected void Grid_Diagnostico_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void btnRegresar_ConsultasDiagnostico_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
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
            if (txtBuscar_Diagnostico.Text == "")
            {
                comando.Parameters.AddWithValue("@Descripcion_Diagnostico", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Descripcion_Diagnostico", txtBuscar_Diagnostico.Text);
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
        }
    }
}