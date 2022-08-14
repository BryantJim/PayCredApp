﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayCredApp.Data;

#nullable disable

namespace PayCredApp.Data.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PayCredApp.Models.Ciudades", b =>
                {
                    b.Property<int>("IdCiudad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCiudad"), 1L, 1);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCiudad");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("PayCredApp.Models.Clientes", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCiudad")
                        .HasColumnType("int");

                    b.Property<int>("IdProvincia")
                        .HasColumnType("int");

                    b.Property<int>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.HasIndex("IdCiudad");

                    b.HasIndex("IdProvincia");

                    b.HasIndex("ModificadoPor");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PayCredApp.Models.dCobros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CapitalCobrado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdCobro")
                        .HasColumnType("int");

                    b.Property<int>("IdPrestamo")
                        .HasColumnType("int");

                    b.Property<decimal>("InteresCobrado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MoraCobrada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NoCuota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCobro");

                    b.ToTable("dCobros");
                });

            modelBuilder.Entity("PayCredApp.Models.dPrestamos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BceCapital")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BceInteres")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Capital")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FechaCuota")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPrestamo")
                        .HasColumnType("int");

                    b.Property<decimal>("Interes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NoCuota")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPrestamo");

                    b.ToTable("dPrestamos");
                });

            modelBuilder.Entity("PayCredApp.Models.eCobros", b =>
                {
                    b.Property<int>("IdCobro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCobro"), 1L, 1);

                    b.Property<decimal>("CapitalCobrado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CreadoPor")
                        .HasColumnType("int");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("EsNulo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdPrestamo")
                        .HasColumnType("int");

                    b.Property<decimal>("InteresCobrado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MoraCobrada")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCobro");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdPrestamo");

                    b.HasIndex("ModificadoPor");

                    b.ToTable("eCobros");
                });

            modelBuilder.Entity("PayCredApp.Models.ePrestamos", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestamo"), 1L, 1);

                    b.Property<decimal>("BceCapital")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BceInteres")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Capital")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CreadoPor")
                        .HasColumnType("int");

                    b.Property<int>("Cuotas")
                        .HasColumnType("int");

                    b.Property<bool>("EsNulo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPrestamo")
                        .HasColumnType("int");

                    b.Property<decimal>("Interes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Saldo")
                        .HasColumnType("bit");

                    b.Property<decimal>("TasaInteres")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TasaMora")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPrestamo");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdTipoPrestamo");

                    b.HasIndex("ModificadoPor");

                    b.ToTable("ePrestamos");
                });

            modelBuilder.Entity("PayCredApp.Models.Provincias", b =>
                {
                    b.Property<int>("IdProvincia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProvincia"), 1L, 1);

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProvincia");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("PayCredApp.Models.Roles", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PayCredApp.Models.TipoPrestamos", b =>
                {
                    b.Property<int>("IdTipoPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoPrestamo"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiaGracias")
                        .HasColumnType("int");

                    b.HasKey("IdTipoPrestamo");

                    b.ToTable("TipoPrestamos");
                });

            modelBuilder.Entity("PayCredApp.Models.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsNulo")
                        .HasColumnType("bit");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PayCredApp.Models.Clientes", b =>
                {
                    b.HasOne("PayCredApp.Models.Ciudades", "Ciudades")
                        .WithMany("Clientes")
                        .HasForeignKey("IdCiudad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayCredApp.Models.Provincias", "Provincias")
                        .WithMany("Clientes")
                        .HasForeignKey("IdProvincia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayCredApp.Models.Usuarios", "Usuarios")
                        .WithMany("Clientes")
                        .HasForeignKey("ModificadoPor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ciudades");

                    b.Navigation("Provincias");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("PayCredApp.Models.dCobros", b =>
                {
                    b.HasOne("PayCredApp.Models.eCobros", "eCobros")
                        .WithMany("dCobros")
                        .HasForeignKey("IdCobro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("eCobros");
                });

            modelBuilder.Entity("PayCredApp.Models.dPrestamos", b =>
                {
                    b.HasOne("PayCredApp.Models.ePrestamos", "ePrestamos")
                        .WithMany("dPrestamos")
                        .HasForeignKey("IdPrestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ePrestamos");
                });

            modelBuilder.Entity("PayCredApp.Models.eCobros", b =>
                {
                    b.HasOne("PayCredApp.Models.Clientes", "Clientes")
                        .WithMany("eCobros")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayCredApp.Models.ePrestamos", "ePrestamos")
                        .WithMany("eCobros")
                        .HasForeignKey("IdPrestamo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PayCredApp.Models.Usuarios", "Usuarios")
                        .WithMany("eCobros")
                        .HasForeignKey("ModificadoPor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Usuarios");

                    b.Navigation("ePrestamos");
                });

            modelBuilder.Entity("PayCredApp.Models.ePrestamos", b =>
                {
                    b.HasOne("PayCredApp.Models.Clientes", "Clientes")
                        .WithMany("ePrestamos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayCredApp.Models.TipoPrestamos", "TipoPrestamos")
                        .WithMany("ePrestamos")
                        .HasForeignKey("IdTipoPrestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PayCredApp.Models.Usuarios", "Usuarios")
                        .WithMany("ePrestamos")
                        .HasForeignKey("ModificadoPor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("TipoPrestamos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("PayCredApp.Models.Usuarios", b =>
                {
                    b.HasOne("PayCredApp.Models.Roles", "Roles")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("PayCredApp.Models.Ciudades", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("PayCredApp.Models.Clientes", b =>
                {
                    b.Navigation("eCobros");

                    b.Navigation("ePrestamos");
                });

            modelBuilder.Entity("PayCredApp.Models.eCobros", b =>
                {
                    b.Navigation("dCobros");
                });

            modelBuilder.Entity("PayCredApp.Models.ePrestamos", b =>
                {
                    b.Navigation("dPrestamos");

                    b.Navigation("eCobros");
                });

            modelBuilder.Entity("PayCredApp.Models.Provincias", b =>
                {
                    b.Navigation("Clientes");
                });

            modelBuilder.Entity("PayCredApp.Models.Roles", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("PayCredApp.Models.TipoPrestamos", b =>
                {
                    b.Navigation("ePrestamos");
                });

            modelBuilder.Entity("PayCredApp.Models.Usuarios", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("eCobros");

                    b.Navigation("ePrestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
