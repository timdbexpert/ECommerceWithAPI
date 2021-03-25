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
    public class BrandController : Controller
    {
        public async Task<IActionResult> Index()
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Brand";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<BrandViewModel>>(Responce.Content);

            return View(responce);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel brand)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.POST);
            request.Resource = $"http://localhost:61909/api/Brand";

            request.AddJsonBody(brand);
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            return RedirectToAction("Index", "Brand", new { area = "Admin" });
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

        [HttpPost]
        public async Task<IActionResult> GetSubMenuById(int id)
        {
            RestClient client = new RestClient();

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:61909/api/SubMenu";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<SubMenuViewModel>>(Responce.Content);

            var select = responce.Where(x => x.MenuId == id).Select(x => new { x.Id, x.Name }).ToList();

            return Json(select);
        }

    }

  
}