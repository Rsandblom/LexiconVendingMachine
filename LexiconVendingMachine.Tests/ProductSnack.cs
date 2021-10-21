using LexiconVendingMachine.Models.Products;
using System;
using Xunit;

namespace LexiconVendingMachine.Tests
{
    public class ProductSnack
    {
        [Fact]
        public void SnackCanOnlyBeCreatedWithAllFieldsAssigned()
        {
            string description = "Candy bar";
            string emptyDescription = "";
            int price = 20;
            string usage = "Open and eat";
            int sugarAmount = 25;
            int incorrectSugarAmount = -1;
            string expirationDate = "2022-02-02";
            string incorrectExpirationDate = "????";

            ArgumentException resultIfDescriptionIsEmpty = Assert.Throws<ArgumentException>(
                () => new Snack(emptyDescription, price, usage, sugarAmount, expirationDate));

            string emptyDecriptionError = "Description cant be null or empty.";

            ArgumentException resultIfSugarIsLessThanZero = Assert.Throws<ArgumentException>(
                () => new Snack(description, price, usage, incorrectSugarAmount, expirationDate));

            string incorrectSugarAmountError = "Sugar amount cant be less than zero.";

            ArgumentException resultIfDateIsIncorrectFormat = Assert.Throws<ArgumentException>(
                () => new Snack(description, price, usage, sugarAmount, incorrectExpirationDate));

            string incorrectDateError = "Expiration date is invalid.";

            Snack snack = new Snack(description, price, usage, sugarAmount, expirationDate);

            Assert.Equal(emptyDecriptionError, resultIfDescriptionIsEmpty.Message);
            Assert.Equal(incorrectSugarAmountError, resultIfSugarIsLessThanZero.Message);
            Assert.Equal(incorrectDateError, resultIfDateIsIncorrectFormat.Message);
            Assert.NotNull(snack);
            Assert.Equal(description, snack.Description);
            Assert.Equal(sugarAmount, snack.SugarAmount);
            Assert.Equal(expirationDate, snack.ExpirationDate.ToShortDateString());
        }

        [Fact]
        public void SwimWearMethodExaminShouldReturnCorrectOverrideExamine()
        {
            string description = "Candy bar";
            int price = 20;
            string usage = "Open and eat";
            int sugarAmount = 25;
            string expirationDate = "2022-02-02";

            string resultFromExamine = $"Info: {description} Price: {price} Sugar amount: {sugarAmount} Expiration date: {expirationDate}";

           Snack snack = new Snack(description, price, usage, sugarAmount, expirationDate);

            Assert.Equal(resultFromExamine, snack.Examine());
        }
    }
}
