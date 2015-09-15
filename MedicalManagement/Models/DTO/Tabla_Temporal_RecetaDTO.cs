using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Temporal_RecetaDTO
    {
        public int Id_Temporal_Receta { get; set; }
        public int Id_FichaIdentificacion { get; set; }
        public int Id_Medicamento { get; set; }
        public string Tem_Dosis { get; set; }
        public string Tem_Notas { get; set; }
        public int Id_Consulta { get; set; }
        public string Tem_Medicamento { get; set; }
    }
}