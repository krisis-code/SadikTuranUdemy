﻿using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository) 
        {
            
            _userRepository = userRepository;
        
        }

        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index","Posts");
            }
            return View();
        }

        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isUser = _userRepository.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

                if (isUser !=null) 
                {

                    var userClaims = new List<Claim>();
                    
                        userClaims.Add(new Claim (ClaimTypes.NameIdentifier,isUser.UserId.ToString()));
                        userClaims.Add(new Claim(ClaimTypes.Name, isUser.UserName ?? ""));
                        userClaims.Add(new Claim(ClaimTypes.UserData, isUser.Image ?? ""));
                    if (isUser.Email == "menesbaspinar@hotmail.com")
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role,"admin"));
                    }
                    var claimsIdentity = new ClaimsIdentity(userClaims , CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToAction("Index", "Posts");
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı yada şifre yanlış");
            }


            return View();
        }
    }
}