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
    public class IncomesController : ControllerBase
    {
        private readonly IIncomesService _incomesService;
        private readonly ILogger<IncomesController> _logger;

        public IncomesController(IIncomesService incomesService, ILogger<IncomesController> logger)
        {
            _incomesService = incomesService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllIncomesAsync()
        {
            try
            {
                _logger.LogInformation("GetIncomes started.");

                var Incomes = await _incomesService.GetIncomeAsync();

                if (Incomes == null || !Incomes.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(Incomes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetIncomes error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncomeAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("GetLocaionById started");
                var Income = await _incomesService.GetIncomeByIdAsync(id);
                if (Income == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(Income);

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetIncomes error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> PostIncomeAsync([FromBody] Income Income)
        {
            try
            {
                _logger.LogInformation("CreateIncome started");
                if (Income == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _incomesService.CreateIncomeAsync(Income);
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
        public async Task<IActionResult> DeleteIncomeAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete Income Started");
                bool result = await _incomesService.DeleteIncomeByIdAsync(id);
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
        public async Task<IActionResult> PutIncome([FromRoute] Guid id, [FromBody] CreateUpdateIncome Income)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (Income == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                CreateUpdateIncome updatedIncome = await _incomesService.UpdateIncomeAsync(id, Income);
                if (updatedIncome == null)
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
        public async Task<IActionResult> PatchIncome([FromRoute] Guid id, [FromBody] PatchIncome Income)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (Income == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                PatchIncome updatedIncome = await _incomesService.UpdatePartiallyIncomeAsync(id, Income);
                if (updatedIncome == null)
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
