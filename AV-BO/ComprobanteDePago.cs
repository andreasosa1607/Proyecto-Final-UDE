using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV.BO
{
    public class ComprobanteDePago
    {
        [Key]
        public int IdDocumento { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string Nombre { get; set; }
        
        
    }
}
