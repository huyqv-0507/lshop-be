using System;
using onlinestore.Vnpay;
using Services.IServices;
using Services.VNPAY;

namespace Services.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {
        }

        public string paymentOrder(OrderInfor orderInfor)
        {
            //Get Config Info
            string vnp_Returnurl = "https://vnpay.vn/"; //URL nhan ket qua tra ve 
            string vnp_Url = "http://sandbox.vnpayment.vn/paymentv2/vpcpay.html"; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = "V506LPIZ"; //Ma website
            string vnp_HashSecret = "OJQGFBNAMFXOYDATMDUBAATKTJMBODMG"; //Chuoi bi mat

            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", "2.0.0");
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);

            string locale = "vn";
            if (!string.IsNullOrEmpty(locale))
            {
                vnpay.AddRequestData("vnp_Locale", locale);
            }
            else
            {
                vnpay.AddRequestData("vnp_Locale", "vn");
            }

            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_TxnRef", orderInfor.OrderId.ToString());//Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất đùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày.
            vnpay.AddRequestData("vnp_OrderInfo", "THANHTOAN");
            vnpay.AddRequestData("vnp_OrderType", "130000"); //default value: other
            vnpay.AddRequestData("vnp_Amount", (orderInfor.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_BankCode", "NCB");

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            return paymentUrl;
        }
    }
}
