using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class PaquetesDTO
    {
        public int Id_AnalisisClinicoPaquetes { get; set; }
        public string Descripcion_AnalisisClinicoPaquetes { get; set; }
        public bool Estatus_AnalisisClinicoPaquetes { get; set; }
        public List<AnalisisEnPaquetesDTO> lAnalisis { get; set; }
    }

    public class PaquetesDAO
    {
        public static List<PaquetesDTO> GetAll(string queryIf, PaquetesDTO onePaquete)
        {
            string query = "select * from Tabla_Catalogo_AnalisisClinicoPaquetes " + queryIf;
            Helpers h = new Helpers();
            var lPaquetes = h.GetAllParametized(query, onePaquete);
            foreach (var y in lPaquetes)
            {
                string innerQuery = " where Id_AnalisisClinicoPaquetes = @Id_AnalisisClinicoPaquetes";
                y.Descripcion_AnalisisClinicoPaquetes = y.Descripcion_AnalisisClinicoPaquetes.Trim();
                AnalisisEnPaquetesDTO oneAnaPaquete = new AnalisisEnPaquetesDTO();
                oneAnaPaquete.Id_AnalisisClinicoPaquetes = y.Id_AnalisisClinicoPaquetes;
                y.lAnalisis = AnalisisEnPaquetesDAO.GetAll(innerQuery, oneAnaPaquete);
            }
            return lPaquetes;
        }

        public void Insert(string queryIf, PaquetesDTO onePaquete)
        {
            string query = "insert into  Tabla_Catalogo_AnalisisClinicoPaquetes (Descripcion_AnalisisClinicoPaquetes, Estatus_AnalisisClinicoPaquetes) values (@Descripcion_AnalisisClinicoPaquetes, @Estatus_AnalisisClinicoPaquetes)";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, onePaquete);
        }

        public void Delete(string queryIf, PaquetesDTO onePaquete)
        {
            string query = "delete Tabla_Catalogo_AnalisisClinicoPaquetes where Id_AnalisisClinicoPaquetes = @Id_AnalisisClinicoPaquetes";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, onePaquete);
            AnalisisEnPaquetesDAO Delete = new AnalisisEnPaquetesDAO();
            AnalisisEnPaquetesDTO oneAnaPaquete = new AnalisisEnPaquetesDTO();
            oneAnaPaquete.Id_AnalisisClinicoPaquetes = onePaquete.Id_AnalisisClinicoPaquetes;
            Delete.deleteFromPaquet("", oneAnaPaquete);
        }
    }
}