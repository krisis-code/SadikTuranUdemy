using IdentityApp.Models;
using IdentityApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IdentityApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        private SignInManager<AppUser> _signInManager;

        private IEmailSender _emailSender;
        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,  SignInManager<AppUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                   var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();

                    if (await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınızı onaylayınız");
                        return View(model);
                    }

                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe,true);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);

                        await _userManager.SetLockoutEndDateAsync(user, null);

                        return RedirectToAction("Index", "Home");
                    }
                    else if(result.IsLockedOut)
                    {
                        var lockOutDate = await _userManager.GetLockoutEndDateAsync(user);

                        var timeLeft = lockOutDate.Value - DateTime.UtcNow;

                        ModelState.AddModelError("", $"Hesabınız kilitlendi , Lütfen {timeLeft.Minutes} dakika sonra tekrar deneyiniz");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Parola hatalı ");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı email ");
                }

               
            }
            return View (model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.FullName
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var url = Url.Action("ConfirmEmail", "Account", new { user.Id, token });

                    await _emailSender.SendEmailAsync(user.Email, "Hesap Onayı", $"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:5034{url}'>tıklayınız.</a>");
                    TempData["message"] = "Email hesabınızdaki onay mailini tıklayınız.";
                    return RedirectToAction("Login" , "Account");
                }

                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string Id , String Token)
        {
            if (Id == null || Token == null )
            {
                TempData["message"] = "Geçersiz Token bilgisi";
                return View();
            }

            var user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, Token);

                if (result.Succeeded)
                {
                    TempData["message"] = "Hesabınız onaylandı";
                    return RedirectToAction("Login","Account");
                }
            }
            TempData["message"] = "Kullanıcı bulunamadı";
            return View();
        }
    }
}

    