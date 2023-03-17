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
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderLineRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public void Create(OrderLine orderLine)
        {
            _context.OrderLines.Add(orderLine);
            _context.SaveChanges();
        }

        public void Delete(OrderLine orderLine)
        {
            _context.OrderLines.Remove(orderLine);
            _context.SaveChanges();
        }

        public void Edit(OrderLine orderLine)
        {
            _context.OrderLines.Update(orderLine);
            _context.SaveChanges();
        }

        public async Task<List<OrderLine>> GetOrderLines()
        {
            return await _context.OrderLines.ToListAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
