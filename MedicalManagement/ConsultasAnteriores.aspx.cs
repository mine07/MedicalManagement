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
    public partial class ConsultasAnteriores : System.Web.UI.Page
    {
        int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_FichaIdentificacion"]);
        string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);


        protected void Page_Load(object sender, EventArgs e)
        {
            llenarconsultas();
        }


        public void llenarconsultas()
        {
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();

            DataTable dt = new DataTable();
            //SqlCommand comando = new SqlCommand("SP_Registro_Agenda", cnn);select * from Tabla_Registro_Consulta
            //comando.CommandType = CommandType.StoredProcedure;
            SqlCommand comando = new SqlCommand(@"select distinct a.Fecha_Consulta,a.Subjetivo_Consulta,a.Objetivo_Consulta,
                                                a.Diagnostico_Consulta,a.Analisis_Consulta,a.Plan_Consulta,b.Medicamento_ConsultaReceta,
                                                b.Cantidad_ConsultaReceta,b.Cada_ConsultaReceta,
                                                c.Observaciones_ConsultaAnalisisClinico 
                                                from Tabla_Registro_Consulta a left join Tabla_Registro_ConsultaReceta b
                                                on (a.Id_Consulta=b.Id_Consulta) left join Tabla_Registro_ConsultaAnalisisClinico c
                                                on (c.Id_Consulta=a.Id_Consulta)

                                                where a.Id_FichaIdentificacion=" + Id_FichaIdentificacion+"order by Fecha_Consulta desc",cnn);            

           


            //comando.Parameters.AddWithValue("@Opcion", "LISTADO");
            //comando.Parameters.AddWithValue("@Nombre_FichaIdentificacion", "");


            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable ds = new DataTable();
            da.Fill(ds);

            DateTime fechaconsulta;
            string subjetivo="";
            string objetivo="";
            string diagnostico="";
            string analisis="";
            string plan="";
            string medicamento="";
            string cantidad="";
            string cada="";
            string observaciones = "";
            string cadena = "<table >";
            cadena = cadena +"<tr><td>" + NombreCompleto + "</td></tr>";
            cadena = cadena + "<tr><td><br></Td></tr>";

            foreach (DataRow row in ds.Rows)
            {
                fechaconsulta = Convert.ToDateTime(row["Fecha_Consulta"]);
                subjetivo = Convert.ToString(row["Subjetivo_Consulta"]);
                objetivo = Convert.ToString(row["Objetivo_Consulta"]);
                diagnostico= Convert.ToString(row["Diagnostico_Consulta"]);
                analisis = Convert.ToString(row["Analisis_Consulta"]);
                plan = Convert.ToString(row["Plan_Consulta"]);
                medicamento = Convert.ToString(row["Medicamento_ConsultaReceta"]);
                cantidad = Convert.ToString(row["Cantidad_ConsultaReceta"]);
                cada = Convert.ToString(row["Cada_ConsultaReceta"]);
                observaciones = Convert.ToString(row["Observaciones_ConsultaAnalisisClinico"]);
                cadena = cadena + "<Tr><td>---FechaConsulta---</Td>";                
                cadena = cadena + "<td>" + fechaconsulta + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td>______Subjetivo______</Td></Tr>";                
                cadena = cadena + "<Tr><td>" + subjetivo + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td>______Objetivo_______</Td></Tr>";
                cadena = cadena + "<Tr><td>"+objetivo+"</Td></Tr>";
                
                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td>______Diagnostico_______</Td></Tr>";
                cadena = cadena + "<Tr><td>" + diagnostico + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td>_______Analisis_______</Td></Tr>";
                cadena = cadena + "<Tr><td>" + analisis + "</Td></Tr>";
                
                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td>______Plan______</Td></Tr>";
                cadena = cadena + "<Tr><td>" + plan + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td>---Medicamento---</Td></Tr>";
                cadena = cadena + "<Tr><td>" + medicamento + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td>______Cantidad_______</Td></Tr>";
                cadena = cadena + "<Tr><td>" + cantidad + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td>______Cada cuando______</Td></Tr>";
                cadena = cadena + "<Tr><td>" + cada + "</Td></Tr>";

                //cadena = cadena + "<Tr><td><br></td></Tr>";
                cadena = cadena + "<Tr><td>______Observaciones______</Td></Tr>";
                cadena = cadena + "<Tr><td>" + observaciones + "</Td></Tr>";

                cadena = cadena + "<Tr><td>___________________________________________________________</Td></Tr>";
            }

            cadena = cadena + "<table>";
            consultasanteriores.InnerHtml = cadena;

            comando = null;
            cnn.Close();

        }

        protected void btnRegresar_Consultas_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Consultas.aspx");
        }

        
    }
}