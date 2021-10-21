using LexiconVendingMachine.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconVendingMachine.Services
{
    public interface IVending
    {
        public Product Purchase(int productIndex);
        public string ShowAll();
        public string InsertMoney(int money);
        public int EndTransaction();
    }
}
