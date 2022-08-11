using AV.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AV_DTO
{
    public class AdministradorDTO
    {
        public int IdAdmin { get; set; }
        public string NombreEmpresa { get; set; }
        public PagoDTO Pago { get; set; }
    }
}
