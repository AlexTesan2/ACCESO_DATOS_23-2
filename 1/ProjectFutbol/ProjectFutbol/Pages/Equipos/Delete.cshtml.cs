using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos;
using Services;

namespace ProjectFutbol.Pages.Equipos
{
    public class DeleteModel : PageModel
    {
        private readonly IEquipoRepositorio equipoRepositorio;

        [BindProperty]//esto permite que se actualice
        public Equipo equipo { get; set; }


        public DeleteModel(IEquipoRepositorio equipoRepositorio, IWebHostEnvironment webHostEnvironment)
        {
            this.equipoRepositorio = equipoRepositorio;

        }
        public void OnGet(int id)
        {
            equipo = equipoRepositorio.GetEquipoById(id);

        }
        public IActionResult OnPost(int id)
        {
            equipoRepositorio.Delete(id);
            return RedirectToPage("Index");
        }



    }
}
