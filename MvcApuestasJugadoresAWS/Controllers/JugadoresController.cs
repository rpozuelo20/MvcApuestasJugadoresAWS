using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcApuestasJugadoresAWS.Models;
using MvcApuestasJugadoresAWS.Repositories;
using MvcApuestasJugadoresAWS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApuestasJugadoresAWS.Controllers
{
    public class JugadoresController : Controller
    {
        private RepositoryJugadores repo;
        private ServiceAWSS3 service;
        public JugadoresController(RepositoryJugadores repo, ServiceAWSS3 service)
        {
            this.repo = repo;
            this.service = service;
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string posicion, IFormFile imagen, int idequipo)
        {
            using (Stream stream = imagen.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, imagen.FileName);
            }
            this.repo.InsertJugador(nombre, posicion, imagen.FileName, idequipo);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            List<Jugador> jugadores = this.repo.GetJugadores();
            return View(jugadores);
        }
    }
}
