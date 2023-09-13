using System.Runtime.ConstrainedExecution;

namespace clase4.Models;

public class GameListViewModel
{
    public string Name { get; set; }
    public int Release { get; set; }
    public int Age => DateTime.Now.Year - Release;
}
