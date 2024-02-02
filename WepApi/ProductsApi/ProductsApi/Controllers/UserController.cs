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
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task<IActionResult> Login (LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null) {
                return BadRequest(new { message = "Mail hatalı" });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                return Ok(new { token = "token" });
            }
            return Unauthorized();
        }
    }
}
