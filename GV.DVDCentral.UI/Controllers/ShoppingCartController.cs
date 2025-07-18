using GV.DVDCentral.BL;
using GV.DVDCentral.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace GV.DVDCentral.UI.Controllers
{
    public class ShoppingCartController : Controller
    {


        ShoppingCart cart;
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            ViewBag.Title = "Shopping Cart";
            cart = GetShoppingCart();

            return View(cart);
        }

        private ShoppingCart GetShoppingCart()
        {
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return HttpContext.Session.GetObject<ShoppingCart>("cart");
            }
            else
            {
                return new ShoppingCart();
            }
        }

        public IActionResult Remove(int id)
        {
            cart = GetShoppingCart();
            Movie movie = cart.Items.FirstOrDefault(i => i.Id == id); //get id // not database related
            ShoppingCartManager.Remove(cart, movie); // removes from the cart. This hits 0 times the database.not database related

            HttpContext.Session.SetObject("cart", cart); // reset the session. This hits 0 tmes the database. not database related
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add(int id)
        {
            cart = GetShoppingCart();
            Movie movie = MovieManager.LoadById(id); // get the existing id
            ShoppingCartManager.Add(cart, movie); // removes from the cart

            HttpContext.Session.SetObject("cart", cart); // reset the session
            return RedirectToAction(nameof(Index), "Movie"); // stay on the index page to add a movie
        }


        public IActionResult Checkout(int customerId, int userId)
        {
            cart = GetShoppingCart();
            ShoppingCartManager.Checkout(cart, customerId, userId);
            HttpContext.Session.SetObject("cart", null);
            return View();

        }

    }
}
