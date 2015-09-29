using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class ConsultaDiagnosticoDTO
    {
        public int Id_ConsultaDiagnostico { get; set; }
        public int Id_Consulta { get; set; }
        public int Id_Diagnostico { get; set; }
        public int Id_FichaIdentificacion { get; set; }
        public DateTime Fecha_ConsultaDiagnostico { get; set; }
        public string Observaciones_ConsultaDiagnostico { get; set; }
        public bool Estatus_ConsultaDiagnostico { get; set; }
        public Tabla_Catalogo_DiagnosticoDTO oneDiag { get; set; }
    }

    public class ConsultaDiagnosticoDAO
    {
        public static List<ConsultaDiagnosticoDTO> GetAllByPaciente(ConsultaDiagnosticoDTO oneConsulta)
        {
            string query =
                "select * from Tabla_Registro_ConsultaDiagnostico where Id_FichaIdentificacion = @Id_FichaIdentificacion";
            Helpers h = new Helpers();
            var lDiags = h.GetAllParametized(query, oneConsulta);
            foreach (var y in lDiags)
            {
                y.oneDiag = new Tabla_Catalogo_DiagnosticoDTO();
                y.oneDiag.Id_Diagnostico = y.Id_Diagnostico;
                y.oneDiag = DiagnosticoDAO.GetOneById(y.oneDiag);
            }
            return lDiags;
        }

        public static List<ConsultaDiagnosticoDTO> GetAllByConsulta(ConsultaDiagnosticoDTO oneConsulta)
        {
            string query = "select * from Tabla_Registro_ConsultaDiagnostico where Id_Consulta = @Id_Consulta";
            Helpers h = new Helpers();
            var lDiags = h.GetAllParametized(query, oneConsulta);
            foreach (var y in lDiags)
            {
                y.oneDiag = new Tabla_Catalogo_DiagnosticoDTO();
                y.oneDiag.Id_Diagnostico = y.Id_Diagnostico;
                y.oneDiag = DiagnosticoDAO.GetOneById(y.oneDiag);
            }
            return lDiags;
        }

        public void Insert(ConsultaDiagnosticoDTO oneConsulta)
        {
            string query =
                "insert into Tabla_Registro_ConsultaDiagnostico(Id_Consulta, Id_Diagnostico, Id_FichaIdentificacion, Fecha_ConsultaDiagnostico, Observaciones_ConsultaDiagnostico, Estatus_ConsultaDiagnostico) values(@Id_Consulta, @Id_Diagnostico, @Id_FichaIdentificacion, @Fecha_ConsultaDiagnostico, @Observaciones_ConsultaDiagnostico, @Estatus_ConsultaDiagnostico)";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneConsulta);
        }

        public void Delete(ConsultaDiagnosticoDTO oneConsulta)
        {
            string query =
                "delete Tabla_Registro_ConsultaDiagnostico where Id_ConsultaDiagnostico = @Id_ConsultaDiagnostico";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneConsulta);
        }
    }
}