namespace TP01_WII6.Models
{
    public class Book
    {
        public Book() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Author> Authors { get; set; }
        public int Qty { get; set; }
        public Book(string name, double price, List<Author> authors)
        {
            Name = name;
            Price = price;
            Authors = authors;
        }
        public Book(string name, double price, List<Author> authors, int qty): this(name, price, authors)
        {
            Qty = qty;
        }
        public string GetName() => Name;
        public double GetPrice() => Price;
        public int GetQty() => Qty;
        public void SetPrice(double price) => Price = price;
        public void SetQty(int qty) => Qty = qty;
        public string GetAuthors()
        {
            return string.Join(", ", Authors);
        }
        public string GetAuthorNames()
        {
            return string.Join(", ", Authors.Select(a => a.Name));
        }
        public override string ToString()
        {
            return $"Book[name={Name}, authors={GetAuthors()}, price={Price}, qty={Qty}]";
        }
    }
}
