using Microsoft.AspNetCore.Mvc;
using MvcApuestasJugadoresAWS.Models;
using MvcApuestasJugadoresAWS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasJugadoresAWS.Controllers
{
    public class EquiposController : Controller
    {
        private RepositoryEquipos repo;
        public EquiposController(RepositoryEquipos repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
        }
    }
}
