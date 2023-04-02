using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;

namespace ExpenseTrackerWebAPI.Services
{
    public interface IIncomesService
    {
        public Task<IEnumerable<Income>> GetIncomeAsync();
        public Task<Income> GetIncomeByIdAsync(Guid id);
        public Task CreateIncomeAsync(Income income);
        public Task<bool> DeleteIncomeByIdAsync(Guid id);
        public Task<CreateUpdateIncome> UpdateIncomeAsync(Guid id, CreateUpdateIncome income);
        public Task<PatchIncome> UpdatePartiallyIncomeAsync(Guid id, PatchIncome income);
    }
}
