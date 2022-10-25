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
    public class ComentarioReservaController : ControllerBase
    {
        private readonly AVDBContext _context;

        public ComentarioReservaController(AVDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDTO>> ComentarioReserva(int id)
        {
           

                List<Reserva> reservas = await _context.Reservas.Include("Cliente").Include("Evento").Where(x => x.IdReserva == id).ToListAsync();


                if (reservas == null || reservas.Count == 0)

                {
                    return NotFound();
                }
                else
                {
                    Reserva reserva = reservas.First();
                    {
                        ReservaBL.ReservaAprobadaORechazada(reserva);
                    }

                    return NoContent();

                }
            }
        }

    }

