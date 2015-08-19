using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_ConsultaRecetaPreviaDTO
    {
        public int Id_ConsultaRecetaPrevia { get; set; }
        public string Nombre_ConsultaRecetaPrevia { get; set; }
        public string Medicamento_ConsultaReceta { get; set; }
        public string Dosis_ConsultaReceta { get; set; }
        public string Notas_ConsultaReceta { get; set; }
        public bool Estatus_ConsultaReceta { get; set; }
        public int Id_Diagnostico { get; set; }
        public string Descripcion_Diagnostico { get; set; }
    }
}
