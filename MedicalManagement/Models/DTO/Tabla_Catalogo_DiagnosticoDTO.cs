using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_DiagnosticoDTO
    {
        public int Id_Diagnostico { get; set; }
        public string Descripcion_Diagnostico { get; set; }
        public bool Estatus_diagnostico { get; set; }
    }
}