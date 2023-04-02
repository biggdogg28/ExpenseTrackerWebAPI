using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;

namespace ExpenseTrackerWebAPI.Services
{
    public interface IExpensesService
    {
        public Task<IEnumerable<Expense>> GetExpenseAsync();
        public Task<Expense> GetExpenseByIdAsync(Guid id);
        public Task CreateExpenseAsync(Expense expense);
        public Task<bool> DeleteExpenseByIdAsync(Guid id);
        public Task<CreateUpdateExpense> UpdateExpenseAsync(Guid id, CreateUpdateExpense expense);
        public Task<PatchExpense> UpdatePartiallyExpenseAsync(Guid id, PatchExpense expense);
    }
}
