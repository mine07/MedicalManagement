using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_ConceptoPagoDTO
    {
        public int Id_ConceptoPago { get; set; }
        public string Descripcion_ConceptoPago { get; set; }
        public string NombreCorto_ConceptoPago { get; set; }
        public bool Estatus_ConceptoPago { get; set; }

    }
}