using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class VehiculoController : Controller
    {
        public Contexto Contexto { get; }
        public VehiculoController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: VehiculoController1
        public ActionResult Index()
        {
            //Viewbag.marcas=Contexto.Marcas.ToList();
            List<VehiculoModelo> listav = Contexto.Vehiculos.Include(v => v.Serie.Marca).ToList();
            return View(listav);
        }

        public ActionResult Busqueda(string busca="")
        {
            ViewBag.num=busca;
            var lista = from v in Contexto.Vehiculos.Include(v => v.Serie) where (v.Matricula.Contains(busca)) select v;
            return View(lista);
        }
        //cuando abra la pagina busqueda, obligatoriamente tengo q pasarle un string, y sino dara error
        //si no le pasas un tring, busca se cargara con "" , la primera vez q entras, busca no tendra nada, por eso lo cargamos con ""

        public ActionResult Busqueda2(string busca = "")
        {
            ViewBag.num2 = new SelectList(Contexto.Vehiculos, "Matricula", "Matricula", busca);
            var lista = from v in Contexto.Vehiculos.Include(v => v.Serie) where (v.Matricula.Equals(busca)) select v;
            return View(lista);
        }
        //parametros: 1-de donde saca los datos, 2-value (lo q se guarda), 3-text (lo q se vee) y 4-selected (seleccionado por defecto)

        // GET: VehiculoController1/Create
        public ActionResult Create()
        {
            ViewBag.SerieId = new SelectList(Contexto.Series, "Id", "NomSerie");
            return View();
        }

        // GET: VehiculoController1/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SLSerieId = new SelectList(Contexto.Series, "Id", "NomSerie");
            var coche = Contexto.Vehiculos.FirstOrDefault(v => v.Id == id);
            return View(coche);
        }

        // POST: VehiculoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, VehiculoModelo vehiculoActualizado)
        {

            /*var vehiculoAct= Contexto.Vehiculos.Attach(vehiculoActualizado);
            vehiculoAct.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Contexto. SaveChanges;*/
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehiculoController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // POST: VehiculoController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehiculoModelo vehiculo)
        {
            Contexto.Vehiculos.Add(vehiculo);
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



        // GET: VehiculoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehiculoController1/Delete/5
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
