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
    public class Tabla_Catalogo_ProcedimientoDTO
    {
        public int Id_Procedimiento { get; set; }
        public string Descripcion_Procedimiento { get; set; }
        public bool Estatus_Procedimiento { get; set; }
    }

    public class ProcedimientoDAO
    {
        public static List<Tabla_Catalogo_ProcedimientoDTO> GetAll()
        {
            string query = "Select * from Tabla_Catalogo_Procedimiento";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, new Tabla_Catalogo_ProcedimientoDTO());
        }
        public static Tabla_Catalogo_ProcedimientoDTO GetOneByName(Tabla_Catalogo_ProcedimientoDTO oneProcedimiento)
        {
            try
            {
                string query = "Select * from Tabla_Catalogo_Procedimiento where Descripcion_Procedimiento = @Descripcion_Procedimiento";
                Helpers h = new Helpers();
                return h.GetAllParametized(query, oneProcedimiento)[0];
            }
            catch
            {
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand comando = new SqlCommand("SP_Catalogo_Procedimiento", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                comando.Parameters.AddWithValue("@Descripcion_Procedimiento", oneProcedimiento.Descripcion_Procedimiento);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                reader.Close();

                string query = "Select * from Tabla_Catalogo_Procedimiento where Descripcion_Procedimiento = @Descripcion_Procedimiento";
                Helpers h = new Helpers();
                return h.GetAllParametized(query, oneProcedimiento)[0];
            }
            /*if (oneProcedimiento.Id_Procedimiento > 0)
            {
            }
            else
            {
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand comando = new SqlCommand("SP_Catalogo_Procedimiento", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                comando.Parameters.AddWithValue("@Descripcion_Procedimiento", oneProcedimiento.Descripcion_Procedimiento);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                reader.Close();
            }
            string query = "Select * from Tabla_Catalogo_Procedimiento where Descripcion_Procedimiento = @Descripcion_Procedimiento";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneProcedimiento)[0];*/
        }

        public static Tabla_Catalogo_ProcedimientoDTO GetOneById(Tabla_Catalogo_ProcedimientoDTO oneProcedimiento)
        {
            string query = "Select * from Tabla_Catalogo_Procedimiento where Id_Procedimiento = @Id_Procedimiento";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneProcedimiento)[0];
        }
    }
}