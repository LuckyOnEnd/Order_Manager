using OrderManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application.Services.Interfaces
{
    public interface IOrderLineService
    {
        List<OrderLine> GetOrderLines(int id);
        void CreateOrderLines(int id, List<OrderLine> model);
        void DeleteOrderLine(int id);
    }
}
