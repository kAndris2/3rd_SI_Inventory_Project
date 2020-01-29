using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Project
{
    class PersistentStore : Store
    {
        private List<Product> products { get; set; } = new List<Product>();

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
