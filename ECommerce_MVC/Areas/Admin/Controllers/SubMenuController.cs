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
    public class SubMenuController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/SubMenu";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<SubMenuViewModel>>(Responce.Content);

            return View(responce);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubMenuViewModel menu)
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.POST);
            request.Resource = "http://localhost:61909/api/SubMenu";
            request.AddJsonBody(menu);
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            return RedirectToAction("Index", "SubMenu", new { area = "Admin" });

        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Menu";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<MenuViewModel>>(Responce.Content);

            return Json(responce);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:61909/api/SubMenu/SubMenu/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;
            var menu = JsonConvert.DeserializeObject<SubMenuViewModel>(context);
            return View(menu);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SubMenuViewModel menu)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.POST);

            request.Resource = $"http://localhost:61909/api/SubMenu/SubMenu/{id}";
            request.AddJsonBody(menu);
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;

            return RedirectToAction("Index", "SubMenu", new { area = "Admin" });

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);

            request.Resource = $"http://localhost:61909/api/SubMenu/Delete/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;
            var menu = JsonConvert.DeserializeObject<SubMenuViewModel>(context);

            return View(menu);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.POST);

            request.Resource = $"http://localhost:61909/api/SubMenu/Delete/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            return RedirectToAction("Index", "SubMenu", new { area = "Admin" });
        }
    }
}