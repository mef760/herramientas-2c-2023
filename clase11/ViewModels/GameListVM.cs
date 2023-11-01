namespace clase7.ViewModels;

public class GameListVM
{
    public List<GameVM> Games { get; set; } = new List<GameVM>();
    public string? Filter { get; set; }
}