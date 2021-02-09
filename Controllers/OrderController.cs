using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apshop.Repositories.Interfaces;
using apshop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using apshop.BLL.Services;
using apshop.BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace apshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly IUserService userService;
        public OrderController(IOrderService os, ICartService cs, IUserService us)
        {
            orderService = os; cartService = cs;userService = us;
        }


        [HttpGet("{orderid}")]
        public async Task<IActionResult> GetOrder(int orderid)
        {
            var order = orderService.GetOrderById(orderid);
            if (order == null) return NotFound();
            else return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int orderid, Order order)
        {
            if (orderid != order.orderId) return BadRequest();

            try
            {
                orderService.UpdateOrder(order);
                return Ok(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                var theorder = orderService.GetOrderById(orderid);
                if (theorder == null) return NotFound();
                else throw;

            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order, [FromHeader]int userId)
        {
            var items = userService.GetMyCart(userId).cartItems;
           
            if (items.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                userService.ClearMyCart(userService.GetMyCart(userId).cartId);
                return Ok();
            }
            return Ok(order);
          
        }


        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromBody] Order order)
        {
            Order _order = orderService.AddOrder(order);
            return Ok(_order);
        }

        
        [HttpDelete("{id}")]
        public async Task<RedirectToActionResult> DeleteOrder(int orderid)
        {
            var order = orderService.GetOrderById(orderid);
            if (order != null)  orderService.DeleteOrder(order);

            return RedirectToAction("GetOrder");
        }


    }

}
