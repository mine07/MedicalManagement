using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalManagement.Models.DTO;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Registro_ConsultaDTO
    {
        public int Id_Consulta { get; set; }
        public int Id_Agenda { get; set; }
        public int Id_FichaIdentificacion { get; set; }
        public DateTime Fecha_Consulta { get; set; }
        public string Subjetivo_Consulta { get; set; }
        public string Objetivo_Consulta { get; set; }
        public string Diagnostico_Consulta { get; set; }
        public string Analisis_Consulta { get; set; }
        public string Plan_Consulta { get; set; }
        public bool Estatus_Consulta { get; set; }
        public Tabla_Catalogo_FichaIdentificacionDTO UsuarioDTO { get; set; }
        public Tabla_Registro_AgendaDTO AgendaDTO { get; set; }
    }
}