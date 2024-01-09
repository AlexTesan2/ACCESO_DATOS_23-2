using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Services
{
    public class EquipoRepositorio : IEquipoRepositorio
	{
        private readonly FutbolDbContext context;

        public EquipoRepositorio(FutbolDbContext context)
        { 
            this.context = context;
		
		}
        public IEnumerable<Equipo> GetAllEquipos()
        {
            return context.Equipos.FromSqlRaw<Equipo>("SELECT * FROM Equipos").ToList();
        }
        public Equipo GetEquipoById(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);

            return context.Equipos.Find(id);
        }
        public void Add(Equipo equipoNuevo)
        {
            var cosa = context.Equipos.Max(a => a.Id);
            context.Equipos.Add(equipoNuevo);
            context.SaveChanges();

            return;
        }

        public Equipo Delete(int idBorrar)
        {
            Equipo equipoBorrar = context.Equipos.Find(idBorrar);
            if (equipoBorrar != null)
            {
                context.Equipos.Remove(equipoBorrar);
                context.SaveChanges();
            }
            return equipoBorrar;
        }

        public void Update(Equipo equipoActualizado)
        {
            var equipo = context.Equipos.Attach(equipoActualizado);
            equipo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;//en lugar de guardar cambios
            context.SaveChanges();
        }

        public IEnumerable<CategoriaCuantos> EquiposPorCategoria(Categoria? categoria)
        {
            IEnumerable<Equipo> consulta = context.Equipos;
            if (categoria.HasValue)
            {
                consulta = consulta.Where(e => e.categoria == categoria).ToList();
            }

            return consulta.GroupBy(e => e.categoria)
                .Select(g => new CategoriaCuantos()//g es por el aGrupamiento
                {
                    Categoria = g.Key,
                    NumEquipos = g.Count()
                }).ToList();//el resultado lo convertimos en lista

        }

		public IEnumerable<Equipo> Busqueda(string elementoABuscar)
		{
            if (string.IsNullOrEmpty(elementoABuscar))
            { 
                return context.Equipos.FromSqlRaw<Equipo>("Select * from Equipos").ToList();
            }
			return context.Equipos.FromSqlRaw<Equipo>("Select * from Equipos").ToList().
                Where(a => a.nomEquipo.Contains(elementoABuscar));
		}
	}
}

