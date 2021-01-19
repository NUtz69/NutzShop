using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.Core.Models
{
    public class BasketItem : BaseEntity
    {
        // Var
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quanity { get; set; }
    }
}
