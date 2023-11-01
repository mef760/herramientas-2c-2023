using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clase7.Models;
using clase7.ViewModels;

namespace clase7.Controllers
{
    public class ConsoleController : Controller
    {
        private readonly VideoGameContext _context;

        public ConsoleController(VideoGameContext context)
        {
            _context = context;
        }

        // GET: Console
        public async Task<IActionResult> Index()
        {
              return _context.GameConsole != null ? 
                          View(await _context.GameConsole.ToListAsync()) :
                          Problem("Entity set 'VideoGameContext.GameConsole'  is null.");
        }

        // GET: Console/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameConsole == null)
            {
                return NotFound();
            }

            var gameConsole = await _context.GameConsole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameConsole == null)
            {
                return NotFound();
            }

            return View(gameConsole);
        }

        // GET: Console/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Console/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Company")] ConsoleVM gameConsoleInput)
        {
            if (ModelState.IsValid)
            {
                var console = new GameConsole {
                    Name = gameConsoleInput.Name,
                    Company = gameConsoleInput.Company,
                    Price = gameConsoleInput.Price
                };
                _context.Add(console);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameConsoleInput);
        }

        // GET: Console/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameConsole == null)
            {
                return NotFound();
            }

            var gameConsole = await _context.GameConsole.FindAsync(id);
            if (gameConsole == null)
            {
                return NotFound();
            }
            return View(gameConsole);
        }

        // POST: Console/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Company")] GameConsole gameConsole)
        {
            if (id != gameConsole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameConsole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameConsoleExists(gameConsole.Id))
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
            return View(gameConsole);
        }

        // GET: Console/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameConsole == null)
            {
                return NotFound();
            }

            var gameConsole = await _context.GameConsole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameConsole == null)
            {
                return NotFound();
            }

            return View(gameConsole);
        }

        // POST: Console/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameConsole == null)
            {
                return Problem("Entity set 'VideoGameContext.GameConsole'  is null.");
            }
            var gameConsole = await _context.GameConsole.FindAsync(id);
            if (gameConsole != null)
            {
                _context.GameConsole.Remove(gameConsole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameConsoleExists(int id)
        {
          return (_context.GameConsole?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
