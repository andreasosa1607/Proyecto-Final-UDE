using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AV.BO;
using AV.DA;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using AV.BL;
using AV_DTO;

namespace AV_API
{
    [Route("api_1_0/[controller]")]
    [ApiController]
    public class GenerarQRController : ControllerBase
    {
        private readonly AVDBContext _context;

        public GenerarQRController(AVDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            return ReservaBL.GenerarQR(reserva);
         
        }

       
    }
}
