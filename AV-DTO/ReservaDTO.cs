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
        public List<Asiento> Asientos { get; set; }
        public string NombreEmpresa { get; set; }
        public int Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int CantidadReservas { get; set; }
        public DateTime FechaReserva { get; set; }
        public string DescripcionEstado { get; set; }
        public ComprobanteDePago ComprobanteDePago { get; set; }

    }
}
