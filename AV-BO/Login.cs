using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AV.BO
{
    public class Login
    {
       [Required]
       [Column(TypeName = "VarChar(20)")]
        public string Rol { get; set; }

        [Required]
        [Column(TypeName = "VarChar(200)")]
        public string Contraseña { get; set; }

        [Key]
        [Required]
        [Column(TypeName = "VarChar(150)")]
        public string CorreoElectronico { get; set; }

       
    }
}