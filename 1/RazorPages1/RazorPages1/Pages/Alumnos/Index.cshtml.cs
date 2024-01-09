using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Modelos;
using RazorPages.Service;
using System.Runtime.CompilerServices;

namespace RazorPages1.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        //declaramos un atributo de clase de la clase IAlumnoRepositorio para poder llamar al método GetAllAlumnos
        private readonly IAlumnoRepositorio alumnoRepositorio;
        //para que salga IAlumnoRepositorio añado la dependencia del .Service 
        // y uso este objeto para llamar al método GetAllAlumnos()
        public IEnumerable<Alumno> Alumnos;
        //cuando llamemos al GetAllAlumnos nos devolverá una lista de objetos de la clase Alumno, por lo que creamos 
        //un objeto de esa clase para poder llamarlo.

        public IndexModel(IAlumnoRepositorio alumnoRepositorio) 
        {
            this.alumnoRepositorio = alumnoRepositorio;
            /*esto es inyección de dependencias:
            * que sin llamar explicitamente a los métodos constructores
            * se creen */
        }
        public void OnGet()
        {
            Alumnos = alumnoRepositorio.GetAllAlumnos();
        }
    }
}
