using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutzShop.Core.Contracts;
using NutzShop.Core.Models;
using NutzShop.Core.ViewModels;
using NutzShop.Services;
using NutzShop.WebUI.Controllers;
using NutzShop.WebUI.Tests.Mocks;
using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;

namespace NutzShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class BasketControllerTests
    {
        // CanAddBasketItem
        [TestMethod]
        public void CanAddBasketItem()
        {
            // Var - Setup
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Product> products = new MockContext<Product>();
            IRepository<Order> orders = new MockContext<Order>(); // Order
            IRepository<Customer> customers = new MockContext<Customer>(); // Customer

            // MockContext
            var httpContext = new MockHttpContext();

            // Service
            IBasketService basketService = new BasketService(products, baskets);
            IOrderService orderService = new OrderService(orders); // Order
            var controller = new BasketController(basketService, orderService, customers);
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            // Act - Add something to the basket
            // basketService.AddToBasket(httpContext, "1");
            controller.AddToBasket("1");

            // Collection
            Basket basket = baskets.Collection().FirstOrDefault();

            // Assert - Tests
            Assert.IsNotNull(basket);
            Assert.AreEqual(1, basket.BasketItems.Count);
            Assert.AreEqual("1", basket.BasketItems.ToList().FirstOrDefault().ProductId);
        }

        // CanGetSummaryViewModel
        [TestMethod]
        public void CanGetSummaryViewModel()
        {
            // Var - Setup
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Product> products = new MockContext<Product>();
            IRepository<Order> orders = new MockContext<Order>(); // Order
            IRepository<Customer> customers = new MockContext<Customer>(); // Customer

            // GetSummary
            products.Insert(new Product() { Id = "1", Price = 10.00m }); // Products DB
            products.Insert(new Product() { Id = "2", Price = 5.00m });

            // Create basket
            Basket basket = new Basket();
            basket.BasketItems.Add(new BasketItem() { ProductId = "1", Quanity = 2 });
            basket.BasketItems.Add(new BasketItem() { ProductId = "2", Quanity = 1 });
            baskets.Insert(basket);

            // Service
            IBasketService basketService = new BasketService(products, baskets);
            IOrderService orderService = new OrderService(orders); // Order
            var controller = new BasketController(basketService, orderService, customers);

            // MockContext
            var httpContext = new MockHttpContext();

            // Cookies
            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value = basket.Id });
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            // Return
            var result = controller.BasketSummary() as PartialViewResult;
            var basketSummary = (BasketSummaryViewModel)result.ViewData.Model;

            // Assert
            Assert.AreEqual(3, basketSummary.BasketCount);
            Assert.AreEqual(25.00m, basketSummary.BasketTotal);
        }

        // CanCheckoutAndCreateOrder
        [TestMethod]
        public void CanCheckoutAndCreateOrder()
        {
            // Product
            IRepository<Customer> customers = new MockContext<Customer>(); // Customer
            IRepository<Product> products = new MockContext<Product>();
            products.Insert(new Product() { Id = "1", Price = 10.00m });
            products.Insert(new Product() { Id = "2", Price = 5.00m });

            // Basket
            IRepository<Basket> baskets = new MockContext<Basket>();
            Basket basket = new Basket();
            basket.BasketItems.Add(new BasketItem() { ProductId = "1", Quanity = 2, BasketId = basket.Id });
            basket.BasketItems.Add(new BasketItem() { ProductId = "1", Quanity = 1, BasketId = basket.Id });
            
            baskets.Insert(basket);

            IBasketService basketService = new BasketService(products, baskets);

            // Order
            IRepository<Order> orders = new MockContext<Order>();
            IOrderService orderService = new OrderService(orders);

            // Customer
            customers.Insert(new Customer() { Id="1", Email="nutz@nutz.be", Code="7850" });
            IPrincipal FakeUser = new GenericPrincipal(new GenericIdentity("nutz@nutz.be", "Forms"), null); // Db

            // Controller
            var controller = new BasketController(basketService, orderService, customers);
            // Fake context cookies
            var httpContext = new MockHttpContext();
            // Manually cookie
            httpContext.User = FakeUser; // Customer
            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value = basket.Id });         
            // Finally
            controller.ControllerContext = new ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            // Act 
            Order order = new Order();
            controller.Checkout(order);

            // Assert
            Assert.AreEqual(2, order.OrderItems.Count);
            Assert.AreEqual(0, basket.BasketItems.Count); // Clear - empty

            // Retrive the order
            Order orderInRep = orders.Find(order.Id);
            Assert.AreEqual(2, orderInRep.OrderItems.Count);
        }
    }
}
