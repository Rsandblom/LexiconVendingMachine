using LexiconVendingMachine.Models.Products;
using LexiconVendingMachine.Services;
using System;
using Xunit;

namespace LexiconVendingMachine.Tests
{
   
    public class ServiceBeachVendingMachine
    {
        [Fact]
        public void ShowAllShouldDisplayProductIndexAndExaminMethodInfoForProducts()
        {
            BeachVendingMachine vendingMachine = new BeachVendingMachine();

            string expectedResult = "Product index: 0 Info: Blue shorts Price: 100 Size: XL Type: Fast drying\n" 
                                + "Product index: 1 Info: Candy bar Price: 20 Sugar amount: 25 Expiration date: 2022-02-02\n"
                                + "Product index: 2 Info: Coca Cola Price: 20 Size: 25 Flavor: original\n";

            Assert.Equal(expectedResult, vendingMachine.ShowAll());
        }

        [Fact]
        public void InsertMoneyShouldOnlyAcceptValidDenominations()
        {
            BeachVendingMachine vendingMachine = new BeachVendingMachine();

            string invalidMoneyResult = "Invalid money type.";


            string validMoneyResult = $"Amount added, current total amount is 100";

            Assert.Equal(invalidMoneyResult, vendingMachine.InsertMoney(7));
            Assert.Equal(validMoneyResult, vendingMachine.InsertMoney(100));
        }

        [Fact]
        public void TryingToPurchaseNonExistingProductShouldRecievCorrectMessage()
        {
            BeachVendingMachine vendingMachine = new BeachVendingMachine();
            vendingMachine.InsertMoney(10);

            string nonExistingProductResult = "Product is not available.";

            ArgumentException nonExistingProductResultEx = Assert.Throws<ArgumentException>(
                () => vendingMachine.Purchase(3));

            Assert.Equal(nonExistingProductResult, nonExistingProductResultEx.Message);
        }

        [Fact]
        public void TryingToPurchaseProductWithInsufficientFundsShouldRecievCorrectMessage()
        {
            BeachVendingMachine vendingMachine = new BeachVendingMachine();
            vendingMachine.InsertMoney(10);

            string moneyIsNotEnoughResult = "Insufficient money inserted";

            ArgumentException moneyIsNotEnoughResultEx = Assert.Throws<ArgumentException>(
                () => vendingMachine.Purchase(1));

            Assert.Equal(moneyIsNotEnoughResult, moneyIsNotEnoughResultEx.Message);
        }

        [Fact]
        public void TryingToPurchaseProductWithSufficientFundsShouldReturnProduct()
        {
            BeachVendingMachine vendingMachine = new BeachVendingMachine();
            vendingMachine.InsertMoney(50);

            Product snack = vendingMachine.Purchase(1);

            string snackUsage = "Usage info: Open and eat";

            Assert.Equal(snackUsage, snack.Use());
        }

        [Fact]
        public void EndingPurchaseShouldReturnCorrectAmountOfMoney()
        {
            BeachVendingMachine vendingMachine = new BeachVendingMachine();
            vendingMachine.InsertMoney(50);

            Product snack = vendingMachine.Purchase(1);

            int expectedRetunedAmount = 30;

            Assert.Equal(expectedRetunedAmount, vendingMachine.EndTransaction());
        }

    }
}
