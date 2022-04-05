using FormClean.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormClean.Application.Interfaces
{
    public interface IDemandedService
    {
        public Task<IEnumerable<DemandedDTO>> GetAllDemandeds();

        public Task<DemandedDTO> GetDemandedsById(int? id);

        public Task Create(DemandedDTO demandedDto);

        public Task Update(DemandedDTO demandedDto);

        public Task Delete(int? id);
    }
}
