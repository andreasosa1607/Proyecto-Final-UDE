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
    public class GetAdminCorreo : Controller
    {
        private readonly AVDBContext _context;

        public GetAdminCorreo(AVDBContext context)
        {
            _context = context;
        }

        [HttpGet("{correoElectronico}/{pass}")]

        public async Task<ActionResult<Administrador>> GetAdmin(string correoElectronico, string pass)
        {
            var login = await _context.Logins.FindAsync(correoElectronico);

            if (login == null)
            {
                return NotFound();
            }
            else
            {
                if (login.Contraseña == pass)
                {

                    List<Administrador> administradores = await _context.Administradores.Where(x => x.Login.CorreoElectronico == login.CorreoElectronico).ToListAsync();

                    if (administradores == null || administradores.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        Administrador administrador = administradores.First();
                        return administrador;
                    }
                }
                else
                {
                    return NotFound();
                }

            }
        }


        [HttpGet("{correoElectronico}")]
        public async Task<ActionResult<Administrador>> GetAdmin(string correoElectronico)
        {
            var login = await _context.Logins.FindAsync(correoElectronico);

            if (login == null)
            {
                return NotFound();
            }
            else
            {
                    List<Administrador> administradores = await _context.Administradores.Where(x => x.Login.CorreoElectronico == login.CorreoElectronico).ToListAsync();

                    if (administradores == null || administradores.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        Administrador administrador = administradores.First();
                        return administrador;
                    }
                
                }

            }
        }
    }
