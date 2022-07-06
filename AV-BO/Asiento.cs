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
        public int NroAsiento { get; set; }

        [Required]
        [Column(TypeName = "Mesa")]
        public Mesa Mesa { get; set; }

        [Required]
        [NotMapped]
        [Column(TypeName = "VarChar(20)")]
        public string CodigoQR { get; set; }

    }
}
