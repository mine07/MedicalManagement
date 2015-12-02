using System;
using System.Web;

using System.Collections.Generic;
using System.Linq;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_AnalisisClinicoDTO
    {
        public int Id_AnalisisClinico { get; set; }
        public string Descripcion_AnalisisClinico { get; set; }
        public bool Estatus_AnalisisClinico { get; set; }

    }

    public class AnalisisClinicosDAO
    {
        public static List<Tabla_Catalogo_AnalisisClinicoDTO> GetAll()
        {
            string query = "Select * from Tabla_Catalogo_AnalisisClinico";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, new Tabla_Catalogo_AnalisisClinicoDTO());
        }
        public static Tabla_Catalogo_AnalisisClinicoDTO GetOneByName(Tabla_Catalogo_AnalisisClinicoDTO oneAnalisisClinico)
        {
            
                string query = "Select * from Tabla_Catalogo_AnalisisClinico where Descripcion_AnalisisClinico = @Descripcion_AnalisisClinico";
                Helpers h = new Helpers();
                return h.GetAllParametized(query, oneAnalisisClinico)[0];
           
            
        }

        public static Tabla_Catalogo_AnalisisClinicoDTO GetOneById(Tabla_Catalogo_AnalisisClinicoDTO oneAnalisisClinico)
        {
            string query = "Select * from Tabla_Catalogo_AnalisisClinico where Id_AnalisisClinico = @Id_AnalisisClinico";
            Helpers h = new Helpers();
            return h.GetAllParametized(query, oneAnalisisClinico)[0];
        }
    }
}