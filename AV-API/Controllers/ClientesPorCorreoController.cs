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
    public class ClientesPorCorreoController : Controller
    {
        private readonly AVDBContext _context;


        public ClientesPorCorreoController(AVDBContext context)
        {
            _context = context;
        }


        [HttpGet("{correoElectronico}")]
        public async Task<ActionResult<int>> GetLoginCorreo(string correoElectronico)
        {
            
            List<Login> logins = await _context.Logins.Where(x => x.CorreoElectronico == correoElectronico).ToListAsync();


            if (logins == null || logins.Count == 0)

            {
                return 0;
            }
            else
            {
                Login login = logins.First();
                string Correo = login.CorreoElectronico;
                Random rndm = new Random();
                int codigo = rndm.Next(10001, 99999);
                var correoService = new AV.DA.ServiceCorreosElectronicos.SoporteCorreos();
                correoService.enviarCorreo(
                    asunto: "SISTEMA: Solicitud de reseteo de contraseña",
                    cuerpo: "Hola! \nUsted solicitó resetear su contraseña.\n" +
                    "Su codigo es: " + codigo +
                    "\n Debe ingresarlo en el campo 'Ingrese el codigo' en el navegador.",
                    destinatarios: new List<string> { correoElectronico }
                    );
                return codigo;
            }

        }
    
    }
}
