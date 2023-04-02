using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;

namespace ExpenseTrackerWebAPI.Repositories
{
    public interface IExpensesRepository
    {
        public Task<IEnumerable<Expense>> GetExpenseAsync();
        public Task<Expense> GetExpenseByIdAsync(Guid id);
        public Task CreateExpenseAsync(Expense expense);
        public Task<bool> DeleteExpenseByIdAsync(Guid id);
        public Task<CreateUpdateExpense> UpdateExpenseAsync(Guid id, CreateUpdateExpense expense);
        public Task<PatchExpense> UpdatePartiallyExpenseAsync(Guid id, PatchExpense expense);
    }
}
