using System;
using BooksVideoServiceProject.Entities;
using BooksVideoServiceProject.Services;


namespace BooksVideoServiceProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer customer = new Customer("Mr. Bryan Walton", "Bryan.Walton@gmail.com");
            Order order = new Order();
            order.addOrderLine("Video 'Transformers'");
            order.addOrderLine("Video 'Transformers'");
            order.addOrderLine("Book Club Membership");


            OrderService os = new OrderService();
            os.Process(order, customer);
            Console.Write("customer: "+customer.getShippingSlips()[0]);

            // Console.WriteLine(order.OrderLines);
            Console.WriteLine("Goodbye World!");

        }
    }
}
