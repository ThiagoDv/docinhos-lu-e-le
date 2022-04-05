using FormClean.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormClean.Application.Interfaces
{
    public interface IClientService
    { 
        public Task<IEnumerable<ClientDTO>> GetAllClients();

        public Task<ClientDTO> GetClientById(int? id);

        public Task Create(ClientDTO client);

        public Task Update(ClientDTO client);

        public Task Delete(int? id);
    }
}
