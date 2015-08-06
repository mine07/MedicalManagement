using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Catalogo_FichaIdentificacionDTO
    {
        public int Id_FichaIdentificacion { get; set; }
        public string Cve_FichaIdentificacion { get; set; }
        public DateTime Fecha_FichaIdentificacion { get; set; }
        public string Nombre_FichaIdentificacion { get; set; }
        public string ApPaterno_FichaIdentificacion { get; set; }
        public string ApMaterno_FichaIdentificacion { get; set; }
        public string LugarNacimiento_FichaIdentificacion { get; set; }
        public DateTime FechaNacimiento_FichaIdentificacion { get; set; }
        public DateTime FechaPrimeraVisita_FichaIdentificacion { get; set; }
        public string Direccion_Calle_FichaIdentificacion { get; set; }
        public string Direccion_NoInt_FichaIdentificacion { get; set; }
        public string Direccion_NoExt_FichaIdentificacion { get; set; }
        public string Direccion_Colonia_FichaIdentificacion { get; set; }
        public string Direccion_Municipio_FichaIdentificacion { get; set; }
        public string Direccion_Pais_FichaIdentificacion { get; set; }
        public string Direccion_CP_FichaIdentificacion { get; set; }
        public string TelefonoCasa_FichaIdentificacion { get; set; }
        public string TelefonoOfinica_FichaIdentificacion { get; set; }
        public string TelefonoMovil_FichaIdentificacion { get; set; }
        public string CorreoElectronico_FichaIdentificacion { get; set; }
        public string CasoEmergencia_FichaIdentificacion { get; set; }
        public string Foto_FichaIdentificacion { get; set; }
        public int Id_Empresa { get; set; }
        public int Id_Sucursal { get; set; }
        public int Id_Sexo { get; set; }
        public int Id_EdoCivil { get; set; }
        public int Id_Ocupacion { get; set; }
        public int Id_Escolaridad { get; set; }
        public int Id_EmpresaConvenio { get; set; }
        public int Id_ReferidoPor { get; set; }
        public int Id_Aseguradora { get; set; }
        public bool Estatus_FichaIdentificacion { get; set; }
    }
}