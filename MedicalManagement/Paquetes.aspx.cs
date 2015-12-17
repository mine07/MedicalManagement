using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class Paquetes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadPaquetes();
                loadItems();
            }
        }

        private void loadItems()
        {
            try
            {
            string queryIf = "where Id_AnalisisClinicoPaquetes = @Id_AnalisisClinicoPaquetes";
            rptItems.DataSource = AnalisisEnPaquetesDAO.GetAll(queryIf, new AnalisisEnPaquetesDTO { Id_AnalisisClinicoPaquetes = Convert.ToInt32(ddlPaquetes.SelectedItem.Value) });
            rptItems.DataBind();
            lblPaqueteNombre.InnerText = ddlPaquetes.SelectedItem.Text;
                
            }
            catch 
            {
            }
        }

        private void loadPaquetes()
        {
            ddlAnalisis.DataSource = AnalisisClinicoDAO.GetAll("", new AnalisisClinicoDTO());
            ddlAnalisis.DataBind();
            ddlPaquetes.DataSource = PaquetesDAO.GetAll("", new PaquetesDTO());
            ddlPaquetes.DataBind();
        }

        protected void ddlChanged(object sender, EventArgs e)
        {
            loadItems();
        }

        protected void insertPacket(object sender, EventArgs e)
        {
            PaquetesDTO onePaquete = new PaquetesDTO();
            onePaquete.Descripcion_AnalisisClinicoPaquetes = txtNombre.Value;
            onePaquete.Estatus_AnalisisClinicoPaquetes = true;
            PaquetesDAO Paquete = new PaquetesDAO();
            Paquete.Insert("", onePaquete);
            loadPaquetes();
            limpiar();
            ddlPaquetes.SelectedIndex = ddlPaquetes.Items.Count - 1;
            loadItems();
        }

        public void limpiar()
        {
            txtNombre.Value = "";
            ddlAnalisis.SelectedIndex = 0;
            ddlPaquetes.SelectedIndex = 0;
        }

        protected void addAnalisis(object sender, EventArgs e)
        {
            AnalisisEnPaquetesDTO oneAnaPaquete = new AnalisisEnPaquetesDTO();
            oneAnaPaquete.Id_AnalisisClinicoPaquetes = Convert.ToInt32(ddlPaquetes.SelectedItem.Value);
            oneAnaPaquete.Id_AnalisisClinico = Convert.ToInt32(ddlAnalisis.SelectedItem.Value);
            AnalisisEnPaquetesDAO Insert = new AnalisisEnPaquetesDAO();
            Insert.Insert("", oneAnaPaquete);
            loadItems();
        }

        protected void deleteItem(object sender, EventArgs e)
        {
            var Id_AnalisisClinicoPaquetesdatos = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            var oneAnaPaquete = new AnalisisEnPaquetesDTO();
            oneAnaPaquete.Id_AnalisisClinicoPaquetesdatos = Id_AnalisisClinicoPaquetesdatos;
            AnalisisEnPaquetesDAO Delete = new AnalisisEnPaquetesDAO();
            Delete.delete("", oneAnaPaquete);
            loadItems();
        }

        protected void deletePacket(object sender, EventArgs e)
        {
            var Id_Paquete = ddlPaquetes.SelectedItem.Value;
            PaquetesDTO onePaquet = new PaquetesDTO();
            onePaquet.Id_AnalisisClinicoPaquetes = Convert.ToInt32(Id_Paquete);
            PaquetesDAO Delete = new PaquetesDAO();
            Delete.Delete("", onePaquet);
            loadPaquetes();
            loadItems();
            limpiar();
        }
    }
}