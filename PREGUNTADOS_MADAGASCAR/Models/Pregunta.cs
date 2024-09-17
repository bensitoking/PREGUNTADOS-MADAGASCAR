public class Pregunta
{
    public int Id { get; set; }
    public string Texto { get; set; }
    public int CategoriaId { get; set; }
    public int DificultadId { get; set; }

    public Pregunta(int id, string texto, int categoriaId, int dificultadId)
    {
        Id = id;
        Texto = texto;
        CategoriaId = categoriaId;
        DificultadId = dificultadId;
    }
    public Pregunta()
    {
        
    }
}