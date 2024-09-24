using System.Data.SqlClient;
using Dapper;

namespace Preguntados.Models
{
    public static class Juego
    {
        public static string username { get; set; }
        public static int puntajeActual { get; set; }
        public static int contadorPreguntaActual { get; set; }
        private static int cantidadPreguntasCorrectas { get; set; }
        public static Pregunta PreguntaActual { get; set; }
        public static List<Pregunta> ListaPreguntas { get; set; }
        public static List<Respuesta> ListaRespuestas { get; set; }

        public static void InicializarJuego()
        {
            username = "";
            puntajeActual = 0;
            cantidadPreguntasCorrectas = 0;
            contadorPreguntaActual = 0;
            PreguntaActual = null;
            ListaPreguntas = new List<Pregunta>();
            ListaRespuestas = new List<Respuesta>();
        }

        public static List<Categoria> ObtenerCategorias()
        {
            return BD.ObtenerCategorias();
        }

        public static List<Dificultad> ObtenerDificultades()
        {
            return BD.ObtenerDificultades();
        }

        public static void CargarPartida(string userName, int dificultad, int categoria)
        {
            InicializarJuego();
            username = userName;
            ListaPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
        }

        public static Pregunta ObtenerProximaPregunta()
        {
            if (ListaPreguntas.Count > contadorPreguntaActual)
            {
                PreguntaActual = ListaPreguntas[contadorPreguntaActual];
                contadorPreguntaActual++;
                return PreguntaActual;
            }
            return null;
        }

        public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
        {
            ListaRespuestas = BD.ObtenerRespuestas(idPregunta);
            return ListaRespuestas;
        }

        public static bool VerificarRespuesta(int idRespuesta)
        {
            var respuesta = ListaRespuestas.FirstOrDefault(r => r.Id == idRespuesta);
            if (respuesta != null && respuesta.Correcta)
            {
                puntajeActual += 5;
                cantidadPreguntasCorrectas++;
                return true;
            }
            contadorPreguntaActual++;
            return false;
        }
    }
}
