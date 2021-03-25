using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ECommerce_MVC.Controllers
{
 
    public class AccountController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
 
     
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                RestClient client = new RestClient();
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = "http://localhost:61909/api/Account/register";
                request.AddJsonBody(registerModel);
                var Responce = await client.ExecuteAsync(request, CancellationToken.None);
                var responce = JsonConvert.DeserializeObject<string>(Responce.Content);
                ModelState.AddModelError("",responce);
                return View();
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                RestClient client = new RestClient();
                RestRequest request = new RestRequest(Method.POST);
                request.Resource = "http://localhost:61909/api/Account/login";
                request.AddJsonBody(loginModel);
                var Responce = await client.ExecuteAsync(request, CancellationToken.None);
                var responce = JsonConvert.DeserializeObject<string>(Responce.Content);
                if(responce== "Email or Password  incorrect")
                {
                    ModelState.AddModelError("", responce);
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Shop"/*, new { Area = "Admin" }*/);
                }
            }
            else
            {
                return View();
            }
        }
    }
}