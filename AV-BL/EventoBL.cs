using AV.BO;
using AV_DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV.BL
{
    public static class EventoBL
    {
        public static string EnvioCorreoEventoEliminado(List<Reserva> reservas, Evento evento)
        {

            if (reservas == null || reservas.Count == 0)

            {
                return ("Este evento no tiene reservas");

            }
            else
            {

                foreach (Reserva reserva in reservas)
                {
                    if (reserva.Evento.EventoId == evento.EventoId)
                    {
                        var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
                        correoService.enviarCorreo(
                         asunto: "Evento cancelado",
                         cuerpo: "¡Hola " + reserva.Cliente.Nombre + "!" + "\nUsted realizó una reserva a nombre de " + reserva.NombreEmpresa + " para el evento " + reserva.Evento.Nombre + ".\n" +
                         "Le informamos que por razones de fuerza mayor, el mismo ha sido cancelado " +
                         "\n \n" +
                         "\n \n" +
                         "\n Si usted ya había efectuado el pago para dicha reserva, le pedimos se comunique con nosotros vía correo Electrónico 'soporteclientesAV@gmail.com' \n" +
                         "\n Indicandonos el nombre con el que registró la reserva:( " + reserva.NombreEmpresa + ")" + " el numero de referencia: (" + reserva.IdReserva + ") y un teléfono de contacto, en nuestra base de datos tenemos los siguientes contactos:\n" + "0" + reserva.Telefono +
                         "\n Un agente de nuestro equipo de soporte se pondrá en contacto con usted para indicarle los pasos a seguir para recibir el reembolso de su dinero." +

                         "\n De parte de AV, le pedimos disculpas por los inconvenientes." +
                         "\n Le reiteramos que ante cualquier duda , puede comunicarse con nosotros via correo electronico a 'soporteclientesAV@gmail.com'" +
                          "\n \n" +
                         "\n \n" +
                          "\n \n" +
                         "\n ¡GRACIAS POR PREFERIRNOS!\n",
                         destinatarios: new List<string> { reserva.CorreoElectronico }
                          );
                    }
                }
            }
            return "ok";
        }

        public static string EnvioCorreoEventoModificado(List<Reserva> reservas, Evento evento)
        {

            if (reservas == null || reservas.Count == 0)

            {
                return ("Este evento no tiene reservas");

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
            else
            {

                foreach (Reserva reserva in reservas)
                {
                    if (reserva.Evento.EventoId == evento.EventoId)
                    {
                        var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
                        correoService.enviarCorreo(
                         asunto: "Evento modificado",
                         cuerpo: "¡Hola " + reserva.Cliente.Nombre + "!" + "\nUsted realizó una reserva a nombre de " + reserva.NombreEmpresa + " para el evento " + reserva.Evento.Nombre + ".\n" +
                         "Le informamos que dicho evento ha sufrido modificaciones. Le solicitamos que ingrese a nuestra web, www.av.com.uy, y allí verá reflejados los respectivos cambios. " +
                         "\n \n" +
                         "\n \n" +
                         "\n Si usted ya había efectuado el pago para dicha reserva, y no está de acuerdo o no le es posible adaptarse a los cambios del evento, puede solicitar el reembolso de su dinero(sujeto a aprobación),  le pedimos se comunique con nosotros vía correo Electrónico 'soporteclientesAV@gmail.com' \n" +
                         "\n Indicandonos el nombre con el que registró la reserva:( " + reserva.NombreEmpresa + ")" + " el numero de referencia: (" + reserva.IdReserva + ") y un teléfono de contacto, en nuestra base de datos tenemos los siguientes contactos:\n" + "0" + reserva.Telefono +
                         "\n Un agente de nuestro equipo de soporte se pondrá en contacto con usted para indicarle los pasos a seguir." +

                         "\n De parte de AV, le pedimos disculpas por los inconvenientes." +
                         "\n Le reiteramos que ante cualquier duda , puede comunicarse con nosotros via correo electronico a 'soporteclientesAV@gmail.com'" +
                          "\n \n" +
                         "\n \n" +
                          "\n \n" +
                         "\n ¡GRACIAS POR PREFERIRNOS!\n",
                         destinatarios: new List<string> { reserva.CorreoElectronico }
                          );
                    }
                }
            }
            return "ok";
        }

        public static void cambiarEstadoEvento(Evento evento)
        {
            DateTime hoy = DateTime.Now;
            double diferencia = evento.FechaHora.Date.Subtract(hoy.Date).TotalDays;

            if (diferencia <= 0)
            {
                evento.EstadoEvento = "Finalizado";

            }
        }

        public static void asientosPorMesa(Evento evento)
        {
            double cntMesas = evento.NroCupos / evento.CantidadAsientosMesa;
            evento.CantidadAsientosMesa = 10;
            evento.CantidadMesas = (int)Math.Ceiling(cntMesas);

        }

        public static List<Mesa> asignarMesas(Evento evento)
        {
            List<Mesa> mesas = new List<Mesa>();
           
            for (int x = 1; x < evento.CantidadMesas +1; x++)
            {
                Mesa nuevaMesa = new Mesa();
                nuevaMesa.CantidadAsientos = 10;
                nuevaMesa.LugaresDisponibles = 10;
                nuevaMesa.NroMesa = x;
                mesas.Add(nuevaMesa);

            }

            return mesas;


        }
    }
}