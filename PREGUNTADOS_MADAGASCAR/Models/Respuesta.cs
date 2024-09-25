public class Respuesta
{
    public int IdRespuesta { get; set; }
    public string Contenido { get; set; }
    public bool Correcta { get; set; }
    public int IdPregunta { get; set; }
    public int Opcion {get; set;}

    public Respuesta(int idRespuesta, string contenido, bool correcta, int idPregunta, int opcion)
    {
        IdRespuesta = idRespuesta;
        Contenido = contenido;
        Correcta = correcta;
        IdPregunta = idPregunta;
        Opcion = opcion;
    }

    public Respuesta() { }
}
