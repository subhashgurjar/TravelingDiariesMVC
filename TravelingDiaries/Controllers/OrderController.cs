using Microsoft.AspNetCore.Mvc;
using TravelingDiaries.Models;

namespace TravelingDiaries.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }


        //This is the form for details
        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {


                ModelState.AddModelError("", "Your cart is empty add some pies");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete",order);

            }

            return View(order);
        }


        public IActionResult CheckoutComplete(Order order)
        {

           
            return View(order);

        }
   

       
    }

    }
