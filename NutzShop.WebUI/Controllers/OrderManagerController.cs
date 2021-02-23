using NutzShop.Core.Contracts;
using NutzShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutzShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        // Var
        IOrderService orderService;

        // Constructor
        public OrderManagerController(IOrderService OrderService)
        {
            this.orderService = OrderService;
        }

        // GET: OrderManager

        // Index
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrdersList();

            return View(orders);
        }

        // One order - Update
        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created",
                "Payment Processed",
                "Order Shipped",
                "Order Complete"
            };

            Order order = orderService.GetOrder(Id);

            return View(order);
        }

        [HttpPost]
        // Update
        public ActionResult UpdateOrder(Order updateOrder, string Id)
        {
            Order order = orderService.GetOrder(Id);

            order.OrderStatus = updateOrder.OrderStatus;
            orderService.UpdateOrder(order);

            return RedirectToAction("Index");
        }
    }
}