﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AV.BO;

namespace AV.DA
{
    public class AVDBContext : DbContext
    {

        public AVDBContext(DbContextOptions<AVDBContext> options) : base(options)
        {

        }

        // Este se agrega para invocarla por fuera del servicio
        public AVDBContext(DbContextOptions options, int op) : base(options)
        {
        }

        public object GetSection(string v)
        {
            throw new NotImplementedException();
        }

        //este método es para que no autogenere los id de tipo int
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().Property(et => et.CorreoElectronico).ValueGeneratedNever();

        }

      

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<ComprobanteDePago> ComprobantesDePagos { get; set; }
    }
}
