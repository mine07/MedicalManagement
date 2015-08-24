using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Registro_ConsultaConceptoPagoDTO
    {
        public int Id_ConsultaConceptoPago { get; set; }
        public int Id_ConceptoPago { get; set; }
        public int Cantidad_ConsultaConceptoPago { get; set; }
        public decimal Precio_ConsultaConceptoPago { get; set; }
        public bool Estatus_ConsultaConceptoPago { get; set; }
        public Tabla_Catalogo_ConceptoPagoDTO oneConcepto { get; set; }
    }
}