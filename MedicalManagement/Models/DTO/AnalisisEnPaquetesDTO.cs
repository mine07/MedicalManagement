﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class AnalisisEnPaquetesDTO
    {
        public int Id_AnalisisClinicoPaquetesdatos { get; set; }
        public int Id_AnalisisClinicoPaquetes { get; set; }
        public int Id_AnalisisClinico { get; set; }
        public bool Estatus_AnalisisClinicoPaquetes { get; set; }
        public AnalisisClinicoDTO oneAnalisis { get; set; }
    }

    public class AnalisisEnPaquetesDAO
    {
        public static List<AnalisisEnPaquetesDTO> GetAll(string queryIf, AnalisisEnPaquetesDTO oneAnaPaquete)
        {
            string query = "select * from Tabla_Registro_AnalisisClinicoPaquetes a left join Tabla_Catalogo_AnalisisClinico b on b.Id_AnalisisClinico = a.Id_AnalisisClinico " + queryIf;
            Helpers h = new Helpers();
            var lAnalisisEnPaquetes = h.GetAllParametized(query, oneAnaPaquete);
            foreach (var y in lAnalisisEnPaquetes)
            {
                string innerQuery = " where Id_AnalisisClinico = @Id_AnalisisClinico";
                y.oneAnalisis = AnalisisClinicoDAO.GetAll(innerQuery, new AnalisisClinicoDTO {Id_AnalisisClinico = y.Id_AnalisisClinico})[0];
            }
            return lAnalisisEnPaquetes;
        }
    }
}