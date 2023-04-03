using ExpenseTrackerWebAPI.Helpers;
using ExpenseTrackerWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExpenseTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                _logger.LogInformation("GetLocations started.");

                var users = await _usersService.GetUsersAsync();

                if (users == null || !users.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetLocations error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError));
            }
        }
    }
}
