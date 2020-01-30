using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Project
{
   public abstract class Product
    {
        //Private volt!
        public string name { get; set; }
        public int price { get; set; }
        public string type { get; set; }
    }
}
