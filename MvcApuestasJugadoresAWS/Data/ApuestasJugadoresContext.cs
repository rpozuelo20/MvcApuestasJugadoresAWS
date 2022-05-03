using Microsoft.EntityFrameworkCore;
using MvcApuestasJugadoresAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasJugadoresAWS.Data
{
    public class ApuestasJugadoresContext:DbContext
    {
        public ApuestasJugadoresContext(DbContextOptions<ApuestasJugadoresContext> options): base(options) { }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
    }
}
