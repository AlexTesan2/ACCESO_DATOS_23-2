using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC2024.Models;

namespace MVC2024.Controllers
{
    public class VehiculoController : Controller
    {

        //se puede crear uan clase dentro de una clase
        public class VehiculoTotal
        {
            public string Nom_Marca { get; set; }
            public string NomSerie { get; set; }
            public string Matricula { get; set; }
            public string Color { get; set; }
        }


        public ActionResult ListadoVehiculoTotal()
        {
            //List<VehiculoTotal> ListaVehiculoTotal = Contexto.VistaTotal.ToList();
            var ListaVehiculoTotal = Contexto.VistaTotal.FromSql($"SELECT Marcas.Nom_Marca, Series.NomSerie, Vehiculos.Matricula, Vehiculos.Color FROM Marcas INNER JOIN Series ON Marcas.Id = Series.MarcaId INNER JOIN Vehiculos ON Series.Id = Vehiculos.SerieId");
            return View(ListaVehiculoTotal);
        }

        public ActionResult ListadoVehiculoTotalConProcedimientoAlmacenado() //Para Agustin: Listado3
        {
            var ListaVehiculoTotal = Contexto.VistaTotal.FromSql($"EXECUTE getSeriesVehiculos");
            return View(ListaVehiculoTotal);
        }//ejecutamos un procedimiento q se encuentra en el sql server

        public ActionResult ListadoVehiculoTotalConProcedimientoAlmacenado2(string color="%")
        {
            ViewBag.color = new SelectList(Contexto.Vehiculos.Select(v => new {Color = v.Color}).Distinct(), "Color", "Color");
            var ListaVehiculoTotal = Contexto.VistaTotal.FromSql($"EXECUTE getVehiculosPorColor {color}");
            return View(ListaVehiculoTotal);
        }

        public ActionResult ListadoVehiculoTotalConProcedimientoAlmacenado3(string color = "%")
        {
            var elColor = new SqlParameter("@ColorSel", color);
            ViewBag.color = new SelectList(Contexto.Vehiculos.Select(v => new { Color = v.Color }).Distinct(), "Color", "Color");
            var ListaVehiculoTotal = Contexto.VistaTotal.FromSql($"EXECUTE getVehiculosPorColor {elColor}");
            return View(ListaVehiculoTotal);
        }

        public Contexto Contexto { get; }
        public VehiculoController(Contexto contexto)
        {
            Contexto = contexto;
        }
        // GET: VehiculoController1
        public ActionResult Index()
        {
            List<VehiculoModelo> listav = Contexto.Vehiculos.Include(v => v.Serie.Marca).Include(v => v.VehiculoExtras).Include(v => v.Vendedor).Include(v => v.FotosDelCoche).ToList();
            ViewBag.marcas = Contexto.Marcas.ToList();
            ViewBag.ex= Contexto.Extras.ToList();
            ViewBag.fot = Contexto.fotos.ToList();
            return View(listav);
        }

        public ActionResult Busqueda(string busca="")
        {
            ViewBag.num=busca;
            var lista = from v in Contexto.Vehiculos.Include(v => v.Serie) where (v.Matricula.Contains(busca)) select v;
            return View(lista);
        }
        //cuando abra la pagina busqueda, obligatoriamente tengo q pasarle un string, y sino dara error
        //si no le pasas un string, busca se cargara con "" , la primera vez q entras, busca no tendra nada, por eso lo cargamos con ""

        public ActionResult Busqueda2(string busca = "")
        {
            ViewBag.num2 = new SelectList(Contexto.Vehiculos, "Matricula", "Matricula", busca);
            var lista = from v in Contexto.Vehiculos.Include(v => v.Serie) where (v.Matricula.Equals(busca)) select v;
            return View(lista);
        }
        //parametros: 1-de donde saca los datos, 2-value (lo q se guarda), 3-text (lo q se vee) y 4-selected (seleccionado por defecto)

        public ActionResult BuscoPorVendedor(string busca = "")
        {
            ViewBag.vendedores = new SelectList(Contexto.vendedores, "NomVendedor", "NomVendedor", busca);
            var lista = from v in Contexto.Vehiculos.Include(v => v.Vendedor).Include(v => v.Serie) where (v.Vendedor.NomVendedor.Equals(busca)) select v;
            return View(lista);
        }



