using MvcApuestasJugadoresAWS.Data;
using MvcApuestasJugadoresAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasJugadoresAWS.Repositories
{
    public class RepositoryApuestas
    {
        private ApuestasJugadoresContext context;
        public RepositoryApuestas(ApuestasJugadoresContext context)
        {
            this.context = context;
        }


        private int GetMaxIdApuesta()
        {
            if (this.context.Apuestas.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Apuestas.Max(z => z.IdApuesta) + 1;
            }
        }
        public void InsertApuesta(string usuario, int idequipolocal, int idequipovisitante, int golesequipolocal, int golesequipovisitante)
        {
            Apuesta a = new Apuesta
            {
                IdApuesta=GetMaxIdApuesta(),
                Usuario=usuario,
                IdEquipoLocal=idequipolocal,
                IdEquipoVisitante=idequipovisitante,
                GolesEquipoLocal=golesequipolocal,
                GolesEquipoVisitante=golesequipovisitante
            };
            this.context.Apuestas.Add(a);
            this.context.SaveChanges();
        }
        public List<Apuesta> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }
    }
}
