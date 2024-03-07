namespace MVC2024.Models
{
    public class VehiculoFotoModelo
    {
        public int id { get; set; }
        public int vehiculoId { get; set; }
        public VehiculoModelo vehiculo { get; set; }
        public int fotoId { get; set; }
        public FotoModelo foto { get; set; }
    }
}
