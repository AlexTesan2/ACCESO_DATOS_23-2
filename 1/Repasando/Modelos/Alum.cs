//en el video es Alumno
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
	public class Alum
	{
        public int ID { get; set; }
		[Required(ErrorMessage ="Complete el nombre")]
		[Display(Name ="lo anterior al apellido ..")]
		public string Name { get; set; }
        public string Foto { get; set; }
		public Curso? CursoId { get; set; }
	}
}
