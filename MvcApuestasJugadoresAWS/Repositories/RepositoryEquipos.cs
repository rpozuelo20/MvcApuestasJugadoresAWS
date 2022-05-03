using MvcApuestasJugadoresAWS.Data;
using MvcApuestasJugadoresAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasJugadoresAWS.Repositories
{
    public class RepositoryEquipos
    {
        private ApuestasJugadoresContext context;
        public RepositoryEquipos(ApuestasJugadoresContext context)
        {
            this.context = context;
        }


        public List<Equipo> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }
    }
}
