using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class Modulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadModulo();
            }
        }

        private void loadModulo()
        {
            var lModulos = ModuloDAO.GetAll();
            rptModulos.DataSource = lModulos;
            rptModulos.DataBind();
        }

        protected void edit(object sender, EventArgs e)
        {
            var id = ((LinkButton) sender).CommandArgument;
            var oneModulo = ModuloDAO.GetOne(new ModuloDTO {Id_Modulo = Convert.ToInt32(id)});
            txtId.Value = oneModulo.Id_Modulo.ToString();
            txtNombreEdit.Value = oneModulo.Nombre_Modulo;
            txtDireccionEdit.Value = oneModulo.Programa_Modulo;
            divHidden.Visible = true;
        }

        protected void saveEdit(object sender, EventArgs e)
        {
            var oneModulo = new ModuloDTO();
            oneModulo.Id_Modulo = Convert.ToInt32(txtId.Value);
            oneModulo.Nombre_Modulo = txtNombreEdit.Value.Trim();
            oneModulo.Programa_Modulo = txtDireccionEdit.Value.Trim();
            ModuloDAO Update = new ModuloDAO();
            Update.Edit(oneModulo);
            loadModulo();
            
            
        }

        protected void delete(object sender, EventArgs e)
        {
            var id = ((LinkButton)sender).CommandArgument;
            ModuloDAO Delete = new ModuloDAO();
            Delete.Delete(new ModuloDTO {Id_Modulo = Convert.ToInt32(id)});
            loadModulo();
        }

        protected void Create(object sender, EventArgs e)
        {
            var oneModulo = new ModuloDTO();
            oneModulo.Nombre_Modulo = txtNombre.Value.Trim();
            oneModulo.Programa_Modulo = txtDireccion.Value.Trim();
            oneModulo.Estatus_Modulo = true;
            ModuloDAO Insert = new ModuloDAO();
            Insert.Insert(oneModulo);
            loadModulo();
            txtNombre.Value = "";
            txtDireccion.Value = "";
        }
    }
}