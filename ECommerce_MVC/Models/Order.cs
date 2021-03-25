using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_MVC.Models
{
    public class Order
    {
        public string UserID { get; set; }
        public DateTime OrderedAt { get; set; }
        public string Status { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
