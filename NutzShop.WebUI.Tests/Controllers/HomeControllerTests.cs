 using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutzShop.Core.Contracts;
using NutzShop.Core.Models;
using NutzShop.Core.ViewModels;
using NutzShop.WebUI;
using NutzShop.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace NutzShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
            // Var
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCategoryContext = new Mocks.MockContext<ProductCategory>();
            HomeController controller = new HomeController(productContext, productCategoryContext);

            // MockContext
            productContext.Insert(new Product());

            // Return
            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel)result.ViewData.Model;

            // Tests
            Assert.AreEqual(1, viewModel.Products.Count());
        }
    }
}
