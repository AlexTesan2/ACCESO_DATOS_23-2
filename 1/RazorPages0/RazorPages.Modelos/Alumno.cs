using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPages.Modelos
{
    public class Alumno
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Obligtoriocompletar el nombre")]
        [MinLength(3,ErrorMessage ="minimo tres caracteres")]
        [RegularExpression(@"az-Az0-9")]
        public string Nombre { get; set; }
		[Required(ErrorMessage = "Obligtoriocompletar el nombre")]
		[RegularExpression(@"az-Az0-9")]
        [Display(Name ="email de casa")]
		public string Email { get; set; }
        public string Foto { get; set; }
        public Curso? CursoID { get; set; }
    }
}
