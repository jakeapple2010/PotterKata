using System.Collections.Generic;
using System.Linq;

namespace PotterKataNet
{
    public class Cart
    {
        public List<string> BooksInCart { get; private set; }
        private readonly decimal _bookCost = 8m;

        public void AddBooksToCard(List<string> booksToAddToCart)
        {
            BooksInCart = booksToAddToCart;
        }

        private readonly Dictionary<int, decimal> _discounts = new Dictionary<int, decimal>
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

            while (BooksInCart.Any())
            {
                if (BooksInCart.HasTwoSetsOfFour())
                {
                    BooksInCart.RemoveTwoSetsOfFour();
                    totalCost += CalculateBookSetCost(4);
                    totalCost += CalculateBookSetCost(4);
                    continue;
                }

                var bookSet = BooksInCart.Distinct().ToList();

                totalCost += CalculateBookSetCost(bookSet.Count);

                BooksInCart.RemoveBookSet(bookSet);
            }
            return totalCost;
        }

        private decimal CalculateBookSetCost(int numberOfBooks)
        {
            return numberOfBooks * _bookCost * (1 - _discounts[numberOfBooks]);
        }
    }
}
