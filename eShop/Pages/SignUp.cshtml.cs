using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace eShop.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Address { get; set; }

        private readonly ILogger<SignUpModel> _logger;
        private readonly IRepo _repo;

        public SignUpModel(ILogger<SignUpModel> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult OnPost()
        {

            _repo.CreateNewCustomer(FirstName, LastName, Address, Email);

            return RedirectToPage("/login");
        }
    }
}
