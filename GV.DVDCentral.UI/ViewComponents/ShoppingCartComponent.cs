using GV.DVDCentral.BL;
using GV.DVDCentral.UI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GV.DVDCentral.UI.ViewComponents
{
    public class ShoppingCartComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //get the cart
            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return View(HttpContext.Session.GetObject<ShoppingCart>("cart"));
            }
            else
            {
                return View(new ShoppingCart());
            }

        }
    }
}
