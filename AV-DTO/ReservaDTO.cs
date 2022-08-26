using AV.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AV_DTO
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }
        public ClienteDTO Cliente { get; set; }
        public EventoDTO Evento { get; set; }
        public string EstadoReserva { get; set; }
        public string ComprobantePago { get; set; }
        public AsientoDTO Asiento { get; set; }
    }
}
