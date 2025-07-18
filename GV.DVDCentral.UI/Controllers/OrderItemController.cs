using GV.DVDCentral.BL;
using Microsoft.AspNetCore.Mvc;

namespace GV.DVDCentral.UI.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of All OrderItems";

            return View(OrderItemManager.Load());
        }



        public IActionResult Delete(int id)
        {
            var item = OrderItemManager.LoadById(id);
            ViewBag.Title = "Delete ";
            return View(item);
        }


        [HttpPost]
        public IActionResult Delete(int id, Order order, bool rollback = false)
        {
            try
            {
                int result = OrderItemManager.Delete(id, rollback);
                return RedirectToAction("Index", "Order");
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View(order);
            }
        }

    }
}
