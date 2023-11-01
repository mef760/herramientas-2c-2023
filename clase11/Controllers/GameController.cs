using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clase7.Models;
using clase7.ViewModels;
using clase7.Services;

namespace clase7.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: Game
        public async Task<IActionResult> Index(string filter)
        { 
            var gameListVM = new GameListVM();
            var gameList = await _gameService.GetAll(filter);
            // Mapeamos la entidad con el view model para enviar a la vista
            foreach (var item in gameList)
            {
                gameListVM.Games.Add(new GameVM {
                    Id = item.Id,
                    Name = item.Name,
                    Company = item.Company,
                    Gender = item.Gender,
                    Release = item.Release,
                    Image = item.Image,
                    Stock = item.Stock
                });
            }

            return View(gameListVM);
        }

        // GET: Game/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var game = await _gameService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Game/Create
        public async Task<IActionResult> Create()
        {
            var consoleList = await _gameService.GetAllConsoles();
            if (consoleList == null) consoleList = new List<GameConsole>();
            ViewData["Consoles"] = new SelectList(consoleList, "Id", "Name");
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Release,Gender,IsMultiplayer,Price,Company,Image,ConsoleIds")] GameCreateVM game)
        {
            if (ModelState.IsValid)
            {
                var consoleList = await _gameService.GetAllConsoles();
                var consoleFilteredList = consoleList.Where(x=> game.ConsoleIds.Contains(x.Id)).ToList();
                var newGame = new Game {
                    Name = game.Name,
                    Gender = game.Gender,
                    Price = game.Price,
                    IsMultiplayer = game.IsMultiplayer,
                    Image = game.Image,
                    Company = game.Company,
                    Release = game.Release,
                    Consoles = consoleFilteredList
                };
                await _gameService.Create(newGame);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Game/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var game = await _gameService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Release,Gender,IsMultiplayer,Price,Company,Image,GameConsoleId")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _gameService.Update(game);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_gameService.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Game/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var game = await _gameService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gameService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Game/Purchase
        public async Task<IActionResult> Purchase(int id)
        {
            var game = await _gameService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            ViewData["Game"] = game;

            return View();
        }

        // POST: Game/Purchase
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase([Bind("GameId,Date,Quantity,InvoiceNumber")] MovementCreateVM purchase)
        {
            if (ModelState.IsValid)
            {
                var newPurchase = new Movement {
                    GameId = purchase.GameId,
                    Quantity = purchase.Quantity,
                    InvoiceNumber = purchase.InvoiceNumber,
                    Date = purchase.Date,
                    TypeM = Utils.MovementType.purchase
                };
                await _gameService.Purchase(newPurchase);
                return RedirectToAction(nameof(Index));
            }
            return View(purchase);
        }

        // GET: Game/Sale
        public async Task<IActionResult> Sale(int id)
        {
            var game = await _gameService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }

            ViewData["Game"] = game;

            return View();
        }

        // POST: Game/Sale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sale([Bind("GameId,Date,Quantity,InvoiceNumber")] MovementCreateVM sale)
        {
            if (ModelState.IsValid)
            {
                var newSale = new Movement {
                    GameId = sale.GameId,
                    Quantity = sale.Quantity,
                    InvoiceNumber = sale.InvoiceNumber,
                    Date = sale.Date,
                    TypeM = Utils.MovementType.sale
                };
                var response = await _gameService.Sale(newSale);

                if (string.IsNullOrEmpty(response))
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMsg"] = response;
            }
            return View(sale);
        }
    }
}
