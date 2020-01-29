using System;
using System.Collections.Generic;

namespace Inventory_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreManager sman = new StoreManager();
            sman.addStorage(new PersistentStore());

            while (true)
            {
                Menu();
                try
                {
                    if (!Choose(sman))
                        break;
                    else
                    {
                        Console.WriteLine("[Press enter to continue...]");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                catch (KeyNotFoundException e) { ManageEx(e.Message); }
                catch (ArgumentException e) { ManageEx(e.Message); }
            }
        }

        public static void Menu()
        {
            var menu = new List<string>() { "Create product", 
                                            "List all products",
                                            "Get total products price"
                                          };

            Console.WriteLine("[Inventory Project]\n");
            for (int i = 0; i < menu.Count; i++)
                Console.WriteLine($"({i + 1}). - {menu[i]}");
            Console.WriteLine("\n(0). - Exit");
        }

        public static bool Choose(StoreManager manager)
        {
            Console.WriteLine("\nChoose an option to enter a menu:");
            string option = Console.ReadLine();

            if (option == "0")
            {
                Environment.Exit(-1);
                return false;
            }
            else if (option == "1")
            {
                Console.Clear();
                List<string> props = new List<string>() { "type (CD/Book)", "name", "price", "size"};
                string[] values = new string[4];

                for (int i = 0; i < values.Length; i++)
                {
                    Console.WriteLine($"\nEnter the product {props[i]}:");
                    if (i == 0)
                    {
                        string temp = Console.ReadLine();
                        if (temp.ToLower() != "cd" && temp.ToLower() != "book")
                            throw new ArgumentException($"Invalid type! ('{temp}')\n");
                        values[i] = temp;
                        continue;
                    }
                    values[i] = Console.ReadLine();
                }

                if (values[0].ToLower() == "cd")
                    manager.addCDProduct(values[1], int.Parse(values[2]), int.Parse(values[3]));
                else
                    manager.addBookProduct(values[1], int.Parse(values[2]), int.Parse(values[3]));

                return true;
            }
            else if (option == "2")
            {
                Console.Clear();
                string text = manager.listProducts();

                if (text.Length == 0)
                    throw new ArgumentException("There are no products in the database!\n");

                Console.WriteLine(text);

                return true;
            }
            else if (option == "3")
            {
                Console.Clear();
                Console.WriteLine($"Total price is {manager.getTotalProductPrice()}$.\n");
                return true;
            }
            else
                throw new KeyNotFoundException($"There is no such option! ('{option}')\n");
        }

        public static void ManageEx(string message)
        {
            Console.Clear();
            Console.WriteLine("[ERROR]: " + message);
        }
    }
}
