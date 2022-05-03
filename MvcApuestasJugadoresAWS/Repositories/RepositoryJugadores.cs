using MvcApuestasJugadoresAWS.Data;
using MvcApuestasJugadoresAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasJugadoresAWS.Repositories
{
    public class RepositoryJugadores
    {
        private ApuestasJugadoresContext context;
        public RepositoryJugadores(ApuestasJugadoresContext context)
        {
            this.context = context;
        }


        private int GetMaxIdJugador()
        {
            if (this.context.Jugadores.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Jugadores.Max(z => z.IdJugador) + 1;
            }
        }

        public void InsertJugador(string nombre, string posicion, string imagen, int idequipo)
        {
            Jugador j = new Jugador
            {
                IdJugador = GetMaxIdJugador(),
                Nombre = nombre,
                Posicion = posicion,
                Imagen = imagen,
                IdEquipo = idequipo
            };
            this.context.Jugadores.Add(j);
            this.context.SaveChanges();
        }
        public List<Jugador> GetJugadores()
        {
            return this.context.Jugadores.ToList();
        }
    }
}
