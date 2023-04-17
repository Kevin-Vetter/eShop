using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace eShop.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        private readonly ILogger<LoginModel> _logger;
        private readonly IRepo _repo;

        public LoginModel(ILogger<LoginModel> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult OnGet()
        {
            if (Request.Cookies["loggedIn"] == "true")
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Email != null)
            {
                Response.Cookies.Append("loggedIn", "true");
                Response.Cookies.Append("user", Email);
            }

            return Page();
        }
    }
}
