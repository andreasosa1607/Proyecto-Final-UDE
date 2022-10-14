using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AV.BO;
using AV.DA;
using Flurl.Http;

namespace AV_API.Controllers
{

    [Route("api_1_0/[controller]")]
    [ApiController]
    public class EventoCanceladoController : Controller
    {
        private readonly AVDBContext _context;


        public EventoCanceladoController(AVDBContext context)
        {
            _context = context;
        }


        // GET: api/Reservas/correoElectronico
        [HttpGet("{idEvento}")]
        public async Task<ActionResult<List<Reserva>>> GetReservaEvento(int idEvento)
        {

            List<Reserva> reservas = await _context.Reservas.Where(x => x.Evento.EventoId == idEvento).ToListAsync();


            if (reservas == null || reservas.Count == 0)

            {
                return NotFound();
            }
            else
            {
                return reservas;
            }
        }

        [HttpGet("{reservas}")]
        public async Task<ActionResult<List<Reserva>>> GetEventosReserva(List<Reserva> reservas)
        {
            foreach (Reserva reserva in reservas)
            {
                var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
                correoService.enviarCorreo(
                    asunto: "Notificación de evento cancelado",
                    cuerpo: "Hola! " + reserva.Cliente.Nombre + "\nUsted tiene una reserva para el evento." + reserva.Evento + "\n" +
                    "Lamentamos informarle que por razones de fuerza mayor, el mismo ha sido cancelado, si usted ya había realizado el pago correspondiente a la reserva, " +
                    "le solicitamos que se comunique con nosotros via correo electrónico (soporteclientesAV@gmail.com), adjuntando una imagen NITIDA y CLARA del comprobante de pago " +
                    "y en el cuerpo del correo, indiquenos el numero de referencia de la reserva: " + reserva.IdReserva + " seguido del nombre o empresa con el que registró la reserva: (" +
                    reserva.NombreEmpresa + ")" +
                    "\n Un agente de soporte se pondrá en contacto con usted a la brevedad para indicarle los pasos a seguir al telefono: " + reserva.Telefono + " en caso de que desee que nos comuniquemos por otro medio, puede indicarlo en en correo electronico" +
                    "\n de parte de AV , le reiteramos las disculpas por lo sucedido y le agradecemos por preferirnos. ",
                    destinatarios: new List<string> { reserva.CorreoElectronico }
                    );
            }

            return reservas;
           
        }

    } 

}

