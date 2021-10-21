using LexiconVendingMachine.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconVendingMachine.Services
{
    public class BeachVendingMachine : IVending
    {
        private readonly int[] denominations = new int[]{1,5,10,20,50,100,500,1000};
        private List<Product> productsInVendingMachine;

        private int moneyPool;
        public int MoneyPool { get { return moneyPool; } }

        public BeachVendingMachine()
        {
            productsInVendingMachine = InitializeListOfProducts();
        }

        private List<Product> InitializeListOfProducts()
        {
            var productList = new List<Product>()
            {
                new SwimWear("Blue shorts", 100, "Unpack and put on", "XL", "Fast drying"),
                new Snack("Candy bar", 20, "Open and eat", 25, "2022-02-02"),
                new Drink("Coca Cola", 20, "Open and drink", 25, "original")
            };

            return productList;
        }

        public Dictionary<int,int> EndTransaction()
        {
            Dictionary<int, int> changeInDenominations = new Dictionary<int, int>();
            changeInDenominations = BreakDownChangeToDenominations(moneyPool);
            moneyPool = 0;
            return changeInDenominations;
        }

        public string InsertMoney(int money)
        {
            if (!Array.Exists(denominations, m => m == money))
                return "Invalid money type.";

            moneyPool += money;
            return $"Amount added, current total amount is {MoneyPool}";
        }

        public Product Purchase(int productIndex)
        {
            if (productIndex > productsInVendingMachine.Count - 1)
                throw new ArgumentException("Product is not available.");

            if (moneyPool < productsInVendingMachine[productIndex].Price)
                throw new ArgumentException("Insufficient money inserted");

            moneyPool -= productsInVendingMachine[productIndex].Price;

            return productsInVendingMachine[productIndex];
        }

        public string ShowAll()
        {
            StringBuilder sbProducts = new StringBuilder(); ;

            int index = 0;

            foreach (var product in productsInVendingMachine)
            {
                sbProducts.Append("Product index: " + index++ + " " + product.Examine() + "\n");
            }

            return sbProducts.ToString();
        }

        public Dictionary<int,int> BreakDownChangeToDenominations(int totalChangeAmount)
        {
            Dictionary<int, int> changeInDenominations = new Dictionary<int, int>();
            int tempRemaingAmount = totalChangeAmount;
            int numberOfDenominations = 0;

            for (int i = denominations.Length - 1; i > -1 ; i--)
            {
                numberOfDenominations = tempRemaingAmount / denominations[i];
                changeInDenominations.Add(denominations[i], numberOfDenominations);
                tempRemaingAmount = tempRemaingAmount - numberOfDenominations * denominations[i];

            }

            return changeInDenominations;

        }
    }
}
