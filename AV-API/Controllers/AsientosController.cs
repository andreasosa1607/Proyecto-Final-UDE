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
    [Route("api/[controller]")]
    [ApiController]
    public class AsientosController : ControllerBase
    {
        private readonly AVDBContext _context;

        public AsientosController(AVDBContext context)
        {
            _context = context;
        }

        // GET: api/Asientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asiento>>> GetAsientos()
        {
            return await _context.Asientos.ToListAsync();
        }

        // GET: api/Asientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asiento>> GetAsiento(int id)
        {
            var asiento = await _context.Asientos.FindAsync(id);

            if (asiento == null)
            {
                return NotFound();
            }

            return asiento;
        }

        // PUT: api/Asientos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsiento(int id, Asiento asiento)
        {
            if (id != asiento.NroAsiento)
            {
                return BadRequest();
            }

            _context.Entry(asiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientoExists(id))
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

        // POST: api/Asientos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asiento>> PostAsiento(Asiento asiento)
        {
            _context.Asientos.Add(asiento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AsientoExists(asiento.NroAsiento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsiento", new { id = asiento.NroAsiento }, asiento);
        }

        // DELETE: api/Asientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsiento(int id)
        {
            var asiento = await _context.Asientos.FindAsync(id);
            if (asiento == null)
            {
                return NotFound();
            }

            _context.Asientos.Remove(asiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsientoExists(int id)
        {
            return _context.Asientos.Any(e => e.NroAsiento == id);
        }
    }
}
