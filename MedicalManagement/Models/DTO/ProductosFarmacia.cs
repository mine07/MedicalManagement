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
    public class ProductosFarmacia
    {
       

      public int Id_Productos {get; set;}
      public string Nombre {get; set;}
      public string Descripcion {get; set;}
      public decimal PrecioCompra {get; set;}
      public int Existencias {get; set;}
      public decimal PrecioVenta {get; set;}
      public int Minimo {get; set;}
      public bool Activo { get; set; }
    }

    public class MedicamentoFarmaciaDAO
    {
        public static List<ProductosFarmacia> GetAll()
        {
            string query = "Select * from Tabla_Catalogo_ProductosFarmacia";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, new ProductosFarmacia());
        }
        public static ProductosFarmacia GetOneByName(ProductosFarmacia oneMedicamento)
        {

            string query = "Select * from Tabla_Catalogo_ProductosFarmacia where Descripcion = @Descripcion";
                Helpers h = new Helpers();
                return h.GetAllParametized(query, oneMedicamento)[0];
        
        }

        public static ProductosFarmacia GetOneById(ProductosFarmacia oneMedicamento)
        {
            string query = "Select * from Tabla_Catalogo_ProductosFarmacia where Id_Productos = @Id_Productos";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneMedicamento)[0];
        }

       
    }
}
