//using AV.DA;
//using AV_DTO;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace AV_API.Controllers
//{
//    [Route("api_1_0/[controller]")]

//    [ApiController]
//    public class EditarClienteController : Controller
//    {

//        private readonly AVDBContext _context;

//        public EditarClienteController(AVDBContext context)
//        {
//            _context = context;
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
//        {

//            var cliente = await _context.Clientes.FindAsync(id);

//            if (cliente == null)
//            {
//                return NotFound();
//            }

//            return MapeoDTO.ClienteDTO(cliente);
//        }

//        // PUT: api/Clientes/5
//        [HttpPut("{id}")]
//        public async Task<ActionResult<ClienteDTO>> PutCliente(int id, EditarClienteDTO clienteDTO)
//        {
//         //   if (id != clienteDTO.ClienteId)
//            {
//                return BadRequest();
//            }
//          //  await _context.Logins.FindAsync(id);
//        //    var cliente = await _context.Clientes.FindAsync(id);
     

//            if (cliente == null)
//            {
//                return NotFound();
//            }

//            cliente = MapeoDTO.ActualizarCliente(cliente, clienteDTO);
//            _context.Entry(cliente).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ClienteExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }


//            return MapeoDTO.ClienteDTO(cliente);

//        }

//            private bool ClienteExists(int id)
//        {
//            return _context.Clientes.Any(e => e.ClienteId == id);
//        }

//    }


//}
