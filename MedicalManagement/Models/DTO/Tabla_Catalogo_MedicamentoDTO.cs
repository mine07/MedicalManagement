using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_MedicamentoDTO
    {
        public int Id_Medicamento { get; set; }
        public string Descripcion_Medicamento { get; set; }
        public bool Estatus_Medicamento { get; set; }
    }
}