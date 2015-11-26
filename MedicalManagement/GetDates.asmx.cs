using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using MedicalManagement.Models;
using MedicalManagement.Models.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MedicalManagement
{
    /// <summary>
    /// Summary description for Search
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]

    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class GetDates : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAgenda()
        {
            var lFechas = new List<dateItem>();
            Helpers h = new Helpers();
            string query =
                @"select CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime) as date, count(CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime)) as cantidad  from Tabla_Registro_Agenda
group by CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime)";
            lFechas = h.GetAll<dateItem>(query);
            string json = JsonConvert.SerializeObject(lFechas);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetConsulta()
        {
            var lFechas = new List<dateItem>();
            Helpers h = new Helpers();
            string query =
                @"select CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime) as date, count(CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime)) as cantidad  from Tabla_Registro_Agenda
group by CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime)";
            lFechas = h.GetAll<dateItem>(query);
            string json = JsonConvert.SerializeObject(lFechas);
            return json;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDiagnosticoItems(string search)
        {
            List<string> lSearch = search.Split(new char[] { ' ' }).ToList();
            var oneDiagnostico = new Tabla_Catalogo_DiagnosticoDTO();
            oneDiagnostico.Descripcion_Diagnostico = "%" + search.Trim() + "%";
            string query =
                "Select * from Tabla_Catalogo_Diagnostico where Descripcion_Diagnostico like @Descripcion_Diagnostico";
            Helpers h = new Helpers();
            var lDiag = h.GetAllParametized(query, oneDiagnostico);
            string json = JsonConvert.SerializeObject(lDiag);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetProcedimientoItems(string search)
        {
            List<string> lSearch = search.Split(new char[] { ' ' }).ToList();
            var oneProcedimiento = new Tabla_Catalogo_ProcedimientoDTO();
            oneProcedimiento.Descripcion_Procedimiento = "%" + search.Trim() + "%";
            string query =
                "Select * from Tabla_Catalogo_Procedimiento where Descripcion_Procedimiento like @Descripcion_Procedimiento";
            Helpers h = new Helpers();
            var lPro = h.GetAllParametized(query, oneProcedimiento);
            string json = JsonConvert.SerializeObject(lPro);
            return json;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRecetaPreviaItems(string search)
        {
            List<string> lSearch = search.Split(new char[] { ' ' }).ToList();
            var oneDiagnostico = new Tabla_Catalogo_ConsultaRecetaPreviaDTO();
            oneDiagnostico.Nombre_ConsultaRecetaPrevia = "%" + search.Trim() + "%";
            oneDiagnostico.Descripcion_Diagnostico = "%" + search.Trim() + "%";
            string query =
                "Select a.*, b.Descripcion_Diagnostico from Tabla_Catalogo_ConsultaRecetaPrevia a left join Tabla_Catalogo_Diagnostico b on b.Id_Diagnostico = a.Id_Diagnostico where b.Descripcion_Diagnostico like @Descripcion_Diagnostico OR a.Nombre_ConsultaRecetaPrevia like @Nombre_ConsultaRecetaPrevia";
            Helpers h = new Helpers();
            var lDiag = h.GetAllParametized(query, oneDiagnostico);
            string json = JsonConvert.SerializeObject(lDiag);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetAgendaItems(getDateItem getDate)
        {
            string fecha = getDate.year + "-" + add0(getDate.month) + "-" + add0(getDate.day);
            string fechaIni = fecha + " 00:00:00";
            string fechaFin = fecha + " 23:59:59";
            var lAgendas = new List<Tabla_Registro_AgendaDTO>();
            Tabla_Registro_AgendaDTO oneAgenda = new Tabla_Registro_AgendaDTO();
            oneAgenda.Fecha_Agenda = DateTime.Parse(fecha);
            Helpers h = new Helpers();
            //string query = "Select * From Tabla_Registro_Agenda where Inicio_Agenda BETWEEN {ts '" + fechaIni + "'} AND {ts '" + fechaFin + "'} OR Fin_Agenda BETWEEN {ts '" + fechaIni + "'} AND {ts '" + fechaFin + "'} ORDER BY Inicio_Agenda";
            string query = "Select * From Tabla_Registro_Agenda where Inicio_Agenda BETWEEN {ts '" + fechaIni +
                           "'} AND {ts '" + fechaFin + "'} ORDER BY Inicio_Agenda";
            lAgendas = h.GetAllParametized(query, oneAgenda);
            foreach (var y in lAgendas)
            {
                query =
                    "Select * From Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
                y.oneUsuario = new Tabla_Catalogo_FichaIdentificacionDTO
                {
                    Id_FichaIdentificacion = y.Id_FichaIdentificacion
                };
                y.oneUsuario = h.GetAllParametized(query, y.oneUsuario)[0];
                y.FinCita = y.Fin_Agenda.ToShortTimeString();
                y.InicioCita = y.Inicio_Agenda.ToShortTimeString();

                y.oneUsuario.Nombre_FichaIdentificacion = y.oneUsuario.Nombre_FichaIdentificacion.Trim();
                y.oneUsuario.ApMaterno_FichaIdentificacion = y.oneUsuario.ApMaterno_FichaIdentificacion.Trim();
                y.oneUsuario.ApPaterno_FichaIdentificacion = y.oneUsuario.ApPaterno_FichaIdentificacion.Trim();
                y._estatus = "pnd";
                if (y.EstadoCitas_Agenda.Trim() == "Confirmado")
                {
                    y._estatus = "conf";
                }
                else if (y.EstadoCitas_Agenda.Trim() == "Cancelado")
                {
                    y._estatus = "canceled";
                }
            }
            string json = JsonConvert.SerializeObject(lAgendas);
            return json;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetConsultaItems(getDateItem getDate)
        {
            string fecha = getDate.year + "-" + add0(getDate.month) + "-" + add0(getDate.day);
            string fechaIni = fecha + " 00:00:00";
            string fechaFin = fecha + " 23:59:59";
            var lConsultas = new List<Tabla_Registro_ConsultaDTO>();
            var oneConsulta = new Tabla_Registro_ConsultaDTO();
            oneConsulta.Fecha_Consulta = DateTime.Parse(fecha);
            Helpers h = new Helpers();
            //            string query = @"Select * From Tabla_Registro_Consulta a where b.Inicio_Agenda BETWEEN {ts '" + fechaIni + "'} AND {ts '" + fechaFin + @"'} 
            //                            left join Tabla_Registro_Agenda on b.Id_Agenda = a.Id_Agenda
            //                            ORDER BY a.Inicio_Agenda ";
            string query = @"Select * From Tabla_Registro_Consulta a  
                            left join Tabla_Registro_Agenda b on b.Id_Agenda = a.Id_Agenda
                            where b.Inicio_Agenda BETWEEN {ts '" + fechaIni + "'} AND {ts '" + fechaFin + @"'}
							order by b.Inicio_Agenda";
            lConsultas = h.GetAllParametized(query, oneConsulta);
            foreach (var y in lConsultas)
            {
                string queryB =
                    "Select * From Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
                y.UsuarioDTO = new Tabla_Catalogo_FichaIdentificacionDTO
                {
                    Id_FichaIdentificacion = y.Id_FichaIdentificacion
                };
                y.UsuarioDTO = h.GetAllParametized(queryB, y.UsuarioDTO)[0];
                y.AgendaDTO = new Tabla_Registro_AgendaDTO
                {
                    Id_Agenda = y.Id_Agenda
                };
                y.UsuarioDTO._NombreCompleto = y.UsuarioDTO.Nombre_FichaIdentificacion.Trim() + " " +
                                               y.UsuarioDTO.ApPaterno_FichaIdentificacion.Trim() + " " +
                                               y.UsuarioDTO.ApMaterno_FichaIdentificacion.Trim();
                queryB = "Select * From Tabla_Registro_Agenda where Id_Agenda = @Id_Agenda";
                y.AgendaDTO = h.GetAllParametized(queryB, y.AgendaDTO)[0];
                y.AgendaDTO.FinCita = y.AgendaDTO.Fin_Agenda.ToShortTimeString();
                y.AgendaDTO.InicioCita = y.AgendaDTO.Inicio_Agenda.ToShortTimeString();
                y.AgendaDTO._estatus = "pnd";
                if (y.AgendaDTO.EstadoCitas_Agenda.Trim() == "Confirmado")
                {
                    y.AgendaDTO._estatus = "conf";
                }
                else if (y.AgendaDTO.EstadoCitas_Agenda.Trim() == "Cancelado")
                {
                    y.AgendaDTO._estatus = "canceled";
                }
            }
            string json = JsonConvert.SerializeObject(lConsultas);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetFichas(string search)
        {
            Tabla_Catalogo_FichaIdentificacionDTO oneItem = new Tabla_Catalogo_FichaIdentificacionDTO
            {
                Nombre_FichaIdentificacion = "%" + search + "%",
                ApPaterno_FichaIdentificacion = "%" + search + "%",
                ApMaterno_FichaIdentificacion = "%" + search + "%",
                TelefonoCasa_FichaIdentificacion = "%" + search + "%",
                TelefonoMovil_FichaIdentificacion = "%" + search + "%",
                TelefonoOfinica_FichaIdentificacion = "%" + search + "%"
            };
            string query =
                "Select * from Tabla_Catalogo_FichaIdentificacion where Nombre_FichaIdentificacion like @Nombre_FichaIdentificacion OR ApPaterno_FichaIdentificacion like @ApPaterno_FichaIdentificacion OR ApMaterno_FichaIdentificacion like @ApMaterno_FichaIdentificacion OR TelefonoCasa_FichaIdentificacion  LIKE @TelefonoCasa_FichaIdentificacion OR TelefonoMovil_FichaIdentificacion  LIKE @TelefonoMovil_FichaIdentificacion  OR TelefonoOfinica_FichaIdentificacion LIKE @TelefonoOfinica_FichaIdentificacion";
            Helpers h = new Helpers();
            var lFichas = h.GetAllParametized(query, oneItem);
            foreach (var y in lFichas)
            {
                y.Nombre_FichaIdentificacion = y.Nombre_FichaIdentificacion.Trim();
                y.ApMaterno_FichaIdentificacion = y.ApMaterno_FichaIdentificacion.Trim();
                y.ApPaterno_FichaIdentificacion = y.ApPaterno_FichaIdentificacion.Trim();
            }
            string json = JsonConvert.SerializeObject(lFichas);
            return json;
        }

        [WebMethod(EnableSession = true)]
        public void InsertarConcepto(Tabla_Catalogo_ConceptoPagoDTO oneConcepto)
        {
            string query = @"
            INSERT INTO [dbo].[Tabla_Catalogo_ConceptoPago]
           ([Descripcion_ConceptoPago]
           ,[NombreCorto_ConceptoPago]
           ,[Estatus_ConceptoPago])
                VALUES
           (@Descripcion_ConceptoPago,
           @NombreCorto_ConceptoPago,
           @Estatus_ConceptoPago)
            ";
            Helpers h = new Helpers();
            h.GetAllParametized(query, oneConcepto);
        }

        [WebMethod(EnableSession = true)]
        public void RemoveActive(int Id_Diagnostico)
        {
            string query = "Update Tabla_Registro_ConsultaDiagnostico SET Estatus_ConsultaDiagnostico = 'False' where Id_ConsultaDiagnostico = @Id_ConsultaDiagnostico";
            Helpers h = new Helpers();
            ConsultaDiagnosticoDTO oneConsulta = new ConsultaDiagnosticoDTO();
            oneConsulta.Id_ConsultaDiagnostico = Id_Diagnostico;
            h.ExecuteNonQueryParam(query, oneConsulta);
        }

        [WebMethod(EnableSession = true)]
        public void RemoveActiveP(int Id_Procedimiento)
        {
            string query = "Update Tabla_Registro_ConsultaProcedimiento SET Estatus_ConsultaProcedimiento = 'False' where Id_ConsultaProcedimiento = @Id_ConsultaProcedimiento";
            Helpers h = new Helpers();
            ConsultaProcedimientoDTO oneProcedimiento = new ConsultaProcedimientoDTO();
            oneProcedimiento.Id_ConsultaProcedimiento = Id_Procedimiento;
            h.ExecuteNonQueryParam(query, oneProcedimiento);
        }

        [WebMethod(EnableSession = true)]
        public void RemoveInActive(int Id_Diagnostico)
        {
            string query = "Update Tabla_Registro_ConsultaDiagnostico SET Estatus_ConsultaDiagnostico = 'True' where Id_ConsultaDiagnostico = @Id_ConsultaDiagnostico";
            Helpers h = new Helpers();
            ConsultaDiagnosticoDTO oneConsulta = new ConsultaDiagnosticoDTO();
            oneConsulta.Id_ConsultaDiagnostico = Id_Diagnostico;
            h.ExecuteNonQueryParam(query, oneConsulta);
        }

        [WebMethod(EnableSession = true)]
        public void RemoveInActiveP(int Id_Procedimiento)
        {
            string query = "Update Tabla_Registro_ConsultaProcedimiento SET Estatus_ConsultaProcedimiento = 'True' where Id_ConsultaProcedimiento = @Id_ConsultaProcedimiento";
            Helpers h = new Helpers();
            ConsultaProcedimientoDTO oneProcedimiento = new ConsultaProcedimientoDTO();
            oneProcedimiento.Id_ConsultaProcedimiento = Id_Procedimiento;
            h.ExecuteNonQueryParam(query, oneProcedimiento);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string loadTemplate(int Id_Template)
        {
            string query = @"select  a.*, b.Descripcion_Medicamento as Tem_Medicamento from Tabla_receta_Template a
            left join Tabla_Catalogo_Medicamento b on b.Id_Medicamento = a.Id_Medicamento where Id_Template = @Id_Template";
            var oneTemp = new Tabla_Receta_TemplateDTO();
            oneTemp.Id_Template = Id_Template;
            Helpers h = new Helpers();
            var lTemporal = h.GetAllParametized(query, oneTemp);
            string json = JsonConvert.SerializeObject(lTemporal);
            return json;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string loadPaquete(int Id_AnalisisClinicoPaquetes)
        {
            string query = @"select  a.*, b.Descripcion_AnalisisClinico as Tem_Medicamento from Tabla_Registro_AnalisisClinicoPaquetes a
            left join Tabla_Catalogo_AnalisisClinico b on b.Id_AnalisisClinico = a.Id_AnalisisClinico where Id_AnalisisClinicoPaquetes = @Id_AnalisisClinicoPaquetes";
            var oneTemp = new Tabla_Registro_AnalisisClinicoPaquetesDTO();
            oneTemp.Id_AnalisisClinicoPaquetes = Id_AnalisisClinicoPaquetes;
            Helpers h = new Helpers();
            var lTemporal = h.GetAllParametized(query, oneTemp);
            string json = JsonConvert.SerializeObject(lTemporal);
            return json;
        }


        public string add0(int number)
        {
            string snum = number.ToString();
            if (Convert.ToInt32(number) < 10)
            {
                snum = "0" + number;
            }
            return snum;
        }
    }

    public class dateItem
    {
        public DateTime date { get; set; }
        public string fecha { get; set; }
        public int cantidad { get; set; }
    }

    public class getDateItem
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }

}
