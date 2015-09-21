using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class AnalisisClinicoDTO
    {
        public int Id_AnalisisClinico { get; set; }
        public string Descripcion_AnalisisClinico { get; set; }
        public bool Estatus_AnalisisClinico { get; set; }
    }

    public class AnalisisClinicoDAO
    {
        public static List<AnalisisClinicoDTO> GetAll(string queryIf, AnalisisClinicoDTO oneAnalisis)
        {
            Helpers h = new Helpers();
            string query = "select * from  tabla_catalogo_analisisclinico " + queryIf;
            return h.GetAllParametized(query, oneAnalisis);
        }
    }
}