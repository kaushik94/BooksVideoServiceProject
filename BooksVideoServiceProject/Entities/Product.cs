using System;

namespace BooksVideoServiceProject.Entities
{
    public class Product : Entity
    {

        public String order_line { get; set; }

        public String membership = "";

        public String type = "";

        /// <summary>
        /// If order contains any physical order
        /// </summary>
        public bool isPhysicalOrder()
        {
            return this.IsBookShippingSlipOrder(this.order_line) || this.IsVideoShippingSlipOrder(this.order_line);
        }

        /// <summary>
        /// If order contains any membership order
        /// </summary>
        public bool isMembershipOrder()
        {
            return this.IsBookMembershipOrder(this.order_line) || this.IsVideoMembershipOrder(this.order_line);
        }

        /// <summary>
        /// If order contains any shipping slip for book
        /// </summary>
        /// <param name="line">The order line</param>
        /// <returns>True if book shipping slip in line, else False</returns>
        public bool IsBookShippingSlipOrder(string line)
        {
            String start_with = "Book";
            String not_start_with = "Book Club Membership";

            return line.StartsWith(start_with) && !line.StartsWith(not_start_with);
        }

        /// <summary>
        /// If order contains any shipping slip for video
        /// </summary>
        /// <param name="line">The order line</param>
        /// <returns>True if video shipping slip in line, else False</returns>
        public bool IsVideoShippingSlipOrder(string line)
        {
            String start_with = "Video";
            String not_start_with = "Video Club Membership";

            return line.StartsWith(start_with) && !line.StartsWith(not_start_with);
        }
        /// <summary>
        /// If order contains any book membership
        /// </summary>
        /// <param name="line">The order line</param>
        /// <returns>True if book membership in line, else False</returns>
        public bool IsBookMembershipOrder(string line)
        {           
            return line.ToLower().Contains("book club membership");
        }

        /// <summary>
        /// If order contains any video membership
        /// </summary>
        /// <param name="line">The order line</param>
        /// <returns>True if video membership in line, else False</returns>
        public bool IsVideoMembershipOrder(string line)
        {
            return line.ToLower().Contains("video club membership");
        }

        private String getMembershipType()
        {
            if (this.IsVideoMembershipOrder(this.order_line)) {
                return "video";
            } else if (this.IsBookMembershipOrder(this.order_line)) {
                return "book";
            }
            return "";
        }

        public String getPhysicalType()
        {
            if (this.IsBookShippingSlipOrder(this.order_line)) {
                return "book";
            } else if (this.IsVideoShippingSlipOrder(this.order_line)) {
                return "video";
            }
            return "";
        }

        private void create(String line)
        {
            if (this.isMembershipOrder()) {
                membership = this.getMembershipType();
            } else {
                type = this.getPhysicalType();
            }
        }
        public Product(string line) {
            order_line = line;
            this.create(line);
        }
    }
}
