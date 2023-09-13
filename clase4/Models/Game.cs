using System.Runtime.ConstrainedExecution;

namespace clase4.Models;

public class Game
{
    public string Name { get; set; }
    public int Release { get; set; }
    public string Gender { get; set; }
    public bool IsMultiplayer { get; set; }
    public decimal Price { get; set; }
}
