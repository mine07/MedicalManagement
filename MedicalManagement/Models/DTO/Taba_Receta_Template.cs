using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Taba_Receta_Template
    {
        public int Id_Receta_Template {get;set;}
        public int Id_Template {get;set;}
        public int Id_Medicamento {get;set;}
        public string Tem_Dosis {get;set;}
        public string Tem_Notas {get;set;}
        public Tabla_Catalogo_MedicamentoDTO oneMedicamento {get;set;}
    }
}