using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV_DTO
{
   public class EditarClienteDTO
    {
        public int ClienteId { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string ProfesionCargo { get; set; }
        public string NombreEmpresa { get; set; }
        public string FotoPerfil { get; set; }
   

    }
}
