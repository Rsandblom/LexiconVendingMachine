using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconVendingMachine.Models.Products
{
    public class Drink : Product
    {
        public int SizeMl { get; set; }
        public string Flavor { get; set; }

        public Drink(string description, int price, string usage, int size, string flavor)
            : base(description, price, usage)
        {
            if (size <= 0)
                throw new ArgumentException("Size cant be zero.");
            if (string.IsNullOrWhiteSpace(flavor))
                throw new ArgumentException("Type cant be null or empty.");

            SizeMl = size;
            Flavor = flavor;
        }

        public override string Examine()
        {

            return $"{base.Examine()} Size: {SizeMl} Flavor: {Flavor}";
        }
    }
}
