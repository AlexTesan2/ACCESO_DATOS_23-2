using Microsoft.AspNetCore.Mvc;
using Services;
using Modelos;

namespace Repasando.Componenets
{
    public class AlumnosCursoViewComponent : ViewComponent
    {
        public IAlumRepositorio AlumRepositorio { get; }
        public AlumnosCursoViewComponent(IAlumRepositorio alumRepositorio)
        {
            AlumRepositorio = alumRepositorio;
        }
        public IViewComponentResult Invoke(Curso? curso=null)
        {
            var resultado=AlumRepositorio.GetAlumnosPorCurso(curso);
            return View(resultado);
        }
    }//como una vista, preo la puedes poner donde quieras
}
