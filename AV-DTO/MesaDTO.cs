using System;
using System.Collections.Generic;
using System.Text;
using AV.BO;

namespace AV_DTO
{
    public class MesaDTO
    {
        public int IdMesa { get; set; }
        public int NroMesa { get; set; }
        public int CantidadAsientos { get; set; }
        public int LugaresDisponibles { get; set; }
        public int EventoId { get; set; }

        public List<Asiento> Asientos { get; set; }
    }
}
