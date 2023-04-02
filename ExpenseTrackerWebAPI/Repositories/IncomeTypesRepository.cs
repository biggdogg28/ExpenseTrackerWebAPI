using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerWebAPI.Repositories
{
    public class IncomeTypesRepository : IIncomeTypesRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        private readonly IMapper _mapper;

        public IncomeTypesRepository(ExpenseTrackerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<IncomeType>> GetIncomeTypeAsync()
        {
            return await _context.IncomeTypes.ToListAsync();
        }

        public async Task<IncomeType> GetIncomeTypeByIdAsync(Guid id)
        {
            return await _context.IncomeTypes.SingleOrDefaultAsync(i => i.IncomeTypeID == id);
        }

        public async Task CreateIncomeTypeAsync(IncomeType incomeType)
        {
            incomeType.IncomeTypeID = Guid.NewGuid();
            _context.IncomeTypes.Add(incomeType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteIncomeTypeByIdAsync(Guid id)
        {
            IncomeType incomeType = await GetIncomeTypeByIdAsync(id);
            if (incomeType == null)
            {
                return false;
            }

            _context.IncomeTypes.Remove(incomeType);
            _context.SaveChanges();
            return true;
        }

        public async Task<CreateUpdateIncomeType> UpdateIncomeTypeAsync(Guid id, CreateUpdateIncomeType incomeType)
        {
            if (!await ExistIncomeTypeAsync(id))
            {
                return null;
            }

            var incomeTypeUpdated = _mapper.Map<IncomeType>(incomeType);
            incomeTypeUpdated.IncomeTypeID = id;

            _context.IncomeTypes.Update(incomeTypeUpdated);
            await _context.SaveChangesAsync();
            return incomeType;
        }

        //helper method for the Update method
        private async Task<bool> ExistIncomeTypeAsync(Guid id)
        {
            return await _context.IncomeTypes.CountAsync(l => l.IncomeTypeID == id) > 0;
        }

        public async Task<PatchIncomeType> UpdatePartiallyIncomeTypeAsync(Guid id, PatchIncomeType incomeType)
        {
            var incomeTypeFromDb = await GetIncomeTypeByIdAsync(id);

            if (incomeTypeFromDb == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(incomeType.Name) && incomeType.Name != incomeTypeFromDb.Name)
            {
                incomeTypeFromDb.Name = incomeType.Name;
            }

            _context.IncomeTypes.Update(incomeTypeFromDb);
            await _context.SaveChangesAsync();
            return incomeType;
        }
    }
}
