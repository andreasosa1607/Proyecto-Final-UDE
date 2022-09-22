using AV.BO;
using System.Collections.Generic;

namespace AV.BL
{
    public static class ReservaBL
    {
        public static string EnvioCorreo(Reserva reserva)
        {
            var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
            correoService.enviarCorreo(
             asunto: "Reserva exitosa",
             cuerpo: "¡Hola " + reserva.Cliente.Nombre + "!" + "\nUsted acaba de realizar una reserva a nombre de " + reserva.nombreEmpresa + " para el evento " + reserva.Evento.Nombre + ".\n" +
             "A continuación, le detallamos los datos de su reserva y la solicitud de pago para que proceda a efectuarla , recuerde que tiene 48hs a partir de este " +
             "momento para hacer efectivo el pago y cargarlo a nuestra web ingresando a http://av/ingresarComprobante" +
             "\n \n" +
             "\n \n" +
             "\n \n" +
             "\n \b Su reserva: \b \n" +
             "\n Evento: " + reserva.Evento.Nombre + "\n" +
             "\n Identificador de reserva: " + reserva.IdReserva + "\n" +
             "\n Cantidad de asientos reservados: " + reserva.cantidadReservas + "\n" +
             "\n Valor unitario de cada asiento: " + reserva.Evento.PrecioAsiento + "\n" +
             "\n Total a pagar: " + reserva.cantidadReservas * reserva.Evento.PrecioAsiento + "\n" +
             "\n \n" +
             "\n \n" +
             "\n \n" +
             "\n Detalle del pago: \n" +
             "\n Debe realizar el deposito a nuestra cuenta BROU 002669727-00112 a nombre de AV-SA \n" +
             "\n Ingresando en el campo 'Referencia', el nombre con el que registró la reserva:( " + reserva.nombreEmpresa + ")" + " seguido del numero de referencia: " + reserva.IdReserva + "\n" +
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
             destinatarios: new List<string> { reserva.correoElectronico }
              );

            return "Ok";
        }
    }
}
