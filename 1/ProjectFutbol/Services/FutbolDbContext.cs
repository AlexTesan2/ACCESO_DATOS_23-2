using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Services
{
    public class FutbolDbContext : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }

        //instancia por inyección de dependencias gracias a esto
        public FutbolDbContext(DbContextOptions<FutbolDbContext> options) : base(options)
        {
        }
    }

}

