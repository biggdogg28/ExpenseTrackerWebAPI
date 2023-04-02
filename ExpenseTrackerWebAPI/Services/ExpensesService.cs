using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.Repositories;

namespace ExpenseTrackerWebAPI.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpensesRepository _expensesRepository;
        public ExpensesService(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public async Task<IEnumerable<Expense>> GetExpenseAsync()
        {
            return await _expensesRepository.GetExpenseAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(Guid id)
        {
            return await _expensesRepository.GetExpenseByIdAsync(id);
        }

        public async Task CreateExpenseAsync(Expense newExpense)
        {
            //validation is added to the business layer (Services)
            // no need for validation for 2 entries on the table

            await _expensesRepository.CreateExpenseAsync(newExpense);
        }

        public async Task<bool> DeleteExpenseByIdAsync(Guid id)
        {
            return await _expensesRepository.DeleteExpenseByIdAsync(id);
        }

        public async Task<CreateUpdateExpense> UpdateExpenseAsync(Guid id, CreateUpdateExpense expense)
        {
            return await _expensesRepository.UpdateExpenseAsync(id, expense);
        }

        public async Task<PatchExpense> UpdatePartiallyExpenseAsync(Guid id, PatchExpense expense)
        {
            return await _expensesRepository.UpdatePartiallyExpenseAsync(id, expense);
        }
    }
}
