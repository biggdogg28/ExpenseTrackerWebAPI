using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerWebAPI.Services
{
    public class TotalsService : ITotalsService
    {
        private readonly ITotalsRepository _totalsRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly IIncomesRepository _incomesRepository;
        public TotalsService(ITotalsRepository totalsRepository, IExpensesRepository expensesRepository, IIncomesRepository incomesRepository)
        {
            _totalsRepository = totalsRepository;
            _expensesRepository= expensesRepository;
            _incomesRepository= incomesRepository;
        }

        public async Task<IEnumerable<Totals>> GetTotalAsync()
        {
            return await _totalsRepository.GetTotalAsync();
        }

        public async Task<Totals> GetTotalByIdAsync(Guid id)
        {
            return await _totalsRepository.GetTotalByIdAsync(id);
        }

        public async Task CreateTotalAsync(Totals newTotal)
        {
            //validation is added to the business layer (Services)
            // no need for validation for 2 entries on the table

            var incomes = await _incomesRepository.GetIncomeAsync();
            decimal sumI = incomes.Sum(x => x.Amount);
            var expenses = await _expensesRepository.GetExpenseAsync();
            decimal sumE = expenses.Sum(x => x.Amount);
            var balance = sumI - sumE;
            newTotal.Balance= balance;
            newTotal.TotalExpenses = sumE;
            newTotal.TotalIncome = sumI;

            await _totalsRepository.CreateTotalAsync(newTotal);
        }
        public async Task<bool> DeleteTotalByIdAsync(Guid id)
        {
            return await _totalsRepository.DeleteTotalByIdAsync(id);
        }

        public async Task<CreateUpdateTotals> UpdateTotalAsync(Guid id, CreateUpdateTotals total)
        {
            var incomes = await _incomesRepository.GetIncomeAsync();
            decimal sumI = incomes.Sum(x => x.Amount);
            var expenses = await _expensesRepository.GetExpenseAsync();
            decimal sumE = expenses.Sum(x => x.Amount);
            var balance = sumI - sumE;
            total.Balance = balance;
            total.TotalExpenses = sumE;
            total.TotalIncome = sumI;
            return await _totalsRepository.UpdateTotalAsync(id, total);
        }

        public async Task<PatchTotals> UpdatePartiallyTotalAsync(Guid id, PatchTotals total)
        {
            var incomes = await _incomesRepository.GetIncomeAsync();
            decimal sumI = incomes.Sum(x => x.Amount);
            var expenses = await _expensesRepository.GetExpenseAsync();
            decimal sumE = expenses.Sum(x => x.Amount);
            var balance = sumI - sumE;
            total.Balance = balance;
            total.TotalExpenses = sumE;
            total.TotalIncome = sumI;
            return await _totalsRepository.UpdatePartiallyTotalAsync(id, total);
        }
    }
}
