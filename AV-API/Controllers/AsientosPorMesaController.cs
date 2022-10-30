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
    public class AsientosPorMesaController : ControllerBase
    {
        private readonly AVDBContext _context;

        public AsientosPorMesaController(AVDBContext context)
        {
            _context = context;
        }


        // GET: api_1_0/AsientosPorMesa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Asiento>>> GetAsientosPorMesa(int id)

        {
            List<Asiento> asientos = await _context.Asientos.Where(x => x.MesaIdMesa == id).ToListAsync();
            return asientos;

        }




    }
}
