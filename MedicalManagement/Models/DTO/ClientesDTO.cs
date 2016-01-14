using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class ClientesDTO 
    {
        public int Id_Clientes { get; set; }
	    public string Nombre { get; set; }
        public string RFC { get; set; }
        public string DomicilioFiscal_Calle { get; set; }
        public string DomicilioFiscal_NoEx { get; set; }
        public string DomicilioFiscal_Colonia { get; set; }
        public string DomicilioFiscal_Municipio { get; set; }
        public string DomicilioFiscal_Estado { get; set; }
        public string DomicilioFiscal_Pais { get; set; } 
        public int DomicilioFiscal_CP { get; set; }
        public DateTime Fecha { get; set; }
       public string Telefono { get; set; }
       public string CorreoElectronico { get; set; }

       public string _NombreCompleto { get; set; }
    }

    public class ClientesDAO
    {
        public static List<ClientesDTO> GetAll()
        {
            Helpers h = new Helpers();
            string query = "select * from Tabla_Catalogo_FichaIdentificacion";
            var lFichas = h.GetAllParametized(query, new ClientesDTO());
            foreach (var y in lFichas)
            {
                y._NombreCompleto = y.Nombre.Trim();
            }
            return lFichas;
        }

        public static ClientesDTO GetOne(ClientesDTO oneFicha)
        {
            Helpers h = new Helpers();
            string query = "select * from Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
            var lFichas = h.GetAllParametized(query, oneFicha);
            foreach (var y in lFichas)
            {
                y._NombreCompleto = y.Nombre.Trim();
            }
            return lFichas[0];
        }

        public static ClientesDTO GetLast()
        {
            Helpers h = new Helpers();
            string query = "select * from Tabla_Catalogo_FichaIdentificacion";
            var lFichas = h.GetAllParametized(query, new ClientesDTO());
            return lFichas.Last();
        }
    }
}