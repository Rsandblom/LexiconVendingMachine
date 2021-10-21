using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconVendingMachine.Models.Products
{
    public class SwimWear : Product
    {
        public string Size { get; set; }
        public string Type { get; set; }

        public SwimWear(string description, int price, string usage, string size, string type) 
            : base (description, price, usage)
        {
            if (string.IsNullOrWhiteSpace(size))
                throw new ArgumentException("Size cant be null or empty.");
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type cant be null or empty.");

            Size = size;
            Type = type;
        }

        public override string Examine()
        {

            return $"{base.Examine()} Size: {Size} Type: {Type}";
        }
    }
}
