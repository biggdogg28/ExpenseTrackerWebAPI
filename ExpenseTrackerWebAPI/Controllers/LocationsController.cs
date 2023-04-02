using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.Helpers;
using ExpenseTrackerWebAPI.Models;
using ExpenseTrackerWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExpenseTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsService _locationsService;
        private readonly ILogger<LocationsController> _logger;

        public LocationsController(ILocationsService locationsService, ILogger<LocationsController> logger)
        {
            _locationsService = locationsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocationsAsync()
        {
            try
            {
                _logger.LogInformation("GetLocations started.");

                var locations = await _locationsService.GetLocationsAsync();

                if (locations == null || !locations.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(locations);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetLocations error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("GetLocaionById started");
                var location = await _locationsService.GetLocationByIdAsync(id);
                if (location == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(location);

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetLocations error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostLocationAsync([FromBody] Location location)
        {
            try
            {
                _logger.LogInformation("CreateLocation started");
                if (location == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _locationsService.CreateLocationAsync(location);
                return Ok(SuccessMessagesEnum.ElementSuccessfullyAdded);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteLocationAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete Location Started");
                bool result = await _locationsService.DeleteLocationByIdAsync(id);
                if (result)
                {
                    return Ok(SuccessMessagesEnum.ElementSuccessfullyDeleted);
                }
                return BadRequest(ErrorMessagesEnum.BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutLocation([FromRoute] Guid id, [FromBody] CreateUpdateLocation location)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if(location == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                CreateUpdateLocation updatedLocation = await _locationsService.UpdateLocationAsync(id, location);
                if (updatedLocation == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(SuccessMessagesEnum.ElementSuccessfullyUpdated);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PatchLocation([FromRoute] Guid id, [FromBody] PatchLocation location)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (location == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                PatchLocation updatedLocation = await _locationsService.UpdatePartiallyLocationAsync(id, location);
                if (updatedLocation == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(SuccessMessagesEnum.ElementSuccessfullyUpdated);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
