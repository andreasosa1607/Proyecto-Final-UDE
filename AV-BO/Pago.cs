using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AV.BO
{
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }

        // ver que tipo de dato es esto
        [Required]
        [NotMapped]
        [Column(TypeName = "VarChar(100)")]
        public string solicitudPago { get; set; }


        // ver como traer opciones
        [Required]
        [Column(TypeName = "VarChar(20)")]
        public string EstadoPago { get; set; }

        [Required]
        [Column(TypeName = "VarChar(200)")]
        public string Comentario { get; set; }

        // ver que tipo de dato es esto
        [Required]
        [NotMapped]
        [Column(TypeName = "VarChar(100)")]
        public string InvitacionEvento { get; set; }
    
        [Required]
        [Column(TypeName = "Reserva")]
        public Reserva Reserva { get; set; }
    
    }
}
