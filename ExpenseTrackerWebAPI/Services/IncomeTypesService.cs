using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.Repositories;

namespace ExpenseTrackerWebAPI.Services
{
    public class IncomeTypesService : IIncomeTypesService
    {
        private readonly IIncomeTypesRepository _incomeTypesRepository;
        public IncomeTypesService(IIncomeTypesRepository incomeTypesRepository)
        {
            _incomeTypesRepository = incomeTypesRepository;
        }

        public async Task<IEnumerable<IncomeType>> GetIncomeTypeAsync()
        {
            return await _incomeTypesRepository.GetIncomeTypeAsync();
        }

        public async Task<IncomeType> GetIncomeTypeByIdAsync(Guid id)
        {
            return await _incomeTypesRepository.GetIncomeTypeByIdAsync(id);
        }

        public async Task CreateIncomeTypeAsync(IncomeType newIncomeType)
        {
            //validation is added to the business layer (Services)
            // no need for validation for 2 entries on the table

            await _incomeTypesRepository.CreateIncomeTypeAsync(newIncomeType);
        }

        public async Task<bool> DeleteIncomeTypeByIdAsync(Guid id)
        {
            return await _incomeTypesRepository.DeleteIncomeTypeByIdAsync(id);
        }

        public async Task<CreateUpdateIncomeType> UpdateIncomeTypeAsync(Guid id, CreateUpdateIncomeType incomeType)
        {
            return await _incomeTypesRepository.UpdateIncomeTypeAsync(id, incomeType);
        }

        public async Task<PatchIncomeType> UpdatePartiallyIncomeTypeAsync(Guid id, PatchIncomeType incomeType)
        {
            return await _incomeTypesRepository.UpdatePartiallyIncomeTypeAsync(id, incomeType);
        }
    }
}
