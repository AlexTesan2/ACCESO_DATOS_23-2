using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace Tesan_Alejandro.Pages.Provincias
{
    public class IndexModel : PageModel
    {
        public Comunidad comu {  get; set; }
        public IProvinciaRepositorio provinciaRepositorio { get; set; }

        public IndexModel(IProvinciaRepositorio provinciaRepositorio)
        {
            this.provinciaRepositorio = provinciaRepositorio;
        }
        public void OnGet()
        {
            comu= provinciaRepositorio.GetComunidades();
        }
    }
}
