using FormClean.Domain.Entities;
using FormClean.Domain.Interfaces;
using FormClean.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormClean.Infra.Data.Repositories
{
    public class DemandedRepository : IDemandedRepository
    {
        private readonly ApplicationDbContext _demandedContext;

        public DemandedRepository(ApplicationDbContext demandedContext)
        {
            _demandedContext = demandedContext;
        }
        public async Task<IEnumerable<Demanded>> GetAllDemandeds()
        {
            var demandeds = await _demandedContext.Demandeds.ToListAsync();
            return demandeds;
        }

        public async Task<Demanded> GetDemandedById(int? id)
        {
            var getById = await _demandedContext.Demandeds.FindAsync(id);
            return getById;
        }

        public async Task<Demanded> CreateAsync(Demanded demanded)
        {
            _demandedContext.Add(demanded);
            await _demandedContext.SaveChangesAsync();
            return demanded;
        }

        public async Task<Demanded> UpdateAsync(Demanded demanded)
        {
            _demandedContext.Update(demanded);
            await _demandedContext.SaveChangesAsync();
            return demanded;
        }
        public async Task<Demanded> DeleteAsync(Demanded demanded)
        {
            _demandedContext.Remove(demanded);
            await _demandedContext.SaveChangesAsync();
            return demanded;
        }
    }
}
