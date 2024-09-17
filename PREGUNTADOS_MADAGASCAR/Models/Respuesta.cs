public class Respuesta
{
    public int Id { get; set; }
    public string Texto { get; set; }
    public bool EsCorrecta { get; set; }
    public int PreguntaId { get; set; }

    public Respuesta(int id, string texto, bool esCorrecta, int preguntaId)
    {
        Id = id;
        Texto = texto;
        EsCorrecta = esCorrecta;
        PreguntaId = preguntaId;
    }
    public Respuesta()
    {
        
    }
}