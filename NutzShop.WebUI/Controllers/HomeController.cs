using NutzShop.Core.Contracts;
using NutzShop.Core.Models;
using NutzShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutzShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // Unity

        // Var
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        // Constructors
        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }

        /* Method */

        // ListProduct
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if (Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }

            // Model
            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;

            // return model
            return View(model);
        }


        // ViewProductDetails
        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}