
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce_MVC.Areas.Admin.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ECommerce_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        RestClient client;
        private readonly IHostingEnvironment hostingEnvironment;
      
        public ProductController(IHostingEnvironment hostingEnvironment)
        {
             client = new RestClient();
            this.hostingEnvironment = hostingEnvironment;
            
        }
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Product";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<ProductViewModel>>(Responce.Content);
            if (!string.IsNullOrEmpty(search))
            {
                responce = responce.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return View(responce);
        }

        [HttpGet]
        public async Task<IActionResult> ProductTable(string search)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Product";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<ProductViewModel>>(Responce.Content);
            if (!string.IsNullOrEmpty(search))
            {
                responce = responce.Where(x => x.Name.Contains(search)).ToList();
            }
            return View(responce);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product,IFormFile photo, IFormFile[] photos)
        {
            if(photo==null&& photo.Length == 0)
            {
                return Content("File not selected");
            }
            else
            {
                string uniqueFileName = null;
                product.Pictures = new List<string>();

                //string uploadfolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                //uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //string filePath = Path.Combine(uploadfolder, uniqueFileName);
                //photo.CopyTo(new FileStream(filePath, FileMode.Create));
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                var uploadfolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);
              
              //  string filePath = Path.Combine(uploadfolder, uniqueFileName);
                var stream = new FileStream(uploadfolder, FileMode.Create);

                await photo.CopyToAsync(stream);

                product.MainImage = uniqueFileName;
               
                foreach (IFormFile image in photos)
                {
                    string uniqueFileName2 = null;
                     uniqueFileName2 = Guid.NewGuid().ToString() + "_" + image.FileName;

                    var uploadfolder2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images",uniqueFileName2);
                  
                   // string filePath2 = Path.Combine(uploadfolder2, uniqueFileName2);
                    var stream2 = new FileStream(uploadfolder2, FileMode.Create);

                    await image.CopyToAsync(stream2);
                    product.Pictures.Add(uniqueFileName2);
                  
                }
              
            }
            
            RestRequest request = new RestRequest(Method.POST);
            request.Resource = "http://localhost:61909/api/Product";
            request.AddJsonBody(product);
            await client.ExecuteAsync(request, CancellationToken.None);

           

            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {            

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"http://localhost:61909/api/Product/Product/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;
            var product = JsonConvert.DeserializeObject<ProductViewModel>(context);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductViewModel product)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.POST);

            request.Resource = $"http://localhost:61909/api/Product/Product/{id}";
            request.AddJsonBody(product);
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;

            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.GET);

            request.Resource = $"http://localhost:61909/api/Product/Delete/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            string context = Responce.Content;
            var product = JsonConvert.DeserializeObject<ProductViewModel>(context);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Method.POST);

            request.Resource = $"http://localhost:61909/api/Product/Delete/{id}";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Menu";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<MenuViewModel>>(Responce.Content);
            return Json(responce);
        }
        [HttpPost]
        public async Task<IActionResult> GetSubmenuById(int id)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/SubMenu";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            var responce = JsonConvert.DeserializeObject<List<SubMenuViewModel>>(Responce.Content);

            var select = responce.Where(x => x.MenuId == id)
                                              .Select(x => new { x.Id, x.Name }).ToList();

            return Json(select);
        }
        [HttpPost]
        public async Task<IActionResult> GetBrandById(int id)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Brand";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);
            var responce = JsonConvert.DeserializeObject<List<BrandViewModel>>(Responce.Content);

            var select = responce.Where(x => x.SubMenuId == id)
                                          .Select(x => new { x.Id, x.Name }).ToList();
           
            return Json(select);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllColor()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/Color";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<ColorViewModel>>(Responce.Content);
            return Json(responce);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOperationSystem()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/OperationSystem";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<OperationSystemViewModel>>(Responce.Content);
            return Json(responce);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProsessor()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/Prosessor";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<OperationSystemViewModel>>(Responce.Content);
            return Json(responce);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRAM()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/RAM";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<RAMViewModel>>(Responce.Content);
            return Json(responce);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHardDrive()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/HardDrive";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<HardDriveViewModel>>(Responce.Content);
            return Json(responce);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSSD()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/SSD";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<SSDViewModel>>(Responce.Content);
            return Json(responce);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStorage()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/Storage";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<StorageViewModel>>(Responce.Content);
            return Json(responce);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStyleJoin()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/StyleJoin";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<StyleJoinViewModel>>(Responce.Content);
            return Json(responce);
        }
    }
}