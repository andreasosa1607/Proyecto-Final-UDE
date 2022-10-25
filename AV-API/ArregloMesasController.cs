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

namespace AV_API
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class ArregloMesasController : ControllerBase
    {
        private readonly AVDBContext _context;

        public ArregloMesasController(AVDBContext context)
        {
            _context = context;
        }


        [HttpGet("{idEvento}")]
        public async Task<ActionResult<List<Mesa>>> GetArrayMesas(int idEvento)
        {
            var evento = await _context.Eventos.FindAsync(idEvento);

            if (evento == null)
            {
                return NotFound();
            }
            else
            {

                return evento.Mesas;
            }


        }
    }
}
