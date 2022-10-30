using AV.BO;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System;
using System.Net;
using System.Text;

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
             "momento para hacer efectivo el pago y cargarlo a nuestra web http://localhost:4200/cliente/reservas-cliente , en la sección 'Ver mis reservas'" +
             "\n \n" +
             "\n \n" +
             "\n \n" +
             "\n \b Su reserva: \b \n" +
             "\n Evento: " + reserva.Evento.Nombre + "\n" +
             "\n Identificador de reserva: " + reserva.IdReserva + "\n" +
             "\n Cantidad de asientos reservados: " + reserva.CantidadReservas + "\n" +
             "\n Valor unitario de cada asiento: " + reserva.Evento.Moneda + reserva.Evento.PrecioAsiento + "\n" +
             "\n Total a pagar: " + reserva.Evento.Moneda + reserva.CantidadReservas * reserva.Evento.PrecioAsiento + "\n" +
             "\n \n" +
             "\n \n" +
             "\n \n" +
             "\n Detalle del pago: \n" +
             "\n Debe realizar el deposito a nuestra cuenta BROU 002669727-00112 a nombre de AV-SA \n" +
             "\n Ingresando en el campo 'Referencia', el nombre con el que registró la reserva:( " + reserva.NombreEmpresa + ")" + " seguido del numero de referencia: " + reserva.IdReserva + "\n" +
             "\n Al realizarla, le solicitamos que tome una foto o captura de pantalla del comprobante (esta debe ser NITIDA Y CLARA)" +
             "Ingrese a nuestra web http://localhost:4200/cliente/reservas-cliente , seleccione la opcion 'Ingresar comprobante de pago'," +
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

        public static string EnvioCorreoSinCosto(Reserva reserva)
        {
            var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
            correoService.enviarCorreo(
             asunto: "Reserva exitosa",
             cuerpo: "¡Hola " + reserva.Cliente.Nombre + "!" + "\nUsted acaba de realizar una reserva a nombre de " + reserva.NombreEmpresa + " para el evento " + reserva.Evento.Nombre + ".\n" +
             "A continuación, le detallamos los datos de su reserva" +
             "\n \n" +
             "\n \n" +
             "\n \n" +
             "\n \b Su reserva: \b \n" +
             "\n Evento: " + reserva.Evento.Nombre + "\n" +
             "\n Identificador de reserva: " + reserva.IdReserva + "\n" +
             "\n Cantidad de asientos reservados: " + reserva.CantidadReservas + "\n" +
             "\n Valor unitario de cada asiento: " + "SIN COSTO" + "\n" +
             "\n \n" +
             "\n \n" +
             "\n \n" +
              "\n 24hs antes del evento le llegará su invitación con el codigo QR correspondiente" +
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
            double diferencia = reserva.FechaReserva.Date.Subtract(hoy.Date).TotalHours;

            if ((diferencia > 48) && (reserva.ComprobanteDePago==null) && (reserva.EstadoReserva=="Pendiente de pago"))
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
              "\n Si el resultado fué positivo, 24hs antes del evento recibirá un correo con la invitación y el código QR correspondiente, de lo contrario, puede volver a cargar su comprobante de pago." +
             "\n Ante cualquier duda , puede comunicarse con nosotros via correo electronico a 'soporteclientesAV@gmail.com'" +
              "\n \n" +
             "\n \n" +
              "\n \n" +
             "\n ¡GRACIAS POR PREFERIRNOS!\n",
             destinatarios: new List<string> { reserva.CorreoElectronico }
              );

            return "Ok";
        }



        public static void asignacionAutomatica(List<Reserva> reservas, List<Mesa> mesas, List<Asiento> asientos, AV.DA.AVDBContext _context)
        {
            List<Reserva> idiomaEspañol = new List<Reserva>();
            List<Reserva> idiomaIngles = new List<Reserva>();
            List<Reserva> idiomaFrances = new List<Reserva>();
            List<Reserva> idiomaOtro = new List<Reserva>();

            List<Reserva> rubroIngenieria = new List<Reserva>();
            List<Reserva> rubroInformatica = new List<Reserva>();
            List<Reserva> rubroAdministracion = new List<Reserva>();
            List<Reserva> rubroOtro = new List<Reserva>();

            DateTime hoy = DateTime.Now;

            foreach (Reserva reserva in reservas)

            {
                double diferencia = reserva.Evento.FechaHora.Date.Subtract(hoy.Date).TotalHours;
                if (diferencia <= 24 && reserva.EstadoReserva == "Aprobada")
                {
                    if (reserva.Evento.CriterioAsignacion == "Idioma")
                    {
                        if (reserva.Cliente.IdiomaPreferencia == "Español")
                        {
                            idiomaEspañol.Add(reserva);
                        }
                        else if (reserva.Cliente.IdiomaPreferencia == "Ingles")
                        {
                            idiomaIngles.Add(reserva);
                        }
                        else if (reserva.Cliente.IdiomaPreferencia == "Frances")
                        {
                            idiomaFrances.Add(reserva);
                        }
                        else
                        {
                            idiomaOtro.Add(reserva);
                        }


                    }
                    else if (reserva.Evento.CriterioAsignacion == "Rubro")
                    {
                        if (reserva.Cliente.ProfesionCargo == "Ingenieria")
                        {
                            rubroIngenieria.Add(reserva);
                        }
                        else if (reserva.Cliente.ProfesionCargo == "Informatica")
                        {
                            rubroInformatica.Add(reserva);
                        }
                        else if (reserva.Cliente.ProfesionCargo == "Administración")
                        {
                            rubroAdministracion.Add(reserva);
                        }
                        else
                        {
                            rubroOtro.Add(reserva);
                        }
                    }
                }


                foreach (Reserva reservaIdioma in idiomaEspañol)
                {
                    int asientosAsignados = 0;
                    reservaIdioma.Asientos = new List<Asiento>();
                    string asignado = "";

                    foreach (Mesa mesa in mesas)
                    {
                        foreach (Asiento asiento in asientos)
                        {
                            if (reservaIdioma.EstadoReserva == "Aprobada" && asiento.IdReserva == 0)
                            {
                                if (mesa.IdMesa == asiento.MesaIdMesa)
                                {
                                    for (int x = 1; (x <= reservaIdioma.CantidadReservas) && (x <= mesa.LugaresDisponibles) && asiento.IdReserva == 0; x++)
                                    {
                                        if (asiento.MesaIdMesa == mesa.IdMesa && mesa.EventoId == reservaIdioma.Evento.EventoId && asiento.IdReserva == 0 && reservaIdioma.EstadoReserva == "Aprobada")
                                        {
                                            asiento.IdReserva = reservaIdioma.IdReserva;
                                            reservaIdioma.Asientos.Add(asiento);
                                            mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                                            asientosAsignados = asientosAsignados + 1;
                                            reservaIdioma.ReservasSinAsignar = (reservaIdioma.ReservasSinAsignar) - 1;
                                            asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                                            _context.SaveChanges();
                                            if (asientosAsignados >= reservaIdioma.CantidadReservas && reservaIdioma.ReservasSinAsignar == 0)
                                            {
                                                reservaIdioma.EstadoReserva = "Asignada";
                                                GenerarQR(reservaIdioma);
                                                _context.SaveChanges();
                                                ReservaAsignada(reservaIdioma, reservaIdioma.CodigoQR, asignado);
                                                asientosAsignados = 0;

                                            }

                                        }
                                    }

                                }

                            }
                        }

                    }



                }
                foreach (Reserva reservaIdioma in idiomaIngles)
                {
                    int asientosAsignados = 0;
                    reservaIdioma.Asientos = new List<Asiento>();
                    string asignado = "";

                    foreach (Mesa mesa in mesas)
                    {
                        foreach (Asiento asiento in asientos)
                        {
                            if (reservaIdioma.EstadoReserva == "Aprobada" && asiento.IdReserva == 0)
                            {
                                if (mesa.IdMesa == asiento.MesaIdMesa)
                                {
                                    for (int x = 1; (x <= reservaIdioma.CantidadReservas) && (x <= mesa.LugaresDisponibles) && asiento.IdReserva == 0; x++)
                                    {
                                        if (asiento.MesaIdMesa == mesa.IdMesa && mesa.EventoId == reservaIdioma.Evento.EventoId && asiento.IdReserva == 0 && reservaIdioma.EstadoReserva == "Aprobada")
                                        {
                                            asiento.IdReserva = reservaIdioma.IdReserva;
                                            reservaIdioma.Asientos.Add(asiento);
                                            mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                                            asientosAsignados = asientosAsignados + 1;
                                            reservaIdioma.ReservasSinAsignar = (reservaIdioma.ReservasSinAsignar) - 1;
                                            asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                                            _context.SaveChanges();
                                            if (asientosAsignados >= reservaIdioma.CantidadReservas && reservaIdioma.ReservasSinAsignar == 0)
                                            {
                                                reservaIdioma.EstadoReserva = "Asignada";
                                                GenerarQR(reservaIdioma);
                                                _context.SaveChanges();
                                                ReservaAsignada(reservaIdioma, reservaIdioma.CodigoQR, asignado);
                                                asientosAsignados = 0;

                                            }

                                        }
                                    }

                                }

                            }
                        }

                    }
                }

                foreach (Reserva reservaIdioma in idiomaFrances)
                {
                    int asientosAsignados = 0;
                    reservaIdioma.Asientos = new List<Asiento>();
                    string asignado = "";

                    foreach (Mesa mesa in mesas)
                    {
                        foreach (Asiento asiento in asientos)
                        {
                            if (reservaIdioma.EstadoReserva == "Aprobada" && asiento.IdReserva == 0)
                            {
                                if (mesa.IdMesa == asiento.MesaIdMesa)
                                {
                                    for (int x = 1; (x <= reservaIdioma.CantidadReservas) && (x <= mesa.LugaresDisponibles) && asiento.IdReserva == 0; x++)
                                    {
                                        if (asiento.MesaIdMesa == mesa.IdMesa && mesa.EventoId == reservaIdioma.Evento.EventoId && asiento.IdReserva == 0 && reservaIdioma.EstadoReserva == "Aprobada")
                                        {
                                            asiento.IdReserva = reservaIdioma.IdReserva;
                                            reservaIdioma.Asientos.Add(asiento);
                                            mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                                            asientosAsignados = asientosAsignados + 1;
                                            reservaIdioma.ReservasSinAsignar = (reservaIdioma.ReservasSinAsignar) - 1;
                                            asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                                            _context.SaveChanges();
                                            if (asientosAsignados >= reservaIdioma.CantidadReservas && reservaIdioma.ReservasSinAsignar == 0)
                                            {
                                                reservaIdioma.EstadoReserva = "Asignada";
                                                GenerarQR(reservaIdioma);
                                                _context.SaveChanges();
                                                ReservaAsignada(reservaIdioma, reservaIdioma.CodigoQR, asignado);
                                                asientosAsignados = 0;

                                            }

                                        }
                                    }

                                }

                            }
                        }

                    }
                }
                foreach (Reserva reservaIdioma in idiomaOtro)
                {
                    if (reservaIdioma.ReservasSinAsignar >= 1)
                    {
                        int asientosAsignados = 0;
                        reservaIdioma.Asientos = new List<Asiento>();
                        string asignado = "";

                        foreach (Mesa mesa in mesas)
                        {
                            foreach (Asiento asiento in asientos)
                            {
                                if (reservaIdioma.EstadoReserva == "Aprobada" && asiento.IdReserva == 0)
                                {
                                    if (mesa.IdMesa == asiento.MesaIdMesa)
                                    {
                                        for (int x = 1; (x <= reservaIdioma.CantidadReservas) && (x <= mesa.LugaresDisponibles) && asiento.IdReserva == 0; x++)
                                        {
                                            if (asiento.MesaIdMesa == mesa.IdMesa && mesa.EventoId == reservaIdioma.Evento.EventoId && asiento.IdReserva == 0 && reservaIdioma.EstadoReserva == "Aprobada")
                                            {
                                                asiento.IdReserva = reservaIdioma.IdReserva;
                                                reservaIdioma.Asientos.Add(asiento);
                                                mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                                                asientosAsignados = asientosAsignados + 1;
                                                reservaIdioma.ReservasSinAsignar = (reservaIdioma.ReservasSinAsignar) - 1;
                                                asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                                                _context.SaveChanges();
                                                if (asientosAsignados >= reservaIdioma.CantidadReservas && reservaIdioma.ReservasSinAsignar == 0)
                                                {
                                                    reservaIdioma.EstadoReserva = "Asignada";
                                                    GenerarQR(reservaIdioma);
                                                    _context.SaveChanges();
                                                    ReservaAsignada(reservaIdioma, reservaIdioma.CodigoQR, asignado);
                                                    asientosAsignados = 0;

                                                }

                                            }
                                        }

                                    }

                                }
                            }

                        }

                    }

                }
                    foreach (Reserva reservaRubro in rubroAdministracion)
                    {
                        int asientosAsignados = 0;
                        reservaRubro.Asientos = new List<Asiento>();
                        string asignado = "";

                        foreach (Mesa mesa in mesas)
                        {
                            foreach (Asiento asiento in asientos)
                            {
                                if (reservaRubro.EstadoReserva == "Aprobada" && asiento.IdReserva == 0)
                                {
                                    if (mesa.IdMesa == asiento.MesaIdMesa)
                                    {
                                        for (int x = 1; (x <= reservaRubro.CantidadReservas) && (x <= mesa.LugaresDisponibles) && asiento.IdReserva == 0; x++)
                                        {
                                            if (asiento.MesaIdMesa == mesa.IdMesa && mesa.EventoId == reservaRubro.Evento.EventoId && asiento.IdReserva == 0 && reservaRubro.EstadoReserva == "Aprobada")
                                            {
                                                asiento.IdReserva = reservaRubro.IdReserva;
                                                reservaRubro.Asientos.Add(asiento);
                                                mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                                                asientosAsignados = asientosAsignados + 1;
                                                reservaRubro.ReservasSinAsignar = (reservaRubro.ReservasSinAsignar) - 1;
                                                asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                                                _context.SaveChanges();
                                                if (asientosAsignados >= reservaRubro.CantidadReservas && reservaRubro.ReservasSinAsignar == 0)
                                                {
                                                    reservaRubro.EstadoReserva = "Asignada";
                                                    GenerarQR(reservaRubro);
                                                    _context.SaveChanges();
                                                    ReservaAsignada(reservaRubro, reservaRubro.CodigoQR, asignado);
                                                    asientosAsignados = 0;

                                                }

                                            }
                                        }

                                    }

                                }
                            }

                        }



                    }

                    foreach (Reserva reservaRubro in rubroInformatica)
                    {
                    int asientosAsignados = 0;
                    reservaRubro.Asientos = new List<Asiento>();
                    string asignado = "";

                    foreach (Mesa mesa in mesas)
                    {
                        foreach (Asiento asiento in asientos)
                        {
                            if (reservaRubro.EstadoReserva == "Aprobada" && asiento.IdReserva == 0)
                            {
                                if (mesa.IdMesa == asiento.MesaIdMesa)
                                {
                                    for (int x = 1; (x <= reservaRubro.CantidadReservas) && (x <= mesa.LugaresDisponibles) && asiento.IdReserva == 0; x++)
                                    {
                                        if (asiento.MesaIdMesa == mesa.IdMesa && mesa.EventoId == reservaRubro.Evento.EventoId && asiento.IdReserva == 0 && reservaRubro.EstadoReserva == "Aprobada")
                                        {
                                            asiento.IdReserva = reservaRubro.IdReserva;
                                            reservaRubro.Asientos.Add(asiento);
                                            mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                                            asientosAsignados = asientosAsignados + 1;
                                            reservaRubro.ReservasSinAsignar = (reservaRubro.ReservasSinAsignar) - 1;
                                            asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                                            _context.SaveChanges();
                                            if (asientosAsignados >= reservaRubro.CantidadReservas && reservaRubro.ReservasSinAsignar == 0)
                                            {
                                                reservaRubro.EstadoReserva = "Asignada";
                                                GenerarQR(reservaRubro);
                                                _context.SaveChanges();
                                                ReservaAsignada(reservaRubro, reservaRubro.CodigoQR, asignado);
                                                asientosAsignados = 0;

                                            }

                                        }
                                    }

                                }

                            }
                        }

                    }


                }

                foreach (Reserva reservaRubro in rubroIngenieria)
                    {
                    int asientosAsignados = 0;
                    reservaRubro.Asientos = new List<Asiento>();
                    string asignado = "";

                    foreach (Mesa mesa in mesas)
                    {
                        foreach (Asiento asiento in asientos)
                        {
                            if (reservaRubro.EstadoReserva == "Aprobada" && asiento.IdReserva == 0)
                            {
                                if (mesa.IdMesa == asiento.MesaIdMesa)
                                {
                                    for (int x = 1; (x <= reservaRubro.CantidadReservas) && (x <= mesa.LugaresDisponibles) && asiento.IdReserva == 0; x++)
                                    {
                                        if (asiento.MesaIdMesa == mesa.IdMesa && mesa.EventoId == reservaRubro.Evento.EventoId && asiento.IdReserva == 0 && reservaRubro.EstadoReserva == "Aprobada")
                                        {
                                            asiento.IdReserva = reservaRubro.IdReserva;
                                            reservaRubro.Asientos.Add(asiento);
                                            mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                                            asientosAsignados = asientosAsignados + 1;
                                            reservaRubro.ReservasSinAsignar = (reservaRubro.ReservasSinAsignar) - 1;
                                            asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                                            _context.SaveChanges();
                                            if (asientosAsignados >= reservaRubro.CantidadReservas && reservaRubro.ReservasSinAsignar == 0)
                                            {
                                                reservaRubro.EstadoReserva = "Asignada";
                                                GenerarQR(reservaRubro);
                                                _context.SaveChanges();
                                                ReservaAsignada(reservaRubro, reservaRubro.CodigoQR, asignado);
                                                asientosAsignados = 0;

                                            }

                                        }
                                    }

                                }

                            }
                        }

                    }



                }
                foreach (Reserva reservaRubro in rubroOtro)
                {
                    int asientosAsignados = 0;
                    reservaRubro.Asientos = new List<Asiento>();
                    string asignado = "";

                    foreach (Mesa mesa in mesas)
                    {
                        foreach (Asiento asiento in asientos)
                        {
                            if (reservaRubro.EstadoReserva == "Aprobada" && asiento.IdReserva == 0)
                            {
                                if (mesa.IdMesa == asiento.MesaIdMesa)
                                {
                                    for (int x = 1; (x <= reservaRubro.CantidadReservas) && (x <= mesa.LugaresDisponibles) && asiento.IdReserva == 0; x++)
                                    {
                                        if (asiento.MesaIdMesa == mesa.IdMesa && mesa.EventoId == reservaRubro.Evento.EventoId && asiento.IdReserva == 0 && reservaRubro.EstadoReserva == "Aprobada")
                                        {
                                            asiento.IdReserva = reservaRubro.IdReserva;
                                            reservaRubro.Asientos.Add(asiento);
                                            mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                                            asientosAsignados = asientosAsignados + 1;
                                            reservaRubro.ReservasSinAsignar = (reservaRubro.ReservasSinAsignar) - 1;
                                            asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                                            _context.SaveChanges();
                                            if (asientosAsignados >= reservaRubro.CantidadReservas && reservaRubro.ReservasSinAsignar == 0)
                                            {
                                                reservaRubro.EstadoReserva = "Asignada";
                                                GenerarQR(reservaRubro);
                                                _context.SaveChanges();
                                                ReservaAsignada(reservaRubro, reservaRubro.CodigoQR, asignado);
                                                asientosAsignados = 0;

                                            }

                                        }
                                    }

                                }

                            }
                        }

                    }


                }
                foreach (Reserva reservaSinAsignar in reservas)
                    {
                        if (reservaSinAsignar.ReservasSinAsignar >= 1)
                        {
                            int asientosAsignados = 0;
                            reservaSinAsignar.Asientos = new List<Asiento>();


                            foreach (Asiento asiento in asientos)
                            {
                                if (reservaSinAsignar.EstadoReserva == "Aprobada")
                                {
                                    foreach (Mesa mesa in mesas)
                                    {
                                        if (asiento.MesaIdMesa == mesa.IdMesa && mesa.EventoId == reservaSinAsignar.Evento.EventoId && reservaSinAsignar.EstadoReserva == "Aprobada")
                                        {
                                            for (int x = 1; (x <= reservaSinAsignar.CantidadReservas) && (x <= mesa.LugaresDisponibles) && asiento.IdReserva == 0; x++)
                                            {

                                                asiento.IdReserva = reservaSinAsignar.IdReserva;
                                                reservaSinAsignar.Asientos.Add(asiento);
                                                mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                                                asientosAsignados = asientosAsignados + 1;
                                                if (asientosAsignados >= reservaSinAsignar.CantidadReservas)
                                                {
                                                    reservaSinAsignar.EstadoReserva = "Asignada";
                                                    asientosAsignados = 0;
                                                }

                                            }

                                        }
                                    }
                                }

                            }

                        }
                 }

             
            }
        }
        public static string ReservaAsignada(Reserva reserva, string codigoQR, string asignado)
        {
            var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
            correoService.enviarCorreo(
             asunto: "Invitacion confirmada para " + reserva.Evento.Nombre,
             cuerpo: "¡Hola " + reserva.NombreEmpresa + "!" + "\n Su/s asiento/s " + "para el evento " + reserva.Evento.Nombre + " " +
             "han sido asignados" + "\n" +
             "\n \n" +
             "\n \n" +
             "\n Sus lugares asignados son: " + asignado +
             "\n En el siguiente link, obtendrá el codigo QR para el acceso al evento: " + codigoQR.ToString().Trim() +
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
            
                    Document doc = new Document(PageSize.A6);
                    string ruta = @"ftp://win5207.site4now.net/" + reserva.CorreoElectronico.ToString().Trim() + reserva.IdReserva;
                    string rutaProvi = Environment.CurrentDirectory + @"\img\" + reserva.CorreoElectronico.ToString().Trim() + reserva.IdReserva + ".pdf";
                    PdfWriter.GetInstance(doc, new FileStream(rutaProvi, FileMode.Create));
                    doc.Open();
                    BarcodeQRCode barcodeQRCode = new BarcodeQRCode(reserva.CorreoElectronico + " ID de Reserva: " + reserva.IdReserva + " Asiento: " + reserva.Asientos, 1000, 1000, null);
                    Image codeQRImage = barcodeQRCode.GetImage();
                   // codeQRImage.OriginalData
                    codeQRImage.ScaleAbsolute(200, 200);
                    doc.Add(codeQRImage);
                    
                    doc.Close();
                    // GuardarQRFTP(reserva.NombreEmpresa + "_"+reserva.IdReserva, codeQRImage);
                    GuardarQRFTP(reserva.CorreoElectronico.ToString().Trim() + reserva.IdReserva + ".pdf" , rutaProvi);
                    reserva.CodigoQR = "http://montevideoit-001-site5.htempurl.com/img/" + reserva.CorreoElectronico.ToString().Trim() + reserva.IdReserva + ".pdf";


                    return ruta;
                }

        //public static void GuardarQRFTP(string fileName, Image doc)
        //{
        //    // Get the object used to communicate with the server.
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://win5207.site4now.net/" + fileName);
        //    request.Method = WebRequestMethods.Ftp.UploadFile;

        //    // This example assumes the FTP site uses anonymous logon.
        //    request.Credentials = new NetworkCredential("proyectoude", "pr0yect0ude2022");

        //    Stream requestStream = request.GetRequestStream();

        //   // doc.save(requestStream, System.Drawing.Imaging.ImageFormat.PNG); //hay que ver ejemplo de llamadas con esos dos parametros
        //    requestStream.Close();
        //    //requestStream.Close();

        //}

        public static void GuardarQRFTP(string fileName, string localFile)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(@"ftp://win5207.site4now.net/" + fileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("proyectoude", "pr0yect0ude2022");
            using (FileStream fileStream = File.Open(localFile ,FileMode.Open, FileAccess.Read))
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                    requestStream.Close();
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        int a = 1;// Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
                    }
                }
            }


        }
    }


    
}
