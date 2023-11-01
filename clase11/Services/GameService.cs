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

    public async Task<string> Purchase(Movement movement)
    {
        return await CreateMovement(movement);
    }

    public async Task<string> Sale(Movement movement)
    {
        return await CreateMovement(movement);
    }

    private async Task<string> CreateMovement(Movement movement)
    {
        var stock = movement.Quantity;
        var game = await _context.Game.FirstOrDefaultAsync(m => m.Id == movement.GameId);
        if (movement.TypeM == Utils.MovementType.sale)
        {
            stock*= -1;
            if ((game.Stock + stock) < 0){
                return "No hay stock disponible para " + game.Name;
            }
        }

        if (game is null)
        {
            return "El juego no existe";
        }  

        game.Stock += stock;
        _context.Update(game);
        _context.Add(movement);
        await _context.SaveChangesAsync();

        return string.Empty;
    }
}