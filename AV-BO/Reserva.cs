using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AV.BO
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        [Required]
        [Column(TypeName = "Cliente")]
        public Cliente Cliente { get; set; }

        [Required]
        [Column(TypeName = "Evento")]
        public Evento Evento { get; set; }

        // ver como traer opciones
        [Required]
        [Column(TypeName = "VarChar(20)")]
        public string EstadoReserva { get; set; }

        // ver esto con Emiliano (traerla por FTP)
        [Required]
        [Column(TypeName = "image")]
        public string ComprobantePago { get; set; }

        [Column(TypeName = "Asiento")]
        public Asiento Asiento { get; set; }
    }
}
