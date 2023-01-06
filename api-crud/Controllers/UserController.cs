using api_crud.Application.Services.Interfaces;
using api_crud.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userServices.GetUsers();
                if (users == null) return NotFound("No registered users");
                return Ok(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userServices.GetUsersById(id);
                if (user == null) return NotFound("User not found");
                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _userServices.AddUser(user))
                    {
                        return Ok("User successfully registered");
                    }
                    return BadRequest("Error while registering user");
                }
                return BadRequest("Error while registering user");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _userServices.UpdateUser(id, model))
                    {
                        return Ok("User successfully updated");
                    }
                    return BadRequest("Error while updating user");
                }
                return BadRequest("Error while updating user");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _userServices.DeleteUser(id))
                    {
                        return Ok("User successfully deleted");
                    }
                    return BadRequest("Error while deleting user");
                }
                return BadRequest("Error while deleting user");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
