using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductsApi.DTO;
using ProductsApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly IConfiguration _configuraiton;

        public UserController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager , IConfiguration configuraiton)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuraiton = configuraiton;
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
                return Ok(new { token = GenerateJWT(user) });
            }
            return Unauthorized();
        }

        private object GenerateJWT(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuraiton.GetSection("AppSettings:Secret").Value ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName ?? ""),

                    }

                    ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
