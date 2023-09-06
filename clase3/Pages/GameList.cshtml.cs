using clase3.Models;
using clase3.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace clase3.Pages
{
    public class GameListModel : PageModel
    {
        public List<Game> Games { get; set; } = new List<Game>();
        [BindProperty]
        public Game NewGame { get; set; }
        
        public void OnGet()
        {
            Games = GameService.GetAll();
        }

        public IActionResult OnPost()
        {
            var newObject = NewGame;
            GameService.Create(newObject);

            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(string name)
        {
            GameService.Delete(name);
            return RedirectToAction("Get");
        }
    }
}
