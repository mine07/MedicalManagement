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
    public class Tabla_Catalogo_MedicamentoDTO
    {
        public int Id_Medicamento { get; set; }
        public string Descripcion_Medicamento { get; set; }
        public bool Estatus_Medicamento { get; set; }
    }

    public class MedicamentoDAO
    {
        public static List<Tabla_Catalogo_MedicamentoDTO> GetAll()
        {
            string query = "Select * from Tabla_Catalogo_Medicamento";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, new Tabla_Catalogo_MedicamentoDTO());
        }
        public static Tabla_Catalogo_MedicamentoDTO GetOneByName(Tabla_Catalogo_MedicamentoDTO oneMedicamento)
        {
            try
            {
                string query = "Select * from Tabla_Catalogo_Medicamento where Descripcion_Medicamento = @Descripcion_Medicamento";
                Helpers h = new Helpers();
                return h.GetAllParametized(query, oneMedicamento)[0];
            }
            catch
            {
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand comando = new SqlCommand("SP_Catalogo_Medicamento", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                comando.Parameters.AddWithValue("@Descripcion_Medicamento", oneMedicamento.Descripcion_Medicamento);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                reader.Close();

                string query = "Select * from Tabla_Catalogo_Medicamento where Descripcion_Medicamento = @Descripcion_Medicamento";
                Helpers h = new Helpers();
                return h.GetAllParametized(query, oneMedicamento)[0];
            }
           /* // Error: Use of unassigned local variable 'n'.
            Console.Write(n);

            if (!("".Equals(oneMedicamento.Id_Medicamento)))
            {
            }
            else
            {
                string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

                SqlConnection cnn;
                cnn = new SqlConnection(conexion);
                cnn.Open();
                SqlCommand comando = new SqlCommand("SP_Catalogo_Medicamento", cnn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Opcion", "INSERTAR");
                comando.Parameters.AddWithValue("@Descripcion_Medicamento", oneMedicamento.Descripcion_Medicamento);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                reader.Close();
            }
            string query = "Select * from Tabla_Catalogo_Medicamento where Descripcion_Medicamento = @Descripcion_Medicamento";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneMedicamento)[0];*/
        }

        public static Tabla_Catalogo_MedicamentoDTO GetOneById(Tabla_Catalogo_MedicamentoDTO oneMedicamento)
        {
            string query = "Select * from Tabla_Catalogo_Medicamento where Id_Medicamento = @Id_Medicamento";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneMedicamento)[0];
        }
    }
}