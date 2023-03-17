using OrderManager.Web.Models;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace OrderManager.Web.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderLine> Lines { get; set; } = new List<OrderLine>();
        public OrderService(HttpClient httpClient) 
        { 
            _httpClient= httpClient;
        }
        public async Task<List<Order>> GetOrders()
        {
            try
            {
                var orders = await _httpClient.GetFromJsonAsync<List<Order>>("api/Order");
                Orders = orders;
                return Orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteOrder(int id)
        {
            await _httpClient.DeleteFromJsonAsync<Order>($"api/Order/{id}");
        }

        public async Task<List<OrderLine>> GetOrderLines(int id)
        {
            try
            {
                var lines = await _httpClient.GetFromJsonAsync<List<OrderLine>>($"api/Order/details/{id}");
                Lines = lines;
                return Lines;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            try
            {
                var order = await _httpClient.GetFromJsonAsync<Order>($"api/Order/{orderId}");
                return order;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
