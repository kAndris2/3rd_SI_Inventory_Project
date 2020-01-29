using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_Project
{
    public class CDProduct : Product
    {
        public int numOfTracks { get; set; }

        public CDProduct() { }

        public CDProduct(string name, int price, int tracks)
        {
            this.name = name;
            this.price = price;
            numOfTracks = tracks;
        }
    }
}
