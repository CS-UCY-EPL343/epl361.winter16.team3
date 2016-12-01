using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uOrder
{
    public class Product
    {
        public String prodName;
        public double prodPrice;
        public Category cat;
        public Product(String n, double p, Category c)
        {
            prodName = n;
            prodPrice = p;
            cat = c;
        }
    }
}
