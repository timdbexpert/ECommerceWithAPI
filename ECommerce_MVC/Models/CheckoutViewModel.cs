using ECommerce_MVC.Areas.Admin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_MVC.Models
{
    public class CheckoutViewModel
    {
        public List<ProductViewModel> CartProducts { get; set; }
        public List<int> CartProductsID { get; set; }
    }
}
