using CsvHelper;
using LINQExamples.POCOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;

namespace LINQExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = loadUserTakeupCSV();

            // Simple Where
            var result = data.Where(ut => ut.EmailAddress == "sharonbiant@yahoo.co.uk").ToList();
            Console.WriteLine($"{result[0].FirstName} {result[0].LastName}");

            // SingleOrDefault
            var result2 = data.SingleOrDefault(ut => ut.EmailAddress == "sharonbiant@yahoo.co.uk");

            if (result2 != null)
            {
                Console.WriteLine($"{result2.FirstName} {result2.LastName}");
            }

            var result3 = data.Where(ut => ut.EmailAddress == "xxxxsharonbiant@yahoo.co.uk");
            
            if (!result3.Any())
            {
                Console.WriteLine("No matches for result3");
            }

            var result4 = data.FirstOrDefault(ut => ut.AccountType != "DSPT");
            Console.WriteLine($"{result4?.FirstName} {result4?.LastName} {result4?.AccountType}");

            // UserTake up, most recent first
            Console.WriteLine("===========================================");
            
            var result5 = data.OrderByDescending(o => o.FirstRegistered).ToList();

            for (int i = 0; i < 5; i++)
            {
                var ut = result5[i];
                Console.WriteLine($"{ut.FirstName} {ut.LastName} {ut.FirstRegistered}");
            }

            Console.WriteLine("===========================================");
            
            // SQL SELECT TOP 5
            foreach (var ut in result5.Take(5))
            {
                Console.WriteLine($"{ut.FirstName} {ut.LastName} {ut.FirstRegistered}");
            }

            Console.WriteLine("===========================================");
            
            // SQL OrderBy LastName, FirstName
            var result6 = data
                .Where(ut => ut.AccountType == "NHSmail")
                .OrderBy(o => o.LastName)
                .ThenBy(o => o.FirstName)
                .Take(5);

            foreach (var ut in result6)
            {
                Console.WriteLine($"{ut.FirstName} {ut.LastName} {ut.FirstRegistered}");
            }

            Console.WriteLine("===========================================");

            // SQL SELECT AccountType, COUNT(*) FROM UserTakeup GROUP BY AccountType

            var result7 = data.GroupBy(g => g.AccountType);

            foreach (var grp in result7)
            {
                Console.WriteLine($"Account type {grp.Key} has {grp.Count()} registered users");
            }

            foreach (var grp in result7)
            {
                var mra = grp.OrderByDescending(o => o.LastAccessed).First();
                Console.WriteLine($"Account type {grp.Key} most recent access is by {mra.FirstName} {mra.LastName} at {mra.LastAccessed}");
            }

            var mostpopular = result7.OrderBy(o => o.Count()).First();
            Console.WriteLine($"Least popular account type is {mostpopular.Key} with {mostpopular.Count()} users");
            
            return;

            var books = loadBooksJson();

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

        private static IList<Book> loadBooksJson()
        {
            using (StreamReader file = File.OpenText(@"Books.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var books = (List<Book>)serializer.Deserialize(file, typeof(List<Book>));
                return books;
            }
        }

        private static IList<UserTakeup> loadUserTakeupCSV()
        {
            using (TextReader reader = new StreamReader("DSPTUserTakeup.csv"))
            {
                var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
                return csvReader.GetRecords<UserTakeup>().ToList();
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
