using Microsoft.EntityFrameworkCore;

namespace MVC2024.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto>options): base(options) 
        {
            
        }   
        public DbSet<MarcaModelo> Marcas { get; set; }
        public DbSet<SerieModelo> Series { get; set; }
        public DbSet<VehiculoModelo> Vehiculos { get; set; }
    }
}
