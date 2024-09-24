public class Pregunta
{
    public int Id { get; set; }
    public string Enunciado { get; set; }
    public int CategoriaId { get; set; }
    public int DificultadId { get; set; }

    public Pregunta(int id, string enunciado, int categoriaId, int dificultadId)
    {
        Id = id;
        Enunciado = enunciado;
        CategoriaId = categoriaId;
        DificultadId = dificultadId;
    }

    public Pregunta() { }
}
