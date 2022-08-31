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


namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class GetClienteCorreo : Controller
    {
        private readonly AVDBContext _context;

        public GetClienteCorreo(AVDBContext context)
        {
            _context = context;
        }

        // GET: api/Clientes/correoElectronico
        [HttpGet("{correoElectronico}")]

        public async Task<ActionResult<Cliente>> GetCliente(string correoElectronico)
        {
            List<Cliente> clientes = await _context.Clientes.Where(x => x.Login.CorreoElectronico == correoElectronico).ToListAsync();

            if (clientes == null || clientes.Count == 0)
            {
                return NotFound();
            }
            else
            {
                Cliente cliente = clientes.First();
                return cliente;
            }
            

        }
    }
}
