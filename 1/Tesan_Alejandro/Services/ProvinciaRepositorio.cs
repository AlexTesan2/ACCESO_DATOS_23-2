using Models;

namespace Services
{
    public class ProvinciaRepositorio : IProvinciaRepositorio
    {

        private readonly GeografiaDBContext context;
        public List<string> loista;
        public ProvinciaRepositorio(GeografiaDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<string> GetComunidades()
        {
            loista = new List<string>();
            
            return loista;
        }


        //de cada Comunidad, su superficie total, el número total de habitantes y el número de provincias que tiene

        public IEnumerable<ComunidadInformacion> GetInfoComunidad(Comunidad? comunidad)
        {
            IEnumerable<Provincia> consulta = context.Provincias;
            if (comunidad.HasValue)
            {
                consulta = consulta.Where(a => a.codComunidad == comunidad).ToList();
            }

            return consulta.GroupBy(a => a.codComunidad)
                .Select(g => new ComunidadInformacion()
                {
                    Com = g.Key,
                    superficie = g.Sum(p => p.superficie),
                    numHabitantes = g.Sum(p => p.numHabitantes),
                    numProvincias = g.Count()
                }).ToList();

        }


    }
}
