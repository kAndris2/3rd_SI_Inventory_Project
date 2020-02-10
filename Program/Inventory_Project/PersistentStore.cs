using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Inventory_Project
{
    class PersistentStore : Store
    {
        public PersistentStore(string ext)
        {
            extension = ext;
            if (File.Exists(FILENAME + "." + ext))
            {
                if (ext == "xml")
                    products = loadProductsFromXml();

                else if (ext == "csv")
                    products = loadProductsFromCsv();
            }
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
