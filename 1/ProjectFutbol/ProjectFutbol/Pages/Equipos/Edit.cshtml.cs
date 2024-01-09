using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProjectFutbol.Pages.Equipos
{
    public class EditModel : PageModel
    {
        private readonly IEquipoRepositorio equipoRepositorio;
        public IWebHostEnvironment WebHostEnvironment { get; }

        [BindProperty]//esto permite que se actualice
        public Equipo equipo { get; set; }



        public EditModel(IEquipoRepositorio equipoRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            this.equipoRepositorio = equipoRepositorio;
            WebHostEnvironment = webHostEnvironment;
        }
      
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                //para que no de error, porque id no sabemos lo que es, le decimos que coja el valor
                equipo = equipoRepositorio.GetEquipoById(id.Value);
            }
            else
            {
                equipo = new Equipo();
            }
            return Page();
        }
        //cuando demos al botón de submit se ejecutará éste metodo
        //en vez de void, va a devolver una acción
        public IActionResult OnPost(Equipo equipo)
        {
            if (ModelState.IsValid)//si he rellenado todos los campos required
            {
                if (equipo.Id != 0)
                    equipoRepositorio.Update(equipo);
                else
                    equipoRepositorio.Add(equipo);
                return RedirectToPage("Index");
            }
            else
                return Page();
        }
    }
}
