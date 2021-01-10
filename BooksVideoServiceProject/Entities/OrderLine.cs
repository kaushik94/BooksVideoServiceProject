namespace BooksVideoServiceProject.Entities
{
    public class OrderLine : Entity
    {
        private string line;

        public string Line
        {
            get { return line; }
            set { line = value; }
        }
    }
}