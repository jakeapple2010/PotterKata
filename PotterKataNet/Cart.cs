using System.Collections.Generic;
using System.Linq;

namespace PotterKataNet
{
    public class Cart
    {
        public ICollection<string> BooksInCart { get; private set; }
        public readonly decimal BookCost = 8m;

        public void AddBooksToCard(ICollection<string> booksToAddToCart)
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
            var workingList = BooksInCart.ToList();

            while (workingList.Any())
            {
                if (workingList.HasTwoSetsOfFive())
                {
                    workingList.RemoveTwoSetsOfFive();
                    totalCost += CalculateBookSetCost(4);
                    totalCost += CalculateBookSetCost(4);
                    totalCost += CalculateBookSetCost(2);
                    continue;
                }
                if (workingList.HasTwoSetsOfFour())
                {
                    workingList.RemoveTwoSetsOfFour();
                    totalCost += CalculateBookSetCost(4);
                    totalCost += CalculateBookSetCost(4);
                    continue;
                }

                var bookSet = workingList.Distinct().ToList();

                totalCost += CalculateBookSetCost(bookSet.Count);

                workingList.RemoveBookSet(bookSet);
            }
            return totalCost;
        }

        private decimal CalculateBookSetCost(int numberOfBooks)
        {
            return numberOfBooks * BookCost * (1 - _discounts[numberOfBooks]);
        }
    }
}
