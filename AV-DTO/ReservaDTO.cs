using AV.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AV_DTO
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }
        public Cliente Cliente { get; set; }
        public Evento Evento { get; set; }
        public string EstadoReserva { get; set; }
        public string ComprobantePago { get; set; }
        public List<Asiento> Asientos { get; set; }
        public string NombreEmpresa { get; set; }
        public int Telefono { get; set; }
        public string correoElectronico { get; set; }
        public int cantidadReservas { get; set; }
    }
}
