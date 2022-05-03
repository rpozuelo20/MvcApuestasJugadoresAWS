using Microsoft.AspNetCore.Mvc;
using MvcApuestasJugadoresAWS.Models;
using MvcApuestasJugadoresAWS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasJugadoresAWS.Controllers
{
    public class ApuestasController : Controller
    {
        private RepositoryApuestas repo;
        public ApuestasController(RepositoryApuestas repo)
        {
            this.repo = repo;
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string usuario, int idequipolocal, int idequipovisitante, int golesequipolocal, int golesequipovisitante)
        {
            this.repo.InsertApuesta(usuario, idequipolocal, idequipovisitante, golesequipolocal, golesequipovisitante);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            List<Apuesta> apuestas = this.repo.GetApuestas();
            return View(apuestas);
        }
    }
}
