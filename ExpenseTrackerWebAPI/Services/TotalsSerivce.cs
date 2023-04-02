using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.Repositories;

namespace ExpenseTrackerWebAPI.Services
{
    public class TotalsSerivce
    {
        private readonly ITotalsRepository _totalsRepository;
        public TotalsSerivce(ITotalsRepository totalsRepository)
        {
            _totalsRepository = totalsRepository;
        }

        public async Task<IEnumerable<Totals>> GetTotalsAsync()
        {
            return await _totalsRepository.GetTotalAsync();
        }

        public async Task<Totals> GetTotalByIdAsync(Guid id)
        {
            return await _totalsRepository.GetTotalByIdAsync(id);
        }

        public async Task CreateTotalAsync(Totals newTotal)
        {
            //validation is added to the business layer (Services)
            // no need for validation for 2 entries on the table

            await _totalsRepository.CreateTotalAsync(newTotal);
        }
        public async Task<bool> DeleteTotalByIdAsync(Guid id)
        {
            return await _totalsRepository.DeleteTotalByIdAsync(id);
        }

        public async Task<CreateUpdateTotals> UpdateTotalAsync(Guid id, CreateUpdateTotals total)
        {
            return await _totalsRepository.UpdateTotalAsync(id, total);
        }

        public async Task<PatchTotals> UpdatePartiallyTotalAsync(Guid id, PatchTotals total)
        {
            return await _totalsRepository.UpdatePartiallyTotalAsync(id, total);
        }
    }
}
