using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages0.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string mensaje { get; set; }
        public string mensajeHora { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            mensaje = "Hola 2ºH!";
            mensajeHora = "Son las " +DateTime.Now.ToString();
        }
    }
}