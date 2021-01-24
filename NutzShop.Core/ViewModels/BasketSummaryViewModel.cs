using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.Core.ViewModels
{
    public class BasketSummaryViewModel
    {
        // Vars
        public int BasketCount { get; set; }
        public decimal BasketTotal { get; set; }

        // Constructors
        public BasketSummaryViewModel()
        {

        }

        // Constructors - Default
        public BasketSummaryViewModel(int basketCount, decimal basketTotal)
        {
            this.BasketCount = basketCount;
            this.BasketTotal = basketTotal;
        }
    }
}
