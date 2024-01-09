using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace Repasando.Pages.Alumnos
{
    public class DeleteModel : PageModel
    {
        public IAlumRepositorio AlumRepositoriomio { get; set; }
        [BindProperty]
        public Alum alumno { get; set; }
        public DeleteModel(IAlumRepositorio alumRepositorio)
        {
            this.AlumRepositoriomio = alumRepositorio;
        }
        public IActionResult OnGet(int id)
        {
            alumno=AlumRepositoriomio.GetAlum(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            AlumRepositoriomio.Delete(alumno.ID);
            return RedirectToPage("Alumnos");
        }
    }
}
