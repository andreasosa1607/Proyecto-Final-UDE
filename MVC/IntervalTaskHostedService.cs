﻿using AV.BO;
using AV.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using AV.BL;

namespace MVC
{
    public class IntervalTaskHostedService : IHostedService, IDisposable
    {


        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(llamoEventoAsync, null, TimeSpan.Zero, TimeSpan.FromHours(24));
            _timer = new Timer(llamoReservasAsync, null, TimeSpan.Zero, TimeSpan.FromHours(24));
            return Task.CompletedTask;
        }


        public async void llamoEventoAsync(object state)
        {
            await GetEventosAsync();
        }

        public async Task GetEventosAsync()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlServer("Data Source=localhost;Initial Catalog=AVBase;Integrated Security=true");
            AVDBContext _context= new AVDBContext(options.Options, 0);


            List<Evento> eventos = await _context.Eventos.ToListAsync();
            foreach (Evento evento in eventos)
            {

                EventoBL.cambiarEstadoEvento(evento);
                await _context.SaveChangesAsync();
                _context.Eventos.Update(evento);

            }
        }


        public async void llamoReservasAsync(object state)
        {
            await GetReservasAsync();
        }

        public async Task GetReservasAsync()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlServer("Data Source=localhost;Initial Catalog=AVBase;Integrated Security=true");
            AVDBContext _context = new AVDBContext(options.Options, 0);


            List<Reserva> reservas = await _context.Reservas.Include("Cliente").Include("Evento").ToListAsync();
            foreach (Reserva reserva in reservas)
            {

                ReservaBL.cancelarReserva(reserva);
                await _context.SaveChangesAsync();
                _context.Reservas.Update(reserva);

            }
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

