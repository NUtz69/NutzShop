using NutzShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutzShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        // Var
        IBasketService basketService;

        // Constructors
        public BasketController(IBasketService BasketService)
        {
            this.basketService = BasketService;
        }

        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext); // List for BasketItem

            return View(model);
        }

        // AddToBasket
        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);

            //return View();
            return RedirectToAction("Index");
        }

        // RemoveFromBasket
        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        // PartialViewResult BasketSummary
        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }
    }
}