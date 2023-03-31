using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;

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
    }
}
