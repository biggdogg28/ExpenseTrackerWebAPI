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
    public class ExpenseCategoriesController : ControllerBase
    {
        private readonly IExpenseCategoriesService _expenseCategoriesService;
        private readonly ILogger<ExpenseCategoriesController> _logger;

        public ExpenseCategoriesController(IExpenseCategoriesService expenseCategoriesService, ILogger<ExpenseCategoriesController> logger)
        {
            _expenseCategoriesService = expenseCategoriesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenseCategoriesAsync()
        {
            try
            {
                _logger.LogInformation("GetExpenseCategories started.");

                var expenseCategory = await _expenseCategoriesService.GetExpenseCategoryAsync();

                if (expenseCategory == null || !expenseCategory.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(expenseCategory);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetLocations error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseCategoryAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("GetExpenseById started");
                var expenseCategories = await _expenseCategoriesService.GetExpenseCategoryByIdAsync(id);
                if (expenseCategories == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(expenseCategories);

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetExpenseCategories error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> PostExpenseCategoryAsync([FromBody] ExpenseCategory expenseCategory)
        {
            try
            {
                _logger.LogInformation("GetExpenseCategories started");
                if (expenseCategory == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _expenseCategoriesService.CreateExpenseCategoryAsync(expenseCategory);
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
        public async Task<IActionResult> DeleteExpenseCategoryAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete ExpenseCategories Started");
                bool result = await _expenseCategoriesService.DeleteExpenseCategoryByIdAsync(id);
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
        public async Task<IActionResult> PutExpenseCategory([FromRoute] Guid id, [FromBody] CreateUpdateExpenseCategory expenseCategory)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (expenseCategory == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                CreateUpdateExpenseCategory updatedexpenseCategories = await _expenseCategoriesService.UpdateExpenseCategoryAsync(id, expenseCategory);
                if (updatedexpenseCategories == null)
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
        public async Task<IActionResult> PatchExpenseCategory([FromRoute] Guid id, [FromBody] PatchExpenseCategory expenseCategory)
        {
            try
            {
                _logger.LogInformation("Update Started");
                if (expenseCategory == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                PatchExpenseCategory updatedExpenseCategory = await _expenseCategoriesService.UpdatePartiallyExpenseCategoryAsync(id, expenseCategory);
                if (updatedExpenseCategory == null)
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
