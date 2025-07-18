using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GV.DVDCentral.BL.Models
{
    public class Order : ShoppingCart
    {

        [DisplayName("Order #")]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        public DateTime ShipDate { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public int OrderItemsId { get; set; }
        public int MovieId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]

        public double Cost { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]

        ShoppingCart cart = new ShoppingCart();

       // cart.TAX_VALUE;
        public double TotalOrder { get { return Math.Round(OrderItems.Sum(item => item.Cost * item.Quantity) * (cart.TAX_VALUE + 1), 2);  } }

        [DisplayFormat(DataFormatString = "{0:C}")]

        public double SubTotalOrder { get { return OrderItems.Sum(item => item.Cost * item.Quantity); } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TaxOrder { get { return SubTotalOrder * TAX_VALUE; } }



        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerFullName { get { return LastName + ", " + FirstName; } }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        [DisplayName("User Full Name")]

        public string UserFullName { get { return UserLastName + ", " + UserFirstName; } }

    }
}
