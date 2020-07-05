using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopBooks.Core.Interfaces
{
	public interface IBook
	{
		int Id { get; set; }
		string Title { get; set; }
		string Author { get; set; }
		string Description { get; set; }
		int Price { get; set; }
		int Count { get; set; }
	}
}
