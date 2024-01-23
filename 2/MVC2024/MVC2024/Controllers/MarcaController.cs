using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class MarcaController : Controller
    {
        public Contexto Contexto { get;}
        public MarcaController(Contexto contexto)
        {
            Contexto = contexto;
        }

        // GET: MarcaController
        public ActionResult Index()
        {
            List<MarcaModelo> lista= Contexto.Marcas.ToList();  //var lista = Contexto.Marcas.ToList();
            return View(lista);
        }

        public ActionResult Desplegable()
        {
            ViewBag.Marcas = new SelectList(Contexto.Marcas, "Id", "Nom_Marca"); //contenedor global
            ViewBag.Marcas2 =  Contexto.Marcas.ToList();
            return View();
        }


        public ActionResult Listado(int id)
        {
            List<MarcaModelo> lista = Contexto.Marcas.ToList();
            return View(lista);
        }

        // GET: MarcaController/Details/5
        // POST: MarcaController/Create   cuando haces click en el boton de submit del formulario de insercion
        //en este caso, es el controador el que espera recibir los datos de la vista
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaModelo marca)
        {
			if (Contexto == null)
			{
		        throw new ArgumentNullException(nameof(Contexto));
			}
			if (marca == null)
			{
				throw new ArgumentNullException(nameof(marca));
			}
			Contexto.Marcas.Add(marca);         //metes los datos en memoria ram
            Contexto.Database.EnsureCreated();  //si la bd no existe, la crea
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
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: MarcaController/Create  la primera vez que se abre la pagina
        public ActionResult Create()
        {

            return View();
        }


        // GET: MarcaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MarcaController/Edit/5
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

        // GET: MarcaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MarcaController/Delete/5
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
