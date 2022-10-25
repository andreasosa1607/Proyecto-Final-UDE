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
using AV_DTO;
using AV.BL;

namespace AV_API.Controllers
{

    [Route("api_1_0/[controller]")]
    [ApiController]
    public class EventoModificadoController : Controller
    {
        private readonly AVDBContext _context;


        public EventoModificadoController(AVDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoDTO>> GetEventoModificado(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            else
            {

                List<Reserva> reservas = await _context.Reservas.Include("Cliente").Where(x => x.Evento.EventoId == evento.EventoId).ToListAsync();


                if (reservas == null || reservas.Count == 0)

                {
                    return NotFound();

                }
                else
                {
                    foreach (Reserva reserva in reservas)
                    {
                        EventoBL.EnvioCorreo(reservas, evento);
                        await _context.SaveChangesAsync();
                    }
                    _context.Eventos.Remove(evento);
                    await _context.SaveChangesAsync();

                    return NoContent();

                }
            }
        }

    } 

}

