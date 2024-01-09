using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Repasando.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		//Estos son los atributos de la clase
        public string mensaje { get; set; }
        public string hora { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			mensaje = "holaa Luis";
			hora = "Son las "+ DateTime.Now.ToString();
		}
		//OnGet carga valores al cargase la pagina
	}
}