using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IProvinciaRepositorio
    {
        public IEnumerable<ComunidadInformacion> GetInfoComunidad(Comunidad? comunidad);
        public IEnumerable<String> GetComunidades();
    }
}
