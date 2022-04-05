using FormClean.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormClean.Domain.Interfaces
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetAllClients();

        public Task<Client> GetClientById(int? id);

        public Task<Client> CreateAsync(Client client);

        public Task<Client> UpdateAsync(Client client);

        public Task<Client> DeleteAsync(Client client);
    }
}
