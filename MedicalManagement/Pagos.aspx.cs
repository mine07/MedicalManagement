using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalManagement.Models;
using MedicalManagement.Models.DTO;
using System.Data;

namespace MedicalManagement
{
    public partial class Pagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                loadData();
                AddDefaultFirstRecord();
                AddDefaultFirstRecordHist();
                
            }
        }

        private void loadData()
        {
            string query = "Select * from Tabla_Catalogo_ConceptoPago";
            string queryFichas = "Select * from Tabla_Catalogo_FichaIdentificacion";
            var oneFicha = new Tabla_Catalogo_FichaIdentificacionDTO();
            var oneConcepto = new Tabla_Catalogo_ConceptoPagoDTO();
            Helpers h = new Helpers();
            var lFichas = h.GetAllParametized(queryFichas, oneFicha);
            foreach(var y in lFichas)
           {
            y._NombreCompleto = y.Nombre_FichaIdentificacion + " " + y.ApPaterno_FichaIdentificacion + " " + y.ApMaterno_FichaIdentificacion;
            }
            var lConceptos = h.GetAllParametized(query, oneConcepto);
            ddlFichas.DataSource = lFichas;
            ddlFichas.DataBind();
            ddlConceptos.DataSource = lConceptos;
            ddlConceptos.DataBind();
        }

        private void loadHistPagos() {
            DataSet ds = new DataSet();
            try
            {
                var oneDiagnostico = new Tabla_Registro_PagosDTO();
                string query = "Select * from Tabla_Registro_PagosB order by Id_Pagos";
                Helpers h = new Helpers();
                var lPagos = h.GetAllParametized(query, oneDiagnostico);
                
                if (lPagos.Count==0)
                {

                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    gvHistPagos.DataSource = ds;
                    gvHistPagos.DataBind();
                    int columncount = gvHistPagos.Rows[0].Cells.Count;
                    gvHistPagos.Rows[0].Cells.Clear();
                    gvHistPagos.Rows[0].Cells.Add(new TableCell());
                    gvHistPagos.Rows[0].Cells[0].ColumnSpan = columncount;
                    gvHistPagos.Rows[0].Cells[0].Text = "SIN DATOS";
                    gvHistPagos.Rows[0].Cells[0].Attributes.CssStyle["text-align"] = "Center";
                    
                }
            }
            catch (Exception ex) { 
                
                
            }
        }



        [WebMethod(EnableSession = true)]
        public static object Create(Tabla_Registro_PagosDTO record)
        {
            try
            {
                Helpers h = new Helpers();
                string query = @"INSERT INTO [dbo].[Tabla_Registro_PagosB]
           (
           [Id_FichaIdentificacion]
           ,[Id_Usuario]
           ,[Id_Consulta]
           ,[Id_FormaPago]
           ,[FechaAlta_Pagos]
           ,[Descripcion_Pagos]
           ,[Origen_Pagos]
           ,[Importe_Pagos]
           ,[Pagado_Pagos]
           ,[Debe_Pagos]
           ,[FechaParaPagar_Pagos]
           ,[FechaPagado_Pagos])
     VALUES
           (
           @Id_FichaIdentificacion
           ,@Id_Usuario
           ,@Id_Consulta
           ,@Id_FormaPago
           ,@FechaAlta_Pagos
           ,@Descripcion_Pagos
           ,@Origen_Pagos
           ,@Importe_Pagos
           ,@Pagado_Pagos
           ,@Debe_Pagos
           ,@FechaParaPagar_Pagos
           ,@FechaPagado_Pagos)
";
                record.FechaAlta_Pagos = DateTime.Now;
                h.ExecuteNonQueryParam(query, record);
                Tabla_Catalogo_FichaIdentificacionDTO oneUsuario = new Tabla_Catalogo_FichaIdentificacionDTO
                {
                    Id_FichaIdentificacion = record.Id_FichaIdentificacion
                };
                query = "Select * from Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
                record.oneUsuario = h.GetAllParametized(query, oneUsuario)[0];
                return new { Result = "OK", Record = record };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }



        [WebMethod(EnableSession = true)]
        public static object GetPagosItems(int jtStartIndex, int jtPageSize)
        {
            try
            {
                var oneDiagnostico = new Tabla_Registro_PagosDTO();
                string query = "Select * from Tabla_Registro_PagosB order by Id_Pagos";
                Helpers h = new Helpers();
                var lPagos = h.GetAllParametized(query, oneDiagnostico);
                foreach (var y in lPagos)
                {
                    Tabla_Catalogo_FichaIdentificacionDTO oneUsuario = new Tabla_Catalogo_FichaIdentificacionDTO
                    {
                        Id_FichaIdentificacion = y.Id_FichaIdentificacion
                    };
                    query = "Select * from Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
                    y.oneUsuario = h.GetAllParametized(query, oneUsuario)[0];
                }
                return new { Result = "OK", Records = lPagos, TotalRecordCount = lPagos.Count };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };
            }
        }

        [WebMethod(EnableSession = true)]
        public static object GetFichasPagos()
        {
            Tabla_Catalogo_FichaIdentificacionDTO oneItem = new Tabla_Catalogo_FichaIdentificacionDTO();
            string query = "Select * from Tabla_Catalogo_FichaIdentificacion";
            Helpers h = new Helpers();
            var lFichas = h.GetAllParametized(query, oneItem);

            foreach (var y in lFichas)
            {
                y.Nombre_FichaIdentificacion = y.Nombre_FichaIdentificacion.Trim();
                y.ApMaterno_FichaIdentificacion = y.ApMaterno_FichaIdentificacion.Trim();
                y.ApPaterno_FichaIdentificacion = y.ApPaterno_FichaIdentificacion.Trim();
                y._NombreCompleto = y.Nombre_FichaIdentificacion + " " + y.ApPaterno_FichaIdentificacion + " " +
                                    y.ApMaterno_FichaIdentificacion;
            }
            var lOpt = lFichas.Select(c => new { DisplayText = c._NombreCompleto, Value = c.Id_FichaIdentificacion }).OrderBy(s => s.DisplayText).ToList();
            return new { Result = "OK", Options = lOpt };
        }



        protected void ddlConceptos_Selected(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Tabla_Catalogo_ConceptoPago WHERE (Id_ConceptoPago=@Id_ConceptoPago)";
            var oneConcepto = new Tabla_Catalogo_ConceptoPagoDTO();
            Helpers h = new Helpers();
            oneConcepto.Id_ConceptoPago = Convert.ToInt32(ddlConceptos.SelectedValue);
            var lConceptos = h.GetAllParametized(query, oneConcepto);
            foreach (var y in lConceptos)
            {
                txtCantidad.Text = "1";
                txtPrecio.Text = y.PrecioUnitario.Trim();
                txtDescuento.Text = "0.0";
            }
            popup.Show();
        }

        
        protected void Add(object sender, EventArgs e)
        {
            
            
        }

        protected void Edit(object sender, EventArgs e) {
        }

        protected void addCP(object sender, EventArgs e) {
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            
                DataTable dtCurrentTable = (DataTable)ViewState["ProductsSold"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //Creating new row and assigning values
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Concepto"] = ddlConceptos.SelectedItem.Text.Trim();
                        drCurrentRow["Cantidad"] = txtCantidad.Text;
                        drCurrentRow["Total"] = txtPrecio.Text;
                        drCurrentRow["Descuento"] = txtDescuento.Text;
                                                
                    }
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Guardado de la gridviwe en ViewState 
                    ViewState["ProductsSold"] = dtCurrentTable;
                    gvConceptos.DataSource = dtCurrentTable;
                    gvConceptos.DataBind();
                }
            }

        private void AddDefaultFirstRecord()
        {
            //creating DataTable
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "ProductsSold";
            //creating columns for DataTable
            dt.Columns.Add(new DataColumn("Concepto", typeof(string)));
            dt.Columns.Add(new DataColumn("Cantidad", typeof(string)));
            dt.Columns.Add(new DataColumn("Total", typeof(string)));
            dt.Columns.Add(new DataColumn("Descuento", typeof(string)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["ProductsSold"] = dt;
            gvConceptos.DataSource = dt;
            gvConceptos.DataBind();
        }

        private void AddDefaultFirstRecordHist()
        {
            //creating DataTable
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "HISTORIAL";
            //creating columns for DataTable
            dt.Columns.Add(new DataColumn("Fecha", typeof(string)));
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Origen", typeof(string)));
            dt.Columns.Add(new DataColumn("Importe", typeof(string)));
            dt.Columns.Add(new DataColumn("Pagado", typeof(string)));
            dt.Columns.Add(new DataColumn("Debe", typeof(string)));
            dt.Columns.Add(new DataColumn("FPP", typeof(string)));
            dt.Columns.Add(new DataColumn("FP", typeof(string)));
            dt.Columns.Add(new DataColumn("Factura", typeof(string)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);

            ViewState["HISTORIAL"] = dt;
            gvHistPagos.DataSource = dt;
            gvHistPagos.DataBind();
        }

        protected void CancelAdd(object sender, EventArgs e)
        {
            
        }

        protected void btnClean_Click(object sender, EventArgs e) { 
            ViewState.Clear();
            Session.RemoveAll();
            Session.Clear();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSavePagos_Click(object sender, EventArgs e) {

        }
    }


    }