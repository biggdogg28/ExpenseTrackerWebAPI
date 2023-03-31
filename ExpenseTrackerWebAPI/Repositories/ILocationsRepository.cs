using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;

namespace ExpenseTrackerWebAPI.Repositories
{
    public interface ILocationsRepository
    {
        public Task<IEnumerable<Location>> GetLocationsAsync();
        public Task<Location> GetLocationByIdAsync(Guid id);
        public Task CreateLocationAsync(Location location);
        public Task<bool> DeleteLocationByIdAsync(Guid id);
        public Task<CreateUpdateLocation> UpdateLocationAsync(Guid id, CreateUpdateLocation location);
        public Task<PatchLocation> UpdatePartiallyLocationAsync(Guid id, PatchLocation location);

    }
}
