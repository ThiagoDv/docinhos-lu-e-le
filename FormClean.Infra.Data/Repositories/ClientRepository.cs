using FormClean.Domain.Entities;
using FormClean.Domain.Interfaces;
using FormClean.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormClean.Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _clientContext;

        public ClientRepository(ApplicationDbContext clientContext)
        {
            _clientContext = clientContext;
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var clients = await _clientContext.Clients.ToListAsync();
            return clients;
        }

        public async Task<Client> GetClientById(int? id)
        {
            var getById = await _clientContext.Clients.FindAsync(id);
            return getById;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            _clientContext.Add(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _clientContext.Update(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> DeleteAsync(Client client)
        {
            _clientContext.Remove(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }
    }
}
