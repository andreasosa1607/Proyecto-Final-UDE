using AV.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV.BL
{
    public static class EventoBL
    {
        public static string EnvioCorreo(List<Reserva> reservas, Evento evento)
        {

            if (reservas == null || reservas.Count == 0)

            {
                return ("Este evento no tiene reservas");

            }
            else
            {

                List<string> reservasList = new List<string>();
                foreach (Reserva reserva in reservas)
                {
                    if (reserva.Evento.EventoId == evento.EventoId)
                    {
                        Correo(reserva);
                    }
                }
            }
            return "ok";
        }


                private static string Correo(Reserva reserva) {
                    var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
                    correoService.enviarCorreo(
                     asunto: "Evento cancelado",
                     cuerpo: "¡Hola " + reserva.Cliente.Nombre + "!" + "\nUsted realizó una reserva a nombre de " + reserva.NombreEmpresa + " para el evento " + reserva.Evento.Nombre + ".\n" +
                     "Le informamos que por razones de fuerza mayor, el mismo ha sido cancelado " +
                     "\n \n" +
                     "\n \n" +
                     "\n Si usted ya había efectuado el pago para dicha reserva, le pedimos se comunique con nosotros vía correo Electrónico 'soporteclientesAV@gmail.com' \n" +
                     "\n Indicandonos el nombre con el que registró la reserva:( " + reserva.NombreEmpresa + ")" + " el numero de referencia: " + reserva.IdReserva + " y un teléfono de contacto, en nuestra base de datos tenemos los siguientes contactos:\n" +
                     +reserva.Cliente.Telefono + " y " + reserva.Telefono +
                     "\n Un agente de nuestro equipo de soporte se pondrá en contacto con usted para indicarle los pasos a seguir para recibir el reembolso de su dinero." +

                     "\n De parte de AV, le pedimos disculpas por los inconvenientes." +
                     "\n Le reiteramos que ante cualquier duda , puede comunicarse con nosotros via correo electronico a 'soporteclientesAV@gmail.com'" +
                      "\n \n" +
                     "\n \n" +
                      "\n \n" +
                     "\n ¡GRACIAS POR PREFERIRNOS!\n",
                     destinatarios: new List<string> { reserva.CorreoElectronico }
                      );

            return ("ok");
        }
                
            }
        }
