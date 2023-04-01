using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.Helpers;
using ExpenseTrackerWebAPI.Repositories;

namespace ExpenseTrackerWebAPI.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly ILocationsRepository _locationsRepository;
        public LocationsService(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _locationsRepository.GetLocationsAsync();
        }

        public async Task<Location> GetLocationByIdAsync(Guid id)
        {
            return await _locationsRepository.GetLocationByIdAsync(id);
        }

        public async Task CreateLocationAsync(Location newLocation)
        {
            //validation is added to the business layer (Services)
            // no need for validation for 2 entries on the table

            await _locationsRepository.CreateLocationAsync(newLocation);
        }

        public async Task<bool> DeleteLocationByIdAsync(Guid id)
        {
            return await _locationsRepository.DeleteLocationByIdAsync(id);
        }

        public async Task<CreateUpdateLocation> UpdateLocationAsync(Guid id, CreateUpdateLocation location)
        {
            return await _locationsRepository.UpdateLocationAsync(id, location);
        }

        public async Task<PatchLocation> UpdatePartiallyLocationAsync(Guid id, PatchLocation location)
        {
            return await _locationsRepository.UpdatePartiallyLocationAsync(id, location);
        }
    }
}
