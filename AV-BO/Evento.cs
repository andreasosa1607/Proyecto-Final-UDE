using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AV.BO
{
    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventoId { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "VarChar(300)")]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "VarChar(30)")]
        public string Tipo { get; set; }

        // ver esto con Emiliano (traerla por FTP)

        [Column(TypeName = "image")]
        public string ImagenPortada { get; set; }


        [Required]
        [DataType(DataType.DateTime)]

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm}", ApplyFormatInEditMode = true)]

        public DateTime FechaHora { get; set; }

        [Required]
        [Column(TypeName = "VarChar(10)")]
        public string Duracion { get; set; }



        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string CallePuerta { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string Barrio { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string Ciudad { get; set; }


        [Required]
        [Column(TypeName = "Integer")]
        public int NroCupos { get; set; }


        [Required]
        [Column(TypeName = "Integer")]
        public int CantidadMesas { get; set; }


        [Required]
        [Column(TypeName = "Integer")]
        public int CantidadAsientosMesa { get; set; }


        [Required]
        [Column(TypeName = "Integer")]
        public int PrecioAsiento { get; set; }

        // VER como traerla ya con las opciones
        [Required]
        [Column(TypeName = "VarChar(20)")]
        public string Idioma { get; set; }

        // VER como traerla ya con las opciones
        [Required]
        [Column(TypeName = "VarChar(20)")]
        public string CriterioAsignacion { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")]
        public string EmpresaCreadora { get; set; }

        [Required]
        [Column(TypeName = "Varchar(30)")]
        public string EstadoEvento { get; set; }

        public List<Mesa> Mesas { get; set; }

    }
}
}
