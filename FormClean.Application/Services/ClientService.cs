using AutoMapper;
using FormClean.Application.DTOs;
using FormClean.Application.Interfaces;
using FormClean.Domain.Entities;
using FormClean.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormClean.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDTO>> GetAllClients()
        {
            var client = await _clientRepository.GetAllClients();
            return _mapper.Map<IEnumerable<ClientDTO>>(client);
        }

        public async Task<ClientDTO> GetClientById(int? id)
        {
            var client = await _clientRepository.GetClientById(id);
            return _mapper.Map<ClientDTO>(client);
        }

        public async Task Create(ClientDTO clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientRepository.CreateAsync(client);
        }

        public async Task Update(ClientDTO clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientRepository.UpdateAsync(client);
        }

        public async Task Delete(int? id)
        {
            var client = _clientRepository.GetClientById(id).Result;
            await _clientRepository.DeleteAsync(client);
        }
    }
}
