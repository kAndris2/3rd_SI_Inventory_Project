using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Inventory_Project
{

    public abstract class Store : StorageCapable
    {
        private static Type[] EXTRA_TYPES = new Type[] { typeof(CDProduct), typeof(BookProduct) };
        public const string FILENAME = "test.xml";
        public List<Product> products { get; set; } = new List<Product>();

        private void saveToXml(Product product)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Product>), EXTRA_TYPES);

            using (TextWriter writerfinal = new StreamWriter(FILENAME))
            {
                writer.Serialize(writerfinal, products);
            }
        }

        public List<Product> loadProducts()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Product>), EXTRA_TYPES);
            List<Product> i;

            using (FileStream readfile = File.OpenRead(FILENAME))
            {
                i = (List<Product>)reader.Deserialize(readfile);
            }

            return i;
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
            else
                throw new TypeAccessException($"Invalid type! ('{type}')");
        }

        public void store(Product product)
        {
            storeProduct(product);
            saveToXml(product);
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
