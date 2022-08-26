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
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int Duracion { get; set; }
        public string callePuerta { get; set; }
        public string barrio { get; set; }
        public string ciudad { get; set; }
        public int NroCupos { get; set; }
        public int CantidadMesas { get; set; }
        public int CantidadAsientosMesa { get; set; }
        public int PrecioAsiento { get; set; }
        public string Idioma { get; set; }
        public string CriterioAsignacion { get; set; }
        public string EmpresaCreadora { get; set; }

    }
}
