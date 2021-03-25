using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CommerceDbContext _context;

        public UserController(UserManager<AppUser> userManager, CommerceDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Route("Users")]
        
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
        {
            return Ok(await _userManager.Users.ToListAsync());
        }

        [HttpGet("{id}")]
       
        public ActionResult<AppUser> Edit(int? id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);


            if (id == null)
            {
                return NotFound();
            }



            if (user == null)
            {
                return NotFound();
            }
            return user;

        }
        [HttpPost("{id}")]
   
        public AppUser Edit(int id, AppUser appUser)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            user.UserName = appUser.UserName;
            user.AccessFailedCount = appUser.AccessFailedCount;
            user.EmailConfirmed = appUser.EmailConfirmed;
            user.Email = appUser.Email;
            user.LockoutEnabled = appUser.LockoutEnabled;
            user.LockoutEnd = appUser.LockoutEnd;
            user.NormalizedEmail = appUser.NormalizedEmail;
            user.NormalizedUserName = appUser.NormalizedUserName;
            user.PasswordHash = appUser.PasswordHash;
            user.PhoneNumber = appUser.PhoneNumber;
            user.PhoneNumberConfirmed = appUser.PhoneNumberConfirmed;
            user.SecurityStamp = appUser.SecurityStamp;
            user.ConcurrencyStamp = appUser.ConcurrencyStamp;
            //user.TwoFactorEnabled = appUser.TwoFactorEnabled;
            _userManager.UpdateAsync(user).GetAwaiter().GetResult();
            _context.SaveChanges();
            return user;
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            _userManager.DeleteAsync(user).GetAwaiter().GetResult();
            _context.SaveChanges();
            return Ok("Deleted");
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult<AppUser> Delete(int? id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}