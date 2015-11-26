using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Registro_AnalisisClinicoPaquetesDTO 
    {
        public int Id_AnalisisClinicoPaquetesdatos { get; set; }
        public int Id_AnalisisClinicoPaquetes { get; set; }
        public int Id_AnalisisClinico { get; set; }
        public bool Estatus_AnalisisClinicoPaquetes { get; set; }
        public Tabla_Catalogo_AnalisisClinicoDTO oneMedicamento { get; set; }
        public string Tem_Medicamento { get; set; }
    }
}