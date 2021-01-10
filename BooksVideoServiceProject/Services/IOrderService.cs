using BooksVideoServiceProject.Entities;

namespace BooksVideoServiceProject.Services
{
    /// <summary>
    /// The order service interface
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Process the order
        /// </summary>
        /// <param name="order">The order</param>
        /// <param name="customer">The customer</param>
        void Process(Order order, Customer customer);        
    }
}
