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
    public class TotalsController : ControllerBase
    {
        private readonly ITotalsService _totalsService;
        private readonly IIncomesService _incomesService;
        private readonly IExpensesService _expensesService;
        private readonly ILogger<TotalsController> _logger;

        public TotalsController(ITotalsService TotalsService, ILogger<TotalsController> logger, IIncomesService incomesService, IExpensesService expensesService)
        {
            _totalsService = TotalsService;
            _logger = logger;
            _incomesService = incomesService;
            _expensesService = expensesService;
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

        public async Task<IActionResult> PostTotalsAsync([FromBody] Totals totals)
        {
            try
            {
                _logger.LogInformation("CreateTotals started");
                if (totals == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _totalsService.CreateTotalAsync(totals);
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
        public async Task<IActionResult> PutTotals([FromRoute] Guid id, [FromBody] CreateUpdateTotals totals)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (totals == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                CreateUpdateTotals updatedTotals = await _totalsService.UpdateTotalAsync(id, totals);
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
        public async Task<IActionResult> PatchTotals([FromRoute] Guid id, [FromBody] PatchTotals totals)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (totals == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                PatchTotals updatedTotals = await _totalsService.UpdatePartiallyTotalAsync(id, totals);
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
