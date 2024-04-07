using GuarderiaAppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GuarderiaAppWeb.Data
{
    public class GuarderiaContext : DbContext
    {
        public GuarderiaContext(DbContextOptions<GuarderiaContext> options) : base(options) { }

        public DbSet<nino> Ninos { get; set; }
        public DbSet<Autorizacion> Autorizaciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Alergia> Alergias { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<CargoMensual> CargoMensuales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                        


            //modelBuilder.Entity<Autorizacion>()
            //    .HasOne(n => n.Nino)
            //    .WithMany(a => a.Autorizacion)   (no va)
            //    .HasForeignKey(m => m.Matricula);

            modelBuilder.Entity<Autorizacion>()
                .HasMany(n => n.Pago) // Una Autorizacion Puede tener muchos pagos
                .WithOne(a => a.Autorizacion) // Cada Pago pertenece a una sola Autorizacion  (Bien)
                .HasForeignKey(m => m.IdAutorizado); // Clave de referencia

            //----------------------------------------------------------------------------------------

            //modelBuilder.Entity<Menu>()
            //    .HasMany(n => n.Ingrediente)
            //    .WithOne(m => m.Menu)    // no va
            //    .HasForeignKey(i => i.IdMenu);
                    modelBuilder.Entity<Menu>()
            .HasMany(m => m.Ingrediente)
            .WithMany(i => i.Menu)
            .UsingEntity(j => j.ToTable("MenuIngrediente"));

            modelBuilder.Entity<Menu>()
                .HasOne(n => n.Alergia)
                .WithMany(m => m.Menus)  // bien
                .HasForeignKey(i => i.IdMenu);

            modelBuilder.Entity<Menu>()
                .HasOne(c => c.Consumo)  // bien
                .WithMany(m => m.Menu)
                .HasForeignKey(i => i.IdMenu);
            //----------------------------------------------------------------------------------------

            //modelBuilder.Entity<Ingrediente>()
            //    .HasOne(c => c.Menu)
            //    .WithMany(m => m.Ingrediente)   // (no va)
            //    .HasForeignKey(i => i.IdMenu);

            //----------------------------------------------------------------------------------------


            //modelBuilder.Entity<Alergia>()
            //    .HasOne(n => n.Nino)     // bien (no va)
            //    .WithMany(a => a.Alergia)
            //    .HasForeignKey(m => m.Matricula);

            modelBuilder.Entity<Alergia>()
                .HasMany(m => m.Menus)      // bien
                .WithOne(a => a.Alergia)
                .HasForeignKey(i => i.IdMenu);
            //----------------------------------------------------------------------------------------

            modelBuilder.Entity<Consumo>()
                .HasOne(n => n.Nino)
                .WithMany(c => c.Consumo) // bien 
                .HasForeignKey(m => m.Matricula)
                 ;

            modelBuilder.Entity<Consumo>()
                .HasMany(m => m.Menu)
                .WithOne(c => c.Consumo)  // bien 
                .HasForeignKey(i => i.IdMenu);

            //modelBuilder.Entity<Consumo>()
            //    .HasOne(c => c.CargoMensual)
            //    .WithMany(c => c.Consumo)
            //    ;

            //----------------------------------------------------------------------------------------

            modelBuilder.Entity<CargoMensual>()
                .HasOne(n => n.Nino)
                .WithMany(c => c.CargoMensual)  // bien
                .HasForeignKey(i => i.Matricula);

            //modelBuilder.Entity<CargoMensual>()
            //    .HasMany(c => c.Consumo)
            //    .WithOne(c => c.CargoMensual)
            //    .HasForeignKey(i => i.IdConsumo);

            modelBuilder.Entity<CargoMensual>()
                .HasOne(p => p.Pago)
                .WithMany(c => c.CargoMensuales)  // bien 
                .HasForeignKey(i => i.NoFactura);
            //----------------------------------------------------------------------------------------

            //modelBuilder.Entity<Pago>()
            //    .HasMany(a => a.Autorizacion)
            //    .WithOne(p => p.Pago)     (No va)
            //    .HasForeignKey(i => i.Pago.IdPago);

            modelBuilder.Entity<Pago>()
                .HasMany(c => c.CargoMensuales)
                .WithOne(p => p.Pago)       // bien
                .HasForeignKey(i => i.NoFactura);
            //----------------------------------------------------------------------------------------

            //modelBuilder.Entity<nino>()
            //    .HasMany(a => a.Autorizacion)
            //    .WithOne(n => n.Nino)     (No va)
            //    .HasForeignKey(i => i.Matricula);

            modelBuilder.Entity<nino>()
           .HasMany(n => n.Autorizacion)
           .WithMany(a => a.Ninos)
           .UsingEntity(j => j.ToTable("NinoAutorizacion")); // Personaliza el nombre de la tabla de unión si es necesario

            modelBuilder.Entity<nino>()
                .HasMany(a => a.Alergia)    // bien 
                .WithOne(n => n.Nino)
                .HasForeignKey(i => i.Matricula);

            modelBuilder.Entity<nino>()
                .HasMany(c => c.Consumo)
                .WithOne(n => n.Nino) //  bien 
                .HasForeignKey(i => i.Matricula);

            //modelBuilder.Entity<nino>()
            //    .HasMany (a => a.CargoMensual)  // bien (no va)
            //    .WithOne (n => n.Nino)
            //    .HasForeignKey (i => i.Matricula);






















        }
    }
}
