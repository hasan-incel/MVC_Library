using Microsoft.AspNetCore.Mvc; 
using MVC_Library.Models; 
using MVC_Library.ViewModels; 
using System.Collections.Generic; 
using System.Linq; 

namespace MVC_Library.Controllers // Define the namespace for the controller
{
    public class AuthorController : Controller // Define the AuthorController class, inheriting from Controller
    {
        public static List<Author> Authors { get; private set; } = new List<Author>(); // Static list to hold authors

        // Action to display the list of authors
        public IActionResult List()
        {
            var viewModel = new AuthorViewModel // Create a new instance of AuthorViewModel
            {
                Authors = Authors // Assign the static list of authors to the view model
            };
            return View(viewModel); // Return the view with the view model
        }

        // Action to display details of a specific author
        public IActionResult Details(int id)
        {
            var author = Authors.FirstOrDefault(a => a.AuthorId == id); // Find the author by ID
            if (author == null) return NotFound(); // Return 404 if the author is not found
            return View(author); // Return the author details view
        }

        // Action to display the create author form
        public IActionResult Create()
        {
            return View(new Author()); // Return a new Author instance to the view
        }

        // POST action to handle the submission of the create form
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                author.AuthorId = Authors.Count > 0 ? Authors.Max(a => a.AuthorId) + 1 : 1; // Simple ID generation
                Authors.Add(author); // Add the new author to the list
                return RedirectToAction("List"); // Redirect to the list of authors
            }
            return View(author); // Return the view with the author if model state is invalid
        }

        // Action to display the edit form for a specific author
        public IActionResult Edit(int id)
        {
            var author = Authors.FirstOrDefault(a => a.AuthorId == id); // Find the author by ID
            if (author == null) return NotFound(); // Return 404 if the author is not found
            return View(author); // Return the edit view for the author
        }

        // POST action to handle the submission of the edit form
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                var existingAuthor = Authors.FirstOrDefault(a => a.AuthorId == author.AuthorId); // Find the existing author
                if (existingAuthor != null)
                {
                    // Update the existing author's properties
                    existingAuthor.FirstName = author.FirstName;
                    existingAuthor.LastName = author.LastName;
                    existingAuthor.DateOfBirth = author.DateOfBirth;
                }
                return RedirectToAction("List"); // Redirect to the list of authors
            }
            return View(author); // Return the view with the author if model state is invalid
        }

        // Action to display the delete confirmation view for a specific author
        public IActionResult Delete(int id)
        {
            var author = Authors.FirstOrDefault(a => a.AuthorId == id); // Find the author by ID
            if (author == null) return NotFound(); // Return 404 if the author is not found
            return View(author); // Return the delete confirmation view
        }

        // POST action to handle the deletion of an author
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = Authors.FirstOrDefault(a => a.AuthorId == id); // Find the author by ID
            if (author != null)
            {
                Authors.Remove(author); // Remove the author from the list
            }
            return RedirectToAction("List"); // Redirect to the list of authors after deletion
        }
    }
}
