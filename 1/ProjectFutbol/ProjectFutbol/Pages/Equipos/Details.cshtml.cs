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
	public class DetailsModel : PageModel
    {
        public Equipo equipo { get; set; }
        //declaramos un atributo de clase de la clase IAlumnoRepositorio para poder llamar al m�todo GetAlumnoById
        private readonly IEquipoRepositorio equipoRepositorio;

        public DetailsModel(IEquipoRepositorio equipoRepositorio)
        {
            this.equipoRepositorio = equipoRepositorio;
        }

        public void OnGet(int id)
        {
            equipo = equipoRepositorio.GetEquipoById(id);


        }
    }
}
