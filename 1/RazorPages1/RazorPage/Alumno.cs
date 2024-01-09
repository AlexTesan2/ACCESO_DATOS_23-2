using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Modelos
{

    public class Alumno //internal es un modificador que equivale al modificador private de Java, por lo que lo cambiamos a public
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Obligatorio completar el nombre")]//Esto es para que el nombre sea obligatorio
        [MinLength(3, ErrorMessage ="El nombre deber tener un mínimo de 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Obligatorio completar el mail")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage ="Email no valido")]
        [Display(Name = "Email de casa")]//esto nos modifica el label
        public string Email { get; set; }
        public string Foto { get; set; }
        public Curso? CursoId { get; set; } // a ese campo le puedes o no asignar un valor por el ? es decir, permite el null.
    }
}
