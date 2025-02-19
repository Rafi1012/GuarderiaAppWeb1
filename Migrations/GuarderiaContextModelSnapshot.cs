﻿// <auto-generated />
using System;
using GuarderiaAppWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuarderiaAppWeb.Migrations
{
    [DbContext(typeof(GuarderiaContext))]
    partial class GuarderiaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Autorizacionnino", b =>
                {
                    b.Property<int>("AutorizacionIdAutorizado")
                        .HasColumnType("int");

                    b.Property<int>("NinosMatricula")
                        .HasColumnType("int");

                    b.HasKey("AutorizacionIdAutorizado", "NinosMatricula");

                    b.HasIndex("NinosMatricula");

                    b.ToTable("NinoAutorizacion", (string)null);
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Alergia", b =>
                {
                    b.Property<int>("IdAlergia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlergia"));

                    b.Property<int>("IdMenu")
                        .HasColumnType("int");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.HasKey("IdAlergia");

                    b.HasIndex("Matricula");

                    b.ToTable("Alergias");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Autorizacion", b =>
                {
                    b.Property<int>("IdAutorizado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAutorizado"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Recoger")
                        .HasColumnType("bit");

                    b.Property<string>("Relacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAutorizado");

                    b.ToTable("Autorizaciones");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.CargoMensual", b =>
                {
                    b.Property<int>("NoFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CostoFijo")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("TotalConsumo")
                        .HasColumnType("int");

                    b.HasKey("NoFactura");

                    b.HasIndex("Matricula");

                    b.ToTable("CargoMensuales");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Consumo", b =>
                {
                    b.Property<int>("IdConsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsumo"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMenu")
                        .HasColumnType("int");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("IdConsumo");

                    b.HasIndex("Matricula");

                    b.ToTable("Consumos");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Ingrediente", b =>
                {
                    b.Property<int>("IdIngrediente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdIngrediente"));

                    b.Property<int>("IdMenu")
                        .HasColumnType("int");

                    b.Property<string>("NomIngrediente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIngrediente");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Menu", b =>
                {
                    b.Property<int>("IdMenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Costo")
                        .HasColumnType("int");

                    b.Property<string>("NomPlato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMenu");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPago"));

                    b.Property<int>("Costo")
                        .HasColumnType("int");

                    b.Property<int>("IdAutorizado")
                        .HasColumnType("int");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<int>("Nocuenta")
                        .HasColumnType("int");

                    b.Property<int>("Nofactura")
                        .HasColumnType("int");

                    b.HasKey("IdPago");

                    b.HasIndex("IdAutorizado");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.nino", b =>
                {
                    b.Property<int>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Matricula"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Matricula");

                    b.ToTable("Ninos");
                });

            modelBuilder.Entity("IngredienteMenu", b =>
                {
                    b.Property<int>("IngredienteIdIngrediente")
                        .HasColumnType("int");

                    b.Property<int>("MenuIdMenu")
                        .HasColumnType("int");

                    b.HasKey("IngredienteIdIngrediente", "MenuIdMenu");

                    b.HasIndex("MenuIdMenu");

                    b.ToTable("MenuIngrediente", (string)null);
                });

            modelBuilder.Entity("Autorizacionnino", b =>
                {
                    b.HasOne("GuarderiaAppWeb.Models.Autorizacion", null)
                        .WithMany()
                        .HasForeignKey("AutorizacionIdAutorizado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuarderiaAppWeb.Models.nino", null)
                        .WithMany()
                        .HasForeignKey("NinosMatricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Alergia", b =>
                {
                    b.HasOne("GuarderiaAppWeb.Models.nino", "Nino")
                        .WithMany("Alergia")
                        .HasForeignKey("Matricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nino");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.CargoMensual", b =>
                {
                    b.HasOne("GuarderiaAppWeb.Models.nino", "Nino")
                        .WithMany("CargoMensual")
                        .HasForeignKey("Matricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuarderiaAppWeb.Models.Pago", "Pago")
                        .WithMany("CargoMensuales")
                        .HasForeignKey("NoFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nino");

                    b.Navigation("Pago");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Consumo", b =>
                {
                    b.HasOne("GuarderiaAppWeb.Models.nino", "Nino")
                        .WithMany("Consumo")
                        .HasForeignKey("Matricula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nino");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Menu", b =>
                {
                    b.HasOne("GuarderiaAppWeb.Models.Alergia", "Alergia")
                        .WithMany("Menus")
                        .HasForeignKey("IdMenu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuarderiaAppWeb.Models.Consumo", "Consumo")
                        .WithMany("Menu")
                        .HasForeignKey("IdMenu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alergia");

                    b.Navigation("Consumo");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Pago", b =>
                {
                    b.HasOne("GuarderiaAppWeb.Models.Autorizacion", "Autorizacion")
                        .WithMany("Pago")
                        .HasForeignKey("IdAutorizado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autorizacion");
                });

            modelBuilder.Entity("IngredienteMenu", b =>
                {
                    b.HasOne("GuarderiaAppWeb.Models.Ingrediente", null)
                        .WithMany()
                        .HasForeignKey("IngredienteIdIngrediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuarderiaAppWeb.Models.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenuIdMenu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Alergia", b =>
                {
                    b.Navigation("Menus");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Autorizacion", b =>
                {
                    b.Navigation("Pago");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Consumo", b =>
                {
                    b.Navigation("Menu");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.Pago", b =>
                {
                    b.Navigation("CargoMensuales");
                });

            modelBuilder.Entity("GuarderiaAppWeb.Models.nino", b =>
                {
                    b.Navigation("Alergia");

                    b.Navigation("CargoMensual");

                    b.Navigation("Consumo");
                });
#pragma warning restore 612, 618
        }
    }
}
