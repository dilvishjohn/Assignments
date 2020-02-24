using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignments.BL
{
    public class Order: Entity
    {
        public int Quantity { get; private set; }
        public Order(string productID):base(productID)
        { 

        }
        public Order(string productID, int quantity):base(productID)
        {
            Quantity = quantity;
        }
    }

}
