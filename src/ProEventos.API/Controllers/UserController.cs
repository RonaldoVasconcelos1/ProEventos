using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain.Entities.Users;
using ProEventos.Application.Contracts;

namespace ProEventos.API.Controllers
{

    [ApiController]
    [Route("v1/Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                if (users == null) return NotFound("No User Found");
                return Ok(users);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Request Error: {ex.Message}");
            }
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByUserId(Guid id)
        {
            try
            {
                var userId = await _userService.GetUserById(id);
                if (userId == null) return NotFound("User Not Found");
                return Ok(userId);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Request Error: {ex.Message}");
            }
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var user = await _userService.GetAllUserEmailAsync(email);
                if (user == null) return NotFound("Event Not Found");
                return Ok(user);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Request Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(User model)
        {
            try
            {
                var userModel = await _userService.Add(model);
                if (userModel == null) return BadRequest("Error Signing Up ");
                return Ok(userModel);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Request Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, User model)
        {
            try
            {
                var user = await _userService.Update(model, id);
                if (user == null) return NotFound("Event Not Found");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Request Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var user = await _userService.Remove(id);
                return (user ? Ok()
                    : BadRequest("Error while deleting"));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                   $"Request Error: {ex.Message}");
            }
        }
    }
}