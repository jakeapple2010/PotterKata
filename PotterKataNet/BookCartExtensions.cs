using System.Collections.Generic;
using System.Linq;

namespace PotterKataNet
{
    static class BookCartExtensions
    {
        public static void RemoveNumberOfBooks(this ICollection<string> books, int count)
        {
            var enumerable = books.Distinct().Take(count).ToList();
            foreach (var item in enumerable)
            {
                books.Remove(item);
            }
        }

        public static void RemoveTwoSetsOfFour(this ICollection<string> books)
        {
            books.RemoveNumberOfBooks(4);
            books.RemoveNumberOfBooks(4);
        }

        public static void RemoveTwoSetsOfFive(this ICollection<string> books)
        {
            books.RemoveNumberOfBooks(5);
            books.RemoveNumberOfBooks(5);
        }

        public static bool HasTwoSetsOfFour(this ICollection<string> books)
        {
            var workingBookList = books.ToList();
            var enumerable = workingBookList.Distinct().Take(4).ToList();
            foreach (var item in enumerable)
            {
                workingBookList.Remove(item);
            }
            return workingBookList.Distinct().Count() >= 4;
        }

        public static bool HasTwoSetsOfFive(this ICollection<string> books)
        {
            var workingBookList = books.ToList();
            var enumerable = workingBookList.Distinct().Take(5).ToList();
            foreach (var item in enumerable)
            {
                workingBookList.Remove(item);
            }
            return workingBookList.Distinct().Count() >= 5;
        }

        public static void RemoveBookSet(this ICollection<string> books, IEnumerable<string> booksToRemove)
        {
            foreach (var s in booksToRemove)
            {
                books.Remove(s);
            }
        }
    }
}