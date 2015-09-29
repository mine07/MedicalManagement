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
        public Tabla_Catalogo_FichaIdentificacionDTO oneUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["lAnalisis"] = new List<AnalisisClinicoDTO>();
                loadPaquetes();
                loadAnalisis();
            }
            var Id_Paciente = Request.QueryString["Id_Paciente"];
            if (Id_Paciente != null)
            {
                oneUser =
                    FichaDAO.GetOne(new Tabla_Catalogo_FichaIdentificacionDTO
                    {
                        Id_FichaIdentificacion = Convert.ToInt32(Id_Paciente)
                    });

                spanName.InnerText = oneUser.Nombre_FichaIdentificacion.Trim() + " " +
                                     oneUser.ApPaterno_FichaIdentificacion.Trim();
            }
            loadSelected();
        }

        private void loadPaquetes()
        {
            string query = "select * from  Tabla_Catalogo_AnalisisClinicoPaquetes";
            Helpers h = new Helpers();
            var lPaquestes = h.GetAllParametized(query, new Tabla_Catalogo_AnalisisClinicoPaquetesDTO());
            rptPaquete.DataSource = lPaquestes;
            rptPaquete.DataBind();
        }

        public void loadAnalisis()
        {
            rptAuxiliares.DataSource = AnalisisClinicoDAO.GetAll("", new AnalisisClinicoDTO());
            rptAuxiliares.DataBind();
        }

        protected void addTemporal(object sender, EventArgs e)
        {
            var id = ((LinkButton)sender).CommandArgument;
            var oneAnalisis = new AnalisisClinicoDTO();
            oneAnalisis.Id_AnalisisClinico = Convert.ToInt32(id);
            string queryIf = " where Id_AnalisisClinico = @Id_AnalisisClinico";
            oneAnalisis = AnalisisClinicoDAO.GetAll(queryIf, oneAnalisis)[0];
            var lTemporal = (List<AnalisisClinicoDTO>)Session["lAnalisis"];
            lTemporal.Add(oneAnalisis);
            loadSelected();
        }

        protected void addTemporalPaquete(object sender, EventArgs e)
        {
            var id = ((LinkButton)sender).CommandArgument;
            var onePaquete = new PaquetesDTO
            {
                Id_AnalisisClinicoPaquetes = Convert.ToInt32(id)
            };
            string queryIf = " where Id_AnalisisClinicoPaquetes = @Id_AnalisisClinicoPaquetes";
            var lPaquetes = PaquetesDAO.GetAll(queryIf, onePaquete);
            var lTemporal = (List<AnalisisClinicoDTO>) Session["lAnalisis"];
            lTemporal.AddRange(from y in lPaquetes from x in y.lAnalisis select x.oneAnalisis);
            Session["lAnalisis"] = lTemporal;
            loadSelected();
        }

        public void loadSelected()
        {
            var lTemporal = (List<AnalisisClinicoDTO>)Session["lAnalisis"];
            rptSeleccionados.DataSource = lTemporal;
            rptSeleccionados.DataBind();
        }

        protected void removeSelected(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            var lTemporal = (List<AnalisisClinicoDTO>)Session["lAnalisis"];
            lTemporal = lTemporal.Where(x => x.Id_AnalisisClinico != id).ToList();
            Session["lAnalisis"] = lTemporal;
            loadSelected();
        }
    }
}