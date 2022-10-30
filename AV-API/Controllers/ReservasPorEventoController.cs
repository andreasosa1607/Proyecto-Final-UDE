using AV.BL;
using AV.BO;
using AV.DA;
using AV_DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AV_API.Controllers
{

    [Route("api_1_0/[controller]")]
    [ApiController]

    public class ReservasPorEventoController : Controller
    {
        private readonly AVDBContext _context;

        public ReservasPorEventoController(AVDBContext context)
        {
            _context = context;
        }



        //GET: api_1_0/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasPorEvento(int id)

        {

            List<Reserva> reservas = await _context.Reservas.Include("Cliente").Include("ComprobanteDePago").Include("Evento").Where(x => x.Evento.EventoId == id).ToListAsync();
            return reservas;

        }
    }
}



       
        




    
