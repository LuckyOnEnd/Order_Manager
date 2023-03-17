using OrderManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application.Services.Interfaces
{
    public interface IOrderService
    {
        public Order GetOrderById(int id);
        public List<Order> GetOrders();
        public void CreateOrder(Order order);
        public Order UpdateOrder(int id, Order order);
        public void DeleteOrder(int id);
        public void UpdateOrderPrice(int id);
    }
}
