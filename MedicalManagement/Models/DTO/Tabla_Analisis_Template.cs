using System;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Analsis_TemplateDTO
    {
        public int Id_Receta_Template { get; set; }
        public int Id_Template { get; set; }
        public string Tem_Nombre { get; set; }
        public Tabla_Catalogo_MedicamentoDTO oneMedicamento { get; set; }
        public string Tem_Medicamento { get; set; }
    }
}