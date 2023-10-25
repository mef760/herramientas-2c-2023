using clase7.Models;

namespace clase7.Services;

public interface IGameService
{
    Task<List<Game>> GetAll(string filter);
    Task Update(Game game);
    Task Delete(int id);
    Task Create(Game game);
    Task<Game> GetById(int? id);
    Task<List<GameConsole>> GetAllConsoles();
}