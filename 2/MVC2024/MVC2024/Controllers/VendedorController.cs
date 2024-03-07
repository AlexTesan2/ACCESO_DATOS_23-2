using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class VendedorController : Controller
    {
        public Contexto Contexto { get; }
        public VendedorController(Contexto contexto)
        {
            Contexto = contexto;
        }


        // GET: VendedorController
        public ActionResult Index()
        {
            List <VendedorModel> lista = Contexto.vendedores.ToList();
            return View(lista);
        }

        // GET: VendedorController/Details/5
        public ActionResult Details(int id)
        {
            VendedorModel vendedor = Contexto.vendedores.Find(id);
            return View(vendedor);
        }

        // GET: VendedorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendedorModel elVendedor)
        {
            Contexto.vendedores.Add(elVendedor);
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

        // GET: VendedorController/Edit/5
        public ActionResult Edit(int id)
        {
            VendedorModel vendedor = Contexto.vendedores.Find(id);
            return View();
        }

        // POST: VendedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,VendedorModel elVendedor)
        {
            VendedorModel antiguoVendedor = Contexto.vendedores.Find(id);
            antiguoVendedor.NomVendedor = elVendedor.NomVendedor;
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

        // GET: VendedorController/Delete/5
        public ActionResult Delete(int id)
        {
            VendedorModel vendedor = Contexto.vendedores.Find(id);
            return View();
        }

        // POST: VendedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VendedorModel vendedor)
        {
            Contexto.vendedores.Remove(vendedor);
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
    }
}
