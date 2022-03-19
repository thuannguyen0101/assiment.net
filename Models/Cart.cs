using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Cart
    {
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhone { get; set; }
        public List<CartItem> listCartItem { get; set; }

        public void Add(int productId, int quantity)
        {
        }

        public void Remove(int productId)
        {
        }

        public void Clear()
        {
        }

        public void Update(int productId, int quantity)
        {
        }
    }
}