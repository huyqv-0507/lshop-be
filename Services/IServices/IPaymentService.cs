using System;
using Services.VNPAY;

namespace Services.IServices
{
    public interface IPaymentService
    {
        String paymentOrder(OrderInfor orderInfor);
    }
}
