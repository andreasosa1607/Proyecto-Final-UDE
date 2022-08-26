using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV.DA.ServiceCorreosElectronicos
{
    public class SoporteCorreos:EnvioCorreoServer
    {
        public SoporteCorreos()
        {
            senderCorreo = "soporteclientesAV@gmail.com";
            contraseña = "xdmvcqqxcsdnfddg";
            host = "smtp.gmail.com";
            puerto = 587;
            ssl = true;
            inicializarSmtpCliente();
        }
    }
}
