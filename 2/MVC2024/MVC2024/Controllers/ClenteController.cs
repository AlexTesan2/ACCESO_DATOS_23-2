using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC2024.Controllers
{
    public class ClenteController : Controller
    {
        // GET: ClenteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClenteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClenteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClenteController/Create
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

        // GET: ClenteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClenteController/Edit/5
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

        // GET: ClenteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClenteController/Delete/5
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
