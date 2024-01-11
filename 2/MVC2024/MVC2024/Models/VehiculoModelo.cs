namespace MVC2024.Models
{
    public class VehiculoModelo
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Color { get; set; }
        public SerieModelo Serie { get; set; }
        public int SerieId { get; set; }
        //despues de crear un modelo, hay q actualizar el contexto
    }
    
}
