using ShoppingCart.Data;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartContext db = new ShoppingCartContext();
        // GET: Cart
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }

        public ActionResult Add(int SanPhamID)
        {
            if (Session["giohang"] == null) 
            {
                Session["giohang"] = new List<CartItem>();  
            }
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  

           
            if (giohang.FirstOrDefault(m => m.ProductId == SanPhamID) == null) 
            {
                Product product = db.Product.Find(SanPhamID);  

                CartItem newItem = new CartItem()
                {
                    ProductId = SanPhamID,
                    ProductName = product.Name,
                    Quantity = 1,
                    UnitPrice = product.Price,
                };  

                giohang.Add(newItem);  
            }
            else
            {
               
                CartItem cardItem = giohang.FirstOrDefault(m => m.ProductId == SanPhamID);
                cardItem.Quantity++;
            }

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Delete(int SanPhamID)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.ProductId == SanPhamID);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Edit(int SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.ProductId == SanPhamID);
            if (itemSua != null)
            {
                itemSua.Quantity = soluongmoi;
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}