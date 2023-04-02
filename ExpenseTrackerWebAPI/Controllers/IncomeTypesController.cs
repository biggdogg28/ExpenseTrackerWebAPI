using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.Helpers;
using ExpenseTrackerWebAPI.Models;
using ExpenseTrackerWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IncomeTypesController : ControllerBase
    {
        private readonly IIncomeTypesService _incomeTypesService;
        private readonly ILogger<IncomeTypesController> _logger;

        public IncomeTypesController(IIncomeTypesService incomeTypesService, ILogger<IncomeTypesController> logger)
        {
            _incomeTypesService = incomeTypesService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIncomeTypeAsync()
        {
            try
            {
                _logger.LogInformation("GetIncomeType started.");

                var IncomeType = await _incomeTypesService.GetIncomeTypeAsync();

                if (IncomeType == null || !IncomeType.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(IncomeType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetIncomeType error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncomeTypeAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("GetIncomeTypeById started");
                var IncomeType = await _incomeTypesService.GetIncomeTypeByIdAsync(id);
                if (IncomeType == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(IncomeType);

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetIncomeType error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> PostIncomeTypeAsync([FromBody] IncomeType IncomeType)
        {
            try
            {
                _logger.LogInformation("CreateIncomeType started");
                if (IncomeType == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _incomeTypesService.CreateIncomeTypeAsync(IncomeType);
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
        public async Task<IActionResult> DeleteIncomeTypeAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete IncomeType Started");
                bool result = await _incomeTypesService.DeleteIncomeTypeByIdAsync(id);
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
        public async Task<IActionResult> PutIncomeType([FromRoute] Guid id, [FromBody] CreateUpdateIncomeType IncomeType)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (IncomeType == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                CreateUpdateIncomeType updatedIncomeType = await _incomeTypesService.UpdateIncomeTypeAsync(id, IncomeType);
                if (updatedIncomeType == null)
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
        public async Task<IActionResult> PatchIncomeType([FromRoute] Guid id, [FromBody] PatchIncomeType IncomeType)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (IncomeType == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                PatchIncomeType updatedIncomeType = await _incomeTypesService.UpdatePartiallyIncomeTypeAsync(id, IncomeType);
                if (updatedIncomeType == null)
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
