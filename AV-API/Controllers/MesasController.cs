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
    public class MesasController : ControllerBase
    {
        private readonly AVDBContext _context;

        public MesasController(AVDBContext context)
        {
            _context = context;
        }

        // GET:api_1_0/Mesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MesaDTO>>> GetMesas()
        {
            return await _context.Mesas
            .Select(x => MapeoDTO.MesaDTO(x))
               .ToListAsync();
        }

        // GET: api_1_0/Mesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MesaDTO>> GetMesa(int id)
        {
            var mesa = await _context.Mesas.FindAsync(id);

            if (mesa == null)
            {
                return NotFound();
            }

            return Ok(mesa);
        }

        // PUT: api_1_0/Mesas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesa(int id, MesaDTO mesaDTO)
        {
            if (id != mesaDTO.NroMesa)
            {
                return BadRequest();
            }
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)

            {
                return NotFound();
            }

            mesa = MapeoDTO.ActualizarMesa(mesa, mesaDTO);
            _context.Entry(mesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesaExists(id))
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

        // POST: api_1_0/Mesas
        [HttpPost]
        public async Task<ActionResult<MesaDTO>> PostMesa(MesaDTO mesaDTO)
        {
            Mesa mesa = MapeoDTO.Mesa(mesaDTO);
            _context.Mesas.Add(mesa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MesaExists(mesa.NroMesa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMesa", new { id = mesa.NroMesa }, mesa);
        }

        // DELETE: api_1_0/Mesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            _context.Mesas.Remove(mesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MesaExists(int id)
        {
            return _context.Mesas.Any(e => e.NroMesa == id);
        }
    }
}
