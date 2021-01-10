using BooksVideoServiceProject.Entities;
using BooksVideoServiceProject.Services;
using System;

namespace BooksVideoServiceProject.Extensions
{
    /// <summary>
    /// The membership order
    /// </summary>
    public class MembershipOrder : IOrderService
    {
        /// <summary>
        /// To process customer order for membership
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        public void Process(Order order, Customer customer)
        {
            this.ApplyMembershipIfApplicable(order, customer);
        }

        /// <summary>
        /// Check if membership is applicable or not
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        private void ApplyMembershipIfApplicable(Order order, Customer customer)
        {
            foreach (var item in order.OrderLines)
            {
                Product product = new Product(item.Line);
                if (product.isMembershipOrder()) {
                    this.ApplyMembership(product.membership, customer);
                }
            }
        }

        /// <summary>
        /// Apply membership to the customer
        /// </summary>
        /// <param name="type">The membership type</param>
        /// <param name="customer">The customer</param>
        private void ApplyMembership(string type, Customer customer)
        {
            customer.AddMembership(type);
        }
    }
}
