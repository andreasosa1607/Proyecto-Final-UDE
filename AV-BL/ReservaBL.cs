using AV.BO;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System;

namespace AV.BL
{
    public static class ReservaBL
    {
        public static string EnvioCorreo(Reserva reserva)
        {
            var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
            correoService.enviarCorreo(
             asunto: "Reserva exitosa",
             cuerpo: "¡Hola " + reserva.Cliente.Nombre + "!" + "\nUsted acaba de realizar una reserva a nombre de " + reserva.NombreEmpresa + " para el evento " + reserva.Evento.Nombre + ".\n" +
             "A continuación, le detallamos los datos de su reserva y la solicitud de pago para que proceda a efectuarla , recuerde que tiene 48hs a partir de este " +
             "momento para hacer efectivo el pago y cargarlo a nuestra web ingresando a http://av/ingresarComprobante" +
             "\n \n" +
             "\n \n" +
             "\n \n" +
             "\n \b Su reserva: \b \n" +
             "\n Evento: " + reserva.Evento.Nombre + "\n" +
             "\n Identificador de reserva: " + reserva.IdReserva + "\n" +
             "\n Cantidad de asientos reservados: " + reserva.CantidadReservas + "\n" +
             "\n Valor unitario de cada asiento: " + reserva.Evento.PrecioAsiento + "\n" +
             "\n Total a pagar: " + reserva.CantidadReservas * reserva.Evento.PrecioAsiento + "\n" +
             "\n \n" +
             "\n \n" +
             "\n \n" +
             "\n Detalle del pago: \n" +
             "\n Debe realizar el deposito a nuestra cuenta BROU 002669727-00112 a nombre de AV-SA \n" +
             "\n Ingresando en el campo 'Referencia', el nombre con el que registró la reserva:( " + reserva.NombreEmpresa + ")" + " seguido del numero de referencia: " + reserva.IdReserva + "\n" +
             "\n Al realizarla, le solicitamos que tome una foto o captura de pantalla del comprobante (esta debe ser NITIDA Y CLARA)" +
             "Ingrese a nuestra web http://av/ingresarComprobante , seleccione la opcion cargar archivo," +
             "en el campo 'Referencia' porfavor ingrese el identificador de reserva indicado más arriba en este correo (" + reserva.IdReserva + ") y seleccione enviar." +
             "\n No salga de la web hasta que el formulario le dé resultado éxitoso. \n" +
             "\n \n" +
             "\n \n" +
             "\n Su comprobante de pago quedará pendiente de aprobación de parte del sistema de soporte de AV, ni bien obtenga un resultado" +
             " (aprobado o rechazado) , le notificaremos vía correo electrónico\n" +
             "\n Ante cualquier duda , puede comunicarse con nosotros via correo electronico a 'soporteclientesAV@gmail.com'" +
              "\n \n" +
             "\n \n" +
              "\n \n" +
             "\n ¡GRACIAS POR PREFERIRNOS!\n",
             destinatarios: new List<string> { reserva.CorreoElectronico }
              );

            return "Ok";


        }

        public static string ReservaCancelada(Reserva reserva)
        {
            var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
            correoService.enviarCorreo(
             asunto: "Reserva cancelada",
             cuerpo: "¡Hola " + reserva.Cliente.Nombre + "!" + "\n Su reserva " + reserva.NombreEmpresa + " para el evento " + reserva.Evento.Nombre + " " +
             "ha sido cancelada con éxito. \n" +
             "\n \n" +
             "\n \n" +
             "\n Ante cualquier duda , puede comunicarse con nosotros via correo electronico a 'soporteclientesAV@gmail.com'" +
              "\n \n" +
             "\n \n" +
              "\n \n" +
             "\n ¡GRACIAS POR PREFERIRNOS!\n",
             destinatarios: new List<string> { reserva.CorreoElectronico }
              );

            return "Ok";
        }


        public static string GenerarQR(Reserva reserva)
        {
            Document doc = new Document(PageSize.A4);
            string ruta = @"C:\Users\Andrea\OneDrive\Escritorio\Proyecto Final\Proyecto-Final-UDE\Codigos QR\" + reserva.NombreEmpresa + reserva.IdReserva + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();
            BarcodeQRCode barcodeQRCode = new BarcodeQRCode(reserva.NombreEmpresa + " ID de Reserva: " + reserva.IdReserva + " Asiento: " + reserva.Asientos, 1000, 1000, null);
            Image codeQRImage = barcodeQRCode.GetImage();
            codeQRImage.ScaleAbsolute(200, 200);
            doc.Add(codeQRImage);
            doc.Close();


            return ruta;
        }


