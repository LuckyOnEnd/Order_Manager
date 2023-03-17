using Microsoft.EntityFrameworkCore;
using OrderManager.Application;
using OrderManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context.Remove(order);
            _context.SaveChanges();
        }

        public void Edit(Order order)
        {
            _context.Update(order);
            _context.SaveChanges();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FirstAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
