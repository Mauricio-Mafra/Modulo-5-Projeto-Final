using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public interface IOrderService
    {
        List<Order> List();
        Order? GetById(int id);
        Order Create(Order newOrder);
        Order Update(Order orderUpdateData, int id);
        void Delete(int id);

    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Create(Order newOrder)
        {
            return _orderRepository.Create(newOrder);
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }

        public Order? GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public List<Order> List()
        {
            return _orderRepository.List();
        }

        public Order Update(Order orderUpdateData, int id)
        {
            return _orderRepository.Update(orderUpdateData, id);
        }
    }
}
