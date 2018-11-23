using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobs.DTO;
using PapaBobs.Persistence;

namespace PapaBobs.Domain
{
    public class OrderManager
    {
        public static void CreateOrder(OrderDTO orderDTO)
        {
            orderDTO.OrderId = Guid.NewGuid();
            orderDTO.TotalCost = PizzaPriceManager.CalculateCost(orderDTO);
            OrderRepository.CreateOrder(orderDTO);
        }

        public static object GetOrders()
        {
            var orders = OrderRepository.GetOrders();
            return orders;
        }

        public static void CompleteOrder(Guid orderId)
        {
            OrderRepository.CompleteOrder(orderId);
        }
    }
}
