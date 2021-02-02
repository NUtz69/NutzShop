using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutzShop.Core.Contracts;
using NutzShop.Core.Models;
using NutzShop.Core.ViewModels;
using NutzShop.Services;
using NutzShop.WebUI.Controllers;
using NutzShop.WebUI.Tests.Mocks;
using System;
using System.Linq;
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

            // MockContext
            var httpContext = new MockHttpContext();

            // Service
            IBasketService basketService = new BasketService(products, baskets);
            var controller = new BasketController(basketService);
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
            var controller = new BasketController(basketService);

            // MockContext
            var httpContext = new MockHttpContext();

            // Cookies
            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value=basket.Id });
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            // Return
            var result = controller.BasketSummary() as PartialViewResult;
            var basketSummary = (BasketSummaryViewModel)result.ViewData.Model;

            // Assert
            Assert.AreEqual(3, basketSummary.BasketCount);
            Assert.AreEqual(25.00m, basketSummary.BasketTotal);
        }
    }
}