        public static string ReservaCanceladaAutomaticamente(Reserva reserva)
        {
            var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
            correoService.enviarCorreo(
             asunto: "Reserva cancelada",
             cuerpo: "¡Hola " + reserva.NombreEmpresa + "!" + "\n Su reserva " + " para el evento " + reserva.Evento.Nombre + " " +
             "ha sido cancelada debido a que se excedieron las 48 horas de plazo para realizar el pago de la misma. \n" +
             "\n \n" +
             "\n \n" +
             "\n Ante cualquier duda , puede comunicarse con nosotros via correo electronico a 'soporteclientesAV@gmail.com'" +
              "\n \n" +
             "\n \n" +
              "\n \n" +
             "\n ¡GRACIAS POR PREFERIRNOS!\n",
             destinatarios: new List<string> { reserva.CorreoElectronico }
              );

            return "Ok";
        }



        public static void cancelarReserva(Reserva reserva)
        {
            DateTime hoy = DateTime.Now;
            double diferencia = reserva.FechaReserva.Date.Subtract(hoy.Date).TotalDays;

            if ((diferencia > 2) && (reserva.ComprobanteDePago==null) && (reserva.EstadoReserva=="Pendiente de pago"))
            {
                reserva.EstadoReserva = "Cancelada";
                ReservaCanceladaAutomaticamente(reserva);

            }
        }

        public static string ReservaAprobadaORechazada(Reserva reserva)
        {
            var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
            correoService.enviarCorreo(
             asunto: "Reserva " + reserva.EstadoReserva,
             cuerpo: "¡Hola " + reserva.NombreEmpresa + "!" + "\n Su comprobante de pago cargado " + "para el evento " + reserva.Evento.Nombre + " " +
             "ha sido " + reserva.EstadoReserva + "y el comentario ingresado por la empresa creadora fué" + reserva.DescripcionEstado + "\n" +
             "\n \n" +
             "\n \n" +
             "\n Ante cualquier duda , puede comunicarse con nosotros via correo electronico a 'soporteclientesAV@gmail.com'" +
              "\n \n" +
             "\n \n" +
              "\n \n" +
             "\n ¡GRACIAS POR PREFERIRNOS!\n",
             destinatarios: new List<string> { reserva.CorreoElectronico }
              );

            return "Ok";
        }



