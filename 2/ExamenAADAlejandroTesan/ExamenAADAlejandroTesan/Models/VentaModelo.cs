namespace ExamenAADAlejandroTesan.Models
{
    public class VentaModelo
    {
        //- Ventas, vendemos un producto a un cliente
        //en una cantidad, a un precio unitario y en una fecha.

        public int Id { get; set; }
        public ProductoModelo producto { get; set; }
        public int productoId { get; set; }

        public ClienteModelo cliente { get; set; }
        public int clienteId { get; set; }

        public int cantidad { get; set; }
        public int precioUnitario { get; set; }
        public String fecha { get; set; }
    }
}
