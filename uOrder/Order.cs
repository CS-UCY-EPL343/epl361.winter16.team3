using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uOrder
{
    public class Order
    {
        public List<Product> products;
        public double price = 0;
        public bool isReady = false;
        public Order()
        {
            products = new List<Product>();
        }
        public bool addProduct(Product p)
        {
            if (p == null) return false;
            products.Add(p);
            price += p.prodPrice;
            return true;
        }
        public bool removeProduct(Product p)
        {
            price -= p.prodPrice;
            return products.Remove(p);
        }

        public bool removeProduct(int p)
        {
            if (p > products.Count) return false;
            price -= products[p].prodPrice;
            products.RemoveAt(p);
            return true;
        }
    }
}
