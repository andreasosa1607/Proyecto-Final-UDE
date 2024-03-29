﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AV.BO;
using AV.DA;
using AV.DA.ServiceCorreosElectronicos;
using AV_DTO;
using Microsoft.AspNetCore.Authorization;
using AV.BL;

namespace AV_API.Controllers
{

    [Route("api_1_0/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
      
        private readonly AVDBContext _context;

        public ClientesController(AVDBContext context)
        {
            _context = context;
        }

        // GET: api_1_0/Clientes
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {
            // return await _context.Clientes.ToListAsync();
            return await _context.Clientes
           .Select(x => MapeoDTO.ClienteDTO(x))
              .ToListAsync();
        }

        // GET: api_1_0/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api_1_0/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.ClienteId)
            {
                return BadRequest();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente = MapeoDTO.ActualizarCliente(cliente, clienteDTO);
            _context.Entry(cliente).State = EntityState.Modified;
          
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api_1_0/Clientes
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> PostCliente(ClienteDTO clienteDTO)
        {
            
            Cliente cliente = MapeoDTO.Cliente(clienteDTO);
            cliente.Login.Contraseña = Encriptar.MD5(cliente.Login.Contraseña);
           
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        // DELETE: api_1_0/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }


    
    }
}
