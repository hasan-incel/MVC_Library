using Microsoft.AspNetCore.Mvc;
using MVC_Library.Models;
using MVC_Library.ViewModels;
using System;


namespace MVC_Library.Controllers // Define the namespace for the controller
{
    public class AuthController : Controller // Define the AuthController class, inheriting from Controller
    {
        private static List<User> users = new List<User>(); // Static list to store registered users

        [HttpGet]
        public IActionResult SignUp() // GET action to show the signup form
        {
            return View(); // Return the signup view
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model) // POST action to handle signup form submission
        {
            if (!ModelState.IsValid) // Check if the model state is valid
            {
                return View(model); // Return the view with the model if validation fails
            }

            User newUser = new User // Create a new User object
            {
                Id = users.Count + 1, // Simple ID generation
                FullName = model.FullName, // Assign full name from the view model
                Email = model.Email, // Assign email from the view model
                Password = model.Password, // Assign password from the view model (should ideally be hashed)
                PhoneNumber = model.PhoneNumber, // Assign phone number from the view model
                JoinDate = DateTime.Now // Set the current date as the join date
            };

            users.Add(newUser); // Add the new user to the list
            return RedirectToAction("Login"); // Redirect to the login action after successful signup
        }

        [HttpGet]
        public IActionResult Login() // GET action to show the login form
        {
            return View(); // Return the login view
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) // POST action to handle login form submission
        {
            if (!ModelState.IsValid) // Check if the model state is valid
            {
                return View(model); // Return the view with the model if validation fails
            }

            var user = users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password); // Find user by email and password
            if (user != null) // If user is found
            {
                // Implement login logic (e.g., create session or set authentication cookie)
                return RedirectToAction("Index", "Home"); // Redirect to the home index action
            }

            // Set error message to be displayed on the login page if authentication fails
            ModelState.AddModelError("", "Invalid email or password."); // Add error to model state
            ViewData["ErrorMessage"] = "Invalid email or password."; // Pass the error message to the view
            return View(model); // Return the view with the model if login fails
        }
    }
}