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
            reservaDTO.Cliente = reserva.Cliente;
            reservaDTO.Evento = reserva.Evento;
            reservaDTO.EstadoReserva = reserva.EstadoReserva;
            reservaDTO.ComprobanteDePago = reserva.ComprobanteDePago;
            reservaDTO.Asientos = reserva.Asientos;
            reservaDTO.NombreEmpresa = reserva.NombreEmpresa;
            reservaDTO.Telefono = reserva.Telefono;
            reservaDTO.CorreoElectronico = reserva.CorreoElectronico;
            reservaDTO.CantidadReservas = reserva.CantidadReservas;
            reservaDTO.FechaReserva = reserva.FechaReserva;
            reservaDTO.DescripcionEstado = reserva.DescripcionEstado;
            reservaDTO.codigoQR = reserva.CodigoQR;
            reserva.ReservasSinAsignar = reservaDTO.ReservasSinAsignar;

            return reservaDTO;
        }



        //Dado una Reserva se actualiza DTO
        public static Reserva ActualizaReserva(Reserva reserva, ReservaDTO reservaDTO)
        {
            reserva.IdReserva = reservaDTO.IdReserva;
            reserva.Cliente = reservaDTO.Cliente;
            reserva.Evento = reservaDTO.Evento;
            reserva.EstadoReserva = reservaDTO.EstadoReserva;
            reserva.ComprobanteDePago = reservaDTO.ComprobanteDePago;
            reserva.Asientos = reservaDTO.Asientos;
            reserva.NombreEmpresa = reservaDTO.NombreEmpresa;
            reserva.Telefono = reservaDTO.Telefono;
            reserva.CorreoElectronico = reservaDTO.CorreoElectronico;
            reserva.CantidadReservas = reservaDTO.CantidadReservas;
            reserva.FechaReserva = reservaDTO.FechaReserva;
            reserva.DescripcionEstado = reservaDTO.DescripcionEstado;
            reserva.CodigoQR = reservaDTO.codigoQR;
            reserva.ReservasSinAsignar = reservaDTO.ReservasSinAsignar;

            return reserva;

        }

        public static Reserva ActualizaReserva2(Reserva reserva, EstadoReservaDTO reservaDTO)
        {
            reserva.IdReserva = reservaDTO.IdReserva;
            reserva.EstadoReserva = reservaDTO.EstadoReserva;
            reserva.DescripcionEstado = reservaDTO.descripcionEstado;

            return reserva;

        }

        //Dado una reservaDTO se crea la reserva  
        public static Reserva Reserva(ReservaDTO reservaDTO)
        {
            Reserva reserva = new Reserva();

            reserva.IdReserva = reservaDTO.IdReserva;
            reserva.Cliente = reservaDTO.Cliente;
            reserva.Evento = reservaDTO.Evento;
            reserva.EstadoReserva = reservaDTO.EstadoReserva;
            reserva.ComprobanteDePago = reservaDTO.ComprobanteDePago;
            reserva.CodigoQR = reservaDTO.codigoQR;
            if (reservaDTO.Asientos != null)
            {

                reserva.Asientos = new List<Asiento>(reservaDTO.Asientos);
            }
            else
            {
                reserva.Asientos = null;
            }
            reserva.NombreEmpresa = reservaDTO.NombreEmpresa;
            reserva.Telefono = reservaDTO.Telefono;
            reserva.CorreoElectronico = reservaDTO.CorreoElectronico;
            reserva.CantidadReservas = reservaDTO.CantidadReservas;
            reserva.FechaReserva = reservaDTO.FechaReserva;
          reserva.DescripcionEstado = reservaDTO.DescripcionEstado;
            reserva.ReservasSinAsignar = reservaDTO.ReservasSinAsignar;
            return reserva;
        }



        public static ClienteDTO ClienteDTO(Cliente cliente)
        {
            ClienteDTO clienteDTO = new ClienteDTO();

            if (cliente != null)
            {

                clienteDTO.ClienteId = cliente.ClienteId;
                clienteDTO.TipoDocumento = cliente.TipoDocumento;
                clienteDTO.NroDocumento = cliente.NroDocumento;
                clienteDTO.Nombre = cliente.Nombre;
                clienteDTO.Apellidos = cliente.Apellidos;
                clienteDTO.Telefono = cliente.Telefono;
                clienteDTO.ProfesionCargo = cliente.ProfesionCargo;
                clienteDTO.NombreEmpresa = cliente.NombreEmpresa;
                clienteDTO.IdiomaPreferencia = cliente.IdiomaPreferencia;
                clienteDTO.login = cliente.Login;



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
            cliente.IdiomaPreferencia = clienteDTO.IdiomaPreferencia;
            cliente.Login = clienteDTO.login;

            return cliente;
        }

        public static Cliente ActualizarCliente2(Cliente cliente, EditarClienteDTO editarClienteDTO)
        {
            cliente.TipoDocumento = editarClienteDTO.TipoDocumento;
            cliente.NroDocumento = editarClienteDTO.NroDocumento;
            cliente.Nombre = editarClienteDTO.Nombre;
            cliente.Apellidos = editarClienteDTO.Apellidos;
            cliente.Telefono = editarClienteDTO.Telefono;
            cliente.ProfesionCargo = editarClienteDTO.ProfesionCargo;
            cliente.NombreEmpresa = editarClienteDTO.NombreEmpresa;

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
            cliente.IdiomaPreferencia = clienteDTO.IdiomaPreferencia;
            cliente.Login = clienteDTO.login;

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

            eventoDTO.FechaHora = evento.FechaHora;
            eventoDTO.CallePuerta = evento.CallePuerta;
            eventoDTO.Barrio = evento.Barrio;
            eventoDTO.Ciudad = evento.Ciudad;
            eventoDTO.Duracion = evento.Duracion;
            eventoDTO.NroCupos = evento.NroCupos;
            eventoDTO.CantidadMesas = evento.CantidadMesas;
            eventoDTO.CantidadAsientosMesa = evento.CantidadAsientosMesa;
            eventoDTO.Moneda = evento.Moneda;
            eventoDTO.PrecioAsiento = evento.PrecioAsiento;
            eventoDTO.Idioma = evento.Idioma;
            eventoDTO.TipoAsignacion = evento.TipoAsignacion;
            eventoDTO.CriterioAsignacion = evento.CriterioAsignacion;
            eventoDTO.EmpresaCreadora = evento.EmpresaCreadora;
            //eventoDTO.Mesas = evento.Mesas;
            eventoDTO.EstadoEvento = evento.EstadoEvento;
            eventoDTO.Mesas = evento.Mesas;
            return eventoDTO;
        }
        //Dado un evento se actualiza con el dto
        public static Evento ActualizarEvento(Evento evento, EventoDTO eventoDTO)
        {

            evento.EventoId = eventoDTO.EventoId;
            evento.Nombre = eventoDTO.Nombre;
            evento.Descripcion = eventoDTO.Descripcion;
            evento.Tipo = eventoDTO.Tipo;
            evento.ImagenPortada = eventoDTO.ImagenPortada;
            evento.FechaHora = eventoDTO.FechaHora;
            evento.CallePuerta = eventoDTO.CallePuerta;
            evento.Barrio = eventoDTO.Barrio;
            evento.Ciudad = eventoDTO.Ciudad;
            evento.Duracion = eventoDTO.Duracion;
            evento.NroCupos = eventoDTO.NroCupos;
            evento.CantidadMesas = eventoDTO.CantidadMesas;
            evento.CantidadAsientosMesa = eventoDTO.CantidadAsientosMesa;
            evento.Moneda = eventoDTO.Moneda;
            evento.PrecioAsiento = eventoDTO.PrecioAsiento;
            evento.Idioma = eventoDTO.Idioma;
            evento.TipoAsignacion = eventoDTO.TipoAsignacion;
            evento.CriterioAsignacion = eventoDTO.CriterioAsignacion;
            evento.EmpresaCreadora = eventoDTO.EmpresaCreadora;
            //evento.Mesas = eventoDTO.Mesas;
            evento.EstadoEvento = eventoDTO.EstadoEvento;
            evento.Mesas = eventoDTO.Mesas;
            return evento;
        }

        //Dado un eventodto se crea un evento
        public static Evento Evento(EventoDTO eventoDTO)
        {
            Evento evento = new Evento();

            evento.EventoId = eventoDTO.EventoId;
            evento.Nombre = eventoDTO.Nombre;
            evento.Descripcion = eventoDTO.Descripcion;
            evento.Tipo = eventoDTO.Tipo;
            evento.Duracion = eventoDTO.Duracion;
            evento.ImagenPortada = eventoDTO.ImagenPortada;

            evento.FechaHora = eventoDTO.FechaHora;
            evento.CallePuerta = eventoDTO.CallePuerta;
            evento.Barrio = eventoDTO.Barrio;
            evento.Ciudad = eventoDTO.Ciudad;
            evento.NroCupos = eventoDTO.NroCupos;
            evento.CantidadMesas = eventoDTO.CantidadMesas;
            evento.CantidadAsientosMesa = eventoDTO.CantidadAsientosMesa;
            evento.Moneda = eventoDTO.Moneda;
            evento.PrecioAsiento = eventoDTO.PrecioAsiento;
            evento.Idioma = eventoDTO.Idioma;
            evento.TipoAsignacion = eventoDTO.TipoAsignacion;
            evento.CriterioAsignacion = eventoDTO.CriterioAsignacion;
            evento.EmpresaCreadora = eventoDTO.EmpresaCreadora;
            if (eventoDTO.Mesas != null)
            {
                evento.Mesas = new List<Mesa>(evento.Mesas);
            }
            else
            {
                evento.Mesas = null;
            }
            evento.EstadoEvento = eventoDTO.EstadoEvento;
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
        public static Login ActualizarLogin(Login login, LoginDTO loginDTO)
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
            administradorDTO.Login = administrador.Login;

            return administradorDTO;
        }

        public static Administrador ActualizarAdministrador(Administrador administrador, AdministradorDTO administradorDTO)
        {
            administrador.IdAdmin = administradorDTO.IdAdmin;
            administrador.NombreEmpresa = administradorDTO.NombreEmpresa;
            administradorDTO.Login = administrador.Login;

            return administrador;

        }

        public static Administrador Administrador(AdministradorDTO administradorDTO)
        {
            Administrador administrador = new Administrador();

            administrador.IdAdmin = administradorDTO.IdAdmin;
            administrador.NombreEmpresa = administradorDTO.NombreEmpresa;
            administrador.Login = administradorDTO.Login;


            return administrador;
        }

        public static MesaDTO MesaDTO(Mesa mesa)
        {
            MesaDTO mesaDTO = new MesaDTO();
            mesaDTO.IdMesa = mesa.NroMesa;
            mesaDTO.NroMesa = mesa.NroMesa;
            mesaDTO.CantidadAsientos = mesa.CantidadAsientos;
            mesaDTO.LugaresDisponibles = mesa.LugaresDisponibles;
            mesaDTO.EventoId = mesa.EventoId;
            mesaDTO.Asientos = mesa.Asientos;
            return mesaDTO;
        }

        //Dado una mesa se actualiza CON EL DTO
        public static Mesa ActualizarMesa(Mesa mesa, MesaDTO mesaDTO)
        {
            mesa.IdMesa = mesaDTO.NroMesa;
            mesa.NroMesa = mesaDTO.NroMesa;
            mesa.CantidadAsientos = mesaDTO.CantidadAsientos;
            mesa.LugaresDisponibles = mesaDTO.LugaresDisponibles;
            mesa.EventoId = mesaDTO.EventoId;
            mesa.Asientos = mesaDTO.Asientos;
            return mesa;
        }

        //Dado una mesaDTO SE CREA Mesa
        public static Mesa Mesa(MesaDTO mesaDTO)
        {
            Mesa mesa = new Mesa();
            mesa.IdMesa = mesaDTO.NroMesa;
            mesa.NroMesa = mesaDTO.NroMesa;
            mesa.CantidadAsientos = mesaDTO.CantidadAsientos;
            mesa.LugaresDisponibles = mesaDTO.LugaresDisponibles;
            mesa.EventoId = mesaDTO.EventoId;
            if (mesaDTO.Asientos != null)
            {
                mesa.Asientos = new List<Asiento>(mesa.Asientos);
            }
            else
            {
                mesa.Asientos = null;
            }


            return mesa;
        }

        public static AsientoDTO AsientoDTO(Asiento asiento)
        {
            AsientoDTO asientoDTO = new AsientoDTO();

            
            asientoDTO.IdAsiento = asiento.IdAsiento;
            asientoDTO.NroAsiento = asiento.NroAsiento;
            asientoDTO.MesaIdMesa = asiento.MesaIdMesa;
            asientoDTO.IdReserva = asiento.IdReserva;

            return asientoDTO;
        }

        //Dado un asiento se actualiza CON EL DTO
        public static Asiento ActualizarAsiento(Asiento asiento, AsientoDTO asientoDTO)
        {
            asiento.IdAsiento = asientoDTO.IdAsiento;
            asiento.NroAsiento = asientoDTO.NroAsiento;


            asiento.MesaIdMesa = asientoDTO.MesaIdMesa;

            asiento.IdReserva = asientoDTO.IdReserva;

            return asiento;
        }

        //Dado DTO se crea Asiento
        public static Asiento Asiento(AsientoDTO asientoDTO)
        {
            Asiento asiento = new Asiento();

            asiento.IdAsiento = asientoDTO.IdAsiento;
            asiento.NroAsiento = asientoDTO.NroAsiento;

            asiento.MesaIdMesa = asientoDTO.MesaIdMesa;

            asiento.IdReserva = asientoDTO.IdReserva;

            return asiento;
        }


        public static ComprobanteDePago ComprobanteDePago(ComprobanteDePagoDTO comprobanteDePagoDTO)
        {
            ComprobanteDePago comprobanteDePago = new ComprobanteDePago();
            comprobanteDePago.IdDocumento = comprobanteDePagoDTO.IdDocumento;
            comprobanteDePago.Nombre = comprobanteDePagoDTO.Nombre;

            return comprobanteDePago;
        }


    }
}


