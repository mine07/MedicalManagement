using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class PermisosDTO
    {
        public int Id_Permiso { get; set; }
        public int Id_Perfil { get; set; }
        public int Id_Modulo { get; set; }
        public bool Estatus_Permiso { get; set; }
        public ModuloDTO oneModulo { get; set; }
    }

    public class PermisosDAO
    {
        public static List<PermisosDTO> GetAll()
        {
            string query = "select * from Tabla_Registro_Permisos_Perfil";
            Helpers h = new Helpers();
            var lPermisos = h.GetAllParametized(query, new PermisosDTO());
            var lModulos = ModuloDAO.GetAll();
            foreach (var y in lPermisos)
            {
                y.oneModulo = lModulos.Single(x => x.Id_Modulo == y.Id_Modulo);
            }
            return lPermisos;
        }

        public static List<PermisosDTO> GetAllByPerfil(PerfilDTO onePerfil)
        {
            var lPermisos = GetAll();
            lPermisos = lPermisos.Where(x => x.Id_Perfil == onePerfil.Id_Perfil).ToList();
            return lPermisos;
        }

        public PermisosDTO onePerfil(PermisosDTO onePerfil)
        {
            var lPerfiles = GetAll();
            onePerfil = lPerfiles.Single(x => x.Id_Permiso == onePerfil.Id_Permiso);
            return onePerfil;
        }

        public void Update(PermisosDTO onePermiso)
        {
            string query = "update Tabla_Registro_Permisos_Perfil set Estatus_Permiso = @Estatus_Permiso where Id_Permiso = @Id_Permiso";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, onePermiso);
        }

        public void Insert(PermisosDTO onePermiso)
        {
            string query = "insert into Tabla_Registro_Permisos_Perfil (Id_Perfil, Id_Modulo, Estatus_Permiso) values (@Id_Perfil, @Id_Modulo, 1)";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, onePermiso);
        }
    }
}