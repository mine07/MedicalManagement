using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class ConsultaProcedimientoDTO
    {
        public int Id_ConsultaProcedimiento { get; set; }
        public int Id_Consulta { get; set; }
        public int Id_Procedimiento { get; set; }
        public int Id_FichaIdentificacion { get; set; }
        public DateTime Fecha_ConsultaProcedimiento { get; set; }
        public string Observaciones_ConsultaProcedimiento { get; set; }
        public bool Estatus_ConsultaProcedimiento { get; set; }
        public Tabla_Catalogo_ProcedimientoDTO onePro { get; set; }
    }

    public class ConsultaProcedimientoDAO
    {
        public static List<ConsultaProcedimientoDTO> GetAllByPaciente(ConsultaProcedimientoDTO oneConsulta)
        {
            string query =
                "select * from Tabla_Registro_ConsultaProcedimiento where Id_FichaIdentificacion = @Id_FichaIdentificacion";
            Helpers h = new Helpers();
            var lPro = h.GetAllParametized(query, oneConsulta);
            foreach (var y in lPro)
            {
                y.onePro = new Tabla_Catalogo_ProcedimientoDTO();
                y.onePro.Id_Procedimiento = y.Id_Procedimiento;
                y.onePro = ProcedimientoDAO.GetOneById(y.onePro);
            }
            return lPro;
        }

        public static List<ConsultaProcedimientoDTO> GetAllByConsulta(ConsultaProcedimientoDTO oneConsulta)
        {
            string query = "select * from Tabla_Registro_ConsultaProcedimiento where Id_Consulta = @Id_Consulta";
            Helpers h = new Helpers();
            var lPros = h.GetAllParametized(query, oneConsulta);
            foreach (var y in lPros)
            {
                y.onePro = new Tabla_Catalogo_ProcedimientoDTO();
                y.onePro.Id_Procedimiento = y.Id_Procedimiento;
                y.onePro = ProcedimientoDAO.GetOneById(y.onePro);
            }
            return lPros;
        }

        public void Insert(ConsultaProcedimientoDTO oneConsulta)
        {
            string query =
                "insert into Tabla_Registro_ConsultaProcedimiento(Id_Consulta, Id_Procedimiento, Id_FichaIdentificacion, Fecha_ConsultaProcedimiento, Observaciones_ConsultaProcedimiento, Estatus_ConsultaProcedimiento) values(@Id_Consulta, @Id_Procedimiento, @Id_FichaIdentificacion, @Fecha_ConsultaProcedimiento, @Observaciones_ConsultaProcedimiento, @Estatus_ConsultaProcedimiento)";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneConsulta);
        }

        public void Delete(ConsultaProcedimientoDTO oneConsulta)
        {
            string query =
                "delete Tabla_Registro_ConsultaProcedimiento where Id_ConsultaProcedimiento = @Id_ConsultaProcedimiento";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneConsulta);
        }
    }
}