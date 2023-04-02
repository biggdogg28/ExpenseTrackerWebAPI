using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.Repositories;

namespace ExpenseTrackerWebAPI.Services
{
    public class IncomesService : IIncomesService
    {
        private readonly IIncomesRepository _incomesRepository;
        public IncomesService(IIncomesRepository incomesRepository)
        {
            _incomesRepository = incomesRepository;
        }

        public async Task<IEnumerable<Income>> GetIncomeAsync()
        {
            return await _incomesRepository.GetIncomeAsync();
        }

        public async Task<Income> GetIncomeByIdAsync(Guid id)
        {
            return await _incomesRepository.GetIncomeByIdAsync(id);
        }

        public async Task CreateIncomeAsync(Income newIncome)
        {
            //validation is added to the business layer (Services)
            // no need for validation for 2 entries on the table

            await _incomesRepository.CreateIncomeAsync(newIncome);
        }

        public async Task<bool> DeleteIncomeByIdAsync(Guid id)
        {
            return await _incomesRepository.DeleteIncomeByIdAsync(id);
        }

        public async Task<CreateUpdateIncome> UpdateIncomeAsync(Guid id, CreateUpdateIncome income)
        {
            return await _incomesRepository.UpdateIncomeAsync(id, income);
        }

        public async Task<PatchIncome> UpdatePartiallyIncomeAsync(Guid id, PatchIncome income)
        {
            return await _incomesRepository.UpdatePartiallyIncomeAsync(id, income);
        }
    }
}
