using System;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Analsis_TemplateDTO
    {
        public int Id_AnalisisClinicoPaquetesdatos { get; set; }
        public int Id_AnalisisClinicoPaquetes { get; set; }
        public int Id_AnalisisClinico { get; set; }
        public bool Estatus_AnalisisClinicoPaquetes { get; set; }
        public Tabla_Catalogo_AnalisisClinicoDTO oneAnalisisClinico { get; set; }
        public string Tem_Medicamento { get; set; }
    }
} 