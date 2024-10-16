namespace TP01_WII6.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public List<Book> Books { get; set; }
        public override string ToString()
        {
            return $"Author[name={Name}, email={Email}, gender={Gender}]";
        }
    }
}
