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
            if ( reservaDTO != null)
            {
                reservaDTO.IdReserva = reserva.IdReserva;
                reservaDTO.Cliente = MapeoDTO.ClienteDTO(reserva.Cliente);
                reservaDTO.Evento = MapeoDTO.EventoDTO(reserva.Evento);
                reservaDTO.EstadoReserva = reserva.EstadoReserva;
                reservaDTO.ComprobantePago = reserva.ComprobantePago;
                reservaDTO.Asiento = MapeoDTO.AsientoDTO(reserva.Asiento);
            }
            return reservaDTO;
        }

        //Dado una Reserva se actualiza DTO
        public static Reserva ActualizaReserva(Reserva reserva, ReservaDTO reservaDTO)
        {
            reserva.IdReserva = reservaDTO.IdReserva;
            reserva.Cliente = Cliente(reservaDTO.Cliente);
            reserva.Evento = Evento(reservaDTO.Evento);
            reserva.EstadoReserva = reservaDTO.EstadoReserva;
            reserva.ComprobantePago = reservaDTO.ComprobantePago;         
            reserva.Asiento = Asiento(reservaDTO.Asiento);
            return reserva;

        }

        //Dado una reservaDTO se crea la reserva  
        public static Reserva Reserva (ReservaDTO reservaDTO)
        {
            Reserva reserva = new Reserva();

            reserva.IdReserva = reservaDTO.IdReserva;           
            reserva.Cliente = Cliente(reservaDTO.Cliente);
            reserva.Evento = Evento(reservaDTO.Evento);
            reserva.EstadoReserva = reservaDTO.EstadoReserva;
            reserva.ComprobantePago = reservaDTO.ComprobantePago;
            reserva.Asiento = Asiento(reservaDTO.Asiento);

            return reserva;
        }

            public static ClienteDTO ClienteDTO(Cliente cliente)
        {
            ClienteDTO clienteDTO = new ClienteDTO();
            
            if (clienteDTO == null)
            {
                clienteDTO.ClienteId = cliente.ClienteId;
                clienteDTO.TipoDocumento = cliente.TipoDocumento;
                clienteDTO.NroDocumento = cliente.NroDocumento;
                clienteDTO.Nombre = cliente.Nombre;
                clienteDTO.Apellidos = cliente.Apellidos;
                clienteDTO.Telefono = cliente.Telefono;
                clienteDTO.ProfesionCargo = cliente.ProfesionCargo;
                clienteDTO.NombreEmpresa = cliente.NombreEmpresa;
                clienteDTO.FotoPerfil = cliente.FotoPerfil;
            }
                return clienteDTO;
        }

        //Dado un Cliente se actualiza CON EL DTO
        public static Cliente ActualizarCliente(Cliente cliente, ClienteDTO clienteDTO)
        {
            cliente.ClienteId = clienteDTO.ClienteId;
            cliente.TipoDocumento = clienteDTO.TipoDocumento;
            cliente.NroDocumento = clienteDTO.NroDocumento;
            cliente.Nombre = clienteDTO.Nombre;
            cliente.Apellidos = clienteDTO.Apellidos;
            cliente.Telefono = clienteDTO.Telefono;
            cliente.ProfesionCargo = clienteDTO.ProfesionCargo;
            cliente.NombreEmpresa = clienteDTO.NombreEmpresa;
            cliente.FotoPerfil = clienteDTO.FotoPerfil;

            return cliente;
        }

        //Dado un Cliente dto se crea un Cliente 
        public static Cliente Cliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = new Cliente();
            cliente.ClienteId = clienteDTO.ClienteId;
            cliente.TipoDocumento = clienteDTO.TipoDocumento;
            cliente.NroDocumento = clienteDTO.NroDocumento;
            cliente.Nombre = clienteDTO.Nombre;
            cliente.Apellidos = clienteDTO.Apellidos;
            cliente.Telefono = clienteDTO.Telefono;
            cliente.ProfesionCargo = clienteDTO.ProfesionCargo;
            cliente.NombreEmpresa = clienteDTO.NombreEmpresa;
            cliente.FotoPerfil = clienteDTO.FotoPerfil;

            return cliente;
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
            eventoDTO.callePuerta = evento.callePuerta;
            eventoDTO.barrio = evento.barrio;
            eventoDTO.ciudad = evento.ciudad;
            eventoDTO.NroCupos = evento.NroCupos;
            eventoDTO.CantidadMesas = evento.CantidadMesas;
            eventoDTO.CantidadAsientosMesa = evento.CantidadAsientosMesa;
            eventoDTO.PrecioAsiento = evento.PrecioAsiento;
            eventoDTO.Idioma = evento.Idioma;
            eventoDTO.CriterioAsignacion = evento.CriterioAsignacion;
            eventoDTO.EmpresaCreadora = evento.EmpresaCreadora;

            return eventoDTO;
        }
        //Dado un evento se actualiza con el dto
        public static Evento ActualizarEvento (Evento evento, EventoDTO eventoDTO)
        {

            evento.EventoId = eventoDTO.EventoId;
            evento.Nombre = eventoDTO.Nombre;
            evento.Descripcion = eventoDTO.Descripcion;
            evento.Tipo = eventoDTO.Tipo;
            evento.ImagenPortada = eventoDTO.ImagenPortada;
            evento.Fecha = eventoDTO.Fecha;
            evento.Hora = eventoDTO.Hora;
            eventoDTO.callePuerta = evento.callePuerta;
            eventoDTO.barrio = evento.barrio;
            eventoDTO.ciudad = evento.ciudad;
            evento.NroCupos = eventoDTO.NroCupos;
            evento.CantidadMesas = eventoDTO.CantidadMesas;
            evento.CantidadAsientosMesa = eventoDTO.CantidadAsientosMesa;
            evento.PrecioAsiento = eventoDTO.PrecioAsiento;
            evento.Idioma = eventoDTO.Idioma;
            evento.CriterioAsignacion = eventoDTO.CriterioAsignacion;
            evento.EmpresaCreadora = eventoDTO.EmpresaCreadora;

            return evento;
        }

        //Dado un eventodto se crea un evento
        public static Evento Evento (EventoDTO eventoDTO)
        {
            Evento evento = new Evento();

            evento.EventoId = eventoDTO.EventoId;
            evento.Nombre = eventoDTO.Nombre;
            evento.Descripcion = eventoDTO.Descripcion;
            evento.Tipo = eventoDTO.Tipo;
            evento.ImagenPortada = eventoDTO.ImagenPortada;
            evento.Fecha = eventoDTO.Fecha;
            evento.Hora = eventoDTO.Hora;
            eventoDTO.callePuerta = evento.callePuerta;
            eventoDTO.barrio = evento.barrio;
            eventoDTO.ciudad = evento.ciudad;
            evento.NroCupos = eventoDTO.NroCupos;
            evento.CantidadMesas = eventoDTO.CantidadMesas;
            evento.CantidadAsientosMesa = eventoDTO.CantidadAsientosMesa;
            evento.PrecioAsiento = eventoDTO.PrecioAsiento;
            evento.Idioma = eventoDTO.Idioma;
            evento.CriterioAsignacion = eventoDTO.CriterioAsignacion;
            evento.EmpresaCreadora = eventoDTO.EmpresaCreadora;

            return evento;
        }

        public static LoginDTO LoginDTO(Login login)
        {
            LoginDTO loginDTO = new LoginDTO();

            loginDTO.Rol = login.Rol;
            loginDTO.CorreoElectronico = login.CorreoElectronico;
            loginDTO.Contraseña = login.Contraseña;

            return loginDTO;
        }

        //Dado un Login se actualiza CON EL DTO
        public static Login ActualizarLogin (Login login, LoginDTO loginDTO)
        {
            login.Rol = loginDTO.Rol;
            login.CorreoElectronico = loginDTO.CorreoElectronico;
            login.Contraseña = loginDTO.Contraseña;

            return login;

        }

        //Dado un Logindto se crea Login
        public static Login Login(LoginDTO loginDTO)
        {
            Login login = new Login();

            login.Rol = loginDTO.Rol;
            login.CorreoElectronico = loginDTO.CorreoElectronico;
            login.Contraseña = loginDTO.Contraseña;

           return login;
        }

            public static AdministradorDTO AdministradorDTO(Administrador administrador)
        {
            AdministradorDTO administradorDTO = new AdministradorDTO();

            administradorDTO.IdAdmin = administrador.IdAdmin;
            administradorDTO.NombreEmpresa = administrador.NombreEmpresa;

            return administradorDTO;
        }

        public static Administrador ActualizarAdministrador(Administrador administrador, AdministradorDTO administradorDTO)
        {
            administrador.IdAdmin = administradorDTO.IdAdmin;
            administrador.NombreEmpresa = administradorDTO.NombreEmpresa;

            return administrador;

        }

        public static Administrador Administrador(AdministradorDTO administradorDTO)
        {
            Administrador administrador = new Administrador();

            administrador.IdAdmin = administradorDTO.IdAdmin;
            administrador.NombreEmpresa = administradorDTO.NombreEmpresa;


            return administrador;
        }

            public static MesaDTO MesaDTO(Mesa mesa)
        {
            MesaDTO mesaDTO = new MesaDTO();
            
            mesaDTO.NroMesa = mesa.NroMesa;
            mesaDTO.CantidadAsientos = mesa.CantidadAsientos;
            mesaDTO.LugaresDisponibles = mesa.LugaresDisponibles;

            return mesaDTO;
        }

        //Dado una mesa se actualiza CON EL DTO
        public static Mesa ActualizarMesa(Mesa mesa, MesaDTO mesaDTO)
        {
            mesa.NroMesa = mesaDTO.NroMesa;
            mesa.CantidadAsientos = mesaDTO.CantidadAsientos;
            mesa.LugaresDisponibles = mesaDTO.LugaresDisponibles;

            return mesa;
        }

        //Dado una mesaDTO SE CREA Mesa 
        public static Mesa Mesa(MesaDTO mesaDTO)
        {
            Mesa mesa = new Mesa();
            mesa.NroMesa = mesaDTO.NroMesa;
            mesa.CantidadAsientos = mesaDTO.CantidadAsientos;
            mesa.LugaresDisponibles = mesaDTO.LugaresDisponibles;

            return mesa;
        }

            public static AsientoDTO AsientoDTO(Asiento asiento)
        {
            AsientoDTO asientoDTO = new AsientoDTO();
            
                asientoDTO.NroAsiento = asiento.NroAsiento;
                asientoDTO.Mesa = MapeoDTO.MesaDTO(asiento.Mesa);
                asientoDTO.CodigoQR = asiento.CodigoQR;
            
            return asientoDTO;
        }

        //Dado un asiento se actualiza CON EL DTO
        public static Asiento ActualizarAsiento(Asiento asiento, AsientoDTO asientoDTO)
        {
            asiento.NroAsiento = asientoDTO.NroAsiento;
            asiento.Mesa = Mesa(asientoDTO.Mesa);
            asiento.CodigoQR = asientoDTO.CodigoQR;

            return asiento;
        }

        //Dado DTO se crea Asiento
        public static Asiento Asiento(AsientoDTO asientoDTO)
        {
            Asiento asiento = new Asiento();

            asiento.NroAsiento = asientoDTO.NroAsiento;
            asiento.Mesa = Mesa(asientoDTO.Mesa);
            asiento.CodigoQR = asientoDTO.CodigoQR;

            return asiento;
        }

            public static PagoDTO PagoDTO(Pago pago)
        {
            PagoDTO pagoDTO = new PagoDTO();

            if (pagoDTO != null)
            {
                pagoDTO.IdPago = pago.IdPago;
                pagoDTO.solicitudPago = pago.solicitudPago;
                pagoDTO.EstadoPago = pago.EstadoPago;
                pagoDTO.Comentario = pago.Comentario;
                pagoDTO.InvitacionEvento = pago.InvitacionEvento;
                pagoDTO.Reserva = MapeoDTO.ReservaDTO(pago.Reserva);
            }
            return pagoDTO;


        }

        //Dado un Pago se actualiza CON EL DTO
        public static Pago ActualizarPago(Pago pago, PagoDTO pagoDTO)
        {
            pago.IdPago = pagoDTO.IdPago;
            pago.solicitudPago = pagoDTO.solicitudPago;
            pago.EstadoPago = pagoDTO.EstadoPago;
            pago.Comentario = pagoDTO.Comentario;
            pago.InvitacionEvento = pagoDTO.InvitacionEvento;
            pago.Reserva = Reserva(pagoDTO.Reserva);

            return pago;
        }

        //Dado DTO se crea Pago
        public static Pago Pago (PagoDTO pagoDTO)
        {
            Pago pago = new Pago();

            pago.IdPago = pagoDTO.IdPago;
            pago.solicitudPago = pagoDTO.solicitudPago;
            pago.EstadoPago = pagoDTO.EstadoPago;
            pago.Comentario = pagoDTO.Comentario;
            pago.InvitacionEvento = pagoDTO.InvitacionEvento;
            pago.Reserva = Reserva(pagoDTO.Reserva);

            return pago;

        }


        }
}


