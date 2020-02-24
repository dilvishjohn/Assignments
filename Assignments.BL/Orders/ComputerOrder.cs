using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments.BL
{
    public class ComputerOrder : Order
    {
        public ComputerOrder(string productID) : base(productID)
        {

        }
        public ComputerOrder(string productID, int quantity) : base (productID, quantity)
        {
        }
    }
}
