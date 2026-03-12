namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> myBooks = new List<Book>
            {
                new Book("123", "Book1", ["Author1"], DateTime.Now, 10.99m),
                new Book("456", "Book2", ["Author2"], DateTime.Now, 15.99m)
            };
            System.Console.WriteLine("User defined delegate: ");
            ProcessBooksDelgt processBooksDelgt = BookFunctions.GetTitle;
            LibraryEngine.ProcessBooks(myBooks, processBooksDelgt);
            System.Console.WriteLine("BCL delegate: ");
            Func<Book, string> processBooksDelgt2 = BookFunctions.GetAuthors;
            LibraryEngine.ProcessBooks(myBooks, processBooksDelgt2);
            System.Console.WriteLine("Anonymous method: ");
            ProcessBooksDelgt processBooksDelgt3 = delegate (Book B)
            {
                return B.ISBN.ToString();
            };
            LibraryEngine.ProcessBooks(myBooks, processBooksDelgt3);
            System.Console.WriteLine("Lambda expression: ");
            ProcessBooksDelgt processBooksDelgt4 = (Book B) => B.Price.ToString();
            LibraryEngine.ProcessBooks(myBooks, processBooksDelgt4);
        }
    }
}
