using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MedicalManagement.Models.DTO
{
    public class Tabla_Registro_ConsultaSeguimientoDTO
    {
        public int Id_ConsultaSeguimiento { get; set; }
        public DateTime Fecha_ConsultaSeguimiento { get; set; }
        public string Observaciones_ConsultaSeguimiento { get; set; }
        public bool Estatus_ConsultaSeguimiento { get; set; }

    }
}
