using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MedicalManagement.Models;
using MedicalManagement.Models.DTO;
using Newtonsoft.Json;

namespace MedicalManagement
{
    public partial class RecetaPrevia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["lTemplates"] = null;
                loadTemporal();
                loadMedicamentos();
                loadItems();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


       

        protected void Eliminar(string id_consultarecetaprevia)
        {

            /*SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings.Get("strConnection"));*/
            string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlConnection cnn;
            cnn = new SqlConnection(conexion);

            cnn.Open();


            SqlCommand command = new SqlCommand("SP_Catalogo_ConsultaRecetaPrevia", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Opcion", "BAJA");
            command.Parameters.AddWithValue("@Id_ConsultaRecetaPrevia", id_consultarecetaprevia);
            command.ExecuteNonQuery();
            command = null;

            String Registro_Operacion_Btacora = "SP_Catalogo_ConsultaRecetaPrevia"
                                            + "@Opcion" + " = " + "BAJA"
                                            + "@Id_ConsultaRecetaPrevia" + " = " + Convert.ToString(id_consultarecetaprevia).Trim();

            SqlCommand comandoBitacora = new SqlCommand("SP_Registro_Bitacora", cnn);
            comandoBitacora.CommandType = CommandType.StoredProcedure;
            comandoBitacora.Parameters.AddWithValue("@Id_Empresa", Convert.ToInt32(Session["Id_Empresa"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Sucursal", Convert.ToInt32(Session["Id_Sucursal"]));
            comandoBitacora.Parameters.AddWithValue("@Id_Usuario", Convert.ToInt32(Session["Id_Usuario"]));
            comandoBitacora.Parameters.AddWithValue("@Registro_Operacion_Btacora", Registro_Operacion_Btacora);
            comandoBitacora.Parameters.AddWithValue("@Descripcion_Bitacora", "Baja RecetaPrevia nueva");

            SqlDataReader readerBitacora = comandoBitacora.ExecuteReader();
            readerBitacora.Read();
            readerBitacora.Close();
            comandoBitacora = null;

            cnn.Close();

        }


        public void loadTemplate()
        {
            string query = @"select  * from Tabla_receta_Template a
            left join Tabla_Catalogo_Medicamento b on b.Id_Medicamento = a.Id_Medicamento where Id_Template = @Id_Template";
            var oneTemp = new Tabla_Receta_TemplateDTO();
            oneTemp.Id_Template = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
            Helpers h = new Helpers();
            var lTemporal = h.GetAllParametized(query, oneTemp);
            rptTemplate.DataSource = lTemporal;
            rptTemplate.DataBind();
        }

        public void RemoveTemporal(object sender, EventArgs e)
        {
            
            var linkButton = (LinkButton)sender;
            var Id_Temporal = Convert.ToInt32(linkButton.CommandArgument);
            var lTemplates = (List<Tabla_Receta_TemplateDTO>)Session["lTemplates"];
            if (ddlTemplate.Enabled)
            {
            lTemplates = lTemplates.Where(x => x.Id_Template != Id_Temporal).ToList();
            }
            else
            {
                lTemplates = lTemplates.Where(x => x.Id_Receta_Template != Id_Temporal).ToList();
            }
            Session["lTemplates"] = lTemplates;
            loadItems();
        }


        protected void saveToTemplate(object sender, EventArgs e)
        {
            Helpers h = new Helpers();
            
            var lTemporal = (List<Tabla_Receta_TemplateDTO>)Session["lTemplates"];
            string queryInsert =
                "insert into Tabla_Receta_Template (Id_Medicamento, Tem_Dosis, Tem_Notas, Tem_Nombre, Id_Template) values (@Id_Medicamento, @Tem_Dosis, @Tem_Notas, @Tem_Nombre, @Id_Template)";
            var oneT = new Tabla_Receta_TemplateDTO();
            string queryLast = "SELECT TOP 1 Id_Template FROM Tabla_Receta_Template ORDER BY Id_Template DESC";
            var lIdTemplate = h.GetAllParametized(queryLast, oneT);
            if (lIdTemplate.Count == 0)
            {
                oneT.Id_Template = 0;
            }
            else if (lTemporal[0].Id_Template != 0)
            {
                oneT.Id_Template = getCurrentId();
            }
            else
            {
                oneT.Id_Template = lIdTemplate[0].Id_Template + 1;
            }
            
            if (!ddlTemplate.Enabled)
            {
                string query = "delete Tabla_Receta_Template where Id_Template = @Id_Template";
                h.ExecuteNonQueryParam(query, new Tabla_Receta_TemplateDTO { Id_Template = Convert.ToInt32(ddlTemplate.SelectedItem.Value) });
            }
            foreach (var y in lTemporal)
            {
                var oneTemplate = new Tabla_Receta_TemplateDTO();
                oneTemplate.Id_Medicamento = y.Id_Medicamento;
                oneTemplate.Tem_Dosis = y.Tem_Dosis;
                oneTemplate.Tem_Notas = y.Tem_Notas;
                oneTemplate.Tem_Nombre = txtNombre.Value;
                oneTemplate.Id_Template = oneT.Id_Template;
                h.ExecuteNonQueryParam(queryInsert, oneTemplate);
            }
            Session["lTemplates"] = null;
            loadItems();
            loadTemporal();
            ddlTemplate.Enabled = true;
            cancelRow.Visible = false;
            txtNombre.Value = "";
        }

        protected void loadMedicamentos()
        {
            string query = "select * from Tabla_Catalogo_Medicamento where Estatus_Medicamento = 1";
            Helpers h = new Helpers();
            var lMeds = h.GetAllParametized(query, new Tabla_Catalogo_MedicamentoDTO());
            ddlMedicamento.DataSource = lMeds;
            ddlMedicamento.DataBind();
        }

        private void loadTemporal()
        {
            Helpers h = new Helpers();
            string queryTemplate = "select Id_Template, Tem_Nombre from tabla_receta_template group by Id_Template , Tem_Nombre";
            var lTemplates = h.GetAllParametized(queryTemplate, new Tabla_Receta_TemplateDTO());
            ddlTemplate.DataSource = lTemplates;
            ddlTemplate.DataBind();
            loadTemplate();
        }

        protected void addToList(object sender, EventArgs e)
        {
            var lTemplates = (List<Tabla_Receta_TemplateDTO>)Session["lTemplates"];
            int id;
            if (lTemplates == null)
            {
                lTemplates = new List<Tabla_Receta_TemplateDTO>();
                id = 0;
            }
            else if (lTemplates.Count > 0)
            {
                id = lTemplates[lTemplates.Count - 1].Id_Template + 1;
            }
            else
            {
                id = 0;
            }
            var oneTemplate = new Tabla_Receta_TemplateDTO
            {
                Id_Template = id,
                Id_Receta_Template = id,
                Id_Medicamento = Convert.ToInt32(ddlMedicamento.SelectedItem.Value),
                Tem_Medicamento = ddlMedicamento.SelectedItem.Text,
                Tem_Dosis = txtDos.Value,
                Tem_Notas = txtNot.Value
            };
            lTemplates.Add(oneTemplate);
            Session["lTemplates"] = lTemplates;
            loadItems();
        }

        public void loadItems()
        {
            var lTemplates = (List<Tabla_Receta_TemplateDTO>)Session["lTemplates"];
            rptTemporal.DataSource = lTemplates;
            rptTemporal.DataBind();
            txtDos.Value = "";
            txtNot.Value = "";
            ddlMedicamento.SelectedIndex = 0;
        }

        protected void editCurrent(object sender, EventArgs e)
        {
            var current = loadTemplate(Convert.ToInt32(ddlTemplate.SelectedItem.Value));
            Session["lTemplates"] = null;
            Session["lTemplates"] = current;
            ddlTemplate.Enabled = false;
            txtNombre.Value = current[0].Tem_Nombre;
            cancelRow.Visible = true;
            loadItems();
        }

        public List<Tabla_Receta_TemplateDTO> loadTemplate(int Id_Template)
        {
            string query = @"select  a.*, b.Descripcion_Medicamento as Tem_Medicamento from Tabla_receta_Template a
            left join Tabla_Catalogo_Medicamento b on b.Id_Medicamento = a.Id_Medicamento where Id_Template = @Id_Template";
            var oneTemp = new Tabla_Receta_TemplateDTO();
            oneTemp.Id_Template = Id_Template;
            Helpers h = new Helpers();
            var lTemporal = h.GetAllParametized(query, oneTemp);
            return lTemporal;
        }

        protected void cancelEdit(object sender, EventArgs e)
        {
            Session["lTemplates"] = null;
            ddlTemplate.Enabled = true;
            cancelRow.Visible = false;
            txtNombre.Value = "";
            loadItems();
        }

        public int getCurrentId()
        {
            var current = loadTemplate(Convert.ToInt32(ddlTemplate.SelectedItem.Value));
            return current[0].Id_Template;
        }

     
    }
}