﻿using AV.BO;
using AV_DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                         "Le informamos que dicho evento ha sufrido modificaciones. Le solicitamos que ingrese a nuestra web, http://localhost:4200/listadoEvento/listadoEvento, y allí verá reflejados los respectivos cambios. " +
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
            double diferencia = evento.FechaHora.Date.Subtract(hoy.Date).TotalHours;

            if (diferencia <= 0)
            {
                evento.EstadoEvento = "Finalizado";

            }
        }
        
        public static void asientosPorMesa(Evento evento)

           {

            evento.CantidadAsientosMesa = 10;
            evento.CantidadMesas = (evento.NroCupos / evento.CantidadAsientosMesa) + 1;

           }




        public static void asignarMesas(Evento evento)
        {

            evento.Mesas = new List<Mesa>();
            for (int x = 1; x < evento.CantidadMesas +1; x++)
                {

                    Mesa nuevaMesa = new Mesa();
                    nuevaMesa.EventoId = evento.EventoId;
                    nuevaMesa.CantidadAsientos = 10;
                    nuevaMesa.LugaresDisponibles = 10;
                    nuevaMesa.NroMesa = x;


                nuevaMesa.Asientos = new List<Asiento>();
                    for (int i = 1; i < evento.CantidadAsientosMesa + 1; i++)
                    {
                        Asiento nuevoAsiento = new Asiento();
                        nuevoAsiento.MesaIdMesa = nuevaMesa.IdMesa;
                        nuevoAsiento.NroAsiento = i;
                        nuevaMesa.Asientos.Add(nuevoAsiento);

                    }
                evento.Mesas.Add(nuevaMesa);

             }
        }
        public static void GuardarArchivoFTP(string fileName, byte[] file)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://win5207.site4now.net/" + fileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("proyectoude", "pr0yect0ude2022");

            Stream requestStream = request.GetRequestStream();
            //requestStream.Write(file);

            requestStream.Write(file, 0, file.Length);
            requestStream.Close();

        }

    }
}