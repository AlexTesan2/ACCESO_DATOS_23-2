using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class GeografiaDBContext : DbContext
    {
        public DbSet<Provincia> Provincias { get; set; }

        //instancia por inyección de dependencias gracias a esto
        public GeografiaDBContext(DbContextOptions<GeografiaDBContext> options) : base(options)
        {
        }
    }
}
