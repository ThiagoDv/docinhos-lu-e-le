using FormClean.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormClean.Domain.Interfaces
{
    public interface IDemandedRepository
    {
        public Task<IEnumerable<Demanded>> GetAllDemandeds();

        public Task<Demanded> GetDemandedById(int? id);

        public Task<Demanded> CreateAsync(Demanded client);

        public Task<Demanded> UpdateAsync(Demanded client);

        public Task<Demanded> DeleteAsync(Demanded client);
    }
}
