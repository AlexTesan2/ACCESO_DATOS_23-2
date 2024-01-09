using Modelos;
namespace Services
{
	//repositorio: crea funciones que acceden a unos datos
	//Interfaz, crea obligaciones, define metodos y funciones
	public interface IAlumRepositorio
	{
		IEnumerable<Alum> GetAllAlumnos();  //Obligamos a AlumRepositorio a tener el metodo getAllAlumnos que devuelva un enumerable de alumn
		Alum GetAlum(int id);         //obligamos a haber un metodo llamado GetAlum q devuelve un alumno y espera recibir un entero en el OnGet
		Alum Update(Alum alumActualizado);
		Alum Add(Alum alumNew);
		Alum Delete(int id);
		IEnumerable<CursoCuantos> GetAlumnosPorCurso(Curso? curso);
	}
}