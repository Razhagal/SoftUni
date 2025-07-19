using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext context = new BookShopContext();
            DbInitializer.ResetDatabase(context);

            //string input = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(context, input);
            //Console.WriteLine(result);

            //Console.WriteLine(GetGoldenBooks(context));
            //Console.WriteLine(GetBooksByPrice(context));

            //int input = int.Parse(Console.ReadLine());
            //string result = GetBooksNotReleasedIn(context, input);
            //Console.WriteLine(result);

            //string inputCategories = Console.ReadLine();
            //string result = GetBooksByCategory(context, inputCategories);
            //Console.WriteLine(result);

            //string inputDate = Console.ReadLine();
            //string result = GetBooksReleasedBefore(context, inputDate);
            //Console.WriteLine(result);

            //string input = Console.ReadLine();
            //string result = GetAuthorNamesEndingIn(context, input);
            //Console.WriteLine(result);

            //string input = Console.ReadLine();
            //string result = GetBookTitlesContaining(context, input);
            //Console.WriteLine(result);

            //string input = Console.ReadLine();
            //string result = GetBooksByAuthor(context, input);
            //Console.WriteLine(result);

            //int input = int.Parse(Console.ReadLine());
            //string result = CountBooks(context, input);
            //Console.WriteLine(result);

            //Console.WriteLine(CountCopiesByAuthor(context));
            //Console.WriteLine(GetTotalProfitByCategory(context));
            //Console.WriteLine(GetMostRecentBooks(context));

            //IncreasePrices(context);

            int removedBooksCount = RemoveBooks(context);
            Console.WriteLine(removedBooksCount);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction restrictionType = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var filteredBooks = context.Books
                .Where(b => b.AgeRestriction == restrictionType)
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filteredBooks.Count; i++)
            {
                sb.AppendLine(filteredBooks[i].Title);
            }

            return sb.ToString();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < goldenBooks.Count; i++)
            {
                sb.AppendLine(goldenBooks[i].Title);
            }

            return sb.ToString();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var filteredBooks = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b =>
                    new
                    {
                        Title = b.Title,
                        Price = b.Price
                    }
                )
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filteredBooks.Count; i++)
            {
                sb.AppendLine($"{filteredBooks[i].Title} - ${filteredBooks[i].Price:F2}");
            }

            return sb.ToString();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var filteredBooks = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b =>
                    new
                    {
                        Title = b.Title
                    }
                )
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filteredBooks.Count; i++)
            {
                sb.AppendLine(filteredBooks[i].Title);
            }

            return sb.ToString();
        }

        public static string GetBooksByCategory(BookShopContext context, string categories)
        {
            string[] inputCategories = categories.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var filteredBooks = context.Books
                .Include(b => b.BookCategories)
                .ThenInclude(bc => bc.Category)
                .Where(b => b.BookCategories
                    .Any(bc => inputCategories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filteredBooks.Count; i++)
            {
                sb.AppendLine(filteredBooks[i].Title);
            }

            return sb.ToString();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string dateInput)
        {
            DateTime date = DateTime.ParseExact(dateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var filteredBooks = context.Books
                .Where(b => b.ReleaseDate < date)
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filteredBooks.Count; i++)
            {
                sb.AppendLine($"{filteredBooks[i].Title} - {filteredBooks[i].EditionType} - ${filteredBooks[i].Price:F2}");
            }

            return sb.ToString();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var filteredAuthors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName + " " + a.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filteredAuthors.Count; i++)
            {
                sb.AppendLine($"{filteredAuthors[i].FirstName} {filteredAuthors[i].LastName}");
            }

            return sb.ToString();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var filteredBooks = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();


            return string.Join(Environment.NewLine, filteredBooks);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var filteredBooks = context.Books
                .Include(b => b.Author)
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filteredBooks.Count; i++)
            {
                sb.AppendLine($"{filteredBooks[i].Title} ({filteredBooks[i].Author.FirstName} {filteredBooks[i].Author.LastName})");
            }

            return sb.ToString();
        }

        public static string CountBooks(BookShopContext context, int lengthCheck)
        {
            int filteredBooksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return filteredBooksCount.ToString();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsWithBooksCount = context.Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    AuthorFullName = a.FirstName + " " + a.LastName,
                    BooksCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.BooksCount)
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < authorsWithBooksCount.Count; i++)
            {
                sb.AppendLine($"{authorsWithBooksCount[i].AuthorFullName} - {authorsWithBooksCount[i].BooksCount}");
            }

            return sb.ToString();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryBooksProfits = context.Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfits = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(x => x.TotalProfits)
                .ThenBy(x => x.CategoryName)
                .ToList();


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < categoryBooksProfits.Count; i++)
            {
                sb.AppendLine($"{categoryBooksProfits[i].CategoryName} ${categoryBooksProfits[i].TotalProfits:F2}");
            }

            return sb.ToString();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var recentBooksByCategory = context.Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    RecentBooks = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < recentBooksByCategory.Count; i++)
            {
                sb.AppendLine($"--{recentBooksByCategory[i].CategoryName}");

                var recentBooks = recentBooksByCategory[i].RecentBooks;
                for (int j = 0; j < recentBooks.Count; j++)
                {
                    sb.AppendLine($"{recentBooks[j].Title} ({recentBooks[j].ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            for (int i = 0; i < booksToRemove.Count; i++)
            {
                context.Books.Remove(booksToRemove[i]);
            }

            //var changes = context.ChangeTracker.Entries().Select(e => new { e.Entity, e.State }).ToList();
            //for (int i = 0; i < changes.Count; i++)
            //{
            //    Console.WriteLine(changes[i].Entity + " " + changes[i].State);
            //}

            context.SaveChanges();

            return booksToRemove.Count;
        }
    }
}