using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopBooks.Core
{
	public class Cart
	{
		public List<CartItem> Items = new List<CartItem>();

		public void AddItem(CartItem item)
		{
			item.Id = Items.Count();
			Items.Add(item);
		}

		public void RemoveItem(int id)
		{
			var item = Items.FirstOrDefault(i => i.Id == id);
			if (item == null) return;

			Items.Remove(item);
		}
	}
}
