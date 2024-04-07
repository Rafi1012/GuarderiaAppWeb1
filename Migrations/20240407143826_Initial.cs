using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuarderiaAppWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autorizaciones",
                columns: table => new
                {
                    IdAutorizado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recoger = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorizaciones", x => x.IdAutorizado);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IdIngrediente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomIngrediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMenu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IdIngrediente);
                });

            migrationBuilder.CreateTable(
                name: "Ninos",
                columns: table => new
                {
                    Matricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninos", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAutorizado = table.Column<int>(type: "int", nullable: false),
                    Nofactura = table.Column<int>(type: "int", nullable: false),
                    Nocuenta = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Autorizaciones_IdAutorizado",
                        column: x => x.IdAutorizado,
                        principalTable: "Autorizaciones",
                        principalColumn: "IdAutorizado");
                });

            migrationBuilder.CreateTable(
                name: "Alergias",
                columns: table => new
                {
                    IdAlergia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    IdMenu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergias", x => x.IdAlergia);
                    table.ForeignKey(
                        name: "FK_Alergias_Ninos_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Ninos",
                        principalColumn: "Matricula");
                });

            migrationBuilder.CreateTable(
                name: "Consumos",
                columns: table => new
                {
                    IdConsumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    IdMenu = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumos", x => x.IdConsumo);
                    table.ForeignKey(
                        name: "FK_Consumos_Ninos_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Ninos",
                        principalColumn: "Matricula");
                });

            migrationBuilder.CreateTable(
                name: "NinoAutorizacion",
                columns: table => new
                {
                    AutorizacionIdAutorizado = table.Column<int>(type: "int", nullable: false),
                    NinosMatricula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinoAutorizacion", x => new { x.AutorizacionIdAutorizado, x.NinosMatricula });
                    table.ForeignKey(
                        name: "FK_NinoAutorizacion_Autorizaciones_AutorizacionIdAutorizado",
                        column: x => x.AutorizacionIdAutorizado,
                        principalTable: "Autorizaciones",
                        principalColumn: "IdAutorizado");
                    table.ForeignKey(
                        name: "FK_NinoAutorizacion_Ninos_NinosMatricula",
                        column: x => x.NinosMatricula,
                        principalTable: "Ninos",
                        principalColumn: "Matricula");
                });

            migrationBuilder.CreateTable(
                name: "CargoMensuales",
                columns: table => new
                {
                    NoFactura = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    CostoFijo = table.Column<int>(type: "int", nullable: false),
                    TotalConsumo = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoMensuales", x => x.NoFactura);
                    table.ForeignKey(
                        name: "FK_CargoMensuales_Ninos_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Ninos",
                        principalColumn: "Matricula");
                    table.ForeignKey(
                        name: "FK_CargoMensuales_Pagos_NoFactura",
                        column: x => x.NoFactura,
                        principalTable: "Pagos",
                        principalColumn: "IdPago");
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    IdMenu = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    NomPlato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.IdMenu);
                    table.ForeignKey(
                        name: "FK_Menus_Alergias_IdMenu",
                        column: x => x.IdMenu,
                        principalTable: "Alergias",
                        principalColumn: "IdAlergia");
                    table.ForeignKey(
                        name: "FK_Menus_Consumos_IdMenu",
                        column: x => x.IdMenu,
                        principalTable: "Consumos",
                        principalColumn: "IdConsumo");
                });

            migrationBuilder.CreateTable(
                name: "MenuIngrediente",
                columns: table => new
                {
                    IngredienteIdIngrediente = table.Column<int>(type: "int", nullable: false),
                    MenuIdMenu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuIngrediente", x => new { x.IngredienteIdIngrediente, x.MenuIdMenu });
                    table.ForeignKey(
                        name: "FK_MenuIngrediente_Ingredientes_IngredienteIdIngrediente",
                        column: x => x.IngredienteIdIngrediente,
                        principalTable: "Ingredientes",
                        principalColumn: "IdIngrediente");
                    table.ForeignKey(
                        name: "FK_MenuIngrediente_Menus_MenuIdMenu",
                        column: x => x.MenuIdMenu,
                        principalTable: "Menus",
                        principalColumn: "IdMenu");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alergias_Matricula",
                table: "Alergias",
                column: "Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_CargoMensuales_Matricula",
                table: "CargoMensuales",
                column: "Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_Consumos_Matricula",
                table: "Consumos",
                column: "Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_MenuIngrediente_MenuIdMenu",
                table: "MenuIngrediente",
                column: "MenuIdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_NinoAutorizacion_NinosMatricula",
                table: "NinoAutorizacion",
                column: "NinosMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdAutorizado",
                table: "Pagos",
                column: "IdAutorizado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoMensuales");

            migrationBuilder.DropTable(
                name: "MenuIngrediente");

            migrationBuilder.DropTable(
                name: "NinoAutorizacion");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Autorizaciones");

            migrationBuilder.DropTable(
                name: "Alergias");

            migrationBuilder.DropTable(
                name: "Consumos");

            migrationBuilder.DropTable(
                name: "Ninos");
        }
    }
}
