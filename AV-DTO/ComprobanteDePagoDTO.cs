using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV_DTO
{
    public class ComprobanteDePagoDTO
    {
        public int IdDocumento { get; set; }
        //public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }
     

    }
}
