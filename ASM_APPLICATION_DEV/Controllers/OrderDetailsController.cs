﻿using ASM_APPLICATION_DEV.Data;
using ASM_APPLICATION_DEV.Models;
using ASM_APPLICATION_DEV.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ASM_APPLICATION_DEV.Controllers
{
	[Authorize]
	public class OrderDetailsController : Controller
	{
		private ApplicationDbContext context;
		private readonly UserManager<User> userManager;

		public OrderDetailsController(ApplicationDbContext context, UserManager<User> userManager)
		{
			this.context = context;
			this.userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index(int id)
		{
			Cart cart = new Cart();		
			int result = 0;

			if (id != 0)
			{
				cart.orderDetails = context.OrderDetails.Include(t => t.Order)
					.Include(t => t.Book).Where(t => t.OrderId == id).ToList();
				foreach (var item in cart.orderDetails)
				{
					result += item.Price;
				}
				cart.totalPrice = result;

				return View(cart);
			}
			cart.orderDetails = context.OrderDetails.Include(t => t.Book).Include(t => t.Order)
				.Where(t => t.Order.StatusOrder == Enums.OrderStatus.Unconfirmed 
				&& t.Order.UserId == userManager.GetUserId(User)).ToList();
			foreach(var item in cart.orderDetails)
			{
				result += item.Price;
			}
			cart.totalPrice =  result;

			return View(cart);
		}

		[HttpGet]
		public IActionResult Delete (int id)
		{
			var orderDetail = context.OrderDetails.Include(t => t.Order).SingleOrDefault(t => t.Id == id);
			orderDetail.Order.PriceOrder = 0;
			context.Remove(orderDetail);
			List<OrderDetail> orderDetails = context.OrderDetails.Include(t => t.Order).Where(t => t.OrderId == orderDetail.OrderId).ToList();

			foreach (var item in orderDetails)
			{			
				item.Order.PriceOrder += item.Price;
			}
			context.SaveChanges();

			return RedirectToAction("Index");
		}


		[HttpPost]
		public IActionResult Edit (Cart cart)
		{
			foreach (var item in cart.orderDetails)
			{
				var a = context.OrderDetails.SingleOrDefault(t => t.Id == item.Id);
			
					a.Quantity = item.Quantity;

	
			}
			context.SaveChanges();
			return RedirectToAction("Checkout", "Orders");
		}

        public IActionResult DetailsForStoreOwner(int id)
        {
            CheckOut checkOut = new CheckOut();

            var ordersDetails = context.OrderDetails
           .Include(t => t.Order).Include(t => t.Order.User).Include(t => t.Book)
           .Where(t => t.OrderId == id).ToList();


            checkOut.orderDetails = ordersDetails;
            checkOut.Name = ordersDetails[0].Order.User.FullName;
            checkOut.Address = ordersDetails[0].Order.User.Address;
            checkOut.TotalPrice = ordersDetails[0].Order.PriceOrder;

            return View(checkOut);
        }
    }
}
