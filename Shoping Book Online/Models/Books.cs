using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OnlineShopBooks.Core.Interfaces;

namespace OnlineShopBooks.Models
{
	[Table("books")]
	public class Book : IBook
	{
		[Key]
		public int Id { get; set; }
		[Required, MaxLength(100)]
		public string Title { get; set; }
		[Required, MaxLength(100)]
		public string Author { get; set; }
		[Required, MinLength(20), MaxLength(1000)]
		public string Description { get; set; }
		[Required, Range(0, int.MaxValue)]
		public int Pages { get; set; }
		[Required, Range(0, int.MaxValue)]
		public int Price { get; set; }
		[Required, Range(0, int.MaxValue)]
		public int Count { get; set; }

		public Book(string title, string author, string description, int pages, int price, int count)
		{
			this.Title = title;
			this.Author = author;
			this.Description = description;
			this.Pages = pages;
			this.Price = price;
			this.Count = count;
		}
		
		public Book() {}
	}
}
