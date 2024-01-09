using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Modelos;
using RazorPages.Service;

namespace RazorPages1.Pages.Alumnos
{
	public class DetailsModel : PageModel
    {
        public Alumno alumno { get; set; }
        //declaramos un atributo de clase de la clase IAlumnoRepositorio para poder llamar al m�todo GetAlumnoById
        private readonly IAlumnoRepositorio alumnoRepositorio;

        public DetailsModel(IAlumnoRepositorio alumnoRepositorio)
        {
            this.alumnoRepositorio = alumnoRepositorio;
        }

        public void OnGet(int id)
        {
            alumno = alumnoRepositorio.GetAlumnoById(id);
            
            
        }
    }
}
