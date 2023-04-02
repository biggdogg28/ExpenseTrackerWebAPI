using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerWebAPI.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        private readonly IMapper _mapper;

        public ExpensesRepository(ExpenseTrackerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Expense>> GetExpenseAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(Guid id)
        {
            return await _context.Expenses.SingleOrDefaultAsync(e => e.IdExpense == id);
        }

        public async Task CreateExpenseAsync(Expense expense)
        {
            expense.IdExpense = Guid.NewGuid();
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteExpenseByIdAsync(Guid id)
        {
            Expense expense = await GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return false;
            }

            _context.Expenses.Remove(expense);
            _context.SaveChanges();
            return true;
        }

        public async Task<CreateUpdateExpense> UpdateExpenseAsync(Guid id, CreateUpdateExpense expense)
        {
            if (!await ExistExpenseAsync(id))
            {
                return null;
            }

            var expenseUpdated = _mapper.Map<Expense>(expense);
            expenseUpdated.IdExpense = id;

            _context.Expenses.Update(expenseUpdated);
            await _context.SaveChangesAsync();
            return expense;
        }

        //helper method for the Update method
        private async Task<bool> ExistExpenseAsync(Guid id)
        {
            return await _context.Expenses.CountAsync(e => e.IdExpense == id) > 0;
        }

        public async Task<PatchExpense> UpdatePartiallyExpenseAsync(Guid id, PatchExpense expense)
        {
            var expenseFromDb = await GetExpenseByIdAsync(id);

            if (expenseFromDb == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(expense.Notes) && expense.Notes != expenseFromDb.Notes)
            {
                expenseFromDb.Notes = expense.Notes;
            }

            _context.Expenses.Update(expenseFromDb);
            await _context.SaveChangesAsync();
            return expense;
        }
    }
}