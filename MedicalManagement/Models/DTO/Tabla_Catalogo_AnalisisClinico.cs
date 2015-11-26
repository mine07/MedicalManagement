using System;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_AnalisisClinicoDTO
    {
        public int Id_AnalisisClinico { get; set; }
        public string Descripcion_AnalisisClinico { get; set; }
        public bool Estatus_AnalisisClinico { get; set; }

    }
}