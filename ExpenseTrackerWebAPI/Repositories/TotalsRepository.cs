using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerWebAPI.Repositories
{
    public class TotalsRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        private readonly IMapper _mapper;

        public TotalsRepository(ExpenseTrackerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Totals>> GetTotalssAsync()
        {
            return await _context.Totals.ToListAsync();
        }

        public async Task<Totals> GetTotalsByIdAsync(Guid id)
        {
            return await _context.Totals.SingleOrDefaultAsync(l => l.IdTotals == id);
        }

        public async Task CreateTotalsAsync(Totals totals)
        {
            totals.IdTotals = Guid.NewGuid();
            _context.Totals.Add(totals);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteTotalsByIdAsync(Guid id)
        {
            Totals totals = await GetTotalsByIdAsync(id);
            if (totals == null)
            {
                return false;
            }

            _context.Totals.Remove(totals);
            _context.SaveChanges();
            return true;
        }

        public async Task<CreateUpdateTotals> UpdateTotalsAsync(Guid id, CreateUpdateTotals totals)
        {
            if (!await ExistTotalsAsync(id))
            {
                return null;
            }

            var TotalsUpdated = _mapper.Map<Totals>(totals);
            TotalsUpdated.IdTotals = id;

            _context.Totals.Update(TotalsUpdated);
            await _context.SaveChangesAsync();
            return totals;
        }

        //helper method for the Update method
        private async Task<bool> ExistTotalsAsync(Guid id)
        {
            return await _context.Totals.CountAsync(l => l.IdTotals == id) > 0;
        }

        public async Task<PatchTotals> UpdatePartiallyTotalsAsync(Guid id, PatchTotals totals)
        {
            var totalsFromDb = await GetTotalsByIdAsync(id);

            if (totalsFromDb == null)
            {
                return null;
            }

            //if (!string.IsNullOrEmpty(totals.Name) && totals.Name != totalsFromDb.Name)
            //{
            //    totalsFromDb.Name = totals.Name;
            //}

            _context.Totals.Update(totalsFromDb);
            await _context.SaveChangesAsync();
            return totals;
        }
    }
}
