using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace eShop.Pages
{
    public class LoginModel : PageModel
    {
        public string Email { get; set; } 

        private readonly ILogger<LoginModel> _logger;
        private readonly IRepo _repo;

        public LoginModel(ILogger<LoginModel> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public void OnGet()
        {
        }
    }
}
