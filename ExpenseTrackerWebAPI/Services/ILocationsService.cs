using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;

namespace ExpenseTrackerWebAPI.Services
{
    public interface ILocationsService
    {
        public Task<IEnumerable<Location>> GetLocationsAsync();
        public Task<Location> GetLocationByIdAsync(Guid id);
        public Task CreateLocationAsync(Location location);
        public Task<bool> DeleteLocationByIdAsync(Guid id);
        public Task<CreateUpdateLocation> UpdateLocationAsync(Guid id, CreateUpdateLocation location);
        public Task<PatchLocation> UpdatePartiallyLocationAsync(Guid id, PatchLocation location);
    }
}
