using clase7.Models;
using Microsoft.EntityFrameworkCore;

namespace clase7.Services;

public class GameService : IGameService
{
    private readonly VideoGameContext _context;
    public GameService(VideoGameContext context)
    {
        _context = context;
    } 

    public async Task Create(Game game)
    {
         _context.Add(game);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var game = await _context.Game.FindAsync(id);
        if (game != null)
        {
            _context.Game.Remove(game);
        }
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<Game>> GetAll(string filter)
    {
        var query = from game in _context.Game select game;
        // el include nos trae los elementos de las relaciones
        //query = query.Include(x=> x.Console);

        // si viene filtro del buscador de la vista filtramos los datos 
        if(!string.IsNullOrEmpty(filter))
        {
            query = query
                .Where(x => x.Name.ToLower().Contains(filter.ToLower()) || 
                            x.Company.ToLower().Contains(filter.ToLower()));
        }

        return await query.ToListAsync();
    }

    public async Task<List<GameConsole>> GetAllConsoles()
    {
        return await _context.GameConsole.ToListAsync();
    }

    public async Task<Game?> GetById(int? id)
    {
        if (id == null || _context.Game == null)
        {
            return null;
        }

        return await _context.Game
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Update(Game game)
    {
        _context.Update(game);
        await _context.SaveChangesAsync();
    }
}