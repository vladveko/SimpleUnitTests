namespace UnitTests
{
    public class OrderService
    {
        private readonly IStorage storage;

        public OrderService(IStorage storage)
        {
            this.storage = storage;
        }

        public int PlaceOrder(Order order)
        {
            var orderId = storage.Store(order);
            
            // Some other work

            return orderId; 
        }
    }

    public class Order
    {
    }

    public interface IStorage
    {
        int Store(object obj);
    }
}