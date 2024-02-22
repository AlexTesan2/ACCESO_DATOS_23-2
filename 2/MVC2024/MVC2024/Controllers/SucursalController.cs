using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class SucursalController : Controller
    {
        public Contexto Contexto { get; }
        public SucursalController(Contexto contexto)
        {
            Contexto = contexto;
        }

        // GET: SucursalController
        public ActionResult Index()
        {
            List<Sucursal> lista = Contexto.Sucursal.ToList();
            return View(lista);
        }

        public ActionResult Seleccionable()
        {
            ViewBag.sucur = new SelectList(Contexto.Sucursal, "Id", "Nombre");
            List<VehiculoModelo> listaV= Contexto.Vehiculos.ToList();
            return View(listaV);
        }

        // GET: SucursalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SucursalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SucursalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SucursalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SucursalController/Edit/5
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

        // GET: SucursalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SucursalController/Delete/5
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
