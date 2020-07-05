using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OnlineShopBooks.Core.Interfaces;

namespace OnlineShopBooks.Models
{
	[Table("audio_books")]
	public class AudioBook : IBook
	{
		[Key]
		public int Id { get; set; }
		[Required, MaxLength(100)]
		public string Title { get; set; }
		[Required, MaxLength(100)]
		public string Author { get; set; }
		[Required, MinLength(20), MaxLength(1000)]
		public string Description { get; set; }
		[Required]
		public string Format { get; set; }
		[Required, Range(0, int.MaxValue)]
		public int Length { get; set; }
		[Required, Range(0, int.MaxValue)]
		public int Size { get; set; }
		[Required, Range(0, int.MaxValue)]
		public int Price { get; set; }
		[Required, Range(0, int.MaxValue)]
		public int Count { get; set; }

		public AudioBook(string title, string author, string description, string format, int length, int price, int count)
		{
			this.Title = title;
			this.Author = author;
			this.Description = description;
			this.Format = format;
			this.Length = length;
			this.Price = price;
			this.Count = count;
		}

		public AudioBook() { }
	}
}
