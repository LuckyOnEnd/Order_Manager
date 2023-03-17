using OrderManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application
{
    public interface IOrderLineRepository
    {
        Task<List<OrderLine>> GetOrderLines();
        void Create(OrderLine orderLine);
        void Edit(OrderLine orderLine);
        void Delete(OrderLine orderLine);
        void SaveChanges();
    }
}