        public static void asignacionAutomatica(List<Reserva> reservas)
        {
            List<Reserva> idiomaEspañol = new List<Reserva>();
            List<Reserva> idiomaIngles = new List<Reserva>();
            List<Reserva> idiomaChinoMandarin = new List<Reserva>();
            List<Reserva> idiomaOtro = new List<Reserva>();

            List<Reserva> rubroIngenieria = new List<Reserva>();
            List<Reserva> rubroInformatica = new List<Reserva>();
            List<Reserva> rubroAdministracion = new List<Reserva>();
            List<Reserva> rubroOtro = new List<Reserva>();

            DateTime hoy = DateTime.Now;

            foreach (Reserva reserva in reservas)
            {
                double diferencia = reserva.Evento.FechaHora.Date.Subtract(hoy.Date).TotalDays;
                if (diferencia <= 1 && reserva.EstadoReserva == "Aprobada")
                {
                    if (reserva.Evento.CriterioAsignacion == "Idioma")
                    {
                        if (reserva.Cliente.IdiomaPreferencia == "Español")
                        {
                            idiomaEspañol.Add(reserva);
                        } else if (reserva.Cliente.IdiomaPreferencia == "Ingles")
                        {
                            idiomaIngles.Add(reserva);
                        }else if (reserva.Cliente.IdiomaPreferencia == "Chino Mandarin")
                        {
                            idiomaChinoMandarin.Add(reserva);
                        }
                        else
                        {
                            idiomaOtro.Add(reserva);
                        }
                     
                      
                    }
                    else if (reserva.Evento.CriterioAsignacion == "Rubro")
                    {
                        if(reserva.Cliente.ProfesionCargo == "Ingenieria")
                        {
                            rubroIngenieria.Add(reserva);
                        }else if(reserva.Cliente.ProfesionCargo == "Informatica")
                        {
                            rubroInformatica.Add(reserva);
                        }else if(reserva.Cliente.ProfesionCargo == "Administración")
                        {
                            rubroAdministracion.Add(reserva);
                        }
                        else
                        {
                            rubroOtro.Add(reserva);
                        }
                    }
                }
            }

            foreach (Reserva reservaIdioma in idiomaEspañol)
            {
                foreach (Mesa mesa in reservaIdioma.Evento.Mesas)
                {
                    if (reservaIdioma.EstadoReserva == "Aprobada")
                    {

                        for (int x = 0; (x < reservaIdioma.CantidadReservas) && (x < mesa.LugaresDisponibles); x++)
                        {
                            foreach (Asiento asiento in mesa.Asientos)
                            {
                                asiento.IdReserva = reservaIdioma.IdReserva;
                                asiento.NroMesa = mesa.NroMesa;
                                reservaIdioma.Asientos.Add(asiento);
                                reservaIdioma.EstadoReserva = "Asignada";
                                mesa.LugaresDisponibles = -1;
                            }
                        }
                    }
                }
            }
            foreach (Reserva reservaIdioma in idiomaIngles)
            {
                foreach (Mesa mesa in reservaIdioma.Evento.Mesas)
                {
                    if (reservaIdioma.EstadoReserva == "Aprobada")
                    {

                        for (int x = 0; (x < reservaIdioma.CantidadReservas) && (x < mesa.LugaresDisponibles); x++)
                        {
                            foreach (Asiento asiento in mesa.Asientos)
                            {
                                asiento.IdReserva = reservaIdioma.IdReserva;
                                asiento.NroMesa = mesa.NroMesa;
                                reservaIdioma.Asientos.Add(asiento);
                                reservaIdioma.EstadoReserva = "Asignada";
                                mesa.LugaresDisponibles = -1;
                            }
                        }
                    }
                }
            }
            foreach (Reserva reservaIdioma in idiomaChinoMandarin)
            {
                foreach (Mesa mesa in reservaIdioma.Evento.Mesas)
                {
                    if (reservaIdioma.EstadoReserva == "Aprobada")
                    {

                        for (int x = 0; (x < reservaIdioma.CantidadReservas) && (x < mesa.LugaresDisponibles); x++)
                        {
                            foreach (Asiento asiento in mesa.Asientos)
                            {
                                asiento.IdReserva = reservaIdioma.IdReserva;
                                asiento.NroMesa = mesa.NroMesa;
                                reservaIdioma.Asientos.Add(asiento);
                                reservaIdioma.EstadoReserva = "Asignada";
                                mesa.LugaresDisponibles = -1;
                            }
                        }
                    }
                }
            }
            foreach (Reserva reservaIdioma in idiomaOtro)
            {
                foreach (Mesa mesa in reservaIdioma.Evento.Mesas)
                {
                    if (reservaIdioma.EstadoReserva == "Aprobada")
                    {

                        for (int x = 0; (x < reservaIdioma.CantidadReservas) && (x < mesa.LugaresDisponibles); x++)
                        {
                            foreach (Asiento asiento in mesa.Asientos)
                            {
                                asiento.IdReserva = reservaIdioma.IdReserva;
                                asiento.NroMesa = mesa.NroMesa;
                                reservaIdioma.Asientos.Add(asiento);
                                reservaIdioma.EstadoReserva = "Asignada";
                                mesa.LugaresDisponibles = -1;
                            }
                        }
                    }
                }
            }

            foreach (Reserva reservaSinAsignar in reservas)
            {
                foreach(Mesa mesa in reservaSinAsignar.Evento.Mesas)
                {
                    if ((reservaSinAsignar.EstadoReserva == "Aprobada") && (mesa.CantidadAsientos >= reservaSinAsignar.CantidadReservas))
                    {
                        for (int x = 0; (x < reservaSinAsignar.CantidadReservas) && (x < mesa.LugaresDisponibles); x++)
                        {
                            foreach (Asiento asiento in mesa.Asientos)
                            {
                                asiento.IdReserva = reservaSinAsignar.IdReserva;
                                asiento.NroMesa = mesa.NroMesa;
                                reservaSinAsignar.Asientos.Add(asiento);
                                reservaSinAsignar.EstadoReserva = "Asignada";
                                mesa.LugaresDisponibles = -1;
                            }
                        }
                    }
                }
               
            }
        }


    }
}
