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
    public partial class ConsultaProcedimiento : System.Web.UI.Page
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
                LlenarGridProcedimiento();
            }

        }


        ///////////////////////////////////////////////////////////////////////////////////////

        protected void txt_OnTextChanged(object sender, EventArgs e)
        {
            LlenarGridProcedimiento();
        }



        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Grid_Procedimiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LlenarGridProcedimiento();

            Grid_Procedimiento.PageIndex = e.NewPageIndex;
            Grid_Procedimiento.DataBind();
        }

        protected void Grid_Procedimiento_PageIndexChanged(object sender, EventArgs e)//EventArgs
        {

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void btnRegresar_ConsultasProcedimiento_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }

        protected void RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }


        protected void btnGuardar_ConsultaProcedimiento_Click(object sender, EventArgs e)
        {
            CheckBox chseleccionado;
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);
            cnn.Open();

            bool varlorcheck;

            foreach (GridViewRow row in Grid_Procedimiento.Rows)
            {
                varlorcheck = false;
                chseleccionado = row.FindControl("CheckBoxelegir") as CheckBox;

                if (chseleccionado.Checked == true)
                {
                    varlorcheck = true;
                    SqlCommand comando = new SqlCommand("SP_Registro_ConsultasProcedimiento", cnn);
                    comando.CommandType = CommandType.StoredProcedure;

                    int numeroidprocedimiento = Convert.ToInt32(row.Cells[0].Text);

                    SqlCommand comando2 = new SqlCommand("select Id_consulta,Id_Procedimiento,Id_FichaIdentificacion,Fecha_ConsultaProcedimiento from Tabla_Registro_ConsultaProcedimiento", cnn);
                    DataTable datos = new DataTable();
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando2);
                    adaptador.Fill(datos);

                    if (datos.Rows.Count == 0)
                    {
                        comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                        comando.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
                        comando.Parameters.AddWithValue("@Id_Procedimiento", numeroidprocedimiento);
                        comando.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
                        comando.Parameters.AddWithValue("@Estatus_ConsultaProcedimiento", varlorcheck);
                        comando.Parameters.AddWithValue("@Fecha_ConsultaProcedimiento", Convert.ToDateTime(Fecha_Consulta));

                        comando.ExecuteNonQuery();
                    }
                    else
                    {
                        bool insertar = false;

                        foreach (DataRow dtRow in datos.Rows)
                        {
                            int valoridconsulta = 0;
                            valoridconsulta = Convert.ToInt32(dtRow["Id_consulta"]);

                            int valoridprocedimiento = 0;
                            valoridprocedimiento = Convert.ToInt32(dtRow["Id_Procedimiento"]);

                            int valoridfichaidentificacion = 0;
                            valoridfichaidentificacion = Convert.ToInt32(dtRow["Id_FichaIdentificacion"]);

                            insertar = true;

                            if ((valoridprocedimiento == numeroidprocedimiento) && (valoridconsulta == Id_Consulta) && (valoridfichaidentificacion == Id_FichaIdentificacion))
                            {
                                insertar = false;
                                comando.Parameters.AddWithValue("@Opcion", "ACTUALIZAR");
                                comando.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
                                comando.Parameters.AddWithValue("@Id_Procedimiento", numeroidprocedimiento);
                                comando.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
                                comando.Parameters.AddWithValue("@Estatus_procedimiento", varlorcheck);
                                comando.Parameters.AddWithValue("@Fecha_ConsultaProcedimiento", Convert.ToDateTime(Fecha_Consulta));
                                comando.ExecuteNonQuery();
                                break;
                            }


                        }



                        if (insertar == true)
                        {


                            comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                            comando.Parameters.AddWithValue("@Id_Consulta", Id_Consulta);
                            comando.Parameters.AddWithValue("@Id_Procedimiento", numeroidprocedimiento);
                            comando.Parameters.AddWithValue("@Id_FichaIdentificacion", Id_FichaIdentificacion);
                            comando.Parameters.AddWithValue("@Estatus_ConsultaProcedimiento", varlorcheck);
                            comando.Parameters.AddWithValue("@Fecha_ConsultaProcedimiento", Convert.ToDateTime(Fecha_Consulta));
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
            System.Web.HttpContext.Current.Response.Write("<script>javascript: alert('Datos modificados');</script>");
            //LlenarGridAnalisisClinico();

        }

        public void LlenarGridProcedimiento()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_Catalogo_Procedimiento", cnn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            if (txtBuscar_Procedimiento.Text == "")
            {
                comando.Parameters.AddWithValue("@Descripcion_Procedimiento", "");
            }
            else
            {
                comando.Parameters.AddWithValue("@Descripcion_Procedimiento", txtBuscar_Procedimiento.Text);
            }
            /*
                0  Id_Empresa
                1  Nombre_Empresa
             */

            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);
            Grid_Procedimiento.Visible = true;
            Grid_Procedimiento.DataSource = ds;
            Grid_Procedimiento.Columns[0].Visible = true;
            Grid_Procedimiento.Columns[1].Visible = true;
            Grid_Procedimiento.DataBind();
            ds.Dispose();
            da.Dispose();
        }
    }
}