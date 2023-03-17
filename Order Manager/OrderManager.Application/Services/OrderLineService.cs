using OrderManager.Application.Services.Interfaces;
using OrderManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Application.Services
{
    public class OrderLineService : IOrderLineService
    {
        private readonly IOrderLineRepository _db;
        public OrderLineService(IOrderLineRepository db)
        {
            _db = db;
        }
        public void DeleteOrderLine(int id)
        {
            try
            {
                var orderLine = _db.GetOrderLines().Result.FirstOrDefault(x => x.Id == id);
                _db.Delete(orderLine);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong {ex}");
            }
        }

        public List<OrderLine> GetOrderLines(int id)
        {
            try
            {
                var result = _db.GetOrderLines().Result.Where(x => x.OrderID == id).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong {ex}");
            }
        }
        public void CreateOrderLines(int orderId, List<OrderLine> model)
        {
            if(orderId == 0)
                orderId = OrderService.Id;
            try
            {
                foreach (var orderLine in model)
                {
                    var order = new OrderLine()
                    {
                        OrderID = orderId,
                        Price = orderLine.Price,
                        Product = orderLine.Product,
                    };

                    _db.Create(order);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong {ex}");
            }
        }
    }
}
