using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;

namespace ExpenseTrackerWebAPI.Services
{
    public interface IExpenseCategoriesService
    {
        public Task<IEnumerable<ExpenseCategory>> GetExpenseCategoryAsync();
        public Task<ExpenseCategory> GetExpenseCategoryByIdAsync(Guid id);
        public Task CreateExpenseCategoryAsync(ExpenseCategory expenseCategory);
        public Task<bool> DeleteExpenseCategoryByIdAsync(Guid id);
        public Task<CreateUpdateExpenseCategory> UpdateExpenseCategoryAsync(Guid id, CreateUpdateExpenseCategory expenseCategory);
        public Task<PatchExpenseCategory> UpdatePartiallyExpenseCategoryAsync(Guid id, PatchExpenseCategory expenseCategory);
    }
}
