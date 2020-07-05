using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopBooks.Core.Interfaces;

namespace OnlineShopBooks.Core
{
	public class CartItem
	{
		public int Id { get; set; }

		public IBook Item { get; }

		public int Quantity { get; }

		public CartItem(IBook item, int quantity)
		{
			this.Item = item;
			this.Quantity = quantity > item.Count ? item.Count : quantity;
		}
	}
}
