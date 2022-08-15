﻿using System;
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
    public class AsientosController : ControllerBase
    {
        private readonly AVDBContext _context;

        public AsientosController(AVDBContext context)
        {
            _context = context;
        }

        // GET: api/Asientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsientoDTO>>> GetAsientos()
        {
            //return await _context.Asientos.ToListAsync();
            return await _context.Asientos
             .Select(x => MapeoDTO.AsientoDTO(x))
                .ToListAsync();
        }

        // GET: api/Asientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsientoDTO>> GetAsiento(int id)
        {
            var asiento = await _context.Asientos.FindAsync(id);

            if (asiento == null)
            {
                return NotFound();
            }

            return Ok(asiento);
        }

        // PUT: api/Asientos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsiento(int id, AsientoDTO asientoDTO)
        {
            if (id != asientoDTO.NroAsiento)
            {
                return BadRequest();
            }

            var asiento = await _context.Asientos.FindAsync(id);
            if (asiento == null)
            {
                return NotFound();
            }

            asiento = MapeoDTO.ActualizarAsiento(asiento, asientoDTO);
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
        public async Task<ActionResult<AsientoDTO>> PostAsiento(AsientoDTO asientoDTO)
        {
            Asiento asiento = MapeoDTO.Asiento(asientoDTO);
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
