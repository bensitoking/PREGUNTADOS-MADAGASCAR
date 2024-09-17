
public class Dificultad
{
    public int Id { get; set; }
    public string Nivel { get; set; }

    public Dificultad(int id, string nivel)
    {
        Id = id;
        Nivel = nivel;
    }
    public Dificultad()
    {
        
    }
}