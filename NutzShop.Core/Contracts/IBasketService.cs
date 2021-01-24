using NutzShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NutzShop.Core.Contracts
{
    public interface IBasketService
    {
        // AddToBasket
        void AddToBasket(HttpContextBase httpContext, string productId);
        // RemoveFromBasket
        void RemoveFromBasket(HttpContextBase httpContext, string itemId);
        // GetBasketItems
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        // BasketSummaryViewModel
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
    }
}
