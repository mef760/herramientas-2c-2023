using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using clase4.Models;
using clase3.Services;

namespace clase4.Controllers;

public class VideoGameController : Controller
{
    private readonly ILogger<VideoGameController> _logger;

    public VideoGameController(ILogger<VideoGameController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var gamelist = GameService.GetAll();
        var gamelistViewModel = new List<GameListViewModel>();

        foreach(var item in gamelist)
        {
            gamelistViewModel.Add(new GameListViewModel{ Name = item.Name, Release = item.Release });
        }

        return View(gamelistViewModel);
    }

    public IActionResult NewGame()
    {
        return View();
    }
}
