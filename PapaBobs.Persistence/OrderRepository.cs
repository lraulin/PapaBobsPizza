using System;
using System.Collections.Generic;
using System.Linq;
using PapaBobs.DTO;

namespace PapaBobs.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder(OrderDTO orderDTO)
        {
            var db = new PapaBobsDbEntities1();
            var order = convertToEntity(orderDTO);

            db.Orders.Add(order);
            db.SaveChanges();
        }

        private static Order convertToEntity(OrderDTO orderDTO)
        {
            var order = new Order();

            order.OrderId = orderDTO.OrderId;
            order.Size = orderDTO.Size;
            order.Crust = orderDTO.Crust;
            order.Sausage = orderDTO.Sausage;
            order.Pepperoni = orderDTO.Pepperoni;
            order.Onions = orderDTO.Onions;
            order.GreenPeppers = orderDTO.GreenPeppers;
            order.Name = orderDTO.Name;
            order.Address = orderDTO.Address;
            order.ZipCode = orderDTO.ZipCode;
            order.Phone = orderDTO.Phone;
            order.TotalCost = orderDTO.TotalCost;
            order.PaymentType = orderDTO.PaymentType;
            order.Completed = orderDTO.Completed;

            return order;
        }

        public static void CompleteOrder(Guid orderId)
        {
            var db = new PapaBobsDbEntities1();
            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderId);
            order.Completed = true;
            db.SaveChanges();
        }

        public static object GetOrders()
        {
            var db = new PapaBobsDbEntities1();
            //var orders = db.Orders.ToList();
            var orders = db.Orders.Where(p => p.Completed == false).ToList();
            var ordersDTO = ConvertToDTO(orders);
            return ordersDTO;
        }

        static List<OrderDTO> ConvertToDTO(List<Order> orders)
        {
            var ordersDTO = new List<OrderDTO>();

            foreach (var order in orders)
            {
                var orderDTO = new OrderDTO();

                orderDTO.OrderId =      order.OrderId;
                orderDTO.Size =         order.Size;
                orderDTO.Crust =        order.Crust;
                orderDTO.Sausage =      order.Sausage;
                orderDTO.Pepperoni =    order.Pepperoni;
                orderDTO.Onions =       order.Onions;
                orderDTO.GreenPeppers = order.GreenPeppers;
                orderDTO.Name =         order.Name;
                orderDTO.Address =      order.Address;
                orderDTO.ZipCode =      order.ZipCode;
                orderDTO.Phone =        order.Phone;
                orderDTO.PaymentType =  order.PaymentType;
                orderDTO.TotalCost =    order.TotalCost;

                ordersDTO.Add(orderDTO);
            }

            return ordersDTO;
        }
    }
}
