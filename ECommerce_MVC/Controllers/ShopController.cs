using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce_MVC.Areas.Admin.ViewModel;
using ECommerce_MVC.Data;
using ECommerce_MVC.Helper;
using ECommerce_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using X.PagedList;
namespace ECommerce_MVC.Controllers
{
    public class ShopController : Controller
    {
        RestClient client;
        List<string> products;
        public ShopController()
        {
            client = new RestClient();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Product(int? id, string searchProduct, int? page,List<ProductViewModel> productss)
        {
            int pageSize = 10;
            var pageNumber = page ?? 1;

            FiltersViewModel model = new FiltersViewModel();

            model.SubMenuId = id;
            model.Search = searchProduct;
            
            model.detected = 0;
            if (searchProduct!=null)
            {
                model.detected = 1;
            }

            ProductService productService = new ProductService();
            

            var products = await productService.GetProducts();
            var brands = await productService.GetBrands();
            var colors = await productService.GetColor();
            var ssds = await productService.GetAllSSD();
            var hardDrives = await productService.GetAllHardDrive();
            var operationSystems = await productService.GetAllOperationSystem();
            var prosessors = await productService.GetAllProsessor();
            var rams = await productService.GetAllRAM();
            var storages = await productService.GetAllStorage();
            var styleJoin = await productService.GetAllStyleJoin();

            #region Filters 
            //RestRequest request = new RestRequest(Method.GET);
            //request.Resource = "http://localhost:61909/api/Product/Filters";
            //var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            //var responce = JsonConvert.DeserializeObject<FiltersViewModel>(Responce.Content);
            #endregion

            model.Brands = brands.Where(x => x.SubMenuId == id).ToList();

            model.Colors = colors.ToList();
            model.HardDrives = hardDrives.ToList();
            model.Operation_Systems = operationSystems.ToList();
            model.Prosessors = prosessors.ToList();
            model.SSDs = ssds.ToList();
            model.RAMs = rams.ToList();
            model.Storages = storages.ToList();
            model.Style_Joins = styleJoin.ToList();


            if (!string.IsNullOrEmpty(searchProduct))
            {
                var selectedProduct = products.Where(x => x.Name.ToLower().Contains(searchProduct.ToLower())).ToList().ToPagedList(pageNumber, 12);
                model.Products = selectedProduct;
            }

            else
            {
                var selectedProduct = products.Where(x => x.Resource == id).ToList().ToPagedList(pageNumber, 12);
                model.Products = selectedProduct;
            }
            
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Product( int submenuId , int[] brandId, int[] storageId, int[] ramId, int[] colorId,int[] ssdId,int[] prosessorId, int[] opsystemId, int[] harddriveId, int[] stylejoinId)
        {

               
            FiltersViewModel model = new FiltersViewModel();

            ProductService productService = new ProductService();

            var products = await productService.GetProducts();
            List<ProductViewModel> productViews = new List<ProductViewModel>();

            model.ProductsVithoutPage = products;


            productViews = await GetProduct(submenuId,brandId, storageId, ramId, colorId, ssdId, prosessorId, opsystemId, harddriveId, stylejoinId);
            model.ProductsVithoutPage = productViews;

            if (brandId.Count() == 0 && storageId.Count() == 0 && ramId.Count() == 0 && colorId.Count() == 0 && ssdId.Count() == 0 && prosessorId.Count() == 0 && opsystemId.Count() == 0 && harddriveId.Count() == 0 && stylejoinId.Count() == 0)
            {
                model.ProductsVithoutPage = products.Where(x => x.Resource == submenuId).ToList();
            }

            return PartialView("_ProductPartialView", model); 
         
        }


        [HttpGet]
        public async Task<IActionResult> InfoProduct(int id)
        {
            RestRequest request = new RestRequest();
            request.Resource = "http://localhost:61909/api/Product/Pictures";

            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<PictureViewModel>>(Responce.Content);

            //////////////////////////////////////////////////////////////////////////
            request.Resource = "http://localhost:61909/api/Product";
            var Responce3 = await client.ExecuteAsync(request, CancellationToken.None);

            var responce3 = JsonConvert.DeserializeObject<List<ProductViewModel>>(Responce3.Content);
            /////////////////////////////////////////////////////////////////////////////
            ///
            request.Resource = "http://localhost:61909/api/Product/Filters";
            var Responce2 = await client.ExecuteAsync(request, CancellationToken.None);

            var responce2 = JsonConvert.DeserializeObject<FiltersViewModel>(Responce2.Content);
            var selectedPictures = responce.Where(x => x.ProductId == id).ToList();

            responce2.Pictures = selectedPictures;
            responce2.Product = responce3.Where(x => x.Id == id).FirstOrDefault();


            return View(responce2);
        }



        [HttpGet]
        public async Task<IActionResult> ProductCart()
        {
            CheckoutViewModel model = new CheckoutViewModel();

            products = new List<string>();
            RestRequest request = new RestRequest();
            request.Resource = "http://localhost:61909/api/Product";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<ProductViewModel>>(Responce.Content);


            var CartProductsCookie = Request.Cookies["ProductCart"];
            if (CartProductsCookie != null)
            {
               
                model.CartProductsID = CartProductsCookie.Split("-").Select(x => int.Parse(x)).ToList();
                model.CartProducts = responce.Where(x => model.CartProductsID.Contains(x.Id)).ToList();
            }

            return View(model);
        }

      

        public static async Task<List<ProductViewModel>> GetProduct(int submenuId, int[] brandId, int[] storageId, int[] ramId, int[] colorId,int[] ssdId, int[] prosessorId, int[] opsystemId, int[] harddriveId, int[] stylejoinId)
        {
            FiltersViewModel model = new FiltersViewModel();

            ProductService productService = new ProductService();

            var products = await productService.GetProducts();

            List<ProductViewModel> productViews = new List<ProductViewModel>();

            List<ProductViewModel> listbrand = new List<ProductViewModel>();
            List<ProductViewModel> listram = new List<ProductViewModel>();
            List<ProductViewModel> listcolor = new List<ProductViewModel>();
            List<ProductViewModel> liststorage = new List<ProductViewModel>();
            List<ProductViewModel> listssd = new List<ProductViewModel>();
            List<ProductViewModel> listprosessor = new List<ProductViewModel>();
            List<ProductViewModel> listopsystem = new List<ProductViewModel>();
            List<ProductViewModel> listharddrive = new List<ProductViewModel>();
            List<ProductViewModel> liststylejoin = new List<ProductViewModel>();


            model.ProductsVithoutPage = products.Where(x=>x.Resource==submenuId).ToList();
            #region Brand
            if (brandId.Count() == 1)
            {
                foreach (var item in brandId)
                {
                    productViews = model.ProductsVithoutPage.Where(x => x.BrandId == item).ToList();
                    //productViews.AddRange(list);
                }
            }

            if (brandId.Count() > 1)
            {
                foreach (var item in brandId)
                {
                    listbrand = model.ProductsVithoutPage.Where(x => x.BrandId == item).ToList();
                    productViews.AddRange(listbrand);
                }
            }
            #endregion

            #region Prosessor
            if (prosessorId.Count() == 1)
            {
                if (brandId.Count() == 0 )
                {
                    foreach (var item in prosessorId)
                    {
                        productViews = model.ProductsVithoutPage.Where(x => x.ProsessorId == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in prosessorId)
                    {
                        productViews = productViews.Where(x => x.ProsessorId == item).ToList();
                    }
                }

            }

            if (prosessorId.Count() > 1)
            {
                if (brandId.Count() == 0 )
                {
                    foreach (var item in prosessorId)
                    {
                        listprosessor = model.ProductsVithoutPage.Where(x => x.ProsessorId == item).ToList();
                        productViews.AddRange(listprosessor);
                    }
                }
                else
                {
                    foreach (var item in prosessorId)
                    {
                        listprosessor.AddRange(productViews.Where(x => x.ProsessorId == item));

                    }
                    productViews = listprosessor;
                }

            }
            #endregion

            #region Hard Drive

            if (harddriveId.Count() == 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count() == 0)
                {
                    foreach (var item in harddriveId)
                    {
                        productViews = model.ProductsVithoutPage.Where(x => x.HardDriveId == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in harddriveId)
                    {
                        productViews = productViews.Where(x => x.HardDriveId == item).ToList();
                    }
                }

            }

            if (harddriveId.Count() > 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count() == 0)
                {
                    foreach (var item in harddriveId)
                    {
                        listharddrive = model.ProductsVithoutPage.Where(x => x.HardDriveId == item).ToList();
                        productViews.AddRange(listharddrive);
                    }
                }
                else
                {
                    foreach (var item in harddriveId)
                    {
                        listharddrive.AddRange(productViews.Where(x => x.HardDriveId == item));

                    }
                    productViews = listharddrive;
                }

            }

            #endregion

            #region RAM

            if (ramId.Count() == 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count() == 0 && harddriveId.Count()==0) 
                {
                    foreach (var item in ramId)
                    {
                        productViews = model.ProductsVithoutPage.Where(x => x.RAMId == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in ramId)
                    {
                        productViews = productViews.Where(x => x.RAMId == item).ToList();
                    }
                }

            }

            if (ramId.Count() > 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count() == 0 && harddriveId.Count() == 0)
                {
                    foreach (var item in ramId)
                    {
                        listram = model.ProductsVithoutPage.Where(x => x.RAMId == item).ToList();
                        productViews.AddRange(listram);
                    }
                }
                else
                {
                    foreach (var item in ramId)
                    {
                        listram.AddRange(productViews.Where(x => x.RAMId == item));

                    }
                    productViews = listram;
                }

            }

            #endregion

            #region Operation System

            if (opsystemId.Count() == 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count() == 0 && harddriveId.Count() == 0 && ramId.Count()==0)
                {
                    foreach (var item in opsystemId)
                    {
                        productViews = model.ProductsVithoutPage.Where(x => x.Operation_SystemId == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in opsystemId)
                    {
                        productViews = productViews.Where(x => x.Operation_SystemId == item).ToList();
                    }
                }

            }

            if (opsystemId.Count() > 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count() == 0 && harddriveId.Count() == 0 && ramId.Count() == 0)
                {
                    foreach (var item in opsystemId)
                    {
                        listopsystem = model.ProductsVithoutPage.Where(x => x.Operation_SystemId == item).ToList();
                        productViews.AddRange(listopsystem);
                    }
                }
                else
                {
                    foreach (var item in opsystemId)
                    {
                        listopsystem.AddRange(productViews.Where(x => x.Operation_SystemId == item));

                    }
                    productViews = listopsystem;
                }

            }

            #endregion

            #region Storage
            if (storageId.Count() == 1)
            {
                if (brandId.Count() == 0 && ramId.Count() == 0 )
                {
                    foreach (var item in storageId)
                    {
                        productViews = model.ProductsVithoutPage.Where(x => x.StorageId == item).ToList();
                        // productViews.AddRange(list);
                    }
                }
                else
                {
                    foreach (var item in storageId)
                    {
                        productViews = productViews.Where(x => x.StorageId == item).ToList();
                        //productViews.AddRange(list);
                    }
                }

            }

            if (storageId.Count() > 1)
            {
                if (brandId.Count() == 0 && ramId.Count() == 0)
                {
                    foreach (var item in storageId)
                    {
                        liststorage = model.ProductsVithoutPage.Where(x => x.StorageId == item).ToList();
                        productViews.AddRange(liststorage);
                    }
                }
                else
                {
                    foreach (var item in storageId)
                    {
                        liststorage.AddRange(productViews.Where(x => x.StorageId == item).ToList());

                    }
                    productViews = liststorage;
                }


            }
            #endregion

            #region SSD

            if (ssdId.Count() == 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count() == 0 && harddriveId.Count() == 0 && ramId.Count() == 0 && opsystemId.Count() == 0)
                {
                    foreach (var item in ssdId)
                    {
                        productViews = model.ProductsVithoutPage.Where(x => x.SSDId == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in ssdId)
                    {
                        productViews = productViews.Where(x => x.SSDId == item).ToList();
                    }
                }

            }

            if (ssdId.Count() > 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count() == 0 && harddriveId.Count() == 0 && ramId.Count() == 0 && opsystemId.Count() == 0)
                {
                    foreach (var item in ssdId)
                    {
                        listssd = model.ProductsVithoutPage.Where(x => x.SSDId == item).ToList();
                        productViews.AddRange(listssd);
                    }
                }
                else
                {
                    foreach (var item in ssdId)
                    {
                        listssd.AddRange(productViews.Where(x => x.SSDId == item));

                    }
                    productViews = listssd;
                }

            }

