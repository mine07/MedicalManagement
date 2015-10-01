using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalManagement.Models.DTO
{
    public class Tabla_Registro_AgendaDTO
    {
        public int Id_Agenda { get; set; }
        public DateTime Fecha_Agenda { get; set; }
        public string Asunto_Agenda { get; set; }
        public string Prioridad_Agenda { get; set; }
        public string EstadoCitas_Agenda { get; set; }
        public string Descripcion_Agenda { get; set; }
        public DateTime Inicio_Agenda { get; set; }
        public DateTime Fin_Agenda { get; set; }
        public int Id_FichaIdentificacion { get; set; }
        public int Id_Categoria { get; set; }
        public bool Estatus_Agenda { get; set; }
        public string InicioCita { get; set; }
        public string FinCita { get; set; }
        public Tabla_Catalogo_FichaIdentificacionDTO oneUsuario { get; set; }
        public string _estatus { get; set; }
    }

    public class AgendaDAO
    {
        public static List<Tabla_Registro_AgendaDTO> GetAll()
        {
            string query = "select * from Tabla_Registro_Agenda";
            Helpers h = new Helpers();
            var lAgendas = h.GetAllParametized(query, new Tabla_Registro_AgendaDTO());
            foreach (var y in lAgendas)
            {
                y.oneUsuario = FichaDAO.GetOne(new Tabla_Catalogo_FichaIdentificacionDTO{Id_FichaIdentificacion = y.Id_FichaIdentificacion});
            }
            return lAgendas;
        }

        public Tabla_Registro_AgendaDTO GetOne(Tabla_Registro_AgendaDTO oneAgenda)
        {
            string query = "select * from Tabla_Registro_Agenda where ID_Agenda = @Id_Agenda";
            Helpers h = new Helpers();
            var lAgendas = h.GetAllParametized(query, new Tabla_Registro_AgendaDTO());
            oneAgenda = lAgendas.Single(x => x.Id_Agenda == oneAgenda.Id_Agenda);
            return oneAgenda;
        }

        public Tabla_Registro_AgendaDTO GetLastById_Ficha(Tabla_Registro_AgendaDTO oneAgenda)
        {
            string query = "select * from Tabla_Registro_Agenda where Id_FichaIdentificacion = @Id_FichaIdentificacion";
            Helpers h = new Helpers();
            var lAgendas = h.GetAllParametized(query, oneAgenda);
            oneAgenda = lAgendas.Last(x => x.Id_FichaIdentificacion == oneAgenda.Id_FichaIdentificacion);
            return oneAgenda;
        }

        public void Insert(Tabla_Registro_AgendaDTO oneAgenda)
        {
            string query =
                "insert into Tabla_Registro_Agenda (Fecha_Agenda, Asunto_Agenda, Prioridad_Agenda, EstadoCitas_Agenda, Descripcion_Agenda, Inicio_Agenda, Fin_Agenda, Id_FichaIdentificacion, Id_Categoria, Estatus_Agenda) values(@Fecha_Agenda, @Asunto_Agenda, @Prioridad_Agenda, @EstadoCitas_Agenda, @Descripcion_Agenda, @Inicio_Agenda, @Fin_Agenda, @Id_FichaIdentificacion, @Id_Categoria, @Estatus_Agenda)";
            Helpers h = new Helpers();
            h.ExecuteNonQueryParam(query, oneAgenda);
        }
    }
}