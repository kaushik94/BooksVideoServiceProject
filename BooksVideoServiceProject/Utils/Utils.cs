using BooksVideoServiceProject.Entities;
using System;

namespace BooksVideoServiceProject.Utils
{
    /// <summary>
    /// The order service
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Process the order
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        public string GenerateShippingSlip(Order order, OrderLine order_line, Customer customer)
        {
            string shipping_slip = "";
            shipping_slip += "Customer Id:";
            shipping_slip += customer.Id + "\n";

            shipping_slip += "Order Id:";
            shipping_slip += order.Id + "\n";

            shipping_slip += "Item:";
            shipping_slip += order_line.Line + "\n";

            shipping_slip += "Address:\n";
            shipping_slip += customer.ShippingAddress;

            return shipping_slip;
        }
    }
}
