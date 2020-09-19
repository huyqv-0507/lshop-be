using System;
using System.Collections.Generic;
using System.Linq;
using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Models;
using Services.IServices;

namespace Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrderRepository orderRepository;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetOrders(string username)
        {
            return orderRepository.GetMany(order => username == order.UserName);
        }

        public IEnumerable<Order> GetOrdersByCreatedTime(string username, DateTime time)
        {
            return orderRepository.GetMany(orders => username == orders.UserName && orders.CreatedTime.Equals(time));
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}
