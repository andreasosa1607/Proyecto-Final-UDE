using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AV.BO
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        // ver como traer opciones
        [Required]
        [Column(TypeName = "VarChar(20)")]
        public string TipoDocumento { get; set; }

        [Required]
        [Column(TypeName = "Integer")]
        public int NroDocumento { get; set; }

        [Required]
        [Column(TypeName = "VarChar(50)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string Apellidos { get; set; }

        // ver como poner formato de telefono
        [Required]
        [Column(TypeName = "Integer")]
        public int Telefono { get; set; }

        // ver como traer opciones
        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string ProfesionCargo { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string NombreEmpresa { get; set; }

        // ver esto con Emiliano (traerla por FTP)
        [Required]
        [Column(TypeName = "image")]
        public string FotoPerfil { get; set; }


    }
}
