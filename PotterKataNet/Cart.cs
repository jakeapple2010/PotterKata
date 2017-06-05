using System.Collections.Generic;
using System.Linq;

namespace PotterKataNet
{
    public class Cart
    {
        public List<string> Books { get; private set; }

        public void AddBooksToCard(List<string> booksToAddToCart)
        {
            Books = booksToAddToCart;
        }

        readonly Dictionary<int, decimal> _discounts = new Dictionary<int, decimal>
        {
            { 0, 0m },
            { 1, 0m },
            { 2, 0.05m },
            { 3, 0.1m },
            { 4, 0.20m },
            { 5, 0.25m }
        };

        public decimal CalculateCost()
        {
            var totalCost = 0m;

            while (Books.Any())
            {
                var bookSet = Books.Distinct().ToList();

                if (HasTwoSetsOfFour())
                {
                    RemoveSetOfFour();
                    RemoveSetOfFour();
                    totalCost += 51.2m;
                    continue;
                }

                RemoveBookSet(bookSet);
                
                if (_discounts.ContainsKey(bookSet.Count()))
                {
                    totalCost += bookSet.Count() * 8 * (1-_discounts[bookSet.Count()]);
                }
            }
            return totalCost;
        }

        private bool HasTwoSetsOfFour()
        {
            var workingBookList = Books.ToList();
            var enumerable = workingBookList.Distinct().Take(4).ToList();
            foreach (var item in enumerable)
            {
                workingBookList.Remove(item);
            }
            return workingBookList.Distinct().Count() >= 4;
        }

        private void RemoveSetOfFour()
        {
            var enumerable = Books.Distinct().Take(4).ToList();
            foreach (var item in enumerable)
            {
                Books.Remove(item);
            }
        }

        private void RemoveBookSet(IEnumerable<string> bookSet)
        {
            foreach (var s in bookSet)
            {
                Books.Remove(s);
            }
        }
    }
}
