using Microsoft.EntityFrameworkCore;
using static MVC2024.Controllers.VehiculoController;

namespace MVC2024.Models
{   //Contexto es como la base de datos
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto>options): base(options) 
        {
            
        }
        
        //est o nos peermite utilizar DBsets sin clave (la vistaTotal)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehiculoTotal>(
                eb =>
                {
                    eb.HasNoKey();
                });
        }
        public DbSet<MarcaModelo> Marcas { get; set; }//Marcas es el mismo nombre q la tabla d ela base de datos
        public DbSet<SerieModelo> Series { get; set; }
        public DbSet<VehiculoModelo> Vehiculos { get; set; }
        public DbSet<VehiculoTotal> VistaTotal { get; set; }//Vistatotal el el mismo nombre que la vista de la BD
        //en este caaso DBset no es una tabla , es una consulta
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<ExtraModelo> Extras { get; set; }
        public DbSet<VendedorModel> vendedores { get; set; }
        public DbSet<VehiculoExtraModelo> VehiculoExtra { get; set; }

        public DbSet<FotoModelo> fotos { get; set; }
        public DbSet<VehiculoFotoModelo> vehiculofotos { get; set; }
        //BbSet es una lista de objetos de la clase q le digas, tiene q llamarse igual al sqlServer

        //public DbSet<VehiculoTotal> VistaTotal { get; set; }

    }
}
