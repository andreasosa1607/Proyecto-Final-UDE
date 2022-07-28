using AV.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AV_DTO
{
   public class PagoDTO
    {
        public int IdPago { get; set; }
        public string SolicitudPago { get; set; }
        public string EstadoPago { get; set; }
        public string Comentario { get; set; }
        public string InvitacionEvento { get; set; }
        public Reserva Reserva { get; set; }
    }
}
