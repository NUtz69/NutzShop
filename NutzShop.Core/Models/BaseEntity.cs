using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.Core.Models
{
    public abstract class BaseEntity
    {
        // Var
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        // Constructors
        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }
    }
}
