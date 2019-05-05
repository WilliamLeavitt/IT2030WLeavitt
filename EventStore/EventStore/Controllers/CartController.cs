using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventStore.Models;

namespace EventStore.Controllers
{
    public class CartController : Controller
    {
        EventStoreDB db = new EventStoreDB();

        // GET: Cart
        public ActionResult Index()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            CartViewModel vm = new CartViewModel()
            {
                CartItems = cart.GetCartItems(),

            };

            return View(vm);
        }

        public ActionResult Summary()
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            CartViewModel vm = new CartViewModel()
            {
                CartItems = cart.GetCartItems(),

            };

            return View(vm);
        }

        //GET: Cart/AddToCart
        public ActionResult AddToCart(int id, int ordered)
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(id, ordered);
            return RedirectToAction("Summary");
        }

        //POST: Cart/RemoveFromCart
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            ShoppingCart cart = ShoppingCart.GetCart(this.HttpContext);

            Event deleted = db.Carts.SingleOrDefault(c => c.RecordId == id).EventSelected;

            cart.RemoveFromCart(id);

            CartRemoveViewModel vm = new CartRemoveViewModel()
            {
                DeleteId = id,
                Message = "Your tickets for " + deleted.Title + " have been removed."
            };

            return Json(vm);
        }
    }
}