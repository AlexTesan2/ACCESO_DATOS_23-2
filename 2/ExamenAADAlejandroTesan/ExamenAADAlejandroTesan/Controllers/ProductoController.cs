using ExamenAADAlejandroTesan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamenAADAlejandroTesan.Controllers
{

    public class ProductoController : Controller
    {
        public Contexto Contexto { get; }
        public ProductoController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: ProductoController

        public ActionResult Examen1()
        {
            var lista = Contexto.ProductosVendidos.FromSql($"EXECUTE ObtenerListadoProductosConCompra2");
            return View(lista);
        }

        public ActionResult Examen2(int productoId = 1)
        {
            ViewBag.pr = new SelectList(Contexto.Productos, "Id", "Nombre", productoId);
            ViewBag.compras = from c in Contexto.compras.Include(c => c.cantidad) where (c.productoId.Equals(productoId)) select c;
            ViewBag.ventas = from c in Contexto.Ventas.Include(c => c.cantidad) where (c.productoId.Equals(productoId)) select c;
            //List<VentaModelo> vehiculos = Contexto.Ventas.Include(c => c.cantidad).Where(c => c.productoId == productoId).ToList();
            return View();
        }


        /*CREATE PROCEDURE ObtenerListadoProductosConCompra2
        AS
        BEGIN
            SELECT 
                P.Nombre,
                SUM(C.Cantidad) AS CantidadComprada,
                AVG(C.PrecioUnitario) AS PrecioCompraPromedio
            FROM 
                Compras C
            INNER JOIN 
                Productos P ON C.ProductoId = P.Id
            GROUP BY 
                P.Nombre;
        END;*/


        public ActionResult Index()
        {
            var listaProductos = Contexto.Productos.ToList();
            return View(listaProductos);
        }

        public ActionResult ListadoExamen2()
        {
            var listaProductos = Contexto.Productos.ToList();
            return View(listaProductos);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoModelo p)
        {
            Contexto.Productos.Add(p);
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

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
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

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
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
