using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppTemplate.ViewModels
{
    public class OrderDetailsViewModel
    {
        [Display(Name = "訂單ID")]
        public int OrderID { get; set; }

        [Display(Name = "產品ID")]
        public int ProductID { get; set; }

        [Display(Name = "單價")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "數量")]
        public short Quantity { get; set; }

        [Display(Name = "折扣")]

        public float Discount { get; set; }
    }
}