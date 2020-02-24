using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments.BL
{
    public class OfficeOrder : Order
    {
        public OfficeOrder(string productID) : base(productID)
        {

        }
        public OfficeOrder(string productID, int quantity) : base(productID, quantity)
        {

        }
    }
}
