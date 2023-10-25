using System.ComponentModel.DataAnnotations;

namespace clase7.ViewModels;

public class GameCreateVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Release { get; set; }
    public string Gender { get; set; }
    public string Company { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    public bool IsMultiplayer { get; set; }
    [Display(Name = "Consola")]
    public List<int> ConsoleIds { get; set; }
}