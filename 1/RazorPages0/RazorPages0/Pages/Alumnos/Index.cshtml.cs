using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using RazorPages.Modelos;

namespace RazorPages0.Pages.Alumnos
{
    public class IndexModel : PageModel
    {
        private readonly IAlumnoRepositorio alumnoRepositorio;
        public IEnumerable<Alumno> Alumnos;
        public IndexModel(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }
        public void OnGet()
        {
            Alumnos=alumnoRepositorio.GetAllAlumnos();
        }
    }
}
