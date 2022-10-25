using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AV.BO
{
    public class Asiento
    {
        [Key]
        public int IdAsiento { get; set; }

        [Required]
        [Column(TypeName = "Integer")]
        public int NroAsiento { get; set; }


        [Required]
        [NotMapped]
        [Column(TypeName = "VarChar(20)")]
        public string CodigoQR { get; set; }

        //public int NroMesa { get; set; }

        public int IdMesa { get; set; }

        public int IdReserva { get; set; }

    }
}

