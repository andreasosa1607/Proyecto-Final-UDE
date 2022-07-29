using System;
using System.Collections.Generic;
using System.Text;
using AV.BO;
namespace AV_DTO
{
   public class AsientoDTO
    {
        public int NroAsiento { get; set; }
        public Mesa Mesa { get; set; }
        public string CodigoQR { get; set; }
    }
}
