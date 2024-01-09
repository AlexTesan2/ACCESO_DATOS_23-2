//En el video es index
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Modelos;

namespace Repasando.Pages.Alumnos
{
    public class AlumnosModel : PageModel
    {
        public IAlumRepositorio alumnoRepositorio { get; set; }
        public IEnumerable<Alum> Alumnos;
        public AlumnosModel(IAlumRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }
        public void OnGet()
        {
            Alumnos=alumnoRepositorio.GetAllAlumnos();//cargamos en la lista los aluumnos mediante un metodo de el alumnoRepositorio 
		}
    }
}
