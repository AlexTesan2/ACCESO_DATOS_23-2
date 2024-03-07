using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public List<int> ExtrasSeleccionados { get; set; }  //no se guarda en la tabla
        public List<VehiculoExtraModelo> VehiculoExtras { get; set; }//establece la relacion,Una lista de los Id de los VehiculoExtraModelo

        public VendedorModel Vendedor { get; set; }
        public int VendedorId { get; set; }


        //relacion muchos a muchos: 
        [NotMapped]
        public List<int> FotosDelCocheIds { get; set; } 
        public List<VehiculoFotoModelo> FotosDelCoche { get; set; }
    }
    //las litas no se poeden guardar en la tabla, pero nos facilita la programacion
    //lo no mapeado no se guardara en la tabla, solo sirve para poder trabajar dentro del prograama.
}
