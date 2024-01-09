/*Este archivo es el controlador, es una clase
Lo podemos llamar como queramos, IndexModel es subclase de la clase
PageModel, para ello lo marcamos con los : */

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages1.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public string Mensaje { get; set; } /*prop mas tab*/

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()/*el metodo OnGet que se ejecuta al cargar, antes de 
                        que se abra la página Index se crea un objeto de la clase
                        IndexModel llamado ILogger y luego se ejectua el OnGet*/
    {
        Mensaje = "Hola 2H! son las:  " + DateTime.Now.ToLongTimeString();
    }
}