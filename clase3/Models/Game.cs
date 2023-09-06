namespace clase3.Models;

public class Game
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string Gender { get; set; }
    public Clasification Clasif { get; set; }
    public bool IsMultiplayer { get; set; }
}

public enum Clasification{
    p3,
    p7,
    p12,
    p16,
    p18
}