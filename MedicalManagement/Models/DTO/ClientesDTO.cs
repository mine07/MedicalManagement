using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        public string DomicilioFiscal_CP { get; set; }
        public DateTime Fecha { get; set; }
       public string Telefono { get; set; }
       public string CorreoElectronico { get; set; }
       public bool Activo { get; set; }
       public string _NombreCompleto { get; set; }
    }

    public class ClientesDAO
    {
        //public static List<ClientesDTO> GetAll()
        //{
        //    Helpers h = new Helpers();
        //    string query = "select * from Table_Catalogo_Clientes";
        //    var lFichas = h.GetAllParametized(query, new ClientesDTO());
        //    foreach (var y in lFichas)
        //    {
        //        y._NombreCompleto = y.Nombre.Trim();
        //    }
        //    return lFichas;
        //}

        //public static ClientesDTO GetOne(ClientesDTO oneFicha)
        //{
        //    Helpers h = new Helpers();
        //    string query = "select * from Table_Catalogo_Clientes where Id_Clientes = @Id_Clientes  ";
        //    var lFichas = h.GetAllParametized(query, oneFicha);
        //    foreach (var y in lFichas)
        //    {
        //        y._NombreCompleto = y.Nombre.Trim();
        //    }
        //    return lFichas[0];
        //}

        //public static ClientesDTO GetLast()
        //{
        //    Helpers h = new Helpers();
        //    string query = "select * from Table_Catalogo_Clientes";
        //    var lFichas = h.GetAllParametized(query, new ClientesDTO());
        //    return lFichas.Last();
        //}

        public static List<ClientesDTO> GetAll()
        {
            string query = "Select * from Table_Catalogo_Clientes ";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, new ClientesDTO());
        }
        public static ClientesDTO  GetOneByName(ClientesDTO  oneMedicamento)
        {

            string query = "Select * from Table_Catalogo_Clientes  where Nombre = @Nombre";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneMedicamento)[0];

        }

        public static ClientesDTO  GetOneById(ClientesDTO  oneMedicamento)
        {
            string query = "Select * from Table_Catalogo_Clientes  where Id_Cliente = @Id_Cliente";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneMedicamento)[0];
        }
    }
}