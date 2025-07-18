using GV.DVDCentral.BL;

namespace GV.DVDCentral.UI.ViewModels
{
    public class OrderVM
    {

        public Order Order { get; set; }
   

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


        public IEnumerable<int> OrderItemsIds { get; set; }



        public OrderVM(int id) 
        {
            OrderItems = OrderItemManager.Load();
            Order = OrderManager.LoadById(id);

            OrderItemsIds = Order.OrderItems.Select(a => a.Id);

        
        }
    }
}
