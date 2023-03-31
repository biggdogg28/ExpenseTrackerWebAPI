using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;

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
    }
}
