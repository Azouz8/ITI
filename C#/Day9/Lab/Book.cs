namespace Lab
{
    public delegate string ProcessBooksDelgt(Book book);

    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string _ISBN, string _Title,
            string[] _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }

        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Price: {Price}";
        }
    }

    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }

        public static string GetAuthors(Book B)
        {
            string authors = "";
            foreach (var item in B.Authors)
            {
                authors += item + ", ";
            }
            return authors;
        }

        public static string GetPrice(Book B)
        {
            return B.Price.ToString();
        }
    }

    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, ProcessBooksDelgt fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

    }

}