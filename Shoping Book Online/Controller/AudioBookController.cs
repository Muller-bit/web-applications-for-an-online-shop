using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopBooks.DAL;
using OnlineShopBooks.Models;

namespace OnlineShopBooks.Controllers
{
	[Authorize]
	public class AudioBookController : Controller
    {
	    private readonly StoreContext _context = new StoreContext();
		// GET: AudioBook
		public ActionResult Index(string sort)
        {
	        IEnumerable<AudioBook> audiBooks;

	        ViewBag.SortOrderTitle = sort == null || sort == "TitleDesc" ? "TitleAsc" : "TitleDesc";
	        ViewBag.SortOrderPrice = sort == null || sort == "PriceDesc" ? "PriceAsc" : "PriceDesc";

	        switch (sort)
	        {
		        case "TitleAsc":
			        audiBooks = _context.AudioBooks.OrderBy(b => b.Title);
			        break;

		        case "TitleDesc":
			        audiBooks = _context.AudioBooks.OrderByDescending(b => b.Title);
			        break;

		        case "PriceAsc":
			        audiBooks = _context.AudioBooks.OrderBy(b => b.Price);
			        break;

		        case "PriceDesc":
			        audiBooks = _context.AudioBooks.OrderByDescending(b => b.Price);
			        break;

		        default:
			        audiBooks = _context.AudioBooks;
			        break;
	        }

	        Session["cart"] = new List<String>();

	        return View(audiBooks);
		}

        // GET: AudioBook/Details/5
        public ActionResult Details(int id)
        {
	        var audioBook = _context.AudioBooks.FirstOrDefault(b => b.Id == id);
			return audioBook == null ? View("Error") : View(audioBook);
        }

		// GET: AudioBook/Create
		[Authorize(Roles = "Admin")]
		public ActionResult Create()
        {
            return View();
        }

		// POST: AudioBook/Create
		[Authorize(Roles = "Admin")]
		[HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
	            var audioBook = new AudioBook(
		            collection["Title"], collection["Author"], collection["Description"],
		            collection["Format"], int.Parse(collection["Length"]), 
		            int.Parse(collection["Price"]), int.Parse(collection["Count"])
		            );

	            _context.AudioBooks.Add(audioBook);
	            _context.SaveChanges();

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		// GET: AudioBook/Edit/5
		[Authorize(Roles = "Admin")]
		public ActionResult Edit(int id)
        {
	        var audioBook = _context.AudioBooks.FirstOrDefault(b => b.Id == id);
	        return audioBook == null ? View("Error") : View(audioBook);
		}

		// POST: AudioBook/Edit/5
		[Authorize(Roles = "Admin")]
		[HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
				var audioBook = _context.AudioBooks.FirstOrDefault(b => b.Id == id);
				if (audioBook == null)
					return View("Error");

				audioBook.Title = collection["Title"];
				audioBook.Author = collection["Author"];
				audioBook.Description = collection["Description"];
				audioBook.Format = collection["Format"];
				audioBook.Length = int.Parse(collection["Length"]);
				audioBook.Size = int.Parse(collection["Size"]);
				audioBook.Price = int.Parse(collection["Price"]);
				audioBook.Count = int.Parse(collection["Count"]);

				_context.SaveChanges();

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		// GET: AudioBook/Delete/5
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(int id)
        {
	        var audioBook = _context.AudioBooks.FirstOrDefault(b => b.Id == id);
	        return audioBook == null ? View("Error") : View(audioBook);
		}

		// POST: AudioBook/Delete/5
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
	            var audioBook = _context.AudioBooks.FirstOrDefault(b => b.Id == id);
	            if (audioBook == null)
		            return View("Error");

	            _context.AudioBooks.Remove(audioBook);
	            _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
