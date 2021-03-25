using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.Data;
using E_Commerce_API.Models;
using Microsoft.AspNetCore.Http;
using SignInNS = Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordValidator<AppUser> _passwordValidator;
        private readonly IConfiguration _configuration;
        private readonly List<string> _roles;

        public AccountController(UserManager<AppUser> userManager,
                                      SignInManager<AppUser> signInManager,
                                         IPasswordValidator<AppUser> passwordValidator,
                                          IConfiguration configuration)

        {

            _userManager = userManager;
            _signInManager = signInManager;
            _passwordValidator = passwordValidator;
            _configuration = configuration;
            _roles = new List<string>();
        }
        [HttpGet]
        [Route("Users")]
       // [Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return Ok(await _userManager.Users.ToListAsync());
        }
        [HttpPost]
        [Route("register")]
        public async Task<string> Register(RegisterModel registerModel)
        {
           
              AppUser currentUser = await _userManager.FindByEmailAsync(registerModel.Email);
              if (currentUser == null)
              {
                    AppUser user = new AppUser
                    {
                        UserName = registerModel.Username,
                        Email = registerModel.Email
                    };
                    var identityResult = await _userManager.CreateAsync(user, registerModel.Password);
                
                if (identityResult.Succeeded)
                {
                    var roles = CreateRoles();
                    await _userManager.AddToRoleAsync(user, roles[1]);
                    return "Added";
                }
                else
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return "Emal is already exits";
                }
                
              }
              else
              {
                  ModelState.AddModelError("", "Emal is already exits");
                  return "Emal is already exits";
              }

        }

        [HttpPost]
        [Route("login")]
        public async Task<string> Login(LoginModel loginModel)
        {
            var currentuser =await _userManager.FindByEmailAsync(loginModel.Email);
            var checkPass = _passwordValidator.ValidateAsync(_userManager, currentuser, loginModel.Password);

            if (checkPass != null && checkPass.Result.Succeeded)
            {
                SignInNS.SignInResult signInResult =  await _signInManager.PasswordSignInAsync(currentuser, loginModel.Password, true, false);

                if (signInResult.Succeeded)
                {
                   
                    return "Sing Prosses is okey";
                }
                else
                {
                    return "Email or Password  incorrect";
                }
            }
            else
            {
                return "Email or Password  incorrect";
            }
        }
        [HttpGet]
        [Route("admin")]
        public async Task<ActionResult<AppUser>> GetAdmin()
        {
            string email = _configuration["User:email"];
            AppUser user =await _userManager.FindByEmailAsync(email);
            return user;
            
        }
        public List<string> CreateRoles()
        {
            var roles = _configuration.GetSection("Roles").Value.Split(",");
            foreach (var role in roles)
            {
                _roles.Add(role);
            }
            return _roles;
        }
    }
}
