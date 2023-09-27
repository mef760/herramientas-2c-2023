namespace clase5.Models;

public class GameConsole
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Company { get; set; }

    public virtual ICollection<Game> Games { get; set; }
}