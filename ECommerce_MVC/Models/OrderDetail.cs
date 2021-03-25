using ECommerce_MVC.Areas.Admin.ViewModel;

namespace ECommerce_MVC.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }
    }
}