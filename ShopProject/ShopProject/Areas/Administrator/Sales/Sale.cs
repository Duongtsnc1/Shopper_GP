using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopProject.Areas.Administrator.Sales
{
    public class Sale
    {
        public Sale() { }
        public Sale(String a, int b) {
            orderDateTime = a;
            totalQuantity = b;
        }
        public String orderDateTime { get; set; }
        public int totalQuantity { get; set; }
    }
}