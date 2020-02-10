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
        public const string FILENAME = "products";
        public List<Product> products { get; set; } = new List<Product>();
        protected string extension { get; set; }

        private void saveToXml()
        {
            string filename = FILENAME + ".xml";
            XmlSerializer writer = new XmlSerializer(typeof(List<Product>), EXTRA_TYPES);

            using (TextWriter writerfinal = new StreamWriter(filename))
            {
                writer.Serialize(writerfinal, products);
            }
        }

        public List<Product> loadProductsFromXml()
        {
            string filename = FILENAME + ".xml";
            XmlSerializer reader = new XmlSerializer(typeof(List<Product>), EXTRA_TYPES);
            List<Product> i;

            using (FileStream readfile = File.OpenRead(filename))
            {
                i = (List<Product>)reader.Deserialize(readfile);
            }

            return i;
        }

        public void saveToCsv()
        {
            string filename = FILENAME + ".csv";
            string text = "";
            for (int i = 0; i < products.Count; i++)
            {
                text += $"{products[i].name};{products[i].price};{products[i].type};";
                if (products[i] is CDProduct)
                    text += $"{((CDProduct)products[i]).numOfTracks}\n";
                else
                    text += $"{((BookProduct)products[i]).numOfPages}\n";
            }
            File.WriteAllText(filename, text);
        }

        public List<Product> loadProductsFromCsv()
        {
            string filename = FILENAME + ".csv";
            List<Product> plist = new List<Product>();
            string[] table = File.ReadAllLines(filename);

            for (int i = 0; i < table.Length; i++)
            {
                string[] temp = table[i].Split(";");
                if (Array.Exists(temp, element => element == "CD"))
                    plist.Add(new CDProduct(temp[0], int.Parse(temp[1]), int.Parse(temp[3])));
                else
                    plist.Add(new BookProduct(temp[0], int.Parse(temp[1]), int.Parse(temp[3])));
            }

            return plist;
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

            if (extension == "xml")
                saveToXml();
            else if (extension == "csv")
                saveToCsv();
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
