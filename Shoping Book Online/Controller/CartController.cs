using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopBooks.Core;
using OnlineShopBooks.Core.Interfaces;
using OnlineShopBooks.DAL;
using OnlineShopBooks.Models;

namespace OnlineShopBooks.Controllers
{
	[Authorize(Roles = "Customer")]
	public class CartController : Controller
	{
		private readonly StoreContext _context = new StoreContext();
		// GET: Cart
		public ActionResult Index()
		{
			if (!(Session["CartStorage"] is Cart) || (Cart)Session["CartStorage"] == null)
				Session["CartStorage"] = new Cart();

			//Session.Remove("CartStorage");
			Cart cart = (Cart)Session["CartStorage"];

			return View(cart.Items);
		}

		// GET: Cart/Add/5
		public ActionResult Add(int id, string type, int quantity)
		{
			if (!(Session["CartStorage"] is Cart) || (Cart)Session["CartStorage"] == null)
				Session["CartStorage"] = new Cart();

			Cart cart = (Cart)Session["CartStorage"];

			switch (type)
			{
				case "Book":
					var book = _context.Books.FirstOrDefault(b => b.Id == id);
					if (book == null) return View("Error");

					cart.AddItem(new CartItem(book, quantity));
					Session["CartStorage"] = cart;

					break;
				case "AudioBook":
					var audioBook = _context.AudioBooks.FirstOrDefault(b => b.Id == id);
					if (audioBook == null) return View("Error");

					cart.AddItem(new CartItem(audioBook, quantity));
					Session["CartStorage"] = cart;

					break;
				default:
					return View("Error");
			}

			return RedirectToAction("Index");
		}

		// GET: Cart/Remove/5
		public ActionResult Remove(int id)
		{
			if (!(Session["CartStorage"] is Cart) || (Cart)Session["CartStorage"] == null)
				Session["CartStorage"] = new Cart();

			Cart cart = (Cart)Session["CartStorage"];

			cart.RemoveItem(id);

			Session["CartStorage"] = cart;

			return RedirectToAction("Index");
		}
	}
}
