using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Registro_AgendaDTO
    {
        public int Id_Agenda { get; set; }
        public DateTime Fecha_Agenda { get; set; }
        public string Asunto_Agenda { get; set; }
        public string Prioridad_Agenda { get; set; }
        public string EstadoCitas_Agenda { get; set; }
        public string Descripcion_Agenda { get; set; }
        public DateTime Inicio_Agenda { get; set; }
        public DateTime Fin_Agenda { get; set; }
        public int Id_FichaIdentificacion { get; set; }
        public int Id_Categoria { get; set; }
        public bool Estatus_Agenda { get; set; }
        public string InicioCita { get; set; }
        public string FinCita { get; set; }
        public Tabla_Catalogo_FichaIdentificacionDTO UsuarioDTO { get; set; }
    }
}