using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce_MVC.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ECommerce_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Menu";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<MenuViewModel>>(Responce.Content);

            return View(responce);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuViewModel menu)
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.POST);
            request.Resource = "http://localhost:61909/api/Menu";
            request.AddJsonBody(menu);
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            return RedirectToAction("Index", "Menu", new { area = "Admin" });
         
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:61909/api/Menu/Menu/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;
            var menu = JsonConvert.DeserializeObject<MenuViewModel>(context);
            return View(menu);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,MenuViewModel menu)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.POST);

            request.Resource = $"http://localhost:61909/api/Menu/Menu/{id}";
            request.AddJsonBody(menu);
            var Responce = await client.ExecuteAsync(request,CancellationToken.None);
            string context = Responce.Content;

            return RedirectToAction("Index", "Menu", new { area = "Admin" });

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);

            request.Resource= $"http://localhost:61909/api/Menu/Delete/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;
            var menu = JsonConvert.DeserializeObject<MenuViewModel>(context);

            return View(menu);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.POST);

            request.Resource = $"http://localhost:61909/api/Menu/Delete/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            return RedirectToAction("Index", "Menu", new { area = "Admin" });
        }
    }
}