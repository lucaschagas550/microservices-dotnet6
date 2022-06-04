﻿using System.ComponentModel.DataAnnotations.Schema;
using GeekShopping.CartAPI.Model.Base;

namespace GeekShopping.CartAPI.Model
{
    [Table("cart_detail")]
    public class CartDetail : BaseEntity
    {
        [ForeignKey("CartHeaderId")]
        public long CartHeaderId { get; set; }

        [ForeignKey("ProductId")]
        public long ProductId { get; set; }

        [Column("count")]
        public int Count { get; set; }

        public virtual CartHeader CartHeader { get; set; }
        public virtual Product Product { get; set; }
    }
}
