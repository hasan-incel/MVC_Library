using System.Collections.Generic;
using MVC_Library.Models;

namespace MVC_Library.Data
{
    public static class InMemoryData
    {
        public static List<Author> Authors { get; } = new List<Author>();
        public static List<Book> Books { get; set; } = new List<Book>(); // Change to settable
    }
}
