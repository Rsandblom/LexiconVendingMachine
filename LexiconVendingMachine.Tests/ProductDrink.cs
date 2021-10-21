using LexiconVendingMachine.Models.Products;
using System;
using Xunit;

namespace LexiconVendingMachine.Tests
{
    public class ProductDrink
    {
        [Fact]
        public void DrinkCanOnlyBeCreatedWithAllFieldsAssigned()
        {
            string description = "Coca cola";
            string emptyDescription = "";
            int price = 20;
            string usage = "Open and drink";
            int size = 25;
            int emptySize = 0;
            string flavor = "Original";

            ArgumentException resultIfDescriptionIsEmpty = Assert.Throws<ArgumentException>(
                () => new Drink(emptyDescription, price, usage, size, flavor));

            string emptyDecriptionError = "Description cant be null or empty.";

            ArgumentException resultIfSizeIsZeroOrLess = Assert.Throws<ArgumentException>(
                () => new Drink (description, price, usage, emptySize, flavor));

            string emptySizeError = "Size cant be zero.";

            Drink drink = new Drink(description, price, usage, size, flavor);

            Assert.Equal(emptyDecriptionError, resultIfDescriptionIsEmpty.Message);
            Assert.Equal(emptySizeError, resultIfSizeIsZeroOrLess.Message);
            Assert.NotNull(drink);
            Assert.Equal(description, drink.Description);
            Assert.Equal(size, drink.SizeMl);
        }

        [Fact]
        public void SwimWearMethodExaminShouldReturnCorrectOverrideExamine()
        {
            string description = "Coca Cola";
            int price = 20;
            string usage = "Open and drink";
            int size = 25;
            string flavor = "Original";

            string resultFromExamine = $"Info: {description} Price: {price} Size: {size} Flavor: {flavor}";

            Drink drink = new Drink(description, price, usage, size, flavor);

            Assert.Equal(resultFromExamine, drink.Examine());
        }
    }
}
