using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AV.BO;
using AV.DA;
using AV.BL;

namespace AV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CambiarEstadoEventoController : ControllerBase
    {
        private readonly AVDBContext _context;

        public CambiarEstadoEventoController(AVDBContext context)
        {
            _context = context;
        }



    }
}