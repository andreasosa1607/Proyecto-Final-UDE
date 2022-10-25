using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AV.BO;
using AV.DA;

namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class MesasPorEventoController : ControllerBase
    {
        private readonly AVDBContext _context;

        public MesasPorEventoController(AVDBContext context)
        {
            _context = context;
        }


        // GET: api/MesasPorEvento/5

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetMesasPorEventos(int id)

        {
            List<Mesa> mesas = await _context.Mesas.Include("Asientos").Where(x => x.EventoId == id).ToListAsync();
            return mesas;



        }
    }
}
