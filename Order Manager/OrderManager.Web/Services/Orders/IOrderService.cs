
using OrderManager.Web.Models;

namespace OrderManager.Web.Services.Orders
{
    public interface IOrderService
    {
        public List<Order> Orders { get; set; }
        public List<OrderLine> Lines { get; set; }
        Task<List<Order>> GetOrders();
        Task DeleteOrder(int id);
        Task<List<OrderLine>> GetOrderLines(int id);
        Task<Order> GetOrderById(int id);
    }
}
