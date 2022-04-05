using AutoMapper;
using FormClean.Application.DTOs;
using FormClean.Application.Interfaces;
using FormClean.Domain.Entities;
using FormClean.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormClean.Application.Services
{
    public class DemandedService : IDemandedService
    {
        private readonly IDemandedRepository _demandedRepository;
        private readonly IMapper _mapper;

        public DemandedService(IDemandedRepository demandedRepository, IMapper mapper)
        {
            _demandedRepository = demandedRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DemandedDTO>> GetAllDemandeds()
        {
            var demanded = await _demandedRepository.GetAllDemandeds();
            return _mapper.Map<IEnumerable<DemandedDTO>>(demanded);
        }

        public async Task<DemandedDTO> GetDemandedsById(int? id)
        {
            var demanded = await _demandedRepository.GetDemandedById(id);
            return _mapper.Map<DemandedDTO>(demanded);
        }

        public async Task Create(DemandedDTO demandedDto)
        {
            var demanded = _mapper.Map<Demanded>(demandedDto);
            await _demandedRepository.CreateAsync(demanded);
        }

        public async Task Update(DemandedDTO demandedDto)
        {
            var demanded = _mapper.Map<Demanded>(demandedDto);
            await _demandedRepository.UpdateAsync(demanded);
        }

        public async Task Delete(int? id)
        {
            var demanded = _demandedRepository.GetDemandedById(id).Result;
            await _demandedRepository.DeleteAsync(demanded);
        }
    }
}
