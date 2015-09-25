using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicalManagement.Models.DTO;

namespace MedicalManagement.Models
{
    public class VerificarPermiso
    {
        public void HasPermision()
        {
            var onePerfil = (PerfilDTO) System.Web.HttpContext.Current.Session["Perfil"];
            var link = "";
            var lPermisos = onePerfil.lPermisos;
            var onePermiso = lPermisos.Single(x => x.oneModulo.Programa_Modulo == link);
            if (!onePermiso.Estatus_Permiso)
            {
                HttpContext.Current.Response.Redirect("MenuInicial.aspx?Forbidden", true);
            }
        }
    }
}