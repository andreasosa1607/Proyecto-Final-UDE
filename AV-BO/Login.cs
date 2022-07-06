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
       // ver como traer opciones
       [Required]
       [Column(TypeName = "VarChar(20)")]
        public string Rol { get; set; }

        // ver si es aca que se encripta
        [Required]
        [Column(TypeName = "VarChar(30)")]
        public string Contraseña { get; set; }

        // ver si esta bien que sea la key y como poner formato mail
        [Key]
        [Required]
        [Column(TypeName = "VarChar(150)")]
        public string CorreoElectronico { get; set; }
    }
}
