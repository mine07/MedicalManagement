using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class PaquetesDTO
    {
        public int Id_AnalisisClinicoPaquetes { get; set; }
        public string Descripcion_AnalisisClinicoPaquetes { get; set; }
        public bool Estatus_AnalisisClinicoPaquetes { get; set; }
    }

    public class PaquetesDAO
    {
        public static List<PaquetesDTO> GetAll(string queryIf, PaquetesDTO onePaquete)
        {
            string query = "select * from Tabla_Catalogo_AnalisisClinicoPaquetes " + queryIf;
            Helpers h = new Helpers();
            var lPaquetes = h.GetAllParametized(query, onePaquete);
            foreach (var y in lPaquetes)
            {
                y.Descripcion_AnalisisClinicoPaquetes = y.Descripcion_AnalisisClinicoPaquetes.Trim();
            }
            return lPaquetes;
        }
    }
}