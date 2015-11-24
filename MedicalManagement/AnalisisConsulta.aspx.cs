﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalManagement.Models.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MedicalManagement.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

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
            string queryIf = "where Id_Consulta = @Id_Consulta";
            rptItems.DataSource = Tabla_Temporal_AnalisisClinicoDAO.GetAll(queryIf, new Tabla_Temporal_AnalisisClinicoDTO { Id_Consulta = Id_Consulta });
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
            var Id_Temporal_AnalisisClinico = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            var oneAnaPaquete = new Tabla_Temporal_AnalisisClinicoDTO();
            oneAnaPaquete.Id_Temporal_AnalisisClinico = Id_Temporal_AnalisisClinico;
            Tabla_Temporal_AnalisisClinicoDAO Delete = new Tabla_Temporal_AnalisisClinicoDAO();
            Delete.delete("", oneAnaPaquete);
            loadItems();
        }

        /*protected void deletePacket(object sender, EventArgs e)
        {
            var Id_Paquete = ddlPaquetes.SelectedItem.Value;
            PaquetesDTO onePaquet = new PaquetesDTO();
            onePaquet.Id_AnalisisClinicoPaquetes = Convert.ToInt32(Id_Paquete);
            PaquetesDAO Delete = new PaquetesDAO();
            Delete.Delete("", onePaquet);
            loadPaquetes();
            loadItems();
            limpiar();
        }*/

        protected void saveToUse(object sender, EventArgs e)
        {
            int Id_Template = Convert.ToInt32(ddlPaquetes.SelectedItem.Value);
            string query = @"select  a.*, b.Descripcion_Medicamento as Tem_Medicamento from Tabla_receta_Template a
            left join Tabla_Catalogo_Medicamento b on b.Id_Medicamento = a.Id_Medicamento where Id_Template = @Id_Template";
            var oneTemp = new Tabla_Receta_TemplateDTO();
            oneTemp.Id_Template = Id_Template;
            Helpers h = new Helpers();
            var lTemporal = h.GetAllParametized(query, oneTemp);
            string queryInsert = "insert into Tabla_Temporal_Receta (Id_FichaIdentificacion, Tem_Dosis, Tem_Notas, Id_Medicamento, Id_Consulta) values (@Id_FichaIdentificacion, @Tem_Dosis, @Tem_Notas, @Id_Medicamento, @Id_Consulta)";
            string queryDelete = "delete from Tabla_Temporal_Receta where Id_Consulta = @Id_Consulta and Id_FichaIdentificacion = @Id_FichaIdentificacion";
            h.ExecuteNonQueryParam(queryDelete, new Tabla_Temporal_RecetaDTO { Id_FichaIdentificacion = Id_FichaIdentificacion, Id_Consulta = Id_Consulta });
            foreach (var y in lTemporal)
            {
                var oneTe = new Tabla_Temporal_RecetaDTO();
                oneTe.Id_Consulta = Id_Consulta;
                oneTe.Id_FichaIdentificacion = Id_FichaIdentificacion;
                oneTe.Id_Medicamento = y.Id_Medicamento;
                oneTe.Tem_Dosis = y.Tem_Dosis;
                oneTe.Tem_Notas = y.Tem_Notas;
                h.ExecuteNonQueryParam(queryInsert, oneTe);
                //loadTemporal();
            }
            string script = "AlertaGuardar();";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            return;
        }
    }
}