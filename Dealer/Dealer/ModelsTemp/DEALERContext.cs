using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dealer.ModelsTemp
{
    public partial class DEALERContext : DbContext
    {
        public DEALERContext()
        {
        }

        public DEALERContext(DbContextOptions<DEALERContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ColorExterior> ColorExteriors { get; set; } = null!;
        public virtual DbSet<ColorInterior> ColorInteriors { get; set; } = null!;
        public virtual DbSet<Concesionario> Concesionarios { get; set; } = null!;
        public virtual DbSet<CondicionVehiculo> CondicionVehiculos { get; set; } = null!;
        public virtual DbSet<EquipamientoExtra> EquipamientoExtras { get; set; } = null!;
        public virtual DbSet<EquipamientoSerie> EquipamientoSeries { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<MetodoPago> MetodoPagos { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<ServicioOficial> ServicioOficials { get; set; } = null!;
        public virtual DbSet<ServicioOficialCliente> ServicioOficialClientes { get; set; } = null!;
        public virtual DbSet<ServicioOficialVendedore> ServicioOficialVendedores { get; set; } = null!;
        public virtual DbSet<VehiculoPersonalizado> VehiculoPersonalizados { get; set; } = null!;
        public virtual DbSet<VehiculosStock> VehiculosStocks { get; set; } = null!;
        public virtual DbSet<VehiculosVendido> VehiculosVendidos { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost; database=DEALER; integrated security=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColorExterior>(entity =>
            {
                entity.HasKey(e => e.IdColorExterior)
                    .HasName("PK__color_ex__A6FF2A213232A96E");

                entity.ToTable("color_exterior");

                entity.Property(e => e.IdColorExterior).HasColumnName("id_color_exterior");

                entity.Property(e => e.ColorExterior1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("color_exterior");

                entity.Property(e => e.ColorHex)
                    .HasMaxLength(8)
                    .HasColumnName("color_hex");

                entity.Property(e => e.PrecioColorExterior)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_color_exterior");
            });

            modelBuilder.Entity<ColorInterior>(entity =>
            {
                entity.HasKey(e => e.IdColorInterior)
                    .HasName("PK__color_in__9E309F1B7D2FD41D");

                entity.ToTable("color_interior");

                entity.Property(e => e.IdColorInterior).HasColumnName("id_color_interior");

                entity.Property(e => e.ColorInterior1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("color_interior");

                entity.Property(e => e.PrecioColorInterior)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_color_interior");
            });

            modelBuilder.Entity<Concesionario>(entity =>
            {
                entity.HasKey(e => e.IdConcesionario)
                    .HasName("PK__concesio__FE95AA278C47716B");

                entity.ToTable("concesionario");

                entity.Property(e => e.IdConcesionario).HasColumnName("id_concesionario");

                entity.Property(e => e.Img)
                    .HasColumnType("text")
                    .HasColumnName("img");

                entity.Property(e => e.NombreConcesionario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_concesionario");
            });

            modelBuilder.Entity<CondicionVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdCondicion)
                    .HasName("PK__condicio__C9237400CCCF1079");

                entity.ToTable("condicion_vehiculo");

                entity.Property(e => e.IdCondicion).HasColumnName("id_condicion");

                entity.Property(e => e.Condicion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("condicion");
            });

            modelBuilder.Entity<EquipamientoExtra>(entity =>
            {
                entity.HasKey(e => e.IdEquipamientoExtra)
                    .HasName("PK__equipami__E517FE91DF344DC9");

                entity.ToTable("equipamiento_extra");

                entity.HasIndex(e => e.IdModelo, "IX_equipamiento_extra_id_modelo");

                entity.Property(e => e.IdEquipamientoExtra).HasColumnName("id_equipamiento_extra");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.Img)
                    .HasColumnType("text")
                    .HasColumnName("img");

                entity.Property(e => e.NombreEquipamientoExtra)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre_equipamiento_extra");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.EquipamientoExtras)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("fk_equipamientoExtra_modelo");
            });

            modelBuilder.Entity<EquipamientoSerie>(entity =>
            {
                entity.HasKey(e => e.IdEquipamientoSerie)
                    .HasName("PK__equipami__FA575F32D8200466");

                entity.ToTable("equipamiento_serie");

                entity.HasIndex(e => e.IdModelo, "IX_equipamiento_serie_id_modelo");

                entity.Property(e => e.IdEquipamientoSerie).HasColumnName("id_equipamiento_serie");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.NombreEquipamientoExtra)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre_equipamiento_extra");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.EquipamientoSeries)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("fk_equipamientoSerie_modelo");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__marca__7E43E99E2906E87E");

                entity.ToTable("marca");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.NombreMarca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_marca");

                entity.Property(e => e.UrlLogoMarca)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("url_logo_marca");
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.HasKey(e => e.IdMetodoPago)
                    .HasName("PK__metodo_p__85BE0EBC15E505E9");

                entity.ToTable("metodo_pago");

                entity.Property(e => e.IdMetodoPago).HasColumnName("id_metodo_pago");

                entity.Property(e => e.MetodoPago1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("metodo_pago");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__modelo__B3BFCFF1FF4D45DF");

                entity.ToTable("modelo");

                entity.HasIndex(e => e.IdMarca, "IX_modelo_id_marca");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.Cilindrada)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cilindrada");

                entity.Property(e => e.Combustible)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("combustible");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.ImgModelo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("img_modelo");

                entity.Property(e => e.ImgModelo2)
                    .HasColumnType("text")
                    .HasColumnName("img_modelo_2");

                entity.Property(e => e.ImgModelo3)
                    .HasColumnType("text")
                    .HasColumnName("img_modelo_3");

                entity.Property(e => e.ImgModelo4)
                    .HasColumnType("text")
                    .HasColumnName("img_modelo_4");

                entity.Property(e => e.ImgModelo5)
                    .HasColumnType("text")
                    .HasColumnName("img_modelo_5");

                entity.Property(e => e.ImgModelo6)
                    .HasColumnType("text")
                    .HasColumnName("img_modelo_6");

                entity.Property(e => e.NombreModelo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre_modelo");

                entity.Property(e => e.Pasajeros)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pasajeros");

                entity.Property(e => e.Potencia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("potencia");

                entity.Property(e => e.PrecioBase)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_base");

                entity.Property(e => e.Traccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("traccion");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("fk_modelo_to_marca");
            });

            modelBuilder.Entity<ServicioOficial>(entity =>
            {
                entity.HasKey(e => e.IdServicioOficial)
                    .HasName("PK__servicio__50B63F8234B1E4DA");

                entity.ToTable("servicio_oficial");

                entity.HasIndex(e => e.IdConcesionario, "IX_servicio_oficial_id_concesionario");

                entity.Property(e => e.IdServicioOficial).HasColumnName("id_servicio_oficial");

                entity.Property(e => e.DomicilioServicioOficial)
                    .HasColumnType("text")
                    .HasColumnName("domicilio_servicio_oficial");

                entity.Property(e => e.IdConcesionario).HasColumnName("id_concesionario");

                entity.Property(e => e.ImgConcesionario)
                    .HasColumnType("text")
                    .HasColumnName("img_concesionario");

                entity.Property(e => e.NombreServicioOficial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_servicio_oficial");

                entity.Property(e => e.RncServicioOficial)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("rnc_servicio_oficial");

                entity.HasOne(d => d.IdConcesionarioNavigation)
                    .WithMany(p => p.ServicioOficials)
                    .HasForeignKey(d => d.IdConcesionario)
                    .HasConstraintName("fk_servicioOficial_concesionario");
            });

            modelBuilder.Entity<ServicioOficialCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__servicio__677F38F5B63FA532");

                entity.ToTable("servicio_oficial_clientes");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.CedulaCliente)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cedula_cliente");

                entity.Property(e => e.IdServicioOficial).HasColumnName("id_servicio_oficial");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_cliente");

                entity.Property(e => e.TelefonoCliente)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefono_cliente");
            });

            modelBuilder.Entity<ServicioOficialVendedore>(entity =>
            {
                entity.HasKey(e => e.IdVendedor)
                    .HasName("PK__servicio__0093030840C18B5E");

                entity.ToTable("servicio_oficial_vendedores");

                entity.HasIndex(e => e.IdServicioOficial, "IX_servicio_oficial_vendedores_id_servicio_oficial");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.CedulaVendedor)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cedula_vendedor");

                entity.Property(e => e.Domicilio)
                    .HasColumnType("text")
                    .HasColumnName("domicilio");

                entity.Property(e => e.IdServicioOficial).HasColumnName("id_servicio_oficial");

                entity.Property(e => e.NombreVendedor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_vendedor");

                entity.HasOne(d => d.IdServicioOficialNavigation)
                    .WithMany(p => p.ServicioOficialVendedores)
                    .HasForeignKey(d => d.IdServicioOficial)
                    .HasConstraintName("fk_servicioOficial_vendedores");
            });

            modelBuilder.Entity<VehiculoPersonalizado>(entity =>
            {
                entity.HasKey(e => e.IdConstruccionVehiculo)
                    .HasName("PK__vehiculo__712ECA30B9B48AEF");

                entity.ToTable("vehiculo_personalizado");

                entity.HasIndex(e => e.ColorExterior, "IX_vehiculo_personalizado_color_exterior");

                entity.HasIndex(e => e.ColorInterior, "IX_vehiculo_personalizado_color_interior");

                entity.HasIndex(e => e.Extra01, "IX_vehiculo_personalizado_extra_01");

                entity.HasIndex(e => e.Extra02, "IX_vehiculo_personalizado_extra_02");

                entity.HasIndex(e => e.Extra03, "IX_vehiculo_personalizado_extra_03");

                entity.HasIndex(e => e.Extra04, "IX_vehiculo_personalizado_extra_04");

                entity.HasIndex(e => e.Extra05, "IX_vehiculo_personalizado_extra_05");

                entity.HasIndex(e => e.Extra06, "IX_vehiculo_personalizado_extra_06");

                entity.HasIndex(e => e.Extra07, "IX_vehiculo_personalizado_extra_07");

                entity.HasIndex(e => e.Extra08, "IX_vehiculo_personalizado_extra_08");

                entity.HasIndex(e => e.Extra09, "IX_vehiculo_personalizado_extra_09");

                entity.HasIndex(e => e.Extra10, "IX_vehiculo_personalizado_extra_10");

                entity.HasIndex(e => e.Extra11, "IX_vehiculo_personalizado_extra_11");

                entity.HasIndex(e => e.Extra12, "IX_vehiculo_personalizado_extra_12");

                entity.HasIndex(e => e.Extra13, "IX_vehiculo_personalizado_extra_13");

                entity.HasIndex(e => e.Extra14, "IX_vehiculo_personalizado_extra_14");

                entity.HasIndex(e => e.Extra15, "IX_vehiculo_personalizado_extra_15");

                entity.HasIndex(e => e.Extra16, "IX_vehiculo_personalizado_extra_16");

                entity.HasIndex(e => e.Extra17, "IX_vehiculo_personalizado_extra_17");

                entity.HasIndex(e => e.Extra18, "IX_vehiculo_personalizado_extra_18");

                entity.HasIndex(e => e.Extra19, "IX_vehiculo_personalizado_extra_19");

                entity.HasIndex(e => e.Extra20, "IX_vehiculo_personalizado_extra_20");

                entity.HasIndex(e => e.IdMarca, "IX_vehiculo_personalizado_id_marca");

                entity.HasIndex(e => e.IdModelo, "IX_vehiculo_personalizado_id_modelo");

                entity.Property(e => e.IdConstruccionVehiculo).HasColumnName("id_construccion_vehiculo");

                entity.Property(e => e.ColorExterior).HasColumnName("color_exterior");

                entity.Property(e => e.ColorInterior).HasColumnName("color_interior");

                entity.Property(e => e.Extra01).HasColumnName("extra_01");

                entity.Property(e => e.Extra02).HasColumnName("extra_02");

                entity.Property(e => e.Extra03).HasColumnName("extra_03");

                entity.Property(e => e.Extra04).HasColumnName("extra_04");

                entity.Property(e => e.Extra05).HasColumnName("extra_05");

                entity.Property(e => e.Extra06).HasColumnName("extra_06");

                entity.Property(e => e.Extra07).HasColumnName("extra_07");

                entity.Property(e => e.Extra08).HasColumnName("extra_08");

                entity.Property(e => e.Extra09).HasColumnName("extra_09");

                entity.Property(e => e.Extra10).HasColumnName("extra_10");

                entity.Property(e => e.Extra11).HasColumnName("extra_11");

                entity.Property(e => e.Extra12).HasColumnName("extra_12");

                entity.Property(e => e.Extra13).HasColumnName("extra_13");

                entity.Property(e => e.Extra14).HasColumnName("extra_14");

                entity.Property(e => e.Extra15).HasColumnName("extra_15");

                entity.Property(e => e.Extra16).HasColumnName("extra_16");

                entity.Property(e => e.Extra17).HasColumnName("extra_17");

                entity.Property(e => e.Extra18).HasColumnName("extra_18");

                entity.Property(e => e.Extra19).HasColumnName("extra_19");

                entity.Property(e => e.Extra20).HasColumnName("extra_20");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Vin)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.ColorExteriorNavigation)
                    .WithMany(p => p.VehiculoPersonalizados)
                    .HasForeignKey(d => d.ColorExterior)
                    .HasConstraintName("fk_construct_color_exterior");

                entity.HasOne(d => d.ColorInteriorNavigation)
                    .WithMany(p => p.VehiculoPersonalizados)
                    .HasForeignKey(d => d.ColorInterior)
                    .HasConstraintName("fk_construct_color_interior");

                entity.HasOne(d => d.Extra01Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra01Navigations)
                    .HasForeignKey(d => d.Extra01)
                    .HasConstraintName("fk_construct_extra01");

                entity.HasOne(d => d.Extra02Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra02Navigations)
                    .HasForeignKey(d => d.Extra02)
                    .HasConstraintName("fk_construct_extra02");

                entity.HasOne(d => d.Extra03Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra03Navigations)
                    .HasForeignKey(d => d.Extra03)
                    .HasConstraintName("fk_construct_extra03");

                entity.HasOne(d => d.Extra04Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra04Navigations)
                    .HasForeignKey(d => d.Extra04)
                    .HasConstraintName("fk_construct_extra04");

                entity.HasOne(d => d.Extra05Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra05Navigations)
                    .HasForeignKey(d => d.Extra05)
                    .HasConstraintName("fk_construct_extra05");

                entity.HasOne(d => d.Extra06Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra06Navigations)
                    .HasForeignKey(d => d.Extra06)
                    .HasConstraintName("fk_construct_extra06");

                entity.HasOne(d => d.Extra07Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra07Navigations)
                    .HasForeignKey(d => d.Extra07)
                    .HasConstraintName("fk_construct_extra07");

                entity.HasOne(d => d.Extra08Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra08Navigations)
                    .HasForeignKey(d => d.Extra08)
                    .HasConstraintName("fk_construct_extra08");

                entity.HasOne(d => d.Extra09Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra09Navigations)
                    .HasForeignKey(d => d.Extra09)
                    .HasConstraintName("fk_construct_extra09");

                entity.HasOne(d => d.Extra10Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra10Navigations)
                    .HasForeignKey(d => d.Extra10)
                    .HasConstraintName("fk_construct_extra10");

                entity.HasOne(d => d.Extra11Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra11Navigations)
                    .HasForeignKey(d => d.Extra11)
                    .HasConstraintName("fk_construct_extra11");

                entity.HasOne(d => d.Extra12Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra12Navigations)
                    .HasForeignKey(d => d.Extra12)
                    .HasConstraintName("fk_construct_extra12");

                entity.HasOne(d => d.Extra13Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra13Navigations)
                    .HasForeignKey(d => d.Extra13)
                    .HasConstraintName("fk_construct_extra13");

                entity.HasOne(d => d.Extra14Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra14Navigations)
                    .HasForeignKey(d => d.Extra14)
                    .HasConstraintName("fk_construct_extra14");

                entity.HasOne(d => d.Extra15Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra15Navigations)
                    .HasForeignKey(d => d.Extra15)
                    .HasConstraintName("fk_construct_extra15");

                entity.HasOne(d => d.Extra16Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra16Navigations)
                    .HasForeignKey(d => d.Extra16)
                    .HasConstraintName("fk_construct_extra16");

                entity.HasOne(d => d.Extra17Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra17Navigations)
                    .HasForeignKey(d => d.Extra17)
                    .HasConstraintName("fk_construct_extra17");

                entity.HasOne(d => d.Extra18Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra18Navigations)
                    .HasForeignKey(d => d.Extra18)
                    .HasConstraintName("fk_construct_extra18");

                entity.HasOne(d => d.Extra19Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra19Navigations)
                    .HasForeignKey(d => d.Extra19)
                    .HasConstraintName("fk_construct_extra19");

                entity.HasOne(d => d.Extra20Navigation)
                    .WithMany(p => p.VehiculoPersonalizadoExtra20Navigations)
                    .HasForeignKey(d => d.Extra20)
                    .HasConstraintName("fk_construct_extra20");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.VehiculoPersonalizados)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("fk_constructVehiculo_marca");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.VehiculoPersonalizados)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("fk_constructVehiculo_modelo");
            });

            modelBuilder.Entity<VehiculosStock>(entity =>
            {
                entity.HasKey(e => e.IdVehiculoStock)
                    .HasName("PK__vehiculo__2C97B5734C4173AF");

                entity.ToTable("vehiculos_stock");

                entity.HasIndex(e => e.ColorExterior, "IX_vehiculos_stock_color_exterior");

                entity.HasIndex(e => e.ColorInterior, "IX_vehiculos_stock_color_interior");

                entity.HasIndex(e => e.Condicion, "IX_vehiculos_stock_condicion");

                entity.HasIndex(e => e.IdMarca, "IX_vehiculos_stock_id_marca");

                entity.HasIndex(e => e.IdModelo, "IX_vehiculos_stock_id_modelo");

                entity.Property(e => e.IdVehiculoStock).HasColumnName("id_vehiculo_stock");

                entity.Property(e => e.Anio)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("anio");

                entity.Property(e => e.ColorExterior).HasColumnName("color_exterior");

                entity.Property(e => e.ColorInterior).HasColumnName("color_interior");

                entity.Property(e => e.Condicion).HasColumnName("condicion");

                entity.Property(e => e.DescripcionEquipamientoExtra)
                    .HasColumnType("text")
                    .HasColumnName("descripcion_equipamiento_extra");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.Img)
                    .HasColumnType("text")
                    .HasColumnName("img");

                entity.Property(e => e.Img2)
                    .HasColumnType("text")
                    .HasColumnName("img_2");

                entity.Property(e => e.Img3)
                    .HasColumnType("text")
                    .HasColumnName("img_3");

                entity.Property(e => e.Img4)
                    .HasColumnType("text")
                    .HasColumnName("img_4");

                entity.Property(e => e.Img5)
                    .HasColumnType("text")
                    .HasColumnName("img_5");

                entity.Property(e => e.Img6)
                    .HasColumnType("text")
                    .HasColumnName("img_6");

                entity.Property(e => e.Img7)
                    .HasColumnType("text")
                    .HasColumnName("img_7");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Vin)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.ColorExteriorNavigation)
                    .WithMany(p => p.VehiculosStocks)
                    .HasForeignKey(d => d.ColorExterior)
                    .HasConstraintName("fk_vehiculoStock_color_exterior");

                entity.HasOne(d => d.ColorInteriorNavigation)
                    .WithMany(p => p.VehiculosStocks)
                    .HasForeignKey(d => d.ColorInterior)
                    .HasConstraintName("fk_vehiculoStock_color_interior");

                entity.HasOne(d => d.CondicionNavigation)
                    .WithMany(p => p.VehiculosStocks)
                    .HasForeignKey(d => d.Condicion)
                    .HasConstraintName("FK_vehiculo_condicion");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.VehiculosStocks)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("fk_vehiculoStock_marca");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.VehiculosStocks)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("fk_vehiculoStock_modelo");
            });

            modelBuilder.Entity<VehiculosVendido>(entity =>
            {
                entity.HasKey(e => e.IdVehiculoVendido)
                    .HasName("PK__vehiculo__EBE1BF2D84DF5318");

                entity.ToTable("vehiculos_vendidos");

                entity.Property(e => e.IdVehiculoVendido).HasColumnName("id_vehiculo_vendido");

                entity.Property(e => e.Cliente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cliente");

                entity.Property(e => e.Marca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Vendedor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("vendedor");

                entity.Property(e => e.Vin)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("VIN");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__ventas__459533BF48EE8E87");

                entity.ToTable("ventas");

                entity.HasIndex(e => e.VinVehiculoPersonalizado, "IX_ventas_VIN_vehiculo_personalizado");

                entity.HasIndex(e => e.VinVehiculoStock, "IX_ventas_VIN_vehiculo_stock");

                entity.HasIndex(e => e.IdCliente, "IX_ventas_id_cliente");

                entity.HasIndex(e => e.IdConcesionario, "IX_ventas_id_concesionario");

                entity.HasIndex(e => e.IdMarca, "IX_ventas_id_marca");

                entity.HasIndex(e => e.IdModelo, "IX_ventas_id_modelo");

                entity.HasIndex(e => e.IdServicioOficial, "IX_ventas_id_servicio_oficial");

                entity.HasIndex(e => e.IdVendedor, "IX_ventas_id_vendedor");

                entity.HasIndex(e => e.MetodoPago, "IX_ventas_metodo_pago");

                entity.HasIndex(e => e.PrecioVehiculoPersonalizado, "IX_ventas_precio_vehiculo_personalizado");

                entity.HasIndex(e => e.PrecioVehiculoStock, "IX_ventas_precio_vehiculo_stock");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("date")
                    .HasColumnName("fecha_entrega");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdConcesionario).HasColumnName("id_concesionario");

                entity.Property(e => e.IdMarca).HasColumnName("id_marca");

                entity.Property(e => e.IdModelo).HasColumnName("id_modelo");

                entity.Property(e => e.IdServicioOficial).HasColumnName("id_servicio_oficial");

                entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");

                entity.Property(e => e.MetodoPago).HasColumnName("metodo_pago");

                entity.Property(e => e.PrecioVehiculoPersonalizado).HasColumnName("precio_vehiculo_personalizado");

                entity.Property(e => e.PrecioVehiculoStock).HasColumnName("precio_vehiculo_stock");

                entity.Property(e => e.Registro)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("registro");

                entity.Property(e => e.VinVehiculoPersonalizado).HasColumnName("VIN_vehiculo_personalizado");

                entity.Property(e => e.VinVehiculoStock).HasColumnName("VIN_vehiculo_stock");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_venta_cliente");

                entity.HasOne(d => d.IdConcesionarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdConcesionario)
                    .HasConstraintName("fk_venta_concesionario");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("fk_venta_VehiculoMarca");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("fk_venta_VehiculoModelo");

                entity.HasOne(d => d.IdServicioOficialNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdServicioOficial)
                    .HasConstraintName("fk_venta_servicio_oficial");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("fk_venta_vendedor");

                entity.HasOne(d => d.MetodoPagoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.MetodoPago)
                    .HasConstraintName("fk_venta_metodoPago");

                entity.HasOne(d => d.PrecioVehiculoPersonalizadoNavigation)
                    .WithMany(p => p.VentaPrecioVehiculoPersonalizadoNavigations)
                    .HasForeignKey(d => d.PrecioVehiculoPersonalizado)
                    .HasConstraintName("fk_venta_precioPersonalizado");

                entity.HasOne(d => d.PrecioVehiculoStockNavigation)
                    .WithMany(p => p.VentaPrecioVehiculoStockNavigations)
                    .HasForeignKey(d => d.PrecioVehiculoStock)
                    .HasConstraintName("fk_venta_precioStock");

                entity.HasOne(d => d.VinVehiculoPersonalizadoNavigation)
                    .WithMany(p => p.VentaVinVehiculoPersonalizadoNavigations)
                    .HasForeignKey(d => d.VinVehiculoPersonalizado)
                    .HasConstraintName("fk_venta_VINpersonalizado");

                entity.HasOne(d => d.VinVehiculoStockNavigation)
                    .WithMany(p => p.VentaVinVehiculoStockNavigations)
                    .HasForeignKey(d => d.VinVehiculoStock)
                    .HasConstraintName("fk_venta_VINstock");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
