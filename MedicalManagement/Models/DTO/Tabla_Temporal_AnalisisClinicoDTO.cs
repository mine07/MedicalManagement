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
        public AnalisisClinicoDTO oneAnalisis { get; set; }
    }
    public class Tabla_Temporal_AnalisisClinicoDAO
    {
        public static List<Tabla_Temporal_AnalisisClinicoDTO> GetAll(string queryIf, Tabla_Temporal_AnalisisClinicoDTO oneAnaPaquete)
        {
            string query = "select * from Tabla_Temporal_AnalisisClinico a left join Tabla_Catalogo_AnalisisClinico b on b.Id_AnalisisClinico = a.Id_Analisisclinico " + queryIf;
            Helpers h = new Helpers();
            var lAnalisisEnPaquetes = h.GetAllParametized(query, oneAnaPaquete);
            foreach (var y in lAnalisisEnPaquetes)
            {
                string innerQuery = " where Id_AnalisisClinico = @Id_AnalisisClinico";
                y.oneAnalisis = AnalisisClinicoDAO.GetAll(innerQuery, new AnalisisClinicoDTO { Id_AnalisisClinico = y.Id_AnalisisClinico })[0];
            }
            return lAnalisisEnPaquetes;
        }
        public void Insert(string queryIf, Tabla_Temporal_AnalisisClinicoDTO oneAnaPaquete)
        {
            string query = "insert into Tabla_Temporal_AnalisisClinico (Id_FichaIdentificacion, Id_AnalisisClinico , Id_Consulta) values (@Id_FichaIdentificacion, @Id_AnalisisClinico , @Id_Consulta)";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneAnaPaquete);
        }
        public void delete(string queryIf, Tabla_Temporal_AnalisisClinicoDTO oneAnaPaquete)
        {
            string query = "delete Tabla_Temporal_AnalisisClinico where Id_Temporal_AnalisisClinico = @Id_Temporal_AnalisisClinico";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneAnaPaquete);
        }
    }
}
