using BooksVideoServiceProject.Entities;
using BooksVideoServiceProject.Extensions;
using System;

namespace BooksVideoServiceProject.Services
{
    /// <summary>
    /// The order service
    /// </summary>
    public class OrderService : IOrderService
    {

        private void processAllProducts(Order order, Customer customer)
        {
            MembershipOrder membershipOrder = new MembershipOrder();
            membershipOrder.Process(order, customer);
        }

        private void purchaseAllProducts(Order order, Customer customer)
        {
            ShippingSlipOrder shippingSlipOrder = new ShippingSlipOrder();
            shippingSlipOrder.Process(order, customer);
        }

        /// <summary>
        /// Process the order
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        public void Process(Order order, Customer customer)
        {
            // MembershipOrder membershipOrder = new MembershipOrder();
            // ShippingSlipOrder shippingSlipOrder = new ShippingSlipOrder();

            // membershipOrder.Process(order, customer);
            // shippingSlipOrder.Process(order, customer);
            this.processAllProducts(order, customer);
            this.purchaseAllProducts(order, customer);
        }
    }
}
