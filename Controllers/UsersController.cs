using Internet_Shop.Services;
using Internet_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Internet_Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var created = await _userService.CreateAsync(user);

            return CreatedAtAction(nameof(GetById), new { id = created.Id},created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, User user)
        {
            var updated = await _userService.UpdateAsync(id, user);

            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userService.DeleteAsync(id);

            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
