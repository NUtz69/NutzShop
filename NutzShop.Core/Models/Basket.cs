using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.Core.Models
{
    public class Basket : BaseEntity
    {
        // Var
        public virtual ICollection<BasketItem> BasketItems { get; set; } // Enity virtual

        // Constructor
        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
