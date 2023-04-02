using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.Repositories;

namespace ExpenseTrackerWebAPI.Services
{
    public class ExpenseCategoriesService : IExpenseCategoriesService
    {
        private readonly IExpenseCategoriesRepository _expenseCategoriesRepository;
        public ExpenseCategoriesService(IExpenseCategoriesRepository expenseCategoriesRepository)
        {
            _expenseCategoriesRepository = expenseCategoriesRepository;
        }

        public async Task<IEnumerable<ExpenseCategory>> GetExpenseCategoryAsync()
        {
            return await _expenseCategoriesRepository.GetExpenseCategoryAsync();
        }

        public async Task<ExpenseCategory> GetExpenseCategoryByIdAsync(Guid id)
        {
            return await _expenseCategoriesRepository.GetExpenseCategoryByIdAsync(id);
        }

        public async Task CreateExpenseCategoryAsync(ExpenseCategory newExpenseCategory)
        {
            //validation is added to the business layer (Services)
            // no need for validation for 2 entries on the table

            await _expenseCategoriesRepository.CreateExpenseCategoryAsync(newExpenseCategory);
        }

        public async Task<bool> DeleteExpenseCategoryByIdAsync(Guid id)
        {
            return await _expenseCategoriesRepository.DeleteExpenseCategoryByIdAsync(id);
        }

        public async Task<CreateUpdateExpenseCategory> UpdateExpenseCategoryAsync(Guid id, CreateUpdateExpenseCategory expenseCategory)
        {
            return await _expenseCategoriesRepository.UpdateExpenseCategoryAsync(id, expenseCategory);
        }

        public async Task<PatchExpenseCategory> UpdatePartiallyExpenseCategoryAsync(Guid id, PatchExpenseCategory expenseCategory)
        {
            return await _expenseCategoriesRepository.UpdatePartiallyExpenseCategoryAsync(id, expenseCategory);
        }
    }
}
