using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Project
{
    interface StorageCapable
    {
        public List<Product> getAllProduct();
        public void storeCDProduct(string name, int price, int tracks);
        public void storeBookProduct(string name, int price, int pages);
    }
}
