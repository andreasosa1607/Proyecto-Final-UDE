using AV.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AV_DTO
{
    public class EventoDTO
    {
        public int EventoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string ImagenPortada { get; set; }
        public DateTime FechaHora { get; set; }
        public string Duracion { get; set; }
        public string CallePuerta { get; set; }
        public string Barrio { get; set; }
        public string Ciudad { get; set; }


        //public string Hora { get; set; }

        public int NroCupos { get; set; }
        public int CantidadMesas { get; set; }
        public int CantidadAsientosMesa { get; set; }
        public int PrecioAsiento { get; set; }
        public string Idioma { get; set; }
        public string CriterioAsignacion { get; set; }
        public string EmpresaCreadora { get; set; }
        public string EstadoEvento { get; set; }
        public List<Mesa> Mesas { get; set; }
    }
}