using System.Collections.Generic;
using System.Linq;

namespace Assignments.BL
{
    public class SystematesInc 
    { 
        private readonly IMessageService _messageService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Supplier> _supplierRepository;

        public SystematesInc(IMessageService messageService,IRepository<Order> orderRepository, IRepository<Supplier> supplierRepository )
        {
            _messageService = messageService;
            _supplierRepository = supplierRepository;
            _orderRepository = orderRepository;
        }

        public Supplier AddSupplier(Supplier sup)
        {
           return _supplierRepository.Add(sup);
        }

        public Order AddOrder(Order sup)
        {
            return _orderRepository.Add(sup);
        }

        public void IssueOrder(string supplierID, string productID, int quantity)
        {
            var supplier = _supplierRepository.GetById(supplierID);
            var product = _orderRepository.GetById(productID);
            string message = $"Error when trying to IssueOrder with supplier:{supplierID} and product:{productID}";


            if (supplier == null)
            {
                _messageService.SendMessage($"{message} There are no such supplier in System");
                return;
            }

            if (product == null)
            {
                _messageService.SendMessage($"{message} There are no such product in System");
                return;
            }
            _messageService.SendMessage($"Issued Purchase Order for {product.GetType().Name} to supplier {supplier.GetType().Name}");
            supplier.ProcessOrder(productID, quantity);
        }
        public static void Register(IEnumerable<Supplier> suppliers, IEnumerable<Order> orders)
        {
            foreach (var s in suppliers)
            {
                foreach (var order in orders)
                {
                    s.AddOrderForSupplier(order);
                }
            }
        }
    }
}
