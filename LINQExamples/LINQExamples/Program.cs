using LINQExamples.POCOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace LINQExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = loadJson();

            // .Where - Only returns items matching the input condition/predicate
            //var booksStartingWithA = books.Where(b => b.Title.StartsWith("A"));
            //writeOutBooks(booksStartingWithA);

            //var booksByEllieSmith = books.Where(b => b.Author.Name == "Ellie Smith");
            //writeOutBooks(booksByEllieSmith);

            //var bookStartingWithA = books.Single(b => b.Title.StartsWith("A"));
            //writeOutBook(bookStartingWithA);

            //var bookByChrisClark = books.FirstOrDefault(b => b.Author.Name == "Chris Clark");
            //writeOutBook(bookByChrisClark);

            //var bookByEllieSmith = books.First(b => b.Author.Name == "Ellie Smith");
            //writeOutBook(bookByEllieSmith);

            //var bookByEllieSmith = books.FirstOrDefault(b => b.Author.Name == "Ellie Smith");
            //var hasBook = (bookByEllieSmith != null);
            //Console.WriteLine($"Ellie hasBook = {hasBook}");
            //var bookByChrisClark = books.FirstOrDefault(b => b.Author.Name == "Chris Clark");
            //hasBook = (bookByChrisClark != null);
            //Console.WriteLine($"Chris hasBook = {hasBook}");
            //var bookStartingWithA = books.FirstOrDefault(b => b.Title.StartsWith("A"));
            //hasBook = (bookStartingWithA != null);
            //Console.WriteLine($"The letter A hasBook = {hasBook}");

            //var hasBook = books.Any(b => b.Author.Name == "Ellie Smith");
            //Console.WriteLine($"Ellie hasBook = {hasBook}");
            //hasBook = books.Any(b => b.Author.Name == "Chris Clark");
            //Console.WriteLine($"Chris hasBook = {hasBook}");
            //hasBook = books.Any(b => b.Title.StartsWith("A"));
            //Console.WriteLine($"The letter A hasBook = {hasBook}");
            Console.WriteLine($"The letter A hasBook = {books.Any(b => b.Title.StartsWith("A"))}");
            //var allBooksByEllie = books.All(b => b.Author.Name == "Ellie Smith");
            //Console.WriteLine($"All Books by Ellie = {allBooksByEllie}");

            //Console.WriteLine($"Have books = {books.Any()}");
            //writeOutBook(bookByEllieSmith);
            
            var book1 = new Book()
            {
                Title = "Childs Play",
                Publisher = "Chapterhouse",
                Author = new AuthorInfo()
                {
                    Name = "Ellie Smith",
                    Website = "www.agoodread.com"
                },
                Categories = new List<string>() { "Thriller" }
            };

            var book2 = new Book()
            {
                Title = "Childs Play",
                Publisher = "Chapterhouse",
                Author = new AuthorInfo()
                {
                    Name = "Ellie Smith",
                    Website = "www.agoodread.com"
                },
                Categories = new List<string>() { "Thriller" }
            };

            var str1 = "This is one";
            var str2 = str1;
            Console.Write($"str2 = {str2}");
            str1 = "This is two";
            Console.Write($"str2 = {str2}");

            var book3 = book1;
            Console.WriteLine($"Book3 title = {book3.Title}");
            book1.Title = "Something different";
            Console.WriteLine($"Book3 title = {book3.Title}");
            Console.WriteLine($"List of Book1 contains Book3 = {new List<Book>() { book1 }.Contains(book3)}");

            //var haveElliesBook = books.Contains(book1, new BookComparer());
            //Console.WriteLine($"haveElliesBook = {haveElliesBook}");
            //haveElliesBook = books.Any(b => b.Title == book1.Title && book1.Author.Name == b.Author.Name);
            //Console.WriteLine($"haveElliesBook = {haveElliesBook}");
            //haveElliesBook = books.Any(getBookEquality(book1));
            //Console.WriteLine($"haveElliesBook = {haveElliesBook}");

            Console.WriteLine("Hit a key");
            Console.ReadKey();
        }

        private static Func<Book, bool> getBookEquality(Book book)
        {
            return b => b.Title == book.Title && b.Author.Name == book.Author.Name;
        }

        private static void writeOutBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                writeOutBook(book);
            }
        }

        private static void writeOutBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Book doesn't exist");
            }
            else
            {
                Console.WriteLine($"Title = {book.Title}");
                Console.WriteLine($"Author = {book.Author.Name}");
                Console.WriteLine("===========================");
            }
        }

        private static IList<Book> loadJson()
        {
            using (StreamReader file = File.OpenText(@"Books.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var books = (List<Book>)serializer.Deserialize(file, typeof(List<Book>));
                return books;
            }
        }
    }

    public class BookComparer : IEqualityComparer<Book>
    {
        public bool Equals([AllowNull] Book x, [AllowNull] Book y)
        {
            return x.Title == y.Title && x.Author.Name == y.Author.Name;
        }

        public int GetHashCode([DisallowNull] Book obj)
        {
            return obj.GetHashCode();
        }
    }
}
