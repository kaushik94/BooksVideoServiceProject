using System;
using System.Collections.Generic;

namespace BooksVideoServiceProject.Entities
{
    public class Order : Entity
    {
        // public int Id { get; set; }

        private int customer_id;
        private List<OrderLine> order_lines = new List<OrderLine>();

        public List<OrderLine> OrderLines 
        {
            get { return order_lines; }
        }

        public int CustomerId
        {
            get { return customer_id; }
            set { customer_id = value; }
        }

        public void addOrderLine(string line) {
            Console.WriteLine("Adding order lines:!"+line);

            OrderLine order_line = new OrderLine();
            order_line.Line = line;
            order_lines.Add(order_line);
        }

        public Order() {}

    }
}
