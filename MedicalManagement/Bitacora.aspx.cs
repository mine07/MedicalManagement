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
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool estatuspermiso = false;
            estatuspermiso = Convert.ToBoolean(Session["estatuspermiso"]);
            int usuario = Convert.ToInt32(Session["inicio"]);
            
            if (Session["inicio"] == null || usuario == 0)
            {
                Response.Redirect("Default.aspx");
            }


            else if (estatuspermiso == false)
            {
                string valornombrepagina = "Bitacora.aspx";
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

                    Session["alerta"] = "<p style=\"color: white;background-color: blue\">No tiene permiso para acceder a 'Bitacora'</p>";
                    Response.Redirect("MenuInicial.aspx");
                }
               
            }

            if (!IsPostBack)
            {

            }

        }
        protected void OnSelectionChanged(object sender, EventArgs e)
        {
            LlenarGridBitacora();
        }
        public void LlenarGridBitacora()
        {


            if (FechaGeneracion.SelectedDate.ToString().Substring(0, 10) != "")
            {
                string Condicion = "";

                if (FechaGeneracion.SelectedDate.Month < 10)
                {
                    Condicion = Condicion + "0";
                }
                Condicion = Condicion + FechaGeneracion.SelectedDate.Month + "-";


                if (FechaGeneracion.SelectedDate.Day < 10)
                {
                    Condicion = Condicion + "0";
                }

                Condicion = Condicion + FechaGeneracion.SelectedDate.Day + "-";

                Condicion = Condicion + FechaGeneracion.SelectedDate.Year;


                /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();

                SqlCommand comando = new SqlCommand("SP_Consulta_Bitacora", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Registro_FechaHora_Bitacora", Condicion);
                               

                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable ds = new DataTable();
                da.Fill(ds);
                Grid_Bitacora.Visible = true;
                Grid_Bitacora.DataSource = ds;
                Grid_Bitacora.DataBind();
                ds.Dispose();
                da.Dispose();

            }
        }

    }
}