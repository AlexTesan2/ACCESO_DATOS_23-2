namespace ExamenAADAlejandroTesan.Models
{
    public class CompraModelo
    {
        //- Compras, compramos un producto a un proveedor en una cantidad,
        //a un precio unitario y en una fecha.
        public int Id { get; set; }
        public ProductoModelo producto { get; set; }
        public int productoId { get; set; }

        public ProveedorModelo proveedor { get; set; }
        public int proveedorId { get; set; }

        public int cantidad { get; set; }
        public int precioUnitario { get; set; }
        public String fecha { get; set; }
    }
}
