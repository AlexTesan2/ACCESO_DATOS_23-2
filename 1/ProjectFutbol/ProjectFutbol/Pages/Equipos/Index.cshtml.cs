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
	public class IndexModel : PageModel
    {
        private readonly IEquipoRepositorio equipoRepositorio;
        
        public IEnumerable<Equipo> Equipos;
       
        public string elementoABuscar { get; set; }

        public IndexModel(IEquipoRepositorio equipoRepositorio)
        {
            this.equipoRepositorio = equipoRepositorio;
            
        }

        public void OnGet(string elementoABuscar = "")
        {
            //Equipos = equipoRepositorio.GetAllEquipos();
            Equipos = equipoRepositorio.Busqueda(elementoABuscar);

		}

        // public void OnGet()
        //[BindProperty(SupportsGet =true)]
	}
}
