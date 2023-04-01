using AutoMapper;
using ExpenseTrackerWebAPI.DataContext;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _context.Location.ToListAsync();
        }

        public async Task<Location> GetLocationByIdAsync(Guid id)
        {
            return await _context.Location.SingleOrDefaultAsync(l => l.IdLocation == id);
        }

        public async Task CreateLocationAsync(Location location)
        {
            location.IdLocation = Guid.NewGuid();
            _context.Location.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteLocationByIdAsync(Guid id)
        {
            Location location = await GetLocationByIdAsync(id);
            if (location == null)
            {
                return false;
            }

            _context.Location.Remove(location);
            _context.SaveChanges();
            return true;
        }

        public async Task<CreateUpdateLocation> UpdateLocationAsync(Guid id, CreateUpdateLocation location)
        {
            if (!await ExistLocationAsync(id))
            {
                return null;
            }

            var locationUpdated = _mapper.Map<Location>(location);
            locationUpdated.IdLocation = id;

            _context.Location.Update(locationUpdated);
            await _context.SaveChangesAsync();
            return location;
        }

        //helper method for the Update method
        private async Task<bool> ExistLocationAsync(Guid id)
        {
            return await _context.Location.CountAsync(l => l.IdLocation == id) > 0;
        }

        public async Task<PatchLocation> UpdatePartiallyLocationAsync(Guid id, PatchLocation location)
        {
            var locationFromDb = await GetLocationByIdAsync(id);

            if (locationFromDb == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(location.Name) && location.Name != locationFromDb.Name)
            {
                locationFromDb.Name = location.Name;
            }

            _context.Location.Update(locationFromDb);
            await _context.SaveChangesAsync();
            return location;
        }
    }
}
