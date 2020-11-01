using System;
namespace Services.VNPAY
{
    public class OrderInfor
    {
        /// <summary>
        /// Merchant OrderId
        /// </summary>
        public decimal OrderId { get; set; }
        /// <summary>
        /// Payment amount
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// VNPAY Transaction Id
        /// </summary>
        public decimal vnp_TransactionNo { get; set; }
        public string vpn_Message { get; set; }
        public string vpn_TxnResponseCode { get; set; }
    }
}
