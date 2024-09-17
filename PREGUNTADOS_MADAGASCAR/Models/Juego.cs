public static class Juego
{
    public static string username;
    public static int PuntajeActual;
    private static int CantidadPreguntasCorrectas;
    private static int ContadorNroPreguntaActual;
    private static Pregunta PreguntaActual;
    private static List<Pregunta> ListaPreguntas;
    private static List<Respuesta> ListaRespuestas;

    private static void InicializarJuego()
    {
        username = string.Empty;
        PuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
        ContadorNroPreguntaActual = 0;
        PreguntaActual = null;
        ListaPreguntas = null;
        ListaRespuestas = null;
    }
    public static List<Categoria> ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }

    public static List<Dificultad> ObtenerDificultades()
    {
        return BD.ObtenerDificultades();
    }

    public static void CargarPartida(string usernameIngresado, int dificultad, int categoria)
    {
        InicializarJuego();
        username = usernameIngresado;
        ListaPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
        ContadorNroPreguntaActual = 0;

        if (ListaPreguntas != null && ListaPreguntas.Count > 0)
        {
            PreguntaActual = ListaPreguntas[0];
            ListaRespuestas = BD.ObtenerRespuestas(new List<Pregunta> { PreguntaActual });
        }
    }

    public static Pregunta ObtenerProximaPregunta()
    {
        if (ContadorNroPreguntaActual < ListaPreguntas.Count)
        {
            PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
            ListaRespuestas = BD.ObtenerRespuestas(new List<Pregunta> { PreguntaActual });
            return PreguntaActual;
        }
        return null; 
    }

    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
    {
        return ListaRespuestas;
    }

    public static bool VerificarRespuesta(int idRespuesta)
    {
        Respuesta respuestaElegida = ListaRespuestas.FirstOrDefault(r => r.Id == idRespuesta);

        if (respuestaElegida != null && respuestaElegida.EsCorrecta)
        {
            PuntajeActual += 10; 
            CantidadPreguntasCorrectas++;
            IncrementarPregunta();
            return true;
        }

        IncrementarPregunta();
        return false;
    }

    private static void IncrementarPregunta()
    {
        ContadorNroPreguntaActual++;
        if (ContadorNroPreguntaActual < ListaPreguntas.Count)
        {
            PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
            ListaRespuestas = BD.ObtenerRespuestas(new List<Pregunta> { PreguntaActual });
        }
        else
        {
            PreguntaActual = null; 
        }
    }
}
