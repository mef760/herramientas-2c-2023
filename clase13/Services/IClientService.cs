using clase13.Models;

namespace clase13.Services;

public interface IClientService
{
    Task<List<Client>> GetAll(string filter);
    Task Update(Client client);
    Task Delete(int id);
    Task Create(Client client);
    Task<Client> GetById(int? id);
}