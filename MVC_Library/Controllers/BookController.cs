using Microsoft.AspNetCore.Mvc;
using MVC_Library.Models;
using MVC_Library.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Library.Controllers
{
	public class BookController : Controller
	{
		private static List<Book> Books { get; set; } = new List<Book>();

		// Reference to the AuthorController's Authors list
		private static List<Author> Authors => AuthorController.Authors;

		public IActionResult List()
		{
			var viewModel = new BookViewModel
			{
				Books = Books,
				Authors = Authors // Include authors for display if needed
			};
			return View(viewModel);
		}

		public IActionResult Details(int id)
		{
			var book = Books.FirstOrDefault(b => b.BookId == id);
			if (book == null) return NotFound();
			return View(book);
		}

		public IActionResult Create()
		{
			ViewBag.Authors = Authors; // Pass authors to the view
			return View();
		}

		[HttpPost]
		public IActionResult Create(Book book)
		{
			if (ModelState.IsValid)
			{
				// Generate a new BookId if necessary
				book.BookId = Books.Count > 0 ? Books.Max(b => b.BookId) + 1 : 1;
				Books.Add(book);
				return RedirectToAction("List");
			}

			ViewBag.Authors = Authors; // Repopulate authors if validation fails
			return View(book);
		}

		public IActionResult Edit(int id)
		{
			var book = Books.FirstOrDefault(b => b.BookId == id);
			if (book == null) return NotFound();

			ViewBag.Authors = Authors; // Populate the authors for the dropdown
			return View(book);
		}

		[HttpPost]
		public IActionResult Edit(Book book)
		{
			if (ModelState.IsValid)
			{
				var existingBook = Books.FirstOrDefault(b => b.BookId == book.BookId);
				if (existingBook != null)
				{
					existingBook.Title = book.Title;
					existingBook.AuthorId = book.AuthorId;
					existingBook.Genre = book.Genre;
					existingBook.PublishDate = book.PublishDate;
					existingBook.ISBN = book.ISBN;
					existingBook.CopiesAvailable = book.CopiesAvailable;
				}
				return RedirectToAction("List");
			}

			ViewBag.Authors = Authors; // Repopulate authors if validation fails
			return View(book);
		}

		public IActionResult Delete(int id)
		{
			var book = Books.FirstOrDefault(b => b.BookId == id);
			if (book == null) return NotFound();
			return View(book);
		}

		[HttpPost]
		public IActionResult DeleteConfirmed(int id)
		{
			var book = Books.FirstOrDefault(b => b.BookId == id);
			if (book != null)
			{
				Books.Remove(book); // Remove the book from the list
			}
			return RedirectToAction("List"); // Redirect back to the list after deletion
		}
	}
}
