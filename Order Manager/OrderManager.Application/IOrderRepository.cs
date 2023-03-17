using OrderManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(int id);
        void Create(Order order);
        void Edit(Order order);
        void Delete(Order order);
        void SaveChanges();
    }
}
