using NutzShop.Core.Contracts;
using NutzShop.Core.Models;
using NutzShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutzShop.Services
{
    public class OrderService : IOrderService
    {
        // Var
        IRepository<Order> orderContext;

        // Constructors
        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem() 
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quanity = item.Quanity
                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }
    }
}
