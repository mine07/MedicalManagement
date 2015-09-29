using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class NotaClinicaDTO
    {
        public int Id_Agenda { get; set; }
        public int Id_Consulta { get; set; }
        public int Id_FichaIdentificacion { get; set; }
        public DateTime Fecha_Consulta { get; set; }
        public string Subjetivo_Consulta { get; set; }
        public string OBjetivo_Consulta { get; set; }
        public string Analisis_Consulta { get; set; }
        public string Plan_consulta { get; set; }
        public bool Estatus_Consulta { get; set; }
        public string Observaciones_ConsultaDiagnostico { get; set; }
        public List<ConsultaDiagnosticoDTO> lDiagnosticos { get; set; }
        public List<Tabla_Temporal_RecetaDTO> lRecetas { get; set; }
    }

    public class NotaClinicaDAO
    {
        public static NotaClinicaDTO GetOneByAgenda(NotaClinicaDTO oneNota)
        {
            Helpers h = new Helpers();
            string query = "select * from Tabla_Registro_Consulta where Id_Agenda = @Id_Agenda";
            oneNota = h.GetAllParametized(query, oneNota)[0];
            oneNota.lDiagnosticos = ConsultaDiagnosticoDAO.GetAllByConsulta(new ConsultaDiagnosticoDTO {Id_Consulta = oneNota.Id_Consulta});
            return oneNota;
        }

        public static List<NotaClinicaDTO> GetAllByFicha(NotaClinicaDTO oneNota)
        {
            Helpers h = new Helpers();
            string query = "select * from Tabla_Registro_Consulta where Id_FichaIdentificacion = @Id_FichaIdentificacion";
            var lNotas = h.GetAllParametized(query, oneNota);
            foreach (var y in lNotas)
            {
                y.lRecetas = loadRecetas(y);
            }
            return lNotas;
        }

        public static List<NotaClinicaDTO> GetOneByConsulta(NotaClinicaDTO oneNota)
        {
            Helpers h = new Helpers();
            string query = "select * from Tabla_Registro_Consulta where Id_Agenda = @Id_Agenda and Id_Consulta = @Id_Agenda";
            var lNotas = h.GetAllParametized(query, oneNota);
            foreach (var y in lNotas)
            {
                y.lRecetas = loadRecetas(y);
            }
            return lNotas;
        }

        public void Update(NotaClinicaDTO oneNota)
        {
            string query =
                "update Tabla_Registro_Consulta set Subjetivo_Consulta = @Subjetivo_Consulta, Objetivo_Consulta = @Objetivo_Consulta, Analisis_Consulta = @Analisis_Consulta, Plan_Consulta = @Plan_Consulta where ID_Consulta = @Id_Consulta and Id_FichaIdentificacion = @Id_FichaIdentificacion";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneNota);
        }

        public void Insert(NotaClinicaDTO oneNota)
        {
            string query = "Insert Into Tabla_Registro_Consulta (Id_Agenda, Id_FichaIdentificacion, Fecha_Consulta) values(@Id_Agenda, @Id_FichaIdentificacion, @Fecha_Consulta)";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneNota);
        }

        public static List<Tabla_Temporal_RecetaDTO> loadRecetas(NotaClinicaDTO oneNota)
        {
            string query = @"select a.*, b.Descripcion_Medicamento as Tem_Medicamento from tabla_temporal_receta a
                            left join Tabla_Catalogo_Medicamento b on b.Id_Medicamento = a.Id_Medicamento where a.Id_FichaIdentificacion = @Id_FichaIdentificacion and a.Id_Consulta = @Id_Consulta";
            var oneTemp = new Tabla_Temporal_RecetaDTO();
            oneTemp.Id_Consulta = oneNota.Id_Consulta;
            oneTemp.Id_FichaIdentificacion = oneNota.Id_FichaIdentificacion;
            Helpers h = new Helpers();
            return  h.GetAllParametized(query, oneTemp);
        }
    }
}