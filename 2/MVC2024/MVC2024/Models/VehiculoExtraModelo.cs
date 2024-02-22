namespace MVC2024.Models
{
    //Tabla intermedia en la relacion muchos a muchos Vehiculos-Extras
    public class VehiculoExtraModelo
    {
        public int ID { get; set; }   //Id de esta tabla
        public int extraID { get; set; }  //Id de la clase ExtraModelo
        public ExtraModelo extra { get; set; }

        public int vehiculoID { get; set; }  //Id de la clase VehiculoModelo
        public VehiculoModelo vehiculo { get; set; }
    }
    //Borraremos la base de datos y al ejecutar el codigo, se volvera a crear con las tablas y relaciones new
}
