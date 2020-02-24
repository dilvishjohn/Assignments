using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments.BL
{

    public class ComputerSupplier : Supplier
    {
        public ComputerSupplier(string name, SupplierType type, IMessageService messageService, IRepository<Order> orderRepository) : 
            base(name, type, messageService, orderRepository)
        {

        }

        public override int DaysForProcessingOrder()
        {
            return 6;
        }
    }
}
