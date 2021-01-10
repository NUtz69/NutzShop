using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.Core.Models
{
    public class ProductCategory
    {
        // Var
        public string Id { get; set; }
        public string Category { get; set; }

        // Constructors
        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
