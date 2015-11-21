using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
	public partial class AnalisisConsulta1 : System.Web.UI.Page
	{
        public int Id_Agenda = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Agenda"]);
        public int Id_FichaIdentificacion = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Paciente"]);
        public string NombreCompleto = Convert.ToString(System.Web.HttpContext.Current.Request.QueryString["NombreCompleto"]);
        public int Id_Consulta = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["IdConsulta"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNombre.Text = NombreCompleto;
                loadPaquetes();
                loadItems();
            }
        }

        private void loadItems()
        {
            string queryIf = "where Id_AnalisisClinicoPaquetes = @Id_AnalisisClinicoPaquetes";
            rptItems.DataSource = AnalisisEnPaquetesDAO.GetAll(queryIf, new AnalisisEnPaquetesDTO { Id_AnalisisClinicoPaquetes = Convert.ToInt32(ddlPaquetes.SelectedItem.Value) });
            rptItems.DataBind();
            lblPaqueteNombre.InnerText = ddlPaquetes.SelectedItem.Text;
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

        /*protected void addAnalisis(object sender, EventArgs e)
        {
            AnalisisEnPaquetesDTO oneAnaPaquete = new AnalisisEnPaquetesDTO();
            oneAnaPaquete.Id_AnalisisClinicoPaquetes = Convert.ToInt32(ddlPaquetes.SelectedItem.Value);
            oneAnaPaquete.Id_AnalisisClinico = Convert.ToInt32(ddlAnalisis.SelectedItem.Value);
            oneAnaPaquete.Estatus_AnalisisClinicoPaquetes = true;
            AnalisisEnPaquetesDAO Insert = new AnalisisEnPaquetesDAO();
            Insert.Insert("", oneAnaPaquete);
            loadItems();
        }*/
        protected void addAnalisis(object sender, EventArgs e)
        {
            Tabla_Temporal_AnalisisClinicoDTO oneAnaPaquete = new Tabla_Temporal_AnalisisClinicoDTO();
            oneAnaPaquete.Id_FichaIdentificacion = Id_FichaIdentificacion;
            oneAnaPaquete.Id_AnalisisClinico = Convert.ToInt32(ddlAnalisis.SelectedItem.Value);
            oneAnaPaquete.Id_Consulta = Id_Consulta;
            Tabla_Temporal_AnalisisClinicoDAO Insert = new Tabla_Temporal_AnalisisClinicoDAO();
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