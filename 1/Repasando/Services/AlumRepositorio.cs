using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using System.Linq;

namespace Services
{
	public class AlumRepositorio : IAlumRepositorio
	{
        public List<Alum> listaAlumnos { get; set; }
        public Alum alummm { get; set; }

        public AlumRepositorio()
        {
			listaAlumnos = new List<Alum>()//metemos los datos a la lista
			{
				new Alum() {ID=1,Name="Sujeto1", CursoId=Curso.A1, Foto="hammmermmman.jpg"},
				new Alum() {ID=2,Name="Jaime", CursoId=Curso.C1, Foto="im.jpg"},
				new Alum() {ID=3,Name="ElMalo", CursoId=Curso.A2, Foto="MONTEERO2.png"},
				new Alum() {ID=4,Name="ElCuarto", CursoId=Curso.B1, Foto="sub3.jpg"}
			};
        }
        public IEnumerable<Alum> GetAllAlumnos()
		{
			return listaAlumnos;
		}

		public Alum GetAlum(int id)
		{
			return listaAlumnos.FirstOrDefault(a => a.ID == id);
		}

		public Alum Update(Alum alumActualizado)
		{
			alummm = listaAlumnos.FirstOrDefault(a=> a.ID == alumActualizado.ID);
			alummm.Name= alumActualizado.Name;
			alummm.CursoId= alumActualizado.CursoId;
			alummm.Foto= alumActualizado.Foto;	
			return alummm;
		}

		public Alum Add(Alum alumNew)
		{
			alumNew.ID= listaAlumnos.Max(a=>a.ID)+1;
			listaAlumnos.Add(alumNew);
			return alumNew;
		}

		public Alum Delete(int id)
		{
			Alum alumnoAborrar = listaAlumnos.FirstOrDefault(a => a.ID == id);
			if (alumnoAborrar != null)
			{
				listaAlumnos.Remove(alumnoAborrar);
			}
			return alumnoAborrar;
		}

		public IEnumerable<CursoCuantos> GetAlumnosPorCurso(Curso? curso)
		{
			IEnumerable<Alum> consulta = listaAlumnos;
			if (curso.HasValue)
			{
				consulta = consulta.Where(a => a.CursoId == curso).ToList();
			}
			//modo predicado, a es el alias del objeto sobre el que actúa el método
			return consulta.GroupBy(a => a.CursoId)
				.Select(g => new CursoCuantos()//g es por el aGrupamiento
				{//hacemos una consulta Select por cada agrupamiento en la que creamos un objeto CursoCuantos
					clase = g.Key.Value,
					NumAlums = g.Count()
				}).ToList();//el resultado lo convertimos en lista

		}
	}
}
