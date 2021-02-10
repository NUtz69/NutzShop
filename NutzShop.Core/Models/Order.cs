using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.Core.Models
{
    public class Order : BaseEntity
    {
        // Constructor
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Code { get; set; }
        public string OrderStatus { get; set; } // OrderStatus
        public virtual ICollection<OrderItem> OrderItems { get; set; } // Virtual - Get items automatically
    }
}
