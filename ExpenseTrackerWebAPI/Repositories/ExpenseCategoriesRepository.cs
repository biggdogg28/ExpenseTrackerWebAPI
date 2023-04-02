using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerWebAPI.Repositories
{
    public class ExpenseCategoriesRepository : IExpenseCategoriesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        private readonly IMapper _mapper;

        public ExpenseCategoriesRepository(ExpenseTrackerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ExpenseCategory>> GetExpenseCategoryAsync()
        {
            return await _context.ExpenseCategory.ToListAsync();
        }

        public async Task<ExpenseCategory> GetExpenseCategoryByIdAsync(Guid id)
        {
            return await _context.ExpenseCategory.SingleOrDefaultAsync(e => e.ExpenseCategoryID == id);
        }

        public async Task CreateExpenseCategoryAsync(ExpenseCategory expenseCategory)
        {
            expenseCategory.ExpenseCategoryID = Guid.NewGuid();
            _context.ExpenseCategory.Add(expenseCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteExpenseCategoryByIdAsync(Guid id)
        {
            ExpenseCategory expenseCategory = await GetExpenseCategoryByIdAsync(id);
            if (expenseCategory == null)
            {
                return false;
            }

            _context.ExpenseCategory.Remove(expenseCategory);
            _context.SaveChanges();
            return true;
        }

        public async Task<CreateUpdateExpenseCategory> UpdateExpenseCategoryAsync(Guid id, CreateUpdateExpenseCategory expenseCategory)
        {
            if (!await ExistExpenseCategoriesAsync(id))
            {
                return null;
            }

            var expenseCategoryUpdated = _mapper.Map<ExpenseCategory>(expenseCategory);
            expenseCategoryUpdated.ExpenseCategoryID = id;

            _context.ExpenseCategory.Update(expenseCategoryUpdated);
            await _context.SaveChangesAsync();
            return expenseCategory;
        }

        //helper method for the Update method
        private async Task<bool> ExistExpenseCategoriesAsync(Guid id)
        {
            return await _context.ExpenseCategory.CountAsync(e => e.ExpenseCategoryID == id) > 0;
        }

        public async Task<PatchExpenseCategory> UpdatePartiallyExpenseCategoryAsync(Guid id, PatchExpenseCategory expenseCategory)
        {
            var expenseCategoryFromDb = await GetExpenseCategoryByIdAsync(id);

            if (expenseCategoryFromDb == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(expenseCategory.Name) && expenseCategory.Name != expenseCategoryFromDb.Name)
            {
                expenseCategoryFromDb.Name = expenseCategory.Name;
            }

            _context.ExpenseCategory.Update(expenseCategoryFromDb);
            await _context.SaveChangesAsync();
            return expenseCategory;
        }
    }
}
