using System;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Services;

namespace ProjectFutbol.Components
{
	public class EquiposCategoriaViewComponent : ViewComponent
	{
        public IEquipoRepositorio EquipoRepositorio { get; }

        public EquiposCategoriaViewComponent(IEquipoRepositorio equipoRepositorio)
		{
            EquipoRepositorio = equipoRepositorio;
        }

        public IViewComponentResult Invoke(Categoria? categoria= null) //puede recibir un objto categoria o no, en ese caso será null
        {

            var resultado = EquipoRepositorio.EquiposPorCategoria(categoria);
            return View(resultado);
        }
    }
}

