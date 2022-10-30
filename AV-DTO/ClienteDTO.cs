using AV.BO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AV_DTO
{
     public class ClienteDTO
    {
        public int ClienteId { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string ProfesionCargo { get; set; }
        public string NombreEmpresa { get; set; }
        public string IdiomaPreferencia { get; set; }
        public Login login { get; set; }

    }
}
