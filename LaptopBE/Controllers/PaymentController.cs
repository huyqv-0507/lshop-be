using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.VNPAY;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopBE.Controllers
{
    [Route("api/v1/payment")]
    public class PaymentController : Controller
    {
        private IPaymentService paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpPost]
        public IActionResult Pay(OrderInfor orderInfor)
        {
            var paymentUrl = paymentService.paymentOrder(orderInfor);
            return Ok(paymentUrl);
        }
    }
}
