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
             cuerpo: "¡Hola " + reserva.Cliente.Nombre + "!" + "\n Su reserva " + reserva.NombreEmpresa + " para el evento " + reserva.Evento.Nombre + " " +
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

            if ((diferencia > 2) && (reserva.ComprobantePago==null) && (reserva.EstadoReserva=="Pendiente de pago"))
            {
                reserva.EstadoReserva = "Cancelada";
                ReservaCanceladaAutomaticamente(reserva);

            }
        }

        public static void asignacionAutomatica(Reserva reserva)
        {
            DateTime hoy = DateTime.Now;
            double diferencia = reserva.Evento.FechaHora.Date.Subtract(hoy.Date).TotalDays;
            if (diferencia <= 2)
            {
            }
        }

       

    }
}
