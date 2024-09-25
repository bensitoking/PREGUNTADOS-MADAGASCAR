public class Dificultad
{
    public int IdDificultad{ get; set; }
    public string Nombre { get; set; }

    public Dificultad(int idDificultad, string nombre)
    {
        IdDificultad = idDificultad;
        Nombre = nombre;
    }
    
    public Dificultad() { }
}
