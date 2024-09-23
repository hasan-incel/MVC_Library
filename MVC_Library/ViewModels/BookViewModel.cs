using System.Collections.Generic;
using MVC_Library.Models;

namespace MVC_Library.ViewModels
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; } // If you want to include authors in this view model
    }
}
