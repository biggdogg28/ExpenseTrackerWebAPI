using ExpenseTrackerWebAPI.DTOs.CreateUpdateObjects;
using ExpenseTrackerWebAPI.DTOs.PatchObjects;
using ExpenseTrackerWebAPI.DTOs;
using ExpenseTrackerWebAPI.Helpers;
using ExpenseTrackerWebAPI.Models;
using ExpenseTrackerWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExpenseTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalsController : ControllerBase
    {
        private readonly ITotalsService _totalsService;
        private readonly ILogger<TotalsController> _logger;

        public TotalsController(ITotalsService TotalsService, ILogger<TotalsController> logger)
        {
            _totalsService = TotalsService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTotalsAsync()
        {
            try
            {
                _logger.LogInformation("GetTotals started.");

                var Totals = await _totalsService.GetTotalAsync();

                if (Totals == null || !Totals.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(Totals);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetTotals error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTotalsAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("GetLocaionById started");
                var Totals = await _totalsService.GetTotalByIdAsync(id);
                if (Totals == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(Totals);

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetTotals error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> PostTotalsAsync([FromBody] Totals Totals)
        {
            try
            {
                _logger.LogInformation("CreateTotals started");
                if (Totals == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _totalsService.CreateTotalAsync(Totals);
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
        public async Task<IActionResult> DeleteTotalsAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete Totals Started");
                bool result = await _totalsService.DeleteTotalByIdAsync(id);
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
        public async Task<IActionResult> PutTotals([FromRoute] Guid id, [FromBody] CreateUpdateTotals Totals)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (Totals == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                CreateUpdateTotals updatedTotals = await _totalsService.UpdateTotalAsync(id, Totals);
                if (updatedTotals == null)
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
        public async Task<IActionResult> PatchTotals([FromRoute] Guid id, [FromBody] PatchTotals Totals)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (Totals == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                PatchTotals updatedTotals = await _totalsService.UpdatePartiallyTotalAsync(id, Totals);
                if (updatedTotals == null)
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
