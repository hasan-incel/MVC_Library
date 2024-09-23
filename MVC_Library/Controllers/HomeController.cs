using Microsoft.AspNetCore.Mvc;
using MVC_Library.Models;
using System.Diagnostics;

namespace MVC_Library.Controllers
{
    public class HomeController : Controller
    {
        // Logger instance for logging messages related to this controller
        private readonly ILogger<HomeController> _logger;

        // Constructor that takes a logger as a parameter
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger; // Assign the logger to the private field
        }

        // Action method to display the home page
        public IActionResult Index()
        {
            return View(); // Returns the view associated with the Index action
        }

        // Action method to display the privacy policy page
        public IActionResult Privacy()
        {
            return View(); // Returns the view associated with the Privacy action
        }

        // Action method to handle errors, with response caching disabled
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Create a new ErrorViewModel with the current request ID
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
