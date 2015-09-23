using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class PerfilDTO
    {
        public int Id_Perfil { get; set; }
        public string Descripcion_Perfil { get; set; }
        public bool Estatus_Perfil { get; set; }
        public List<PermisosDTO> lPermisos { get; set; }
    }

    public class PerfilDAO
    {
        public static List<PerfilDTO> GetAll()
        {
            string query = "select * from Tabla_Catalogo_Perfil";
            Helpers h = new Helpers();
            var lPerfiles = h.GetAllParametized(query, new PerfilDTO());
            foreach (var y in lPerfiles)
            {
                y.lPermisos = PermisosDAO.GetAllByPerfil(y);
            }
            return lPerfiles;
        }

        public PerfilDTO onePerfil(PerfilDTO onePerfil)
        {
            var lPerfiles = GetAll();
            onePerfil = lPerfiles.Single(x => x.Id_Perfil == onePerfil.Id_Perfil);
            return onePerfil;
        }

        public void Create(PerfilDTO onePerfil)
        {
            string query = "insert into Tabla_Catalogo_Perfil (Descripcion_Perfil, Estatus_Perfil)values(@Descripcion_Perfil, @Estatus_Perfil)";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, onePerfil);
            var lastPerfil = GetLast();
            var lModulos = ModuloDAO.GetAll();
            PermisosDAO insert = new PermisosDAO();
            foreach (var y in lModulos)
            {
                PermisosDTO onePermiso = new PermisosDTO();
                onePermiso.Id_Modulo = y.Id_Modulo;
                onePermiso.Id_Perfil = lastPerfil.Id_Perfil;
                insert.Insert(onePermiso);
            }
        }

        public static PerfilDTO GetLast()
        {
            Helpers h = new Helpers();
            var lPerfiles = GetAll();
            var onePerfil = lPerfiles.Last();
            return onePerfil;
        }

        public void Delete(PerfilDTO onePerfil)
        {
            string query = "Delete Tabla_Catalogo_Perfil where Id_Perfil = @Id_Perfil";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, onePerfil);
            string queryB = "delete Tabla_Registro_Permisos_Perfil where Id_Perfil = @Id_Perfil";
            h.ExecuteNonQueryParam(queryB, onePerfil);
        }
    }
}