using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AV.DA.Migrations
{
    public partial class creacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "VarChar(20)", nullable: false),
                    NroDocumento = table.Column<int>(type: "Integer", nullable: false),
                    Nombre = table.Column<string>(type: "VarChar(50)", nullable: false),
                    Apellidos = table.Column<string>(type: "VarChar(100)", nullable: false),
                    Telefono = table.Column<int>(type: "Integer", nullable: false),
                    ProfesionCargo = table.Column<string>(type: "VarChar(100)", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "VarChar(100)", nullable: false),
                    FotoPerfil = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VarChar(100)", nullable: false),
                    Descripcion = table.Column<string>(type: "VarChar(300)", nullable: false),
                    Tipo = table.Column<string>(type: "VarChar(30)", nullable: false),
                    ImagenPortada = table.Column<byte[]>(type: "image", nullable: false),
                    Lugar = table.Column<string>(type: "VarChar(100)", nullable: false),
                    NroCupos = table.Column<int>(type: "Integer", nullable: false),
                    CantidadMesas = table.Column<int>(type: "Integer", nullable: false),
                    CantidadAsientosMesa = table.Column<int>(type: "Integer", nullable: false),
                    PrecioAsiento = table.Column<int>(type: "Integer", nullable: false),
                    Idioma = table.Column<string>(type: "VarChar(20)", nullable: false),
                    CriterioAsignacion = table.Column<string>(type: "VarChar(20)", nullable: false),
                    EmpresaCreadora = table.Column<string>(type: "Varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    CorreoElectronico = table.Column<string>(type: "VarChar(150)", nullable: false),
                    Rol = table.Column<string>(type: "VarChar(20)", nullable: false),
                    Contraseña = table.Column<string>(type: "VarChar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.CorreoElectronico);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    NroMesa = table.Column<int>(type: "int", nullable: false),
                    CantidadAsientos = table.Column<int>(type: "Int", nullable: false),
                    LugaresDisponibles = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.NroMesa);
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    NroAsiento = table.Column<int>(type: "int", nullable: false),
                    MesaNroMesa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.NroAsiento);
                    table.ForeignKey(
                        name: "FK_Asientos_Mesas_MesaNroMesa",
                        column: x => x.MesaNroMesa,
                        principalTable: "Mesas",
                        principalColumn: "NroMesa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    EventoId = table.Column<int>(type: "int", nullable: true),
                    EstadoReserva = table.Column<string>(type: "VarChar(20)", nullable: false),
                    ComprobantePago = table.Column<byte[]>(type: "image", nullable: false),
                    AsientoNroAsiento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Asientos_AsientoNroAsiento",
                        column: x => x.AsientoNroAsiento,
                        principalTable: "Asientos",
                        principalColumn: "NroAsiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoPago = table.Column<string>(type: "VarChar(20)", nullable: false),
                    Comentario = table.Column<string>(type: "VarChar(200)", nullable: false),
                    ReservaIdReserva = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Reservas_ReservaIdReserva",
                        column: x => x.ReservaIdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpresa = table.Column<string>(type: "VarChar(100)", nullable: false),
                    PagoIdPago = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.IdAdmin);
                    table.ForeignKey(
                        name: "FK_Administradores_Pagos_PagoIdPago",
                        column: x => x.PagoIdPago,
                        principalTable: "Pagos",
                        principalColumn: "IdPago",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_PagoIdPago",
                table: "Administradores",
                column: "PagoIdPago");

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_MesaNroMesa",
                table: "Asientos",
                column: "MesaNroMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ReservaIdReserva",
                table: "Pagos",
                column: "ReservaIdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AsientoNroAsiento",
                table: "Reservas",
                column: "AsientoNroAsiento");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_EventoId",
                table: "Reservas",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Mesas");
        }
    }
}
