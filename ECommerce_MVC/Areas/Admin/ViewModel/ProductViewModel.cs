using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_MVC.Areas.Admin.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public int Resource { get; set; }
        public decimal Price { get; set; }
        public string MainImage { get; set; }
        public DateTime Created { get; set; }

        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int Operation_SystemId { get; set; }
        public int RAMId { get; set; }
        public int ProsessorId { get; set; }
        public int HardDriveId { get; set; }
        public int SSDId { get; set; }
        public int StorageId { get; set; }
        public int Style_JoinId { get; set; }
        public List<string> Pictures { get; set; }

    }
}
