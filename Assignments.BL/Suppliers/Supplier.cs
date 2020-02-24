namespace Assignments.BL
{

    public class Supplier:Entity
    {

        public SupplierType Type { get; private set; }

        private readonly IMessageService _messageService;
        private readonly IRepository<Order> _orderRepository;

        public Supplier(string id, SupplierType type, IMessageService messageService, IRepository<Order> orderRepository) :base(id)
        {
            Type = type;
            _messageService = messageService;
            _orderRepository = orderRepository;
        }
        public void ProcessOrder(string productID, int quantity)
        {

            if(_orderRepository.GetById(productID) == null)
            {
                _messageService.SendMessage($"Error while  Received order for {quantity} quantity of Order {productID}. The are no such order for  Supplier: {GetType().Name}");
                return;
            }
            _messageService.SendMessage($"Message from Supplier {GetType().Name}: Received order for {quantity} quantity of Order {productID}. The order will be processed in {DaysForProcessingOrder()} days");
        }

        public void AddOrderForSupplier(Order product)
        {
            _orderRepository.Add(product);
        }

        public virtual int DaysForProcessingOrder()
        {
           return 0;
        }
        
    }
}
