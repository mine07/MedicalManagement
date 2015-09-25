using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class PermisosPorPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load();
            }
        }

        private void load()
        {
            var lPerfiles = PerfilDAO.GetAll();
            ddlPerfil.DataSource = lPerfiles;
            ddlPerfil.DataBind();
            loadPermisos(new object(), new EventArgs());
        }

        protected void loadPermisos(object sender, EventArgs e)
        {
            PerfilDAO GetOne = new PerfilDAO();
            var onePerfil = new PerfilDTO();
            onePerfil.Id_Perfil = Convert.ToInt32(ddlPerfil.SelectedItem.Value);
            onePerfil = GetOne.onePerfil(onePerfil);
            spanNombre.InnerText = onePerfil.Descripcion_Perfil;
            var lPermisos = onePerfil.lPermisos;
            rptPermiso.DataSource = lPermisos;
            rptPermiso.DataBind();
        }

        public string hasPermision(bool has)
        {
            if (has)
            {
                return "hidden";
            }
            return "";
        }

        protected void OnClick(object sender, EventArgs e)
        {
            var Id = ((LinkButton) sender).CommandArgument;
            PermisosDAO Update = new PermisosDAO();
            Update.Update(new PermisosDTO {Id_Permiso = Convert.ToInt32(Id)});
            loadPermisos(sender, e);
        }

        protected void OnClickGreen(object sender, EventArgs e)
        {
            var Id = ((LinkButton)sender).CommandArgument;
            PermisosDAO Update = new PermisosDAO();
            Update.Update(new PermisosDTO { Id_Permiso = Convert.ToInt32(Id), Estatus_Permiso = true });
            loadPermisos(sender, e);
        }
    }
}