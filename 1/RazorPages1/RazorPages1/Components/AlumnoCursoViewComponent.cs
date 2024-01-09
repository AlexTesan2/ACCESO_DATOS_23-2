using System;
using Microsoft.AspNetCore.Mvc;
using RazorPages.Modelos;
using RazorPages.Service;

namespace RazorPages1.Components
{
    public class AlumnoCursoViewComponent : ViewComponent
//subclase de ViewComponent que está dentro de AspNetCore.Mvc, es obligatorio que el nombre de la clase acabe con ViewComponent
	{
        public IAlumnoRepositorio AlumnoRepositorio { get; }

		public AlumnoCursoViewComponent(IAlumnoRepositorio alumnoRepositorio)
		{
            AlumnoRepositorio = alumnoRepositorio;
        }

        //el metodo invoque es el método que se ejecuta en el ciclo de vida de un ViewComponent, como sería el onGet de las PageModel
        public IViewComponentResult Invoke(Curso? curso = null) //puede recibir un objto curso o no, en ese caso será null
        {
            
            var resultado = AlumnoRepositorio.AlumnosPorCurso(curso);
            return View(resultado);
        }
    }
}

