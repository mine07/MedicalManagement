using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_DiagnosticoDTO
    {
        public int Id_Diagnostico { get; set; }
        public string Descripcion_Diagnostico { get; set; }
        public bool Estatus_diagnostico { get; set; }
    }

    public class DiagnosticoDAO
    {
        public static List<Tabla_Catalogo_DiagnosticoDTO> GetAll()
        {
            string query = "Select * from Tabla_Catalogo_Diagnostico";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, new Tabla_Catalogo_DiagnosticoDTO());
        }

        public static Tabla_Catalogo_DiagnosticoDTO GetOneByName(Tabla_Catalogo_DiagnosticoDTO oneDiagnostico)
        {
            if (oneDiagnostico.Id_Diagnostico > 0) { 
            }
            else
            {
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand comando = new SqlCommand("SP_Catalogo_Diagnostico", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                comando.Parameters.AddWithValue("@Descripcion_Diagnostico", oneDiagnostico.Descripcion_Diagnostico);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                reader.Close();
            }

            string query = "Select * from Tabla_Catalogo_Diagnostico where Descripcion_Diagnostico = @Descripcion_Diagnostico";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneDiagnostico)[0];
        }

        public static Tabla_Catalogo_DiagnosticoDTO GetOneById(Tabla_Catalogo_DiagnosticoDTO oneDiagnostico)
        {
            string query = "Select * from Tabla_Catalogo_Diagnostico where Id_Diagnostico = @Id_Diagnostico";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneDiagnostico)[0];
        }
    }
}