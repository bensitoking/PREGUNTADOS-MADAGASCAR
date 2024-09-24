public class Respuesta
{
    public int Id { get; set; }
    public string Contenido { get; set; }
    public bool Correcta { get; set; }
    public int PreguntaId { get; set; }
    public int Opcion {get; set;}

    public Respuesta(int id, string contenido, bool correcta, int preguntaId, int opcion)
    {
        Id = id;
        Contenido = contenido;
        Correcta = correcta;
        PreguntaId = preguntaId;
        Opcion = opcion;
    }

    public Respuesta() { }
}
