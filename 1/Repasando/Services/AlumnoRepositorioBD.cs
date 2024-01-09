using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos;
using Microsoft.Data.SqlClient;

namespace Services
{
	public class AlumnoRepositorioBD : IAlumRepositorio
	{
		private readonly AlumnoDdContext context;
		public AlumnoRepositorioBD(AlumnoDdContext context)
        {
			this.context = context;
		}

		public Alum Add(Alum alumNew)
		{
			context.Alumnos.Add(alumNew);
			context.SaveChanges();
			return alumNew;


			/*context.Database.ExecuteSqlRaw("insertarAlumno {0}, {1}, {2}, {3}",
				alumNew.Name,
				alumNew.Foto,
				alumNew.CursoId);
			return alumNew;*/
		}

		public IEnumerable<Alum> FindAlumnos(string elementoABuscar)
		{
			if (string.IsNullOrEmpty(elementoABuscar))
			{
				return context.Alumnos;
			}
			else
			{
				return context.Alumnos.Where(a => a.Name.Contains(elementoABuscar));
			}
		}

		public Alum Delete(int id)
		{
			Alum alumnoAborrar = context.Alumnos.Find(id);
			if (alumnoAborrar != null)
			{
				context.Alumnos.Remove(alumnoAborrar);
				context.SaveChanges();
			}
			return alumnoAborrar;
		}


		public IEnumerable<Alum> GetAllAlumnos()
		{
			return context.Alumnos;
			//return context.Alumnos.FromSqlRaw<Alum>("SELECT * FROM Alumnos").ToList();
		}

		public Alum GetAlum(int id)
		{
			return context.Alumnos.Find(id);
			//SqlParameter parameter = new SqlParameter("@Id", id);
			//return context.Alumnos.FromSqlRaw<Alum>("GetAlumnoById @Id", id).ToList().FirstOrDefault();
		}

		public Alum Update(Alum alumActualizado)
		{
			var alummm = context.Alumnos.Attach(alumActualizado);
			alummm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return alumActualizado;
		}


		public IEnumerable<CursoCuantos> GetAlumnosPorCurso(Curso? curso)
		{
			IEnumerable<Alum> consulta = context.Alumnos;
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
