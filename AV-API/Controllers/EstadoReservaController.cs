using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AV_DTO;
using AV.DA;
using Microsoft.EntityFrameworkCore;

namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]

    public class EstadoReservaController : Controller
    {
        private readonly AVDBContext _context;

        public EstadoReservaController(AVDBContext context)
        {
            _context = context;
        }


        // PUT: api/Reservas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ReservaDTO>> PutReserva(int id, EstadoReservaDTO reservaDTO)
        {
            if (id != reservaDTO.IdReserva)
            {
                return BadRequest();
            }

            var reservas = await (_context.Reservas.Include("Evento").Include("Cliente").Where(x => x.IdReserva == id).ToListAsync());
            var reserva = reservas.First();
            if (reserva == null)

            {
                return NotFound();
            }

            reserva = MapeoDTO.ActualizaReserva2(reserva, reservaDTO);
             
            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return MapeoDTO.ReservaDTO(reserva);
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }



    }
}
