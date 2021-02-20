using NutzShop.Core.Models;
using NutzShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.Core.Contracts
{
    public interface IOrderService
    {
        // CreateOrder
        void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems);

        // Admin
        List<Order> GetOrdersList();
        Order GetOrder(string Id);
        void UpdateOrder(Order updateOrder);
    }
}
