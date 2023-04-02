using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;

namespace ExpenseTrackerWebAPI.Repositories
{
    public interface IIncomeTypesRepository
    {
        public Task<IEnumerable<IncomeType>> GetIncomeTypeAsync();
        public Task<IncomeType> GetIncomeTypeByIdAsync(Guid id);
        public Task CreateIncomeTypeAsync(IncomeType incomeType);
        public Task<bool> DeleteIncomeTypeByIdAsync(Guid id);
        public Task<CreateUpdateIncomeType> UpdateIncomeTypeAsync(Guid id, CreateUpdateIncomeType incomeType);
        public Task<PatchIncomeType> UpdatePartiallyIncomeTypeAsync(Guid id, PatchIncomeType incomeType);
    }
}
