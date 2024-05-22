using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Cs_Plantlover.Areas.Admin.Models
{
    public static class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Admin = " Admin";
        //
        public const string ssShoppingCart = "Shopping Cart Session";
        public const string StatusPending = "Chờ xử lý";
        public const string StatusApproved = "Đã tiếp nhận";
        public const string StatusInProcess = "Đang giao";
        public const string StatusShipped = "Giao thành công";
        public const string StatusCancelled = "Hủy đơn";
        public const string StatusRefunded = "Hoàn lại";

        public const string PaymentStatusPending = "Chờ xử lý";
        public const string PaymentStatusApproved = "Đã thanh toán";
        public const string PaymentStatusDelayedPayment = "Thanh toán khi nhận hàng";
        public const string PaymentStatusRejected = "Hoàn tiền";
    }
}
