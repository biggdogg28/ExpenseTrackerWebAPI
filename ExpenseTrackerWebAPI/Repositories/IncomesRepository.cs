using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerWebAPI.Repositories
{
    public class IncomesRepository : IIncomesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        private readonly IMapper _mapper;

        public IncomesRepository(ExpenseTrackerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Income>> GetIncomeAsync()
        {
            return await _context.Income.ToListAsync();
        }

        public async Task<Income> GetIncomeByIdAsync(Guid id)
        {
            return await _context.Income.SingleOrDefaultAsync(i => i.IdIncome == id);
        }

        public async Task CreateIncomeAsync(Income income)
        {
            income.IdIncome = Guid.NewGuid();
            _context.Income.Add(income);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteIncomeByIdAsync(Guid id)
        {
            Income income = await GetIncomeByIdAsync(id);
            if (income == null)
            {
                return false;
            }

            _context.Income.Remove(income);
            _context.SaveChanges();
            return true;
        }

        public async Task<CreateUpdateIncome> UpdateIncomeAsync(Guid id, CreateUpdateIncome income)
        {
            if (!await ExistIncomeAsync(id))
            {
                return null;
            }

            var IncomeUpdated = _mapper.Map<Income>(income);
            IncomeUpdated.IdIncome = id;

            _context.Income.Update(IncomeUpdated);
            await _context.SaveChangesAsync();
            return income;
        }

        //helper method for the Update method
        private async Task<bool> ExistIncomeAsync(Guid id)
        {
            return await _context.Income.CountAsync(i => i.IdIncome == id) > 0;
        }

        public async Task<PatchIncome> UpdatePartiallyIncomeAsync(Guid id, PatchIncome income)
        {
            var incomeFromDb = await GetIncomeByIdAsync(id);

            if (incomeFromDb == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(income.Name) && income.Name != incomeFromDb.Name)
            {
                incomeFromDb.Name = income.Name;
            }

            _context.Income.Update(incomeFromDb);
            await _context.SaveChangesAsync();
            return income;
        }
    }
}
