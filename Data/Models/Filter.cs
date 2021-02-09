using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apshop.Data.Models
{
    public class Filter
    {
        public string category { get; set; }
        public bool male{ get; set; }
        public bool female { get; set; }
        public string name { get; set; }
        public double shippingPrice { get; set; }
        public double minPrice{ get; set; }
        public double maxPrice { get; set; }

        public Filter(string name, string category, bool male, bool female, double shippingPrice, double minPrice, double maxPrice)
        {
           this.name=name; this.category = category; this.male = male; this.female =female ; this.shippingPrice = shippingPrice; this.minPrice = minPrice; this.maxPrice = maxPrice;
        }

        public Filter()
        {

            this.name = "undefined"; this.category = "undefined"; this.male = false; this.female = false; this.shippingPrice = 0; this.minPrice = 0; this.maxPrice = 500;


        }
    }

}
