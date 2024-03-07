using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class fotoController : Controller
    {
        public Contexto Contexto { get; }
        public fotoController(Contexto contexto)
        {
            Contexto = contexto;
        }

        // GET: fotoController
        public ActionResult Index()
        {
            var lista = Contexto.fotos.ToList();
            return View(lista);
        }

        // GET: fotoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: fotoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fotoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FotoModelo f)
        {
            Contexto.fotos.Add(f);
            Contexto.Database.EnsureCreated();
            Contexto.SaveChanges();
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: fotoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: fotoController/Edit/5
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

        // GET: fotoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: fotoController/Delete/5
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
