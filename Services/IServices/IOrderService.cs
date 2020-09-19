using System;
using System.Collections.Generic;
using Data.Models;

namespace Services.IServices
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders(string username);
        IEnumerable<Order> GetOrdersByCreatedTime(string username, DateTime time);
        void Save();
    }
}
