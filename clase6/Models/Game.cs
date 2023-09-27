namespace clase5.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Release { get; set; }
    public string Gender { get; set; }
    public bool IsMultiplayer { get; set; }
    public decimal Price { get; set; }
    public string Company { get; set; }
    public string Image { get; set; }

    public int? GameConsoleId { get; set; }
}
