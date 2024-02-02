using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]

        public async Task<IActionResult> CreateUser(userDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                AddedTime = DateTime.Now, 

            };

            var result = await _userManager.CreateAsync(user , model.Password);

            if (result.Succeeded)
            {
                return StatusCode(201);
            }
            return Ok();
           
        }

        public async Task<IActionResult> Login ()
        {
            
        }
    }
}
