using Microsoft.AspNetCore.Mvc;
using PREGUNTADOS_MADAGASCAR.Models;

namespace PREGUNTADOS_MADAGASCAR.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

            public IActionResult Respuesta()
        {
            return View();
        }
        public IActionResult JuegoView()
        {
            return View();
        }

        public IActionResult ConfigurarJuego()
        {
            ViewBag.Categorias = Juego.ObtenerCategorias();
            ViewBag.Dificultades = Juego.ObtenerDificultades();
            return View();
        }

        public IActionResult Comenzar(string username, int dificultad, int categoria)
        {
            Juego.CargarPartida(username, dificultad, categoria);
            return RedirectToAction("Jugar");
        }


        public IActionResult Jugar()
        {
            Pregunta pregunta = Juego.ObtenerProximaPregunta();
            if (pregunta == null)
            {
                return RedirectToAction("Fin");
            }

            ViewBag.Pregunta = pregunta;
            ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(pregunta.Id);
            ViewBag.Username = Juego.username;
            ViewBag.Puntaje = Juego.PuntajeActual;
            return RedirectToAction("JuegoView");
        }

        [HttpPost]
        public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
        {
            bool esCorrecta = Juego.VerificarRespuesta(idRespuesta);
            ViewBag.EsCorrecta = esCorrecta;
            ViewBag.RespuestaCorrecta = Juego.ObtenerProximasRespuestas(idPregunta).FirstOrDefault(r => r.EsCorrecta)?.Texto;

            if (Juego.ObtenerProximaPregunta() == null)
            {
                return RedirectToAction("Fin");
            }

            return RedirectToAction("Respuesta");
        }

        public IActionResult Fin()
        {
            ViewBag.Username = Juego.username;
            ViewBag.PuntajeFinal = Juego.PuntajeActual;
            return View();
        }
    }
}
