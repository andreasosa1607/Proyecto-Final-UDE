﻿
using System;
using AV.DA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AVDA.Migrations
{
    [DbContext(typeof(AVDBContext))]
    partial class AVDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AV.BO.Administrador", b =>
                {
                    b.Property<int>("IdAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LoginCorreoElectronico")
                        .HasColumnType("VarChar(150)");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.HasKey("IdAdmin");

                    b.HasIndex("LoginCorreoElectronico");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("AV.BO.Asiento", b =>
                {
                    b.Property<int>("IdAsiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdReserva")
                        .HasColumnType("int");

                    b.Property<int>("MesaIdMesa")
                        .HasColumnType("int");

                    b.Property<int>("NroAsiento")
                        .HasColumnType("Integer");

                    b.Property<int?>("ReservaIdReserva")
                        .HasColumnType("int");

                    b.HasKey("IdAsiento");

                    b.HasIndex("MesaIdMesa");

                    b.HasIndex("ReservaIdReserva");

                    b.ToTable("Asientos");
                });

            modelBuilder.Entity("AV.BO.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.Property<byte[]>("FotoPerfil")
                        .HasColumnType("image");

                    b.Property<string>("IdiomaPreferencia")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("LoginCorreoElectronico")
                        .HasColumnType("VarChar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.Property<string>("NroDocumento")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<string>("ProfesionCargo")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.Property<int>("Telefono")
                        .HasColumnType("Integer");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("VarChar(20)");

                    b.HasKey("ClienteId");

                    b.HasIndex("LoginCorreoElectronico");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("AV.BO.ComprobanteDePago", b =>
                {
                    b.Property<int>("IdDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.HasKey("IdDocumento");

                    b.ToTable("ComprobantesDePagos");
                });

            modelBuilder.Entity("AV.BO.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barrio")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.Property<string>("CallePuerta")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.Property<int>("CantidadAsientosMesa")
                        .HasColumnType("Integer");

                    b.Property<int>("CantidadMesas")
                        .HasColumnType("Integer");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.Property<string>("CriterioAsignacion")
                        .IsRequired()
                        .HasColumnType("VarChar(20)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("VarChar(300)");

                    b.Property<string>("Duracion")
                        .IsRequired()
                        .HasColumnType("VarChar(10)");

                    b.Property<string>("EmpresaCreadora")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("EstadoEvento")
                        .IsRequired()
                        .HasColumnType("Varchar(30)");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasColumnType("VarChar(20)");

                    b.Property<string>("ImagenPortada")
                        .HasColumnType("VarChar(100)");

                    b.Property<string>("Moneda")
                        .IsRequired()
                        .HasColumnType("Varchar(3)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.Property<int>("NroCupos")
                        .HasColumnType("Integer");

                    b.Property<int>("PrecioAsiento")
                        .HasColumnType("Integer");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("VarChar(30)");

                    b.Property<string>("TipoAsignacion")
                        .IsRequired()
                        .HasColumnType("VarChar(20)");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("AV.BO.Login", b =>
                {
                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("VarChar(150)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("VarChar(200)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("VarChar(20)");

                    b.HasKey("CorreoElectronico");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("AV.BO.Mesa", b =>
                {
                    b.Property<int>("IdMesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadAsientos")
                        .HasColumnType("Integer");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<int>("LugaresDisponibles")
                        .HasColumnType("Integer");

                    b.Property<int>("NroMesa")
                        .HasColumnType("Integer");

                    b.HasKey("IdMesa");

                    b.HasIndex("EventoId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("AV.BO.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadReservas")
                        .HasColumnType("Integer");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoQR")
                        .HasColumnType("VarChar(100)");

                    b.Property<int?>("ComprobanteDePagoIdDocumento")
                        .HasColumnType("int");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("DescripcionEstado")
                        .IsRequired()
                        .HasColumnType("VarChar(50)");

                    b.Property<string>("EstadoReserva")
                        .IsRequired()
                        .HasColumnType("VarChar(20)");

                    b.Property<int?>("EventoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("DateTime");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.Property<int>("ReservasSinAsignar")
                        .HasColumnType("Integer");

                    b.Property<int>("Telefono")
                        .HasColumnType("Integer");

                    b.HasKey("IdReserva");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ComprobanteDePagoIdDocumento");

                    b.HasIndex("EventoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("AV.BO.Administrador", b =>
                {
                    b.HasOne("AV.BO.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginCorreoElectronico");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("AV.BO.Asiento", b =>
                {
                    b.HasOne("AV.BO.Mesa", null)
                        .WithMany("Asientos")
                        .HasForeignKey("MesaIdMesa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AV.BO.Reserva", null)
                        .WithMany("Asientos")
                        .HasForeignKey("ReservaIdReserva");
                });

            modelBuilder.Entity("AV.BO.Cliente", b =>
                {
                    b.HasOne("AV.BO.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginCorreoElectronico");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("AV.BO.Mesa", b =>
                {
                    b.HasOne("AV.BO.Evento", null)
                        .WithMany("Mesas")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AV.BO.Reserva", b =>
                {
                    b.HasOne("AV.BO.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("AV.BO.ComprobanteDePago", "ComprobanteDePago")
                        .WithMany()
                        .HasForeignKey("ComprobanteDePagoIdDocumento");

                    b.HasOne("AV.BO.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId");

                    b.Navigation("Cliente");

                    b.Navigation("ComprobanteDePago");

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("AV.BO.Evento", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("AV.BO.Mesa", b =>
                {
                    b.Navigation("Asientos");
                });

            modelBuilder.Entity("AV.BO.Reserva", b =>
                {
                    b.Navigation("Asientos");
                });
#pragma warning restore 612, 618
        }
    }
}
