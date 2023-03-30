using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dealer.Migrations
{
    public partial class DealerDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "color_exterior",
                columns: table => new
                {
                    id_color_exterior = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    color_exterior = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    precio_color_exterior = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__color_ex__A6FF2A213232A96E", x => x.id_color_exterior);
                });

            migrationBuilder.CreateTable(
                name: "color_interior",
                columns: table => new
                {
                    id_color_interior = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    color_interior = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    precio_color_interior = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__color_in__9E309F1B7D2FD41D", x => x.id_color_interior);
                });

            migrationBuilder.CreateTable(
                name: "concesionario",
                columns: table => new
                {
                    id_concesionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_concesionario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    img = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__concesio__FE95AA278C47716B", x => x.id_concesionario);
                });

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    id_marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_marca = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    url_logo_marca = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__marca__7E43E99E2906E87E", x => x.id_marca);
                });

            migrationBuilder.CreateTable(
                name: "metodo_pago",
                columns: table => new
                {
                    id_metodo_pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    metodo_pago = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__metodo_p__85BE0EBC15E505E9", x => x.id_metodo_pago);
                });

            migrationBuilder.CreateTable(
                name: "servicio_oficial_clientes",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_servicio_oficial = table.Column<int>(type: "int", nullable: true),
                    nombre_cliente = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    cedula_cliente = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    telefono_cliente = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__servicio__677F38F5B63FA532", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "vehiculos_vendidos",
                columns: table => new
                {
                    id_vehiculo_vendido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    modelo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    VIN = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: true),
                    cliente = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    vendedor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__vehiculo__EBE1BF2D84DF5318", x => x.id_vehiculo_vendido);
                });

            migrationBuilder.CreateTable(
                name: "servicio_oficial",
                columns: table => new
                {
                    id_servicio_oficial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_concesionario = table.Column<int>(type: "int", nullable: true),
                    nombre_servicio_oficial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    domicilio_servicio_oficial = table.Column<string>(type: "text", nullable: true),
                    rnc_servicio_oficial = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    img_concesionario = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__servicio__50B63F8234B1E4DA", x => x.id_servicio_oficial);
                    table.ForeignKey(
                        name: "fk_servicioOficial_concesionario",
                        column: x => x.id_concesionario,
                        principalTable: "concesionario",
                        principalColumn: "id_concesionario");
                });

            migrationBuilder.CreateTable(
                name: "modelo",
                columns: table => new
                {
                    id_modelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_marca = table.Column<int>(type: "int", nullable: true),
                    nombre_modelo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    potencia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cilindrada = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    combustible = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pasajeros = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    traccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    precio_base = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    img_modelo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__modelo__B3BFCFF1FF4D45DF", x => x.id_modelo);
                    table.ForeignKey(
                        name: "fk_modelo_to_marca",
                        column: x => x.id_marca,
                        principalTable: "marca",
                        principalColumn: "id_marca");
                });

            migrationBuilder.CreateTable(
                name: "servicio_oficial_vendedores",
                columns: table => new
                {
                    id_vendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_servicio_oficial = table.Column<int>(type: "int", nullable: true),
                    nombre_vendedor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    cedula_vendedor = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    domicilio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__servicio__0093030840C18B5E", x => x.id_vendedor);
                    table.ForeignKey(
                        name: "fk_servicioOficial_vendedores",
                        column: x => x.id_servicio_oficial,
                        principalTable: "servicio_oficial",
                        principalColumn: "id_servicio_oficial");
                });

            migrationBuilder.CreateTable(
                name: "equipamiento_extra",
                columns: table => new
                {
                    id_equipamiento_extra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_modelo = table.Column<int>(type: "int", nullable: true),
                    nombre_equipamiento_extra = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    img = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__equipami__E517FE91DF344DC9", x => x.id_equipamiento_extra);
                    table.ForeignKey(
                        name: "fk_equipamientoExtra_modelo",
                        column: x => x.id_modelo,
                        principalTable: "modelo",
                        principalColumn: "id_modelo");
                });

            migrationBuilder.CreateTable(
                name: "equipamiento_serie",
                columns: table => new
                {
                    id_equipamiento_serie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_modelo = table.Column<int>(type: "int", nullable: true),
                    nombre_equipamiento_extra = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__equipami__FA575F32D8200466", x => x.id_equipamiento_serie);
                    table.ForeignKey(
                        name: "fk_equipamientoSerie_modelo",
                        column: x => x.id_modelo,
                        principalTable: "modelo",
                        principalColumn: "id_modelo");
                });

            migrationBuilder.CreateTable(
                name: "vehiculos_stock",
                columns: table => new
                {
                    id_vehiculo_stock = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_marca = table.Column<int>(type: "int", nullable: true),
                    id_modelo = table.Column<int>(type: "int", nullable: true),
                    VIN = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: true),
                    color_exterior = table.Column<int>(type: "int", nullable: true),
                    color_interior = table.Column<int>(type: "int", nullable: true),
                    anio = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    descripcion_equipamiento_extra = table.Column<string>(type: "text", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    img = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__vehiculo__2C97B5734C4173AF", x => x.id_vehiculo_stock);
                    table.ForeignKey(
                        name: "fk_vehiculoStock_color_exterior",
                        column: x => x.color_exterior,
                        principalTable: "color_exterior",
                        principalColumn: "id_color_exterior");
                    table.ForeignKey(
                        name: "fk_vehiculoStock_color_interior",
                        column: x => x.color_interior,
                        principalTable: "color_interior",
                        principalColumn: "id_color_interior");
                    table.ForeignKey(
                        name: "fk_vehiculoStock_marca",
                        column: x => x.id_marca,
                        principalTable: "marca",
                        principalColumn: "id_marca");
                    table.ForeignKey(
                        name: "fk_vehiculoStock_modelo",
                        column: x => x.id_modelo,
                        principalTable: "modelo",
                        principalColumn: "id_modelo");
                });

            migrationBuilder.CreateTable(
                name: "vehiculo_personalizado",
                columns: table => new
                {
                    id_construccion_vehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_marca = table.Column<int>(type: "int", nullable: true),
                    id_modelo = table.Column<int>(type: "int", nullable: true),
                    VIN = table.Column<string>(type: "varchar(17)", unicode: false, maxLength: 17, nullable: true),
                    color_exterior = table.Column<int>(type: "int", nullable: true),
                    color_interior = table.Column<int>(type: "int", nullable: true),
                    extra_01 = table.Column<int>(type: "int", nullable: true),
                    extra_02 = table.Column<int>(type: "int", nullable: true),
                    extra_03 = table.Column<int>(type: "int", nullable: true),
                    extra_04 = table.Column<int>(type: "int", nullable: true),
                    extra_05 = table.Column<int>(type: "int", nullable: true),
                    extra_06 = table.Column<int>(type: "int", nullable: true),
                    extra_07 = table.Column<int>(type: "int", nullable: true),
                    extra_08 = table.Column<int>(type: "int", nullable: true),
                    extra_09 = table.Column<int>(type: "int", nullable: true),
                    extra_10 = table.Column<int>(type: "int", nullable: true),
                    extra_11 = table.Column<int>(type: "int", nullable: true),
                    extra_12 = table.Column<int>(type: "int", nullable: true),
                    extra_13 = table.Column<int>(type: "int", nullable: true),
                    extra_14 = table.Column<int>(type: "int", nullable: true),
                    extra_15 = table.Column<int>(type: "int", nullable: true),
                    extra_16 = table.Column<int>(type: "int", nullable: true),
                    extra_17 = table.Column<int>(type: "int", nullable: true),
                    extra_18 = table.Column<int>(type: "int", nullable: true),
                    extra_19 = table.Column<int>(type: "int", nullable: true),
                    extra_20 = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__vehiculo__712ECA30B9B48AEF", x => x.id_construccion_vehiculo);
                    table.ForeignKey(
                        name: "fk_construct_color_exterior",
                        column: x => x.color_exterior,
                        principalTable: "color_exterior",
                        principalColumn: "id_color_exterior");
                    table.ForeignKey(
                        name: "fk_construct_color_interior",
                        column: x => x.color_interior,
                        principalTable: "color_interior",
                        principalColumn: "id_color_interior");
                    table.ForeignKey(
                        name: "fk_construct_extra01",
                        column: x => x.extra_01,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra02",
                        column: x => x.extra_02,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra03",
                        column: x => x.extra_03,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra04",
                        column: x => x.extra_04,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra05",
                        column: x => x.extra_05,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra06",
                        column: x => x.extra_06,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra07",
                        column: x => x.extra_07,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra08",
                        column: x => x.extra_08,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra09",
                        column: x => x.extra_09,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra10",
                        column: x => x.extra_10,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra11",
                        column: x => x.extra_11,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra12",
                        column: x => x.extra_12,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra13",
                        column: x => x.extra_13,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra14",
                        column: x => x.extra_14,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra15",
                        column: x => x.extra_15,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra16",
                        column: x => x.extra_16,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra17",
                        column: x => x.extra_17,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra18",
                        column: x => x.extra_18,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra19",
                        column: x => x.extra_19,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_construct_extra20",
                        column: x => x.extra_20,
                        principalTable: "equipamiento_extra",
                        principalColumn: "id_equipamiento_extra");
                    table.ForeignKey(
                        name: "fk_constructVehiculo_marca",
                        column: x => x.id_marca,
                        principalTable: "marca",
                        principalColumn: "id_marca");
                    table.ForeignKey(
                        name: "fk_constructVehiculo_modelo",
                        column: x => x.id_modelo,
                        principalTable: "modelo",
                        principalColumn: "id_modelo");
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    id_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "date", nullable: true),
                    registro = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    id_concesionario = table.Column<int>(type: "int", nullable: true),
                    id_servicio_oficial = table.Column<int>(type: "int", nullable: true),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    id_vendedor = table.Column<int>(type: "int", nullable: true),
                    VIN_vehiculo_stock = table.Column<int>(type: "int", nullable: true),
                    VIN_vehiculo_personalizado = table.Column<int>(type: "int", nullable: true),
                    id_marca = table.Column<int>(type: "int", nullable: true),
                    id_modelo = table.Column<int>(type: "int", nullable: true),
                    precio_vehiculo_stock = table.Column<int>(type: "int", nullable: true),
                    precio_vehiculo_personalizado = table.Column<int>(type: "int", nullable: true),
                    fecha_entrega = table.Column<DateTime>(type: "date", nullable: true),
                    metodo_pago = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ventas__459533BF48EE8E87", x => x.id_venta);
                    table.ForeignKey(
                        name: "fk_venta_cliente",
                        column: x => x.id_cliente,
                        principalTable: "servicio_oficial_clientes",
                        principalColumn: "id_cliente");
                    table.ForeignKey(
                        name: "fk_venta_concesionario",
                        column: x => x.id_concesionario,
                        principalTable: "concesionario",
                        principalColumn: "id_concesionario");
                    table.ForeignKey(
                        name: "fk_venta_metodoPago",
                        column: x => x.metodo_pago,
                        principalTable: "metodo_pago",
                        principalColumn: "id_metodo_pago");
                    table.ForeignKey(
                        name: "fk_venta_precioPersonalizado",
                        column: x => x.precio_vehiculo_personalizado,
                        principalTable: "vehiculo_personalizado",
                        principalColumn: "id_construccion_vehiculo");
                    table.ForeignKey(
                        name: "fk_venta_precioStock",
                        column: x => x.precio_vehiculo_stock,
                        principalTable: "vehiculos_stock",
                        principalColumn: "id_vehiculo_stock");
                    table.ForeignKey(
                        name: "fk_venta_servicio_oficial",
                        column: x => x.id_servicio_oficial,
                        principalTable: "servicio_oficial",
                        principalColumn: "id_servicio_oficial");
                    table.ForeignKey(
                        name: "fk_venta_VehiculoMarca",
                        column: x => x.id_marca,
                        principalTable: "marca",
                        principalColumn: "id_marca");
                    table.ForeignKey(
                        name: "fk_venta_VehiculoModelo",
                        column: x => x.id_modelo,
                        principalTable: "modelo",
                        principalColumn: "id_modelo");
                    table.ForeignKey(
                        name: "fk_venta_vendedor",
                        column: x => x.id_vendedor,
                        principalTable: "servicio_oficial_vendedores",
                        principalColumn: "id_vendedor");
                    table.ForeignKey(
                        name: "fk_venta_VINpersonalizado",
                        column: x => x.VIN_vehiculo_personalizado,
                        principalTable: "vehiculo_personalizado",
                        principalColumn: "id_construccion_vehiculo");
                    table.ForeignKey(
                        name: "fk_venta_VINstock",
                        column: x => x.VIN_vehiculo_stock,
                        principalTable: "vehiculos_stock",
                        principalColumn: "id_vehiculo_stock");
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipamiento_extra_id_modelo",
                table: "equipamiento_extra",
                column: "id_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_equipamiento_serie_id_modelo",
                table: "equipamiento_serie",
                column: "id_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_modelo_id_marca",
                table: "modelo",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_servicio_oficial_id_concesionario",
                table: "servicio_oficial",
                column: "id_concesionario");

            migrationBuilder.CreateIndex(
                name: "IX_servicio_oficial_vendedores_id_servicio_oficial",
                table: "servicio_oficial_vendedores",
                column: "id_servicio_oficial");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_color_exterior",
                table: "vehiculo_personalizado",
                column: "color_exterior");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_color_interior",
                table: "vehiculo_personalizado",
                column: "color_interior");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_01",
                table: "vehiculo_personalizado",
                column: "extra_01");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_02",
                table: "vehiculo_personalizado",
                column: "extra_02");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_03",
                table: "vehiculo_personalizado",
                column: "extra_03");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_04",
                table: "vehiculo_personalizado",
                column: "extra_04");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_05",
                table: "vehiculo_personalizado",
                column: "extra_05");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_06",
                table: "vehiculo_personalizado",
                column: "extra_06");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_07",
                table: "vehiculo_personalizado",
                column: "extra_07");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_08",
                table: "vehiculo_personalizado",
                column: "extra_08");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_09",
                table: "vehiculo_personalizado",
                column: "extra_09");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_10",
                table: "vehiculo_personalizado",
                column: "extra_10");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_11",
                table: "vehiculo_personalizado",
                column: "extra_11");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_12",
                table: "vehiculo_personalizado",
                column: "extra_12");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_13",
                table: "vehiculo_personalizado",
                column: "extra_13");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_14",
                table: "vehiculo_personalizado",
                column: "extra_14");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_15",
                table: "vehiculo_personalizado",
                column: "extra_15");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_16",
                table: "vehiculo_personalizado",
                column: "extra_16");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_17",
                table: "vehiculo_personalizado",
                column: "extra_17");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_18",
                table: "vehiculo_personalizado",
                column: "extra_18");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_19",
                table: "vehiculo_personalizado",
                column: "extra_19");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_extra_20",
                table: "vehiculo_personalizado",
                column: "extra_20");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_id_marca",
                table: "vehiculo_personalizado",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculo_personalizado_id_modelo",
                table: "vehiculo_personalizado",
                column: "id_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_stock_color_exterior",
                table: "vehiculos_stock",
                column: "color_exterior");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_stock_color_interior",
                table: "vehiculos_stock",
                column: "color_interior");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_stock_id_marca",
                table: "vehiculos_stock",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_stock_id_modelo",
                table: "vehiculos_stock",
                column: "id_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_cliente",
                table: "ventas",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_concesionario",
                table: "ventas",
                column: "id_concesionario");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_marca",
                table: "ventas",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_modelo",
                table: "ventas",
                column: "id_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_servicio_oficial",
                table: "ventas",
                column: "id_servicio_oficial");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_vendedor",
                table: "ventas",
                column: "id_vendedor");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_metodo_pago",
                table: "ventas",
                column: "metodo_pago");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_precio_vehiculo_personalizado",
                table: "ventas",
                column: "precio_vehiculo_personalizado");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_precio_vehiculo_stock",
                table: "ventas",
                column: "precio_vehiculo_stock");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_VIN_vehiculo_personalizado",
                table: "ventas",
                column: "VIN_vehiculo_personalizado");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_VIN_vehiculo_stock",
                table: "ventas",
                column: "VIN_vehiculo_stock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipamiento_serie");

            migrationBuilder.DropTable(
                name: "vehiculos_vendidos");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "servicio_oficial_clientes");

            migrationBuilder.DropTable(
                name: "metodo_pago");

            migrationBuilder.DropTable(
                name: "vehiculo_personalizado");

            migrationBuilder.DropTable(
                name: "vehiculos_stock");

            migrationBuilder.DropTable(
                name: "servicio_oficial_vendedores");

            migrationBuilder.DropTable(
                name: "equipamiento_extra");

            migrationBuilder.DropTable(
                name: "color_exterior");

            migrationBuilder.DropTable(
                name: "color_interior");

            migrationBuilder.DropTable(
                name: "servicio_oficial");

            migrationBuilder.DropTable(
                name: "modelo");

            migrationBuilder.DropTable(
                name: "concesionario");

            migrationBuilder.DropTable(
                name: "marca");
        }
    }
}
