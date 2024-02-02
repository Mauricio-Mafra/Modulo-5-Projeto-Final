using Domain.Entities;
using Domain.Exceptions;

namespace Infrastructure.Repositories
{

    public interface IOrderRepository
    {
        List<Order> List();
        Order? GetById(int id);
        Order Create(Order order);
        Order Update(Order orderUpdateData, int id);
        void Delete(int id);
    }
    public class OrderRepository : IOrderRepository
    {
        private static readonly List<Order> _orders = new List<Order>();

        public Order Create(Order newOrder)
        {
            newOrder.Id = _orders.Count + 1;
            _orders.Add(newOrder);
            return newOrder;
        }

        public void Delete(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order is null) {
                throw new NotFoundException("Order not found!");
            }
            _orders.Remove(order);
        }

        public Order? GetById(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> List()
        {
            return _orders;
        }

        public Order Update(Order orderUpdateData, int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order is null)
            {
                throw new NotFoundException("Order not found!");
            }
            order.ProductId = orderUpdateData.ProductId;
            order.UserId = orderUpdateData.UserId;
            _orders.Remove(order);
            _orders.Add(order);

            return order;

        }
    }
}
