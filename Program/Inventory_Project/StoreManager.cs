using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Project
{
    class StoreManager
    {
        private StorageCapable IStorage;

        public void addStorage(StorageCapable storage)
        {
            IStorage = storage;
        }

        public void addCDProduct(string name, int price, int tracks)
        {
            IStorage.storeCDProduct(name, price, tracks);
        }

        public void addBookProduct(string name, int price, int pages)
        {
            IStorage.storeBookProduct(name, price, pages);
        }

        public string listProducts()
        {
            string text = "";

            foreach (Product product in IStorage.getAllProduct())
            {
                text += $"Name: {product.name}\n" +
                        $"Price: {product.price}\n";
                if (product is CDProduct)
                    text += "Type: CD\n\n";
                else
                    text += "Type: Book\n\n";
            }

            return text;
        }

        public int getTotalProductPrice()
        {
            int result = 0;

            foreach (Product product in IStorage.getAllProduct())
                result += product.price;

            return result;
        }
    }
}
