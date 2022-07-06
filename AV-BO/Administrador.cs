using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AV.BO
{
    public class Administrador
    {
        [Key]
        public int IdAdmin { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string NombreEmpresa { get; set; }

        [Required]
        [Column(TypeName = "Pago")]
        public Pago Pago { get; set; }
    }
}
