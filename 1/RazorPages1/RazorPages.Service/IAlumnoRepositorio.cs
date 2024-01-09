using RazorPages.Modelos; //el import de Java

namespace RazorPages.Service
{
    public interface IAlumnoRepositorio
        /*botón derecho en dependencias y agregar dependencias del proyecto
         * elegimos el Razor.Pages.Modelos y así tendremos acceso a las clases
         * de ese proyecto (ahora curso y alumnos)
         * 
         * Un repositorio es un lugar de donde se cogen datos, leyéndolo (base de datos, xml...)
         * puede haber funciones, métodos...
         * en nuestro caso serán métodos que obtengan datos de otro lado y los devuelvan transformados.
         * 
         * En un Interfaz se declaran los encabezados de las funciones que luego tendremos que implementar
         * Como el Runnable, luego te obliga a implementar las funciones que le pertenecen.
         * */
    {
        //vamos a crear un método que devuelva todos los alumnos y los devuelva en una lista, en este caso 
        //utilizamos la clase IEnumerable, actúa como la clase list
        IEnumerable<Alumno> GetAllAlumnos();
        //Aquí vamos a crear un método para que nos devuelva un objeto de la clase Alumno cuando le pases un entero
        Alumno GetAlumnoById(int id);
        //Una función que guarde los cambios del alumno
        void Update(Alumno alumnoActualizado);
        //un método que recibe un objeto de la clase alumno y lo insertará en la lista de alumnos
        void Add(Alumno alumnoNuevo);
        //un método que reciba un objeto de la clase alumno y lo elimine de la lista
        Alumno Delete(int idBorrar);
        //Un método que devuelva una lista de objetos de la clase CursoCuantos
        IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso);
    }
}