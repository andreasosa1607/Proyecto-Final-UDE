
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
using AV.BL;

namespace AV_API.Controllers
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class LoginesController : ControllerBase
    {
        private readonly AVDBContext _context;

        public LoginesController(AVDBContext context)
        {
            _context = context;
        }

        // GET: api_1_0/Logines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginDTO>>> GetLogins()
        {
            // return await _context.Logins.ToListAsync();
            return await _context.Logins
           .Select(x => MapeoDTO.LoginDTO(x))
              .ToListAsync();
        }

        // GET: api_1_0/Logines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(string id)
        {
            var login = await _context.Logins.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;



        }

        [HttpGet("{id}/{passAnterior}")]
        public async Task<ActionResult<Login>> GetLoginYPass(string id, string passAnterior)
        {
            var login = await _context.Logins.FindAsync(id);
            passAnterior = Encriptar.MD5(passAnterior);

            if (login == null)
            {
                return NotFound();
            }
            else
            {
                if (login.Contraseña == passAnterior)
                {
                    return login;
                }
                else
                {
                    return NotFound();
                }

            }
        }

        // PUT: api_1_0/Logines/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LoginDTO>> PutLogin(string id, LoginDTO loginDTO)
        {
            if (id != loginDTO.CorreoElectronico)
            {
                return BadRequest();
            }


            var login = await _context.Logins.FindAsync(id);


            if (login == null)

            {
                return NotFound();
            }

           
            loginDTO.Contraseña = Encriptar.MD5(loginDTO.Contraseña);

            login = MapeoDTO.ActualizarLogin(login, loginDTO);

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return MapeoDTO.LoginDTO(login);
        }

        // POST: api_1_0/Logines
        [HttpPost]
        public async Task<ActionResult<LoginDTO>> PostLogin(LoginDTO loginDTO)
        {
            Login login = MapeoDTO.Login(loginDTO);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginExists(login.CorreoElectronico))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLogin", new { id = login.CorreoElectronico }, login);
        }

        // DELETE: api_1_0/Logines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Login>> DeleteLogin(string id)
        {
            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();

            return login;
        }

        private bool LoginExists(string id)
        {
            return _context.Logins.Any(e => e.CorreoElectronico == id);
        }
    }
}
