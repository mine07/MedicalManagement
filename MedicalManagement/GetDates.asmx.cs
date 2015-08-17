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
            string query = @"select CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime) as date, count(CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime)) as cantidad  from Tabla_Registro_Agenda
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
            string query = @"select CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime) as date, count(CAST(FLOOR(CAST(Inicio_Agenda as FLOAT)) as DateTime)) as cantidad  from Tabla_Registro_Agenda
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
            string query = "Select * from Tabla_Catalogo_Diagnostico where Descripcion_Diagnostico like @Descripcion_Diagnostico";
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
            string query = "Select * From Tabla_Registro_Agenda where Inicio_Agenda BETWEEN {ts '" + fechaIni + "'} AND {ts '" + fechaFin + "'} ORDER BY Inicio_Agenda";
            lAgendas = h.GetAllParametized(query, oneAgenda);
            foreach (var y in lAgendas)
            {
                query = "Select * From Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
                y.UsuarioDTO = new Tabla_Catalogo_FichaIdentificacionDTO
                {
                    Id_FichaIdentificacion = y.Id_FichaIdentificacion
                };
                y.UsuarioDTO = h.GetAllParametized(query, y.UsuarioDTO)[0];
                y.FinCita = y.Fin_Agenda.ToShortTimeString();
                y.InicioCita = y.Inicio_Agenda.ToShortTimeString();

                y.UsuarioDTO.Nombre_FichaIdentificacion = y.UsuarioDTO.Nombre_FichaIdentificacion.Trim();
                y.UsuarioDTO.ApMaterno_FichaIdentificacion = y.UsuarioDTO.ApMaterno_FichaIdentificacion.Trim();
                y.UsuarioDTO.ApPaterno_FichaIdentificacion = y.UsuarioDTO.ApPaterno_FichaIdentificacion.Trim();
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
                string queryB = "Select * From Tabla_Catalogo_FichaIdentificacion where Id_FichaIdentificacion = @Id_FichaIdentificacion";
                y.UsuarioDTO = new Tabla_Catalogo_FichaIdentificacionDTO
                {
                    Id_FichaIdentificacion = y.Id_FichaIdentificacion
                };
                y.UsuarioDTO = h.GetAllParametized(queryB, y.UsuarioDTO)[0];
                y.AgendaDTO = new Tabla_Registro_AgendaDTO
                {
                    Id_Agenda = y.Id_Agenda
                };
                y.UsuarioDTO._NombreCompleto = y.UsuarioDTO.Nombre_FichaIdentificacion.Trim() + " "+
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
            string query = "Select * from Tabla_Catalogo_FichaIdentificacion where Nombre_FichaIdentificacion like @Nombre_FichaIdentificacion OR ApPaterno_FichaIdentificacion like @ApPaterno_FichaIdentificacion OR ApMaterno_FichaIdentificacion like @ApMaterno_FichaIdentificacion OR TelefonoCasa_FichaIdentificacion  LIKE @TelefonoCasa_FichaIdentificacion OR TelefonoMovil_FichaIdentificacion  LIKE @TelefonoMovil_FichaIdentificacion  OR TelefonoOfinica_FichaIdentificacion LIKE @TelefonoOfinica_FichaIdentificacion";
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
