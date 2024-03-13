using ExamenAADAlejandroTesan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamenAADAlejandroTesan.Controllers
{
    public class CompraController : Controller
    {
        public Contexto Contexto { get; }
        public CompraController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: CompraController
        public ActionResult Index()
        {
            ViewBag.ProductosL = Contexto.Productos.ToList();
            ViewBag.ProveedoresL = Contexto.Proveedores.ToList();
            var lista = Contexto.compras.ToList();
            return View(lista);
        }

        // GET: CompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompraController/Create
        public ActionResult Create()
        {
            ViewBag.Productos = new SelectList(Contexto.Productos, "Id", "Nombre");
            ViewBag.Proveedores = new SelectList(Contexto.Proveedores, "Id", "Nombre");
            return View();
        }

        // POST: CompraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompraModelo c)
        {
            Contexto.compras.Add(c);
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

        // GET: CompraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompraController/Edit/5
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

        // GET: CompraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompraController/Delete/5
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
