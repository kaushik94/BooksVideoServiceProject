using BooksVideoServiceProject.Entities;
using BooksVideoServiceProject.Services;
using BooksVideoServiceProject.Utils;
using System;

namespace BooksVideoServiceProject.Extensions
{
    /// <summary>
    /// The shipping slip order
    /// </summary>
    public class ShippingSlipOrder: IOrderService
    {
        /// <summary>
        /// To process customer order for slipping line
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        public void Process(Order order, Customer customer)
        {
            this.CreateShippingSlipWhereApplicable(order, customer);
            this.PurchaseAll(order, customer);
        }

        private int getPointsForType(String type)
        {
            if (type == "book")
            {
                return 5;
            }
            if (type == "video")
            {
                return 5;
            }

            return 0;
        }

        private int CheckMembershipAndAddBonus(string type, Customer customer)
        {
            // if customer has that membership
            if (customer.memberships.Contains(type))
            {
                return this.getPointsForType(type);
            }
            return 0;
        }

        private void Purchase(Product product, Customer customer) {
            int bonus = this.CheckMembershipAndAddBonus(product.type, customer);
            customer.AddPoints(bonus);
        }

        /// <summary>
        /// Purchase all products in the Order
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        private void PurchaseAll(Order order, Customer customer)
        {
            foreach (var item in order.OrderLines)
            {
                Product product = new Product(item.Line);
                if (product.isPhysicalOrder()) {
                    this.Purchase(product, customer);
                }
            }
        }

        /// <summary>
        /// Check if shiipping slip is applicable or not
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        private void CreateShippingSlipWhereApplicable(Order order, Customer customer)
        {
            foreach (var item in order.OrderLines)
            {
                Product product = new Product(item.Line);
                if (product.isPhysicalOrder()) {
                    this.CreateShippingSlip(item, order, customer);
                }
            }
        }

        /// <summary>
        /// Create Shipping slip
        /// </summary>
        /// <param name="order_line">The order line</param>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        private void CreateShippingSlip(OrderLine order_line, Order order, Customer customer)
        {

            Utilities utilities = new Utilities();
            string slip = utilities.GenerateShippingSlip(order, order_line, customer);
            customer.addShippingSlip(slip);
        }
    }
}
