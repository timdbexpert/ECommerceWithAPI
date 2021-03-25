using ECommerce_MVC.Areas.Admin.ViewModel;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using X.PagedList;

namespace ECommerce_MVC.Data
{
    public class ProductService
    {
        RestClient client;
        public ProductService()
        {
            client = new RestClient();
        }

        public async Task<List<ProductViewModel>> GetProducts()
        {
            
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Product";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<ProductViewModel>>(Responce.Content);

            // return responce.OrderBy(x => x.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            return responce.ToList();
            
        }
        public async Task<List<BrandViewModel>> GetBrands()
        {

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Brand";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<BrandViewModel>>(Responce.Content);

            return responce.ToList();
            
        }

        public async Task<List<ColorViewModel>> GetColor()
        {

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/Color";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<ColorViewModel>>(Responce.Content);

            return responce.ToList();

        }

        public async Task<List<HardDriveViewModel>> GetAllHardDrive()
        {

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/HardDrive";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<HardDriveViewModel>>(Responce.Content);

            return responce.ToList();

        }

        public async Task<List<OperationSystemViewModel>> GetAllOperationSystem()
        {

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/OperationSystem";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<OperationSystemViewModel>>(Responce.Content);

            return responce.ToList();

        }

        public async Task<List<ProsessorViewModel>> GetAllProsessor()
        {

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/Prosessor";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<ProsessorViewModel>>(Responce.Content);

            return responce.ToList();

        }

        public async Task<List<RAMViewModel>> GetAllRAM()
        {

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/RAM";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<RAMViewModel>>(Responce.Content);

            return responce.ToList();

        }

        public async Task<List<SSDViewModel>> GetAllSSD()
        {

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/SSD";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<SSDViewModel>>(Responce.Content);

            return responce.ToList();

        }

        public async Task<List<StorageViewModel>> GetAllStorage()
        {

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/Storage";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<StorageViewModel>>(Responce.Content);

            return responce.ToList();

        }
        public async Task<List<StyleJoinViewModel>> GetAllStyleJoin()
        {

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = "http://localhost:61909/api/Option/StyleJoin";
            var Responce = await client.ExecuteAsync(request, CancellationToken.None);

            var responce = JsonConvert.DeserializeObject<List<StyleJoinViewModel>>(Responce.Content);

            return responce.ToList();

        }

       
    }
}
