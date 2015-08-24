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

namespace MedicalManagement
{
    public partial class PagosIndividuales : System.Web.UI.Page
    {
        public int Id_Usuario = Convert.ToInt32(System.Web.HttpContext.Current.Request.QueryString["Id_Usuario"]);

        protected void Page_Load(object sender, EventArgs e)
        {
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
        public static object GetPagosItems(int jtStartIndex, int jtPageSize, int Id_Usuario)
        {
            try
            {
                var oneDiagnostico = new Tabla_Registro_PagosDTO
                {
                    Id_FichaIdentificacion = Id_Usuario
                };
                string query = "Select * from Tabla_Registro_PagosB where Id_FichaIdentificacion = @Id_FichaIdentificacion order by Id_Pagos";
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
    }
}