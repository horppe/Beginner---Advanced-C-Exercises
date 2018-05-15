using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Book_Library
{
    class Test
    {
        static Library library = new Library();
        static void Main()
        {
            library.AddBook(new Book("The Shining", "Stephen King", "Doubleday", "28 January 1977", 9780385121675L));
            library.AddBook(new Book("It", "Stephen King", "Viking", "25 September 1986", 0670813028L));
            library.AddBook(new Book("Pride and Prejudice", "Jane Austen", "Thomas Egerton", "28 January 1813", 38659585L));
            library.AddBook(new Book("Pride", "Austen", "Thomas", "15 January 1984", 986573559585L));
            int length = library.books.Count;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine();
                library.DisplayBook(i);
            }

            int swt = 0;
            while (swt != -1)
            {
                swt = library.SearchForBook("Stephen King");
                if (swt != -1)
                {
                    library.Delete(swt);
                }
            }
            length = library.books.Count;
            Console.WriteLine();
            Console.WriteLine("After deleting Stephen King's Books:");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine();
                library.DisplayBook(i);
            }

            Console.ReadKey();
        }
    }
    class Library
    {
        private string libraryName = "OAU Library";
        public List<Book> books = new List<Book>();
        public Library()
        {
        }

        public string LibraryName
        {
            get { return libraryName; }
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void Delete(int index)
        {
            books.RemoveAt(index);
        }

        public int SearchForBook(string author)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (author == books[i].author)
                {
                    return i;
                }
            }
            return -1;
        }

        public void DisplayBook(int index)
        {
            Console.WriteLine("Title: {0}.\r\nAuthor: {1}.\r\nPublisher: {2}.\r\nISBN: {3}.", books[index].title,
                             books[index].author, books[index].publisher, books[index].ISBN);
        }
    }
    class Book
    {
        public string title;
        public string author;
        public string publisher;
        string releaseDate;
        private long isbnNo;
        public long ISBN
        {
            get
            {
                return isbnNo;
            }
        }
        public Book(string title, string author, string publisher, string release, long isbn)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            releaseDate = release;
            isbnNo = isbn;
        }
    }
}
