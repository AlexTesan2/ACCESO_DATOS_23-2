using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Services
{
	public class AlumnoDdContext: DbContext
	{
        public AlumnoDdContext(DbContextOptions<AlumnoDdContext> options) : base(options) 
        {
            
        }
        public DbSet<Alum> Alumnos { get; set; }//la tabla se llama Alumnos en el sql server
    }
}
