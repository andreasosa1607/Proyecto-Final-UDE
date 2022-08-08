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

namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly AVDBContext _context;

        public AdministradoresController(AVDBContext context)
        {
            _context = context;
        }

        // GET: api/Administradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdministradorDTO>>> GetAdministradores()
        {
            //return await _context.Administradores.ToListAsync();

            return await _context.Administradores
                .Select(x => MapeoDTO.AdministradorDTO(x))
                .ToListAsync();
        }
        // GET: api/Administradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdministradorDTO>> GetAdministrador(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return Ok(administrador);
        }

        // PUT: api/Administradores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, AdministradorDTO administradorDTO)
        {
            if (id != administradorDTO.IdAdmin)
            {
                return BadRequest();
            }

            var administrador = await _context.Administradores.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            administrador = MapeoDTO.ActualizarAdministrador(administrador, administradorDTO);
            _context.Entry(administrador).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // POST: api/Administradores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdministradorDTO>> PostAdministrador(AdministradorDTO administradorDTO)
        {
            Administrador administrador = MapeoDTO.Administrador(administradorDTO);
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrador", new { id = administrador.IdAdmin }, administrador);
        }

        // DELETE: api/Administradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.IdAdmin == id);
        }
    }
}
