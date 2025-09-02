using Internet_Shop.Services;
using Internet_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Internet_Shop.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();

            return Ok(users);
        }

        /// <summary>
        /// Get user's data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var created = await _service.CreateAsync(user);

            return CreatedAtAction(nameof(GetById), new { id = created.Id},created);
        }

        /// <summary>
        /// Change user's data by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(int id, User user)
        {
            var updated = await _service.UpdateAsync(id, user);

            if (updated == null) return NotFound();

            return Ok(updated);
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
