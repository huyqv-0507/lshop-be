using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopBE.Controllers
{
    [Route("api/v1/orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        //GET api/v1/orders
        [HttpGet("{username}")]
        public IActionResult GetOrders(string username)
        {
            var orders = orderService.GetOrders(username);
            if (orders == null) return Content("Order is empty");
            return Ok(orders);
        }
        //GET api/v1/orders
        [HttpGet("{username}&{daytime}")]
        public IActionResult GetOrders(string username, DateTime daytime)
        {
            var orders = orderService.GetOrdersByCreatedTime(username, daytime);
            if (orders == null) return Content("Order is empty");
            return Ok(orders);
        }
    }
}
