using Microsoft.AspNetCore.Mvc;
using RazorPages.Modelos;
using RazorPages.Services;

namespace RazorPages0.Components
{
	public class AlumnoCursoViewComponent : ViewComponent//no es pageModel, sino un componente. lo scomponentes los creas y luego los pones donde quieras
	{
		public IAlumnoRepositorio AlumnoRepositorio { get; }
		public AlumnoCursoViewComponent(IAlumnoRepositorio alumnoRepositorio) 
		{
			AlumnoRepositorio = alumnoRepositorio;
		}
																//equivalente a onGet
		public IViewComponentResult Invoke (Curso? curso = null)//puede recibir un objeto curso, y sino recibe null
		{
			var resultado=AlumnoRepositorio.AlumnosPorCurso(curso);
			return View(resultado);
		}
	}
}
