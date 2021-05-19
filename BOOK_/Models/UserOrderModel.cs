using BOOK_.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOOK_.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public EnumOrderState OrderState { get; set; } //sipariş durumunu gosteriyo
        public DateTime OrderDate { get; set; }
    }
}