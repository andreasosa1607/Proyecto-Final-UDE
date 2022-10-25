using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AV.BO;
using AV.DA;
using AV.BL;
using AV_DTO;

namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class CancelarReservaController : ControllerBase
    {
        private readonly AVDBContext _context;

        public CancelarReservaController(AVDBContext context)
        {
            _context = context;
        }





        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDTO>> CancelarReserva(int id)
        {

                List<Reserva> reservas = await _context.Reservas.Include("Cliente").Include("Evento").Where(x => x.IdReserva == id).ToListAsync();

                if (reservas == null || reservas.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    Reserva reserva = reservas.First();
                    ReservaBL.cancelarReserva(reserva);
                reserva.Evento.NroCupos = (reserva.Evento.NroCupos) + (reserva.CantidadReservas);
                reserva.EstadoReserva = "Reserva cancelada";
                await _context.SaveChangesAsync();
            }

            return NoContent();

        }


        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }

    }
}

