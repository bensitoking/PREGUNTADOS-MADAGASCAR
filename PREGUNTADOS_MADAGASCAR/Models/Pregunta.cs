public class Pregunta
{
    public int IdPregunta { get; set; }
    public string Enunciado { get; set; }
    public int IdCategoria { get; set; }
    public int IdDificultad { get; set; }

    public Pregunta(int Idpregunta, string enunciado, int idCategoria, int idDificultad)
    {
        IdPregunta = Idpregunta;
        Enunciado = enunciado;
        IdCategoria = idCategoria;
        IdDificultad = idDificultad;
    }

    public Pregunta() { }
}
