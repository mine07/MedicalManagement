using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Receta_TemplateDTO
    {
        public int Id_Receta_Template {get;set;}
        public int Id_Template {get;set;}
        public int Id_Medicamento {get;set;}
        public int Id_Diagnostico { get; set; }
        public string Tem_Nombre { get; set; }
        public string Tem_Dosis {get;set;}
        public string Tem_Notas {get;set;} 
        public Tabla_Catalogo_MedicamentoDTO oneMedicamento {get;set;}
        public string Tem_Medicamento { get; set; }
    }
}