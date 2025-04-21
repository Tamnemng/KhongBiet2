using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class OrderController : Controller
    {
        private Cart cart;

        public OrderController(Cart cartService)
        {
            cart = cartService;
        }

        public ViewResult Checkout()
        {
            // Kiểm tra xem giỏ hàng có trống không
            if (cart.Lines.Count() == 0)
            {
                TempData["CartEmpty"] = "Your cart is empty! Please add some products before checkout.";
                return View("EmptyCart");
            }
            
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                // Thông báo thành công (sẽ thay thế bằng lưu vào DB sau)
                TempData["OrderSuccess"] = "Your order has been placed successfully!";
                cart.Clear();
                return RedirectToAction("Completed");
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            return View();
        }

        public ViewResult EmptyCart()
        {
            return View();
        }
    }
}