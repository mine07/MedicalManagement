using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class ModuloDTO
    {
        public int Id_Modulo { get; set; }
        public string Nombre_Modulo { get; set; }
        public string Programa_Modulo { get; set; }
        public bool Estatus_Modulo { get; set; }
    }

    public class ModuloDAO
    {
        public static List<ModuloDTO> GetAll()
        {
            string query = "select * from Tabla_Catalogo_Modulo where Estatus_Modulo = 1";
            Helpers h = new Helpers();
            var lModulos = h.GetAllParametized(query, new ModuloDTO());
            return lModulos;
        }

        public static ModuloDTO GetOne(ModuloDTO oneModulo)
        {
            Helpers h = new Helpers();
            var lModulos = GetAll();
            oneModulo = lModulos.Single(x => x.Id_Modulo == oneModulo.Id_Modulo);
            return oneModulo;
        }

        public static ModuloDTO GetOneByName(ModuloDTO oneModulo)
        {
            Helpers h = new Helpers();
            var lModulos = GetAll();
            oneModulo = lModulos.Single(x => x.Nombre_Modulo == oneModulo.Nombre_Modulo && x.Programa_Modulo == oneModulo.Programa_Modulo);
            return oneModulo;
        }
        public void Edit(ModuloDTO oneModulo)
        {
            string query = "Update Tabla_Catalogo_Modulo set Nombre_Modulo = @Nombre_Modulo, Programa_Modulo = @Programa_Modulo where Id_Modulo = @Id_Modulo";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneModulo);
        }

        public void Insert(ModuloDTO oneModulo)
        {
            string query = "Insert into Tabla_Catalogo_Modulo (Nombre_Modulo, Programa_Modulo, Estatus_Modulo) values(@Nombre_Modulo, @Programa_Modulo, @Estatus_Modulo) ";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneModulo);
            var lastModule = GetOneByName(oneModulo);
            var lPerfiles = PerfilDAO.GetAll();
            PermisosDAO insert = new PermisosDAO();
            foreach (var y in lPerfiles)
            {
                PermisosDTO onePermiso = new PermisosDTO();
                onePermiso.Id_Modulo = lastModule.Id_Modulo;
                onePermiso.Id_Perfil = y.Id_Perfil;
                insert.Insert(onePermiso);
            }
        }

        public void Delete(ModuloDTO oneModulo)
        {
            string query = "Delete Tabla_Catalogo_Modulo where Id_Modulo = @Id_Modulo";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneModulo);
            string queryB = "delete Tabla_Registro_Permisos_Perfil where Id_Modulo = @Id_Modulo";
            h.ExecuteNonQueryParam(queryB, oneModulo);
        }
    }
}