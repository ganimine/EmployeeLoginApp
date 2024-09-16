using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLoginApp.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Employee Employee { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the Employee object to the database (or in-memory)
            // Example: _context.Employees.Add(Employee);

            return RedirectToPage("Login");
        }
    }

    public class Employee
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
