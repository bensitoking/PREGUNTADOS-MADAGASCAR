using Microsoft.AspNetCore.Mvc;
using Preguntados.Models;

namespace Preguntados.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConfigurarJuego()
        {
            ViewBag.Dificultades = Juego.ObtenerDificultades();
            ViewBag.Categorias = Juego.ObtenerCategorias();
            return View();
        }

        public IActionResult Comenzar(string username, int dificultad, int categoria)
        {
            if (string.IsNullOrEmpty(username) || dificultad < -1 || categoria < -1)
            {
                TempData["Error"] = "Parámetros inválidos. Intente de nuevo.";
                return RedirectToAction("ConfigurarJuego");
            }
            Juego.CargarPartida(username, dificultad, categoria);
            return RedirectToAction("Jugar");
        }

        public IActionResult Jugar()
        {
            var pregunta = Juego.ObtenerProximaPregunta();
            if (pregunta == null)
            {
                ViewBag.Username = Juego.username;
                ViewBag.Puntaje = Juego.puntajeActual;
                return View("Fin");
            }

            ViewBag.Pregunta = pregunta;
            ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(pregunta.IdPregunta);
            return View("JuegoView");
        }

        [HttpPost]
        public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
        {
            bool Correcta = Juego.VerificarRespuesta(idRespuesta);
            ViewBag.Correcta = Correcta;
            ViewBag.RespuestaCorrecta = Juego.obtenerRespuestaCorrecta(idPregunta);
            return View("Respuesta");
        }
    }
}
