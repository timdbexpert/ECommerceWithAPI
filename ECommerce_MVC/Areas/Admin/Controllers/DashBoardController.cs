using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce_MVC.Attribute;
using ECommerce_MVC.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ECommerce_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]      
    public class DashBoardController : Controller
    {   

        [HttpGet]       
        public async Task< IActionResult> Index()
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/User/users";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<AppUser>>(Responce.Content);

            return View(responce);
            
        }

        [HttpGet]
        
        public async Task<IActionResult> Edit(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:61909/api/User/{id}";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;
            var user = JsonConvert.DeserializeObject<AppUser>(context);
            return View(user);
        }

        [HttpPost]    
        public async Task<IActionResult> Edit(int id,AppUser appUser)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.POST);
            request.Resource = $"http://localhost:61909/api/User/{id}";
            request.AddJsonBody(appUser);
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;
            var user = JsonConvert.DeserializeObject<AppUser>(context);
            return View(user);
        }

        [HttpPost]       
        public async Task<IActionResult> Delete(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.POST);
            request.Resource = $"http://localhost:61909/api/User/Delete/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }


        [HttpGet]
        
        public async Task<IActionResult> Delete(int? id)
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:61909/api/User/Delete/{id}";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;

            var user = JsonConvert.DeserializeObject<AppUser>(context);
            return View(user);
               
        }
    }
     
}