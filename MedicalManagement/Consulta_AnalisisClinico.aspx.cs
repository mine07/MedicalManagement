using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalManagement.Models;
using MedicalManagement.Models.DTO;

namespace MedicalManagement
{
    public partial class Consulta_AnalisisClinico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadPaquetes();
        }

        private void loadPaquetes()
        {
            string query = "select * from  Tabla_Catalogo_AnalisisClinicoPaquetes";
            Helpers h = new Helpers();
            var lPaquestes = h.GetAllParametized(query, new Tabla_Catalogo_AnalisisClinicoPaquetesDTO());
            rptPaquete.DataSource = lPaquestes;
            rptPaquete.DataBind();
        }
    }
}