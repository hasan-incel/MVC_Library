using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Library.Models
{
    public class Author // Define the Author class
    {
        public int AuthorId { get; set; } // Unique identifier for the author

        [Required(ErrorMessage = "First name is required.")] // Validation attribute to ensure first name is provided
        public string FirstName { get; set; } // Author's first name

        [Required(ErrorMessage = "Last name is required.")] // Validation attribute to ensure last name is provided
        public string LastName { get; set; } // Author's last name

        [Required(ErrorMessage = "Date of birth is required.")] // Validation attribute to ensure date of birth is provided
        public DateTime DateOfBirth { get; set; } // Author's date of birth

        public string FullName => $"{FirstName} {LastName}"; // Read-only property to get the full name of the author
    }
}
