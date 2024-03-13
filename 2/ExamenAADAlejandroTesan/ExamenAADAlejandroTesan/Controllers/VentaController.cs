using ExamenAADAlejandroTesan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamenAADAlejandroTesan.Controllers
{
    public class VentaController : Controller
    {
        public Contexto Contexto { get; }
        public VentaController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: VentaController
        public ActionResult Index()
        {
            ViewBag.ProductosL = Contexto.Productos.ToList();
            ViewBag.ClientesL = Contexto.Clientes.ToList();
            var listaVentas = Contexto.Ventas.ToList();
            return View(listaVentas);
        }

        // GET: VentaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VentaController/Create
        public ActionResult Create()
        {
            ViewBag.Productos = new SelectList(Contexto.Productos, "Id", "Nombre");
            ViewBag.Clientes = new SelectList(Contexto.Clientes, "Id", "Nombre");
            return View();
        }

        // POST: VentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VentaModelo v)
        {
            Contexto.Ventas.Add(v);
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

        // GET: VentaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VentaController/Edit/5
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

        // GET: VentaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VentaController/Delete/5
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
