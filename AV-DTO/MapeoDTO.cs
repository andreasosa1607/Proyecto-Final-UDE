using System;
using System.Collections.Generic;
using System.Text;
using AV.BO;
namespace AV_DTO
{
    public class MapeoDTO
    {
        public static ReservaDTO ReservaDTO(Reserva reserva)
        {
            ReservaDTO reservaDTO = new ReservaDTO();

            reservaDTO.IdReserva = reserva.IdReserva;
            //reservaDTO.Cliente = reserva.Cliente;
            //reservaDTO.Evento = reserva.Evento;
            reservaDTO.EstadoReserva = reservaDTO.EstadoReserva;
            reservaDTO.ComprobantePago = reservaDTO.ComprobantePago;
            reservaDTO.ComprobantePago = reservaDTO.ComprobantePago;

            return reservaDTO;
        }

        public static ClienteDTO ClienteDTO(Cliente cliente)
        {
            ClienteDTO clienteDTO = new ClienteDTO();

            clienteDTO.ClienteId = cliente.ClienteId;
            clienteDTO.TipoDocumento = cliente.TipoDocumento;
            clienteDTO.NroDocumento = cliente.NroDocumento;
            clienteDTO.Nombre = cliente.Nombre;
            clienteDTO.Apellidos = cliente.Apellidos;
            clienteDTO.Telefono = cliente.Telefono;
            clienteDTO.ProfesionCargo = cliente.ProfesionCargo;
            clienteDTO.NombreEmpresa = cliente.NombreEmpresa;
            clienteDTO.FotoPerfil = cliente.FotoPerfil;

            return clienteDTO;
        }

        public static EventoDTO EventoDTO(Evento evento)
        {
            EventoDTO eventoDTO = new EventoDTO();

            eventoDTO.EventoId = evento.EventoId;
            eventoDTO.Nombre = evento.Nombre;
            eventoDTO.Descripcion = evento.Descripcion;
            eventoDTO.Tipo = evento.Tipo;
            eventoDTO.ImagenPortada = evento.ImagenPortada;
            eventoDTO.Fecha = evento.Fecha;
            eventoDTO.Hora = evento.Hora;
            eventoDTO.Lugar = evento.Lugar;
            eventoDTO.NroCupos = evento.NroCupos;
            eventoDTO.CantidadMesas = evento.CantidadMesas;
            eventoDTO.CantidadAsientosMesa = evento.CantidadAsientosMesa;
            eventoDTO.PrecioAsiento = evento.PrecioAsiento;
            eventoDTO.Idioma = evento.Idioma;
            eventoDTO.CriterioAsignacion = evento.CriterioAsignacion;
            eventoDTO.EmpresaCreadora = evento.EmpresaCreadora;

            return eventoDTO;
        }

        public static LoginDTO LoginDTO(Login login)
        {
            LoginDTO loginDTO = new LoginDTO();

            loginDTO.Rol = login.Rol;
            loginDTO.CorreoElectronico = login.CorreoElectronico;
            loginDTO.Contraseña = login.Contraseña;

            return loginDTO;
        }

        public static AdministradorDTO AdministradorDTO(Administrador administrador)
        {
            AdministradorDTO administradorDTO = new AdministradorDTO();

            administradorDTO.IdAdmin = administrador.IdAdmin;
            administradorDTO.NombreEmpresa = administrador.NombreEmpresa;
            administradorDTO.Pago = administrador.Pago;

            return administradorDTO;
        }

        public static MesaDTO MesaDTO(Mesa mesa)
        {
            MesaDTO mesaDTO = new MesaDTO();

            mesaDTO.NroMesa = mesa.NroMesa;
            mesaDTO.CantidadAsientos = mesa.CantidadAsientos;
            mesaDTO.LugaresDisponibles = mesa.LugaresDisponibles;


            return mesaDTO;
        }

        public static AsientoDTO AsientoDTO(Asiento asiento)
        {
            AsientoDTO asientoDTO = new AsientoDTO();

            asientoDTO.NroAsiento = asiento.NroAsiento;
            asientoDTO.Mesa = asiento.Mesa;
            asientoDTO.CodigoQR = asiento.CodigoQR;

            return asientoDTO;
        }

        public static PagoDTO PagoDTO(Pago pago)
        {
            PagoDTO pagoDTO = new PagoDTO();

            pagoDTO.IdPago = pago.IdPago;
            pagoDTO.SolicitudPago = pago.solicitudPago;
            pagoDTO.EstadoPago = pago.EstadoPago;
            pagoDTO.Comentario = pago.Comentario;
            pagoDTO.InvitacionEvento = pago.InvitacionEvento;
            pagoDTO.Reserva = pago.Reserva;

            return pagoDTO;
        }
    }
}


