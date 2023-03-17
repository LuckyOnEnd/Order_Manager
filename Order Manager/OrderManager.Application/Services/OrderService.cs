using OrderManager.Application.Services.Interfaces;
using OrderManager.Domain.Entity;
using OrderManager.Domain.StaticDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderLineRepository _orderLineRepository;
        public static int Id = 0;
        public OrderService(IOrderRepository orderRepository, IOrderLineRepository orderLineRepository)
        {
            _orderRepository = orderRepository;
            _orderLineRepository = orderLineRepository;
        }
        public OrderService() { }
        public List<Order> GetOrders()
        {
            try
            {
                return _orderRepository.GetOrders().Result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong {ex}");
            }
        }
        public void CreateOrder(Order model)
        {
            try
            {
                Order order = new Order()
                {
                    OrderPrice = model.OrderPrice,
                    ClientName = model.ClientName,
                    Address = model.Address,
                    City = model.City,
                    Status = StatusSD.New,
                    CreateDate = DateTime.Now,
                    AdditionalInfo = model.AdditionalInfo,
                };
                _orderRepository.Create(order);
                Id = order.Id;
            }
            catch (Exception ex) 
            {
                throw new ArgumentException($"Something went wrong {ex}");
            }
        }

        public void DeleteOrder(int id)
        {
            try
            {
                var order = _orderRepository.GetOrderById(id).Result;
                if (order.Status.ToString() != "New")
                    throw new ArgumentException("You can delete orders only in New status");
                _orderRepository.Delete(order);
                var lines = _orderLineRepository.GetOrderLines().Result.Where(x => x.OrderID == id).ToList();
                foreach(var x in lines)
                    _orderLineRepository.Delete(x);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong {ex}");
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                var result = _orderRepository.GetOrderById(id).Result;
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong {ex}");
            }
        }

        public Order UpdateOrder(int id, Order model)
        {
            try
            {
                var order = _orderRepository.GetOrderById(id).Result;
                if (order.Status != "New")
                    throw new ArgumentException("You cannot change order status");
                order.ClientName = model.ClientName;
                order.City = model.City;
                order.Address = model.Address;
                order.Status = model.Status;

                _orderRepository.Edit(order);

                return order;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong {ex}");
            }
        }

        public void UpdateOrderPrice(int id)
        {
            var order = _orderRepository.GetOrderById(id).Result;
            var orderLines = _orderLineRepository.GetOrderLines().Result.Where(x => x.OrderID == id); 

            order.OrderPrice = orderLines.Sum(x => x.Price);

            _orderRepository.Edit(order);
        }
    }
}
