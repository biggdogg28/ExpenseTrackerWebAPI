using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;

namespace ExpenseTrackerWebAPI.Repositories
{
    public interface IExpenseCategoriesRepository
    {
        public Task<IEnumerable<ExpenseCategory>> GetExpenseCategoryAsync();
        public Task<ExpenseCategory> GetExpenseCategoryByIdAsync(Guid id);
        public Task CreateExpenseCategoryAsync(ExpenseCategory expenseCategory);
        public Task<bool> DeleteExpenseCategoryByIdAsync(Guid id);
        public Task<CreateUpdateExpenseCategory> UpdateExpenseCategoryAsync(Guid id, CreateUpdateExpenseCategory expenseCategory);
        public Task<PatchExpenseCategory> UpdatePartiallyExpenseCategoryAsync(Guid id, PatchExpenseCategory expenseCategory);
    }
}
