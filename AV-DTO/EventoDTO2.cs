﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV_DTO
{
    public class EventoDTO2
    {
        public int EventoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string ImagenPortada { get; set; }
        public string callePuerta { get; set; }
       public string barrio { get; set; }
       public string ciudad { get; set; }
        public int NroCupos { get; set; }
        public int PrecioAsiento { get; set; }
        public string Idioma { get; set; }
        public string CriterioAsignacion { get; set; }
        public string EmpresaCreadora { get; set; }


    }
}