        public ActionResult Seleccion(int marcaId = 1, int serieId= 0)
        {
            ViewBag.lasMarcas = new SelectList(Contexto.Marcas,"Id", "Nom_Marca", marcaId);
            ViewBag.lasSeries = new SelectList(Contexto.Series.Where(s => s.MarcaId == marcaId),"Id", "NomSerie", serieId);
            List<VehiculoModelo> vehiculos = Contexto.Vehiculos.Where(v => v.SerieId == serieId).ToList();
            return View(vehiculos);
        }



        // GET: VehiculoController1/Create
        public ActionResult Create()
        {
            ViewBag.SerieId = new SelectList(Contexto.Series, "Id", "NomSerie");
            ViewBag.VehiculosExtras = new MultiSelectList(Contexto.Extras, "Id", "Name");
            ViewBag.VendedorID = new SelectList(Contexto.vendedores, "Id", "NomVendedor");
            ViewBag.fotos = new MultiSelectList(Contexto.fotos, "id", "nomFoto");
            return View();
        }

        // GET: VehiculoController1/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SLSerieId = new SelectList(Contexto.Series, "Id", "NomSerie");
            VehiculoModelo coche = Contexto.Vehiculos.Find(id);

            coche.ExtrasSeleccionados= Contexto.VehiculoExtra.Where(ve => ve.vehiculoID == id).Select(ve => ve.extraID).ToList();

            ViewBag.ExtraList = new MultiSelectList(Contexto.Extras, "Id", "Name", coche.ExtrasSeleccionados);
            ViewBag.Vendedor = new SelectList(Contexto.vendedores, "Id", "NomVendedor");

            return View(coche);
        }

        // POST: VehiculoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehiculoModelo cocheActualizado)
        {
            VehiculoModelo cocheAntiguo = Contexto.Vehiculos.Find(id);
            cocheAntiguo.Matricula = cocheActualizado.Matricula;
            cocheAntiguo.Serie = cocheActualizado.Serie;
            cocheAntiguo.Color = cocheActualizado.Color;
            cocheAntiguo.SerieId = cocheActualizado.SerieId;
            cocheAntiguo.VendedorId = cocheActualizado.VendedorId;
            Contexto.SaveChanges();

            var extrasActuales = Contexto.VehiculoExtra.Where(ve => ve.vehiculoID == id);

            foreach (var extraAEliminar in extrasActuales)
            { 
                Contexto.VehiculoExtra.Remove(extraAEliminar);
            }

            foreach (int extraAAnyadir in cocheActualizado.ExtrasSeleccionados)
            {
                var ObjetoVehiculoExtra = new VehiculoExtraModelo()
                {
                    extraID = extraAAnyadir,
                    vehiculoID = cocheActualizado.Id
                };
                Contexto.VehiculoExtra.Add(ObjetoVehiculoExtra);
            }
            //Contexto:Base de datos / VehiculoExtra: tabla
            //Añadimos objetos de la clase VehiculoExtraModelo /  extraAAnyadir es un numeroEntero
            //Creo un objeto nuevo, le doy valores iniciales, 

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

        // GET: VehiculoController1/Details/5
        public ActionResult Details(int id)
        {
            VehiculoModelo vehiculo = Contexto.Vehiculos.Include(v => v.Serie.Marca).Include(v => v.Vendedor).FirstOrDefault(v => v.Id == id);
            return View(vehiculo);
        }
        // Otra opcion: Contexto.Vehiculos.Include("Serie.Marca")

        // POST: VehiculoController1/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehiculoModelo vehiculo)
        {
            Contexto.Vehiculos.Add(vehiculo);
            Contexto.Database.EnsureCreated();
            Contexto.SaveChanges();                 //primero guarda los cambios, y asi asigna una id al vehiculo, y despues podremos trabajar con esta id

            foreach (int xtraID in vehiculo.ExtrasSeleccionados) 
            {
                var obj= new VehiculoExtraModelo() //metodo constuctor de la clase VehiculoExtraModelo
                {
                    extraID = xtraID,
                    vehiculoID = vehiculo.Id
                };
                Contexto.VehiculoExtra.Add(obj);
            }
            Contexto.SaveChanges();

            foreach (int f in vehiculo.FotosDelCocheIds)
            {
                var obj = new VehiculoFotoModelo() //metodo constuctor de la clase VehiculoExtraModelo
                {
                    fotoId = f,
                    vehiculoId= vehiculo.Id
                };
                Contexto.vehiculofotos.Add(obj);
            }
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
            VehiculoModelo vehiculo = Contexto.Vehiculos.Find(id);
            return View(vehiculo);
        }

        // POST: VehiculoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VehiculoModelo cocheAEliminar)
        {
            Contexto.Vehiculos.Remove(cocheAEliminar);
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
