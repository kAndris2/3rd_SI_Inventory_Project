using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Inventory_Project
{
    class PersistentStore : Store
    {
        public PersistentStore()
        {
            if (File.Exists(FILENAME))
                products = loadProducts();
        }

        public override void storeProduct(Product product)
        {
            products.Add(product);
        }

        public override List<Product> getAllProduct()
        {
            return products;
        }
    }
}
