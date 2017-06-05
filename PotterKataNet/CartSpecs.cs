using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PotterKataNet
{
    [TestFixture]
    public class CartSpecs
    {
        private readonly Cart _classUnderTest = new Cart();

        [Test]
        public void Calculate_cost_of_no_books()
        {
            var books = new List<string> { };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(0m));
        }

        [Test]
        public void Calculate_cost_of_one_book()
        {
            var books = new List<string> { "book1" };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(8m));
        }

        [Test]
        public void Calculate_cost_of_two_books()
        {
            var books = new List<string> { "book1", "book2" };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(16m * .95m));
        }

        [Test]
        public void Calculate_cost_of_three_books()
        {
            var books = new List<string> { "book1", "book2", "book3" };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(24m * .9m));
        }

        [Test]
        public void Calculate_cost_of_four_books()
        {
            var books = new List<string> { "book1", "book2", "book3", "book4" };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(32m * .8m));
        }

        [Test]
        public void Calculate_cost_of_five_books()
        {
            var books = new List<string> { "book1", "book2", "book3", "book4", "book5" };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(40m * .75m));
        }

        [Test]
        public void Calculate_cost_of_two_of_the_same_books()
        {
            var books = new List<string> { "book1", "book1" };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(16m));
        }

        [Test]
        public void Calculate_cost_of_two_of_the_same_books_plus_another()
        {
            var books = new List<string> { "book1", "book2", "book1" };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(16m * 0.95m + 8m));
        }

        [Test]
        public void Calculate_cost_of_two_of_book_one_plus_two_of_book_two()
        {
            var books = new List<string> { "book1", "book2", "book1", "book2" };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(16m * 0.95m + 16m * 0.95m));
        }

        [Test]
        public void Calculate_cost_of_two_of_first_second_and_third_and_one_of_fourth_and_fifth()
        {
            var books = new List<string> { "book1", "book1", "book2", "book2", "book3", "book3", "book4", "book5" };

            _classUnderTest.AddBooksToCard(books);
            var result = _classUnderTest.CalculateCost();

            Assert.That(result, Is.EqualTo(51.2m));
        }

        [Test]
        public void Cost_calculation_does_NOT_effect_cart_contents()
        {
            var books = new List<string> { "book1", "book1", "book2", "book2", "book3", "book3", "book4", "book5" };

            _classUnderTest.AddBooksToCard(books.ToArray());
            _classUnderTest.CalculateCost();

            Assert.That(_classUnderTest.BooksInCart, Is.EqualTo(books));
        }
    }
}