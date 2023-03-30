using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace eShop.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string fName { get; set; }
        [BindProperty]
        public string lName { get; set; }
        [BindProperty]
        public string adress { get; set; }
        [BindProperty]
        public string mail { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IRepo _repo;

        public IndexModel(ILogger<IndexModel> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            _repo.CreateNewCustomer(fName,lName,adress,mail);
        }
        public IActionResult OnPostUpdateCustomer()
        {
            _repo.UpdateCustomer(Id,fName,lName,adress,mail);
            return Page();
        }
    }
}