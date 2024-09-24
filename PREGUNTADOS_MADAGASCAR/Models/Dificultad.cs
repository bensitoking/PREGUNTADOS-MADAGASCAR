public class Dificultad
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Dificultad(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
    
    public Dificultad() { }
}
