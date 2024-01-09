using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Tesan_Alejandro.Componentes
{
    public class ComunidadDatosViewComponent : ViewComponent
    {
        public IProvinciaRepositorio provinciaRepositorio {  get; set; }
        public ComunidadDatosViewComponent(IProvinciaRepositorio provinciaRepositorio)
        {
            provinciaRepositorio = provinciaRepositorio;
        }

        public IViewComponentResult Invoke(Comunidad? comunidad = null)
        {
            var resultado = provinciaRepositorio.GetInfoComunidad(comunidad);
            return View(resultado);
        }
    }
}
