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
            string queryIf = "where Id_AnalisisClinicoPaquetes = @Id_AnalisisClinicoPaquetes";
            rptItems.DataSource = AnalisisEnPaquetesDAO.GetAll(queryIf, new AnalisisEnPaquetesDTO{Id_AnalisisClinicoPaquetes = Convert.ToInt32(ddlPaquetes.SelectedItem.Value)});
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
    }
}