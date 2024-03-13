using Microsoft.EntityFrameworkCore;

namespace ExamenAADAlejandroTesan.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductosVendidos>(
                eb =>
                {
                    eb.HasNoKey();
                });
        }
        public DbSet<EnvioRegaloModelo> EnvioRegalos { get; set; }
        public DbSet<ProductoModelo> Productos { get; set; }
        public DbSet<ProveedorModelo> Proveedores { get; set; }
        public DbSet<ClienteModelo> Clientes { get; set; }
        public DbSet<VentaModelo> Ventas { get; set; }
        public DbSet<CompraModelo> compras { get; set; }
        public DbSet<ProductosVendidos> ProductosVendidos { get; set; }
    }
}
/*
 La base de datos se llamará Almacén. En el almacén habrá:
- Productos de los que guardaremos el Nombre y el Precio. 
- Clientes de los que guardaremos el Nombre y el NIF.
- Proveedores de los que guardamos Nombre y NIF.
- Compras, compramos un producto a un proveedor en una cantidad, a un precio unitario
y en una fecha.
- Ventas, vendemos un producto a un cliente en una cantidad, a un precio unitario
y en una fecha.

La creación de una estructura de modelos completa vale 2 puntos.



a) Sacar un listado de los productos de los que disponemos y 
la cantidad que de ese producto hemos comprado hasta ahora 
(sólo compras) y su precio de compra promedio.  Para esto vas
a crear un procedimiento y utilizarlo.  4 puntos.

b) Realizar un programa en el que seleccionemos un Producto
y nos muestre, por separado, las compras y las ventas que hemos
hecho de él hasta ahora. El listado debe incluir cantidad, precio
unitario, cantidad por precio y estará ordenado por fecha. Debajo
de cada listado aparecerá la cantidad comprada y el precio total. 
4 puntos.
 */