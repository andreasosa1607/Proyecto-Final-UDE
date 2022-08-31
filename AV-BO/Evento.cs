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
        public DateTime Fecha { get; set; }


        [Required]
        [Column(TypeName = "Integer")]
        public int Duracion { get; set; }


        [Required]
        [Column(TypeName = "Varchar(10)")]
        public string Hora { get; set; }


        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string callePuerta { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string barrio { get; set; }

        [Required]
        [Column(TypeName = "VarChar(100)")]
        public string ciudad { get; set; }


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
    
    
    }
}