            #endregion

            #region Style Join

            if (stylejoinId.Count() == 1)
            {
                if (brandId.Count() == 0 )
                {
                    foreach (var item in stylejoinId)
                    {
                        productViews = model.ProductsVithoutPage.Where(x => x.Style_JoinId == item).ToList();
                    }
                }
                else
                {
                    foreach (var item in stylejoinId)
                    {
                        productViews = productViews.Where(x => x.Style_JoinId == item).ToList();
                    }
                }

            }

            if (stylejoinId.Count() > 1)
            {
                if (brandId.Count() == 0 )
                {
                    foreach (var item in stylejoinId)
                    {
                        liststylejoin = model.ProductsVithoutPage.Where(x => x.Style_JoinId == item).ToList();
                        productViews.AddRange(liststylejoin);
                    }
                }
                else
                {
                    foreach (var item in stylejoinId)
                    {
                        liststylejoin.AddRange(productViews.Where(x => x.Style_JoinId == item));

                    }
                    productViews = liststylejoin;
                }

            }

            #endregion

            #region Color
            if (colorId.Count() == 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count()==0 && ramId.Count() == 0 && storageId.Count() == 0 && harddriveId.Count() == 0 && ssdId.Count() == 0 && opsystemId.Count() == 0 && stylejoinId.Count()==0)
                {
                    foreach (var item in colorId)
                    {
                        productViews = model.ProductsVithoutPage.Where(x => x.ColorId == item).ToList();
                        //productViews.AddRange(list);
                    }
                }
                else
                {
                    foreach (var item in colorId)
                    {
                        productViews = productViews.Where(x => x.ColorId == item).ToList();
                        // productViews.AddRange(list);
                    }
                }

            }

            if (colorId.Count() > 1)
            {
                if (brandId.Count() == 0 && prosessorId.Count() == 0 && ramId.Count() == 0 && storageId.Count() == 0 && harddriveId.Count() == 0 && ssdId.Count() == 0 && opsystemId.Count() == 0)
                {
                    foreach (var item in colorId)
                    {
                        listcolor = model.ProductsVithoutPage.Where(x => x.ColorId == item).ToList();
                        productViews.AddRange(listcolor);
                    }
                }
                else
                {
                    foreach (var item in colorId)
                    {
                        listcolor.AddRange(productViews.Where(x => x.ColorId == item).ToList());

                    }
                    productViews = listcolor;
                }

            }
            #endregion
            
            return productViews;

        }
    
        public IActionResult PlaceOrder(string productsIds,string quantities)
        {
            return View();
        }
    }
}
