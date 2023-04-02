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
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesService _expensesService;
        private readonly ILogger<ExpensesController> _logger;

        public ExpensesController(IExpensesService expensesService, ILogger<ExpensesController> logger)
        {
            _expensesService = expensesService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExpenseAsync()
        {
            try
            {
                _logger.LogInformation("GetExpense started.");

                var Expense = await _expensesService.GetExpenseAsync();

                if (Expense == null || !Expense.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(Expense);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetExpense error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("GetExpenseById started");
                var Expense = await _expensesService.GetExpenseByIdAsync(id);
                if (Expense == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(Expense);

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetExpense error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> PostExpenseAsync([FromBody] Expense Expense)
        {
            try
            {
                _logger.LogInformation("CreateExpense started");
                if (Expense == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _expensesService.CreateExpenseAsync(Expense);
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
        public async Task<IActionResult> DeleteExpenseAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete Expense Started");
                bool result = await _expensesService.DeleteExpenseByIdAsync(id);
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
        public async Task<IActionResult> PutExpense([FromRoute] Guid id, [FromBody] CreateUpdateExpense Expense)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (Expense == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                CreateUpdateExpense updatedExpense = await _expensesService.UpdateExpenseAsync(id, Expense);
                if (updatedExpense == null)
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
        public async Task<IActionResult> PatchExpense([FromRoute] Guid id, [FromBody] PatchExpense Expense)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (Expense == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                PatchExpense updatedExpense = await _expensesService.UpdatePartiallyExpenseAsync(id, Expense);
                if (updatedExpense == null)
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
