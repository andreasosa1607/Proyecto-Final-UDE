﻿using System;
using System.Collections.Generic;
using System.Text;
using AV.BO;
namespace AV_DTO
{
    public class AsientoDTO
    {
        public int IdAsiento { get; set; }
        public int NroAsiento { get; set; }
        public int IdMesa { get; set; }
        public int IdReserva { get; set; }
        public string CodigoQR { get; set; }
    }
}

