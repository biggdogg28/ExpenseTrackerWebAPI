using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;

namespace ExpenseTrackerWebAPI.Repositories

{
    public interface ITotalsRepository
    {
        public Task<IEnumerable<Totals>> GetTotalAsync();
        public Task<Totals> GetTotalByIdAsync(Guid id);
        public Task CreateTotalAsync(Totals totals);
        public Task<bool> DeleteTotalByIdAsync(Guid id);
        public Task<CreateUpdateTotals> UpdateTotalAsync(Guid id, CreateUpdateTotals totals);
        public Task<PatchTotals> UpdatePartiallyTotalAsync(Guid id, PatchTotals totals);
    }
}
