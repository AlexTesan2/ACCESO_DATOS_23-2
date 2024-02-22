using Microsoft.EntityFrameworkCore;
using static MVC2024.Controllers.VehiculoController;

namespace MVC2024.Models
{   //Contexto es como la base de datos
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto>options): base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehiculoTotal>(
                eb =>
                {
                    eb.HasNoKey();
                });
        }
        public DbSet<MarcaModelo> Marcas { get; set; }
        public DbSet<SerieModelo> Series { get; set; }
        public DbSet<VehiculoModelo> Vehiculos { get; set; }
        public DbSet<VehiculoTotal> VistaTotal { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }

        public DbSet<ExtraModelo> Extras { get; set; }
        public DbSet<VehiculoExtraModelo> VehiculoExtra { get; set; }
        //BbSet es una lista de objetos de la clase q le digas, tiene q llamarse igual al sqlServer
    }
}
