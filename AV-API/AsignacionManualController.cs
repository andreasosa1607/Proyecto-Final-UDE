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

namespace AV_API
{
    [Route("api_1_0/[controller]")]
    [ApiController]

    public class AsignacionManualController : ControllerBase
    {
        private readonly AVDBContext _context;

        public AsignacionManualController(AVDBContext context)
        {
            _context = context;
        }

        // GET: api/AsignacionManual
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasAprobadas()
        {


            return await _context.Reservas.Include("Cliente").Include("Evento").Where(x => x.EstadoReserva == "Aprobada").ToListAsync();

        }
    }
}

            