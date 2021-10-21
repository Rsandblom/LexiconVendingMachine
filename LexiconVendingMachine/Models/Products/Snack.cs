using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LexiconVendingMachine.Models.Products
{
    public class Snack :Product
    {
        public int SugarAmount { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Snack(string description, int price, string usage, int sugarAmount, string expirationDate)
            : base(description, price, usage)
        {
            if (sugarAmount < 0)
                throw new ArgumentException("Sugar amount cant be less than zero.");

            DateTime dateTime;
            if (DateTime.TryParse(expirationDate, out dateTime))
            {
                ExpirationDate = dateTime;
            }

            else
            {
                throw new ArgumentException($"Expiration date is invalid.");
            }

            SugarAmount = sugarAmount;
        }

        public override string Examine()
        {

            return $"{base.Examine()} Sugar amount: {SugarAmount} Expiration date: {ExpirationDate.ToShortDateString()}";
        }
    }
}
