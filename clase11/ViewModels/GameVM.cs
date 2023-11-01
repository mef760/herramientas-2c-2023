using System.ComponentModel.DataAnnotations;

namespace clase7.ViewModels;

public class GameVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Release { get; set; }
    public string Gender { get; set; }
    public string Company { get; set; }
    public string Image { get; set; }
    [Display(Name = "Consola")]
    public string? ConsoleName { get; set; }
    public int Stock { get; set; }
}