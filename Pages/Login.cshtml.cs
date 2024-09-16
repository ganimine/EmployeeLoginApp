using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLoginApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginViewModel LoginData { get; set; }

        // In-memory data for demo purposes
        private static List<Employee> RegisteredEmployees = new List<Employee>
        {
            new Employee { Email = "test@test.com", Password = "Password123" }
        };

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var employee = RegisteredEmployees.FirstOrDefault(e => e.Email == LoginData.Email && e.Password == LoginData.Password);
            if (employee != null)
            {
                return RedirectToPage("Welcome");  // Navigate to a welcome page upon successful login
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
