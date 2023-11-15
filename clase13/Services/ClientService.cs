using clase13.Data;
using clase13.Models;
using Microsoft.EntityFrameworkCore;

namespace clase13.Services;

public class ClientService : IClientService
{
    private readonly Clase13Context _context;
    public ClientService(Clase13Context context)
    {
        _context = context;
    } 

    public async Task Create(Client client)
    {
         _context.Add(client);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var client = await _context.Client.FindAsync(id);
        if (client != null)
        {
            _context.Client.Remove(client);
        }
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<Client>> GetAll(string filter)
    {
        var query = from client in _context.Client select client;
        // el include nos trae los elementos de las relaciones
        //query = query.Include(x=> x.Console);

        // si viene filtro del buscador de la vista filtramos los datos 
        if(!string.IsNullOrEmpty(filter))
        {
            query = query
                .Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }

        return await query.ToListAsync();
    }

    public async Task<Client?> GetById(int? id)
    {
        if (id == null || _context.Client == null)
        {
            return null;
        }

        return await _context.Client
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Update(Client client)
    {
        _context.Update(client);
        await _context.SaveChangesAsync();
    }
}