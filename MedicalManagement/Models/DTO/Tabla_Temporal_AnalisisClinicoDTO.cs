using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Temporal_AnalisisClinicoDTO 
    {
        public int Id_Temporal_AnalisisClinico { get; set; }
        public int Id_FichaIdentificacion { get; set; }
        public int Id_AnalisisClinico { get; set; }
        public int Id_Consulta { get; set; }
    }
    public class Tabla_Temporal_AnalisisClinicoDAO
    {
        public void Insert(string queryIf, Tabla_Temporal_AnalisisClinicoDTO oneAnaPaquete)
        {
            string query = "insert into Tabla_Temporal_AnalisisClinico (Id_FichaIdentificacion, Id_AnalisisClinico , Id_Consulta) values (@Id_FichaIdentificacion, @Id_AnalisisClinico , @Id_Consulta)";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneAnaPaquete);
        }
    }
}
