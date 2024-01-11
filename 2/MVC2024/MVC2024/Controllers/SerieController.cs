using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;
//trabajaremos con dos tablas; marca y serie 
namespace MVC2024.Controllers
{
	public class SerieController : Controller
	{
		public Contexto Contexto { get; }
        public SerieController(Contexto contexto)
        {
			this.Contexto = contexto;
        }

        // GET: SerieController
        public ActionResult Index()
		{
			List<SerieModelo> lista = Contexto.Series.Include(s => s.Marca).ToList();
			return View(lista);
        }
		//importante el Include, permite acceder a los atributos de otra clase
        //1 se ejecuta el metodo del controlador correspondiente a la vista, y luego la vista
		//contexto es la base de datos (en la ram), series es un DbSet de serie-modelo (una lista)

        // GET: SerieController/Details/5
        public ActionResult Details(int id)
		{
			return View();
		}

		// GET: SerieController/Create
		public ActionResult Create()
		{
			ViewBag.MarcaId = new SelectList(Contexto.Marcas, "Id", "Nom_Marca");
			return View();
		}

		// POST: SerieController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(SerieModelo serie)
		{
			if (Contexto == null)
			{
				throw new ArgumentNullException(nameof(Contexto));
			}

			if (serie == null)
			{
				throw new ArgumentNullException(nameof(serie));
			}
			Contexto.Series.Add(serie);         
			Contexto.Database.EnsureCreated();  
			Contexto.SaveChanges();
			try
			{
				return RedirectToAction(nameof(Create));
			}
			catch
			{
				return View();
			}
		}

		// GET: SerieController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SerieController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: SerieController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SerieController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
