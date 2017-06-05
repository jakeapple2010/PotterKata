using System.Collections.Generic;
using System.Linq;

namespace PotterKataNet
{
    static class BookCartExtensions
    {
        public static void RemoveSetOfFour(this ICollection<string> books)
        {
            var enumerable = books.Distinct().Take(4).ToList();
            foreach (var item in enumerable)
            {
                books.Remove(item);
            }
        }

        public static void RemoveTwoSetsOfFour(this ICollection<string> books)
        {
            books.RemoveSetOfFour();
            books.RemoveSetOfFour();
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

        public static void RemoveBookSet(this ICollection<string> books, IEnumerable<string> booksToRemove)
        {
            foreach (var s in booksToRemove)
            {
                books.Remove(s);
            }
        }
    }
}