using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_ConceptoPagoDTO
    {
        public int    Id_ConceptoPago          { get; set; }
        public string Descripcion_ConceptoPago { get; set; }
        public string NombreCorto_ConceptoPago { get; set; }
        public bool   Estatus_ConceptoPago     { get; set; }
        public string PrecioUnitario { get; set; }
        public string _NombreConsulta { get; set; }
    }
    public class ConseptoPagoDAO
    {
        public static List<Tabla_Catalogo_ConceptoPagoDTO> GetAll()
        {
            Helpers h = new Helpers();
            string query = "select * from Tabla_Catalogo_ConceptoPago";
            var lFichas = h.GetAllParametized(query, new Tabla_Catalogo_ConceptoPagoDTO());
            foreach (var y in lFichas)
            {
                y._NombreConsulta = y.Descripcion_ConceptoPago.Trim() + "";
            }
            return lFichas;
        }

        public static Tabla_Catalogo_ConceptoPagoDTO GetOne(Tabla_Catalogo_ConceptoPagoDTO oneFicha)
        {
            Helpers h = new Helpers();
            string query = "select * from Tabla_Catalogo_ConceptoPago where Id_ConceptoPago = @Id_ConceptoPago";
            var lFichas = h.GetAllParametized(query, oneFicha);
            foreach (var y in lFichas)
            {
                y._NombreConsulta = y.Descripcion_ConceptoPago.Trim() + "";
            }
            return lFichas[0];
        }

        public static Tabla_Catalogo_ConceptoPagoDTO GetLast()
        {
            Helpers h = new Helpers();
            string query = "select * from Tabla_Catalogo_ConceptoPago";
            var lFichas = h.GetAllParametized(query, new Tabla_Catalogo_ConceptoPagoDTO());
            return lFichas.Last();
        }
    }
}