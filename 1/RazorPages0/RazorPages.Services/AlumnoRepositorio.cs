using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorPages.Modelos;
using RazorPages.Services;
using System.Linq;

namespace RazorPages.Services
{
    public class AlumnoRepositorio : IAlumnoRepositorio
    {
        public List<Alumno>listaAlumnos { get; set; }

        public AlumnoRepositorio()
        {
            listaAlumnos = new List<Alumno>()
            {
                new Alumno() { Id=1, Nombre="Hammermman", CursoID=Curso.H1, Email="h@gmail.com", Foto="hammmermmman2.jpg"},
                new Alumno() { Id=2, Nombre="Dr. T", CursoID=Curso.H1, Email="t@gmail.com", Foto="sonrisa.jpg"},
                new Alumno() { Id=3, Nombre="Gigante Electrico", CursoID=Curso.E1, Email="e@gmail.com", Foto="im.jpg"},
                new Alumno() { Id=4, Nombre="Mega", CursoID=Curso.E2, Email="m@gmail.com", Foto="vader.jpeg"}
            };
        }
        public IEnumerable<Alumno> GetAllAlumnos()
        {
            return listaAlumnos;
        }

		public Alumno GetAlumno(int id)
		{
            return listaAlumnos.FirstOrDefault(a => a.Id == id);
		}

		public Alumno Update(Alumno alumnoActualizado)
		{
            Alumno alumno = listaAlumnos.FirstOrDefault(a => a.Id == alumnoActualizado.Id);
            alumno.Nombre = alumnoActualizado.Nombre;
			alumno.Email = alumnoActualizado.Email;
			alumno.CursoID = alumnoActualizado.CursoID;
            alumno.Foto= alumnoActualizado.Foto;
            return alumno;
		}

		public Alumno Add(Alumno alumnoNuevo)
		{
			alumnoNuevo.Id=listaAlumnos.Max(a => a.Id)+1;
            listaAlumnos.Add(alumnoNuevo);
            return alumnoNuevo;
		}

		public Alumno Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<CursoCuantos> AlumnosPorCurso(Curso? curso)
			{
			IEnumerable<Alumno> consulta = listaAlumnos;
			if (curso.HasValue) 
            {
				consulta=consulta.Where(a=> a.CursoID ==curso).ToList();
            }
            return consulta.GroupBy(a => a.CursoID)  //el a es el alias de listaAlumnos
                .Select(g => new CursoCuantos()  //g es el agrupamiento de la mlista nde los alumnos
                {
                    Clase = g.Key.Value,
                    NumAlumn = g.Count()
                }).ToList(); 
		}
	}
}
