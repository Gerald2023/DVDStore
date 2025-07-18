using GV.DVDCentral.BL.Models;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GV.DVDCentral.BL
{
    public class ShoppingCartManager
    {
        public static void Add(ShoppingCart cart, Movie movie)
        {
            if (cart != null)
            {

                Movie currentMovie = cart.Items.FirstOrDefault(i => i.Id == movie.Id);

                if (currentMovie != null)
                {

                    currentMovie.Quantity += 1;

                   





                }

                else
                {
                    cart.Items.Add(movie);

                }

            }


        }

        public static void Remove(ShoppingCart cart, Movie movie)
        {
            if (cart != null) { cart.Items.Remove(movie); }
        }

        public static void Checkout(ShoppingCart cart, int customerId, int userId)
        {
            try
            {
                if(cart != null && cart.Items.Count > 0)
                {
                    // Create an Order
                    Order order = new Order
                    {
                        CustomerId = 1,
                        UserId = 1,
                        OrderDate = DateTime.Now,
                        ShipDate = DateTime.Now.AddDays(3),

                    };

                    // Insert the Order into the database
                    int orderId = 0;
                    OrderManager.Insert(order.CustomerId, order.UserId, ref orderId);

                    // Update the orderId in the Order object
                    order.Id = orderId;

                    // 1 to many OrderItems
                    foreach (Movie item in cart.Items)
                    {
                        // OrderItem.Quantity should be set to 1.

                        // Create a new order item
                        OrderItem orderItem = new OrderItem
                        {
                            OrderId = order.Id, // Now you have the correct orderId
                            MovieId = item.Id,
                            Quantity = item.Quantity,
                            Cost = item.Cost,
                        };

                        // Insert the OrderItem into the database
                        int orderItemId = 0;
                        OrderItemManager.Insert(orderItem.OrderId, orderItem.MovieId, orderItem.Quantity, orderItem.Cost, ref orderItemId);

                        // Add the OrderItem to the Order
                        order.OrderItems.Add(orderItem);
                    }

                    //  Clear out the Shopping Cart object
                    cart.Items.Clear();

                }
                else {                     throw new Exception("Shopping Cart is empty");
                              
                
                }
  
                  

        


               
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
