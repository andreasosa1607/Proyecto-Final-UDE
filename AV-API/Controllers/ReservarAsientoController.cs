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
    public class ReservarAsientoController : ControllerBase
    {
        private readonly AVDBContext _context;

        public ReservarAsientoController(AVDBContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<ActionResult<Reserva>> Reservados(ReservaDTO reservaDTO)
        {
            Reserva reserva = MapeoDTO.Reserva(reservaDTO);
            string asignado = "";
            int asientosAsignados = 0;
            List<Asiento> asientosNoAsignados = reserva.Asientos;
            var mesa = _context.Mesas.Find(asientosNoAsignados.First().MesaIdMesa);
            //reserva.Asientos = new List<Asiento>();
            //string asignado = "";
            if (reserva != null)
            {
                foreach (Asiento asiento in asientosNoAsignados)
                {
                    asiento.IdReserva = reserva.IdReserva;
                    _context.Entry(asiento).State = EntityState.Modified;

                    mesa.LugaresDisponibles = (mesa.LugaresDisponibles) - 1;
                    asientosAsignados = asientosAsignados + 1;
                    //reservaRubro.ReservasSinAsignar = (reservaRubro.ReservasSinAsignar) - 1;
                    //asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                    reserva.ReservasSinAsignar = (reserva.ReservasSinAsignar) - 1;
                    asignado = asignado + "\n" + "Mesa " + mesa.NroMesa + ", Asiento" + asiento.NroAsiento + "\n";
                    if (asientosAsignados >= reserva.CantidadReservas && reserva.ReservasSinAsignar == 0)
                    {
                        reserva.EstadoReserva = "Asignada";
                        ReservaBL.GenerarQR(reserva);
                        ReservaBL.ReservaAsignada(reserva, reserva.CodigoQR, asignado);
                        asientosAsignados = 0;

                    }

                }
                _context.Entry(mesa).State = EntityState.Modified;
                _context.Entry(reserva).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(MapeoDTO.ReservaDTO(reserva));
            }
            return NotFound();



        }



        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}
