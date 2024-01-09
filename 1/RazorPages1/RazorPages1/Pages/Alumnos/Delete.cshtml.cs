using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Modelos;
using RazorPages.Service;

namespace RazorPages1.Pages.Alumnos
{
	public class DeleteModel : PageModel
    {
        //declaramos un atributo de clase de la clase IAlumnoRepositorio para poder llamar al método GetAlumnoById
        private readonly IAlumnoRepositorio alumnoRepositorio;

        [BindProperty]//esto permite que se actualice
        public Alumno alumno { get; set; }


        public DeleteModel(IAlumnoRepositorio alumnoRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            this.alumnoRepositorio = alumnoRepositorio;
           
        }
        public void OnGet(int id)
        {
            alumno = alumnoRepositorio.GetAlumnoById(id);

        }
        public IActionResult OnPost(int id)
        {
            alumnoRepositorio.Delete(id);
            return RedirectToPage("Index");
        }
            
           
        
    }
}
