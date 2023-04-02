using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;

namespace ExpenseTrackerWebAPI.Services
{
    public interface IIncomeTypesService
    {
        public Task<IEnumerable<IncomeType>> GetIncomeTypeAsync();
        public Task<IncomeType> GetIncomeTypeByIdAsync(Guid id);
        public Task CreateIncomeTypeAsync(IncomeType incomeType);
        public Task<bool> DeleteIncomeTypeByIdAsync(Guid id);
        public Task<CreateUpdateIncomeType> UpdateIncomeTypeAsync(Guid id, CreateUpdateIncomeType incomeType);
        public Task<PatchIncomeType> UpdatePartiallyIncomeTypeAsync(Guid id, PatchIncomeType incomeType);
    }
}
