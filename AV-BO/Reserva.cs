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


        [Column(TypeName = "Asiento")]
        public List<Asiento> Asientos { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string NombreEmpresa { get; set; }

        [Required]
        [Column(TypeName = "Integer")]
        public int Telefono { get; set; }

        [Required]
        [Column(TypeName = "VarChar(50)")]
        public string CorreoElectronico { get; set; }

        [Required]
        [Column(TypeName = "Integer")]
        public int CantidadReservas { get; set; }

        [Required]
        [Column(TypeName = "DateTime")]
        public DateTime FechaReserva { get; set; }

        [Required]
        [Column(TypeName = "VarChar(50)")]
        public string DescripcionEstado { get; set; }

        public ComprobanteDePago ComprobanteDePago { get; set; }

    }
}
