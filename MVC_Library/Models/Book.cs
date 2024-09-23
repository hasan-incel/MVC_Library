using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Library.Models
{
	public class Book
	{
		public int BookId { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Author ID is required.")]
		public int AuthorId { get; set; }

		[Required(ErrorMessage = "Genre is required.")]
		public string Genre { get; set; }

		[Required(ErrorMessage = "Publish date is required.")]
		[DataType(DataType.Date)]
		public DateTime PublishDate { get; set; }

		[Required(ErrorMessage = "ISBN is required.")]
		public string ISBN { get; set; }

		[Required(ErrorMessage = "Copies available is required.")]
		[Range(0, int.MaxValue, ErrorMessage = "Copies available must be a non-negative number.")]
		public int CopiesAvailable { get; set; }
	}
}
