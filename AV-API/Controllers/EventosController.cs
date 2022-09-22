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
    public class EventosController : ControllerBase
    {
        private readonly AVDBContext _context;

        public EventosController(AVDBContext context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoDTO>>> GetEventos()
        {
            //return await _context.Eventos.ToListAsync();
            return await _context.Eventos
          .Select(x => MapeoDTO.EventoDTO(x))
             .ToListAsync();

        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDTO>> GetEvento(int id)
        {

            var evento = await _context.Eventos.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return MapeoDTO.EventoDTO(evento);
        }


        // PUT: api/Eventos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, EventoDTO eventoDTO)
        {
            if (id != eventoDTO.EventoId)
            {
                return BadRequest();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)

            {
                return NotFound();
            }

            evento = MapeoDTO.ActualizarEvento(evento, eventoDTO);
            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
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

        // POST: api/Eventos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventoDTO>> PostEvento(EventoDTO eventoDTO)
        {
            Evento evento = MapeoDTO.Evento(eventoDTO);
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.EventoId }, evento);
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            else
            {

                List<Reserva> reservas = await _context.Reservas.Where(x => x.Evento.EventoId == evento.EventoId).ToListAsync();


                if (reservas == null || reservas.Count == 0)

                {
                    return NotFound();

                }
                else
                {
                        _context.Eventos.Remove(evento);
                foreach(Reserva reserva in reservas)
                    {
                        reserva.EstadoReserva = "Evento cancelado";
                        await _context.SaveChangesAsync();
                    }
                        await _context.SaveChangesAsync();

                        return NoContent();
                    
                }
            }
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.EventoId == id);
        }
    }
}
