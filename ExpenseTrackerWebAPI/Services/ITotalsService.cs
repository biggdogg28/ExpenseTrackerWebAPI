using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;

namespace ExpenseTrackerWebAPI.Services
{
    public interface ITotalsService
    {
        public Task<IEnumerable<Totals>> GetTotalAsync();
        public Task<Totals> GetTotalByIdAsync(Guid id);
        public Task CreateTotalAsync(Totals totals);
        public Task<bool> DeleteTotalByIdAsync(Guid id);
        public Task<CreateUpdateTotals> UpdateTotalAsync(Guid id, CreateUpdateTotals totals);
        public Task<PatchTotals> UpdatePartiallyTotalAsync(Guid id, PatchTotals totals);
    }
}
