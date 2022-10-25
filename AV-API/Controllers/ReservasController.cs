using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AV.BO;
using AV.DA;
using AV_DTO;
using AV.BL;

namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly AVDBContext _context;

        public ReservasController(AVDBContext context)
        {
            _context = context;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaDTO>>> GetReservas()
        {

            return await _context.Reservas.Include("Cliente").Include("Evento").Select(x => MapeoDTO.ReservaDTO(x)).ToListAsync();


        }




        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDTO>> GetReserva(int id)
        {
          
            var reservas = await (_context.Reservas.Include("Evento").Include("ComprobanteDePago").Include("Cliente").Where(x => x.IdReserva == id).ToListAsync());
            var reserva = reservas.First();
            if (reserva == null)
            {
                return NotFound();
            }
            List<Reserva> reservas = await _context.Reservas.Include("Evento").Include("Cliente").Include("Asientos").Where(x => x.IdReserva == id).ToListAsync();



            if (reservas == null || reservas.Count == 0)

            {
                return NotFound();
            }
            else
            {
                Reserva reserva2 = reservas.First();



                return Ok(reserva2);
            }

            return MapeoDTO.ReservaDTO(reserva);

        }

        // PUT: api/Reservas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, ReservaDTO reservaDTO)
        {
            if (id != reservaDTO.IdReserva)
            {
                return BadRequest();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)

            {
                return NotFound();
            }

            reserva = MapeoDTO.ActualizaReserva(reserva, reservaDTO);
            _context.Entry(reserva).State = EntityState.Modified;

            // _context.Entry(reservaDTO).State = EntityState.Modified;

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

            return NoContent();
        }

        // POST: api/Reservas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservaDTO>> PostReserva(ReservaDTO reservaDTO)
        {
            Reserva reserva = MapeoDTO.Reserva(reservaDTO);
            reserva.Evento.NroCupos = (reserva.Evento.NroCupos) - (reserva.CantidadReservas);
            _context.Eventos.Update(reserva.Evento);
            _context.Clientes.Update(reserva.Cliente);
            _context.Logins.Update(reserva.Cliente.Login);
            _context.Reservas.Add(reserva);
            
            await _context.SaveChangesAsync();
           
            ReservaBL.EnvioCorreo(reserva);
            return CreatedAtAction("GetReserva", new { id = reserva.IdReserva }, reserva);
        }

 
        

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}
