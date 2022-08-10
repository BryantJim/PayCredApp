using Microsoft.EntityFrameworkCore;
using PayCredApp.Models;

namespace PayCredApp.Data
{
	public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Usuarios
            modelBuilder.Entity<Usuarios>()
                .HasOne<Roles>(u => u.Roles)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.IdRol);

            //Clientes
            modelBuilder.Entity<Clientes>()
                .HasOne<Ciudades>(x => x.Ciudades)
                .WithMany(c => c.Clientes)
                .HasForeignKey(x => x.IdCiudad);

            modelBuilder.Entity<Clientes>()
                .HasOne<Provincias>(x => x.Provincias)
                .WithMany(c => c.Clientes)
                .HasForeignKey(x => x.IdProvincia);

            modelBuilder.Entity<Clientes>()
                .HasOne<Usuarios>(x => x.Usuarios)
                .WithMany(c => c.Clientes)
                .HasForeignKey(x => x.CreadoPor);

            modelBuilder.Entity<Clientes>()
                .HasOne<Usuarios>(x => x.Usuarios)
                .WithMany(c => c.Clientes)
                .HasForeignKey(x => x.ModificadoPor)
                .OnDelete(DeleteBehavior.NoAction);

            //ePrestamos
            modelBuilder.Entity<ePrestamos>()
                .HasOne<Clientes>(x => x.Clientes)
                .WithMany(x => x.ePrestamos)
                .HasForeignKey(x => x.IdCliente);

            modelBuilder.Entity<ePrestamos>()
               .HasOne<TipoPrestamos>(x => x.TipoPrestamos)
               .WithMany(x => x.ePrestamos)
               .HasForeignKey(x => x.IdTipoPrestamo);

            modelBuilder.Entity<ePrestamos>()
                .HasOne<Usuarios>(x => x.Usuarios)
                .WithMany(c => c.ePrestamos)
                .HasForeignKey(x => x.CreadoPor);

            modelBuilder.Entity<ePrestamos>()
                .HasOne<Usuarios>(x => x.Usuarios)
                .WithMany(c => c.ePrestamos)
                .HasForeignKey(x => x.ModificadoPor)
                .OnDelete(DeleteBehavior.NoAction);

            //dPrestamos
            modelBuilder.Entity<dPrestamos>()
                .HasOne<ePrestamos>(x => x.ePrestamos)
                .WithMany(c => c.dPrestamos)
                .HasForeignKey(x => x.IdPrestamo);
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<ePrestamos> ePrestamos { get; set; }
        public DbSet<dPrestamos> dPrestamos { get; set; }
        public DbSet<TipoPrestamos> TipoPrestamos { get; set; }

    }
}
