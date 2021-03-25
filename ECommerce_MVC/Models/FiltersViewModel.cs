using ECommerce_MVC.Areas.Admin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace ECommerce_MVC.Models
{
    public class FiltersViewModel
    {

        public List<ColorViewModel> Colors { get; set; }
        public List<OperationSystemViewModel> Operation_Systems { get; set; }
        public List<RAMViewModel> RAMs { get; set; }
        public List<BrandViewModel> Brands { get; set; }
        public List<SSDViewModel> SSDs { get; set; }
        public List<ProsessorViewModel> Prosessors { get; set; }
        public List<HardDriveViewModel> HardDrives { get; set; }
        public List<StorageViewModel> Storages { get; set; }
        public List<StyleJoinViewModel> Style_Joins { get; set; }
        public IPagedList<ProductViewModel> Products { get; set; }
        public List<ProductViewModel> ProductsVithoutPage { get; set; }
        public List<PictureViewModel> Pictures { get; set; }
        public ProductViewModel Product { get; set; }
        public int? SubMenuId { get; set; }
        public string Search { get; set; }
        public int detected { get; set; }
    }
}
