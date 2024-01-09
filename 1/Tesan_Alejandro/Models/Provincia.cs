using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Provincia
    {
        [Key]
        public int codProvincia { get; set; }
        public string nomProvincia { get; set; }
        public int superficie { get; set; }
        public int numHabitantes { get; set; }
        public Comunidad codComunidad { get; set; }
}
}
