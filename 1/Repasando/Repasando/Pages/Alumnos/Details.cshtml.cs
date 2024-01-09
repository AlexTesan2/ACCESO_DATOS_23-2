using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace Repasando.Pages.Alumnos
{
    public class DetailsModel : PageModel
    {
        public Alum Alumm { get; set; }
		public IAlumRepositorio AlumRepositorio { get; }

		public DetailsModel(IAlumRepositorio alumRepositorio)
        {
			AlumRepositorio = alumRepositorio;
		}

        public void OnGet(int id)
        {
			Alumm = AlumRepositorio.GetAlum(id);
		}
    }
}