﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV.BO
{
    public class Mesa
    {
        [Key]
        public int IdMesa { get; set; }

        [Required]
        [Column(TypeName = "Integer")]
        public int NroMesa { get; set; }

    
        [Required]
        [Column(TypeName = "Integer")]
        public int CantidadAsientos { get; set; }

       
        [Required]
        [Column(TypeName = "Integer")]
        public int LugaresDisponibles { get; set; }

        public int EventoId { get; set; }

        public List<Asiento> Asientos { get; set; }


    }
}

