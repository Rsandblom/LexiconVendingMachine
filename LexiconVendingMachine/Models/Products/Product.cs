using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconVendingMachine.Models.Products
{
    public abstract class Product
    {
        

        public string Description { get; set; }
        public int Price { get; set; }

        public string Usage { get; set; }

        public virtual string Examine()
        {
            return $"Info: {Description} Price: {Price}";
        }

        public virtual string Use()
        {
            return $"Usage info: {Usage}";
        }

        protected Product(string description, int price, string usage)
        {

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cant be null or empty.");
            if (string.IsNullOrWhiteSpace(usage))
                throw new ArgumentException("Usage cant be null or empty.");

            Description = description;
            Price = price;
            Usage = usage;
        }





    }
}
