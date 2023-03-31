using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;

namespace ExpenseTrackerWebAPI.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly ExpenseTrackerDataContext _context;

        private readonly IMapper _mapper;

        public LocationsRepository(ExpenseTrackerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
