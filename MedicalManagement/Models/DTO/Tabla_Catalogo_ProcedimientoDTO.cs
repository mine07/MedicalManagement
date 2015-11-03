using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            string query = "Select * from Tabla_Catalogo_Procedimiento where Descripcion_Procedimiento = @Descripcion_Procedimiento";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneProcedimiento)[0];
        }

        public static Tabla_Catalogo_ProcedimientoDTO GetOneById(Tabla_Catalogo_ProcedimientoDTO oneProcedimiento)
        {
            string query = "Select * from Tabla_Catalogo_Procedimiento where Id_Procedimiento = @Id_Procedimiento";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneProcedimiento)[0];
        }
    }
}