using System;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_Ticket 
    {
        public int Id_Ticket { get; set; }
        public int Id_Medicamento { get; set; }
        public decimal Costo { get; set; }
        public string NombreMedicamento { get; set; }
        public string RazonSocial { get; set; }
    }
}