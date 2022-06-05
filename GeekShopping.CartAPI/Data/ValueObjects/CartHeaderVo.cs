﻿using System.Diagnostics.CodeAnalysis;

namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class CartHeaderVo
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string? CouponCode { get; set; }
    }
}
