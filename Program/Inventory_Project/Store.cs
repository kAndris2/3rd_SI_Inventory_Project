using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Inventory_Project
{

    public abstract class Store : StorageCapable
    {
        private void saveToXml(Product product)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Product));

            using (TextWriter writerfinal = new StreamWriter("test.xml"))
            {
                writer.Serialize(writerfinal, product);
            }
        }

        public abstract void storeProduct(Product product);
        public abstract List<Product> getAllProduct();

        protected Product createProduct(string type, string name, int price, int size)
        {
            if (type.ToLower() == "cd")
            {
                return new CDProduct(name, price, size);
            }
            else if (type.ToLower() == "book")
            {
                return new BookProduct(name, price, size);
            }
            return null;
        }

        public List<Product> loadProducts()
        {
            return null;
        }

        public void store(Product product)
        {
            //saveToXml(product);
            storeProduct(product);
        }

        public void storeCDProduct(string name, int price, int tracks)
        {
            store(createProduct("cd", name, price, tracks));
        }

        public void storeBookProduct(string name, int price, int pages)
        {
            store(createProduct("book", name, price, pages));
        }
    }
}
