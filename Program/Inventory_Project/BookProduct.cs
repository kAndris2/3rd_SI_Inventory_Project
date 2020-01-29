using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Project
{
    public class BookProduct : Product
    {
        public int numOfPages { get; set; }

        public BookProduct() { }

        public BookProduct(string name, int price, int pages)
        {
            this.name = name;
            this.price = price;
            numOfPages = pages;
        }
    }
}
