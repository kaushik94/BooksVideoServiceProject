using BooksVideoServiceProject.Entities;
using BooksVideoServiceProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BooksVideoServiceProject.Tests
{
    /// <summary>
    /// The order service unit test
    /// </summary>
    [TestClass]
    public class OrderServiceUnitTest
    {
        /// <summary>
        /// The customer membership test
        /// </summary>
        [TestMethod]
        public void TestCustomerMembership()
        {
            // arrange
            Customer customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            Order order = new Order();
            order.addOrderLine("Book Club Membership");

            // act
            OrderService os = new OrderService();
            os.Process(order, customer);

            // assert
            Assert.IsTrue(customer.memberships.Contains("book"));
        }

        /// <summary>
        /// The shipping slip test
        /// </summary>
        [TestMethod]
        public void TestShippingSlips()
        {
            // arrange
            Customer customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            Order order = new Order();
            order.addOrderLine("Book Harry Potter and the Goblet of Fire");            

            // act
            OrderService os = new OrderService();
            os.Process(order, customer);

            // assert
            Assert.AreEqual(customer.shipping_slips.Count, 1);
            Assert.IsTrue(customer.shipping_slips[0].Contains("Item:Book Harry Potter and the Goblet of Fire"));

            // arrange
            customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            order = new Order();            
            order.addOrderLine("Video 'Transformers'");

            // act
            os = new OrderService();
            os.Process(order, customer);

            // assert
            Assert.AreEqual(customer.shipping_slips.Count, 1);
            Assert.IsTrue(customer.shipping_slips[0].Contains("Video 'Transformers'"));
        }

        /// <summary>
        /// Test book balance
        /// </summary>
        [TestMethod]
        public void TestBookBalance()
        {
            // arrange
            Customer customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            Order order = new Order();
            order.addOrderLine("Book Harry Potter and the Goblet of Fire");

            // act
            OrderService os = new OrderService();
            os.Process(order, customer);

            // assert
            Assert.AreEqual(customer.balance, 0);

            // arrange
            customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            order = new Order();
            order.addOrderLine("Book Harry Potter and the Goblet of Fire");
            order.addOrderLine("Book Club Membership");

            // act
            os = new OrderService();
            os.Process(order, customer);

            // assert
            Assert.AreEqual(customer.balance, 5);

            // arrange
            customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            order = new Order();
            order.addOrderLine("Book Club Membership");
            order.addOrderLine("Book Harry Potter and the Goblet of Fire");
            // order.addOrderLine("Book Club Membership");
            order.addOrderLine("Book Hidden Brains");
            // order.addOrderLine("Book Club Membership");

            // act
            os = new OrderService();
            os.Process(order, customer);

            // assert
            Assert.AreEqual(customer.balance, 10);
        }

        /// <summary>
        /// Test video balance
        /// </summary>
        [TestMethod]
        public void TestVideoBalance()
        {
            // arrange
            Customer customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            Order order = new Order();
            order.addOrderLine("Video Transformers");

            // act
            OrderService os = new OrderService();
            os.Process(order, customer);

            // assert
            Assert.AreEqual(customer.balance, 0);

            // arrange
            customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            order = new Order();
            order.addOrderLine("Video Transformers");
            order.addOrderLine("Video Club Membership");

            // act
            os = new OrderService();
            os.Process(order, customer);

            // assert
            Assert.AreEqual(customer.balance, 5);

            // arrange
            customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            order = new Order();
            order.addOrderLine("Video Club Membership");
            order.addOrderLine("Video Transformers");
            // order.addOrderLine("Video Club Membership");
            order.addOrderLine("Video Transporter");
            // order.addOrderLine("Video Club Membership");

            // act
            os = new OrderService();
            os.Process(order, customer);

            // assert
            Assert.AreEqual(customer.balance, 10);
        }
    }
}
