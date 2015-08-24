using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Registro_PagosDTO
    {
        public int Id_Pagos { get; set; }
        public int Id_FichaIdentificacion { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Consulta { get; set; }
        public int Id_FormaPago { get; set; }
        public DateTime FechaAlta_Pagos { get; set; }
        public string Descripcion_Pagos { get; set; }
        public string Origen_Pagos { get; set; }
        public decimal Importe_Pagos { get; set; }
        public decimal Pagado_Pagos { get; set; }
        public decimal Debe_Pagos { get; set; }
        public DateTime FechaParaPagar_Pagos { get; set; }
        public DateTime FechaPagado_Pagos { get; set; }
        public Tabla_Catalogo_FichaIdentificacionDTO oneUsuario { get; set; }
        public List<Tabla_Registro_ConsultaConceptoPagoDTO> lConceptos { get; set; }
    }
}