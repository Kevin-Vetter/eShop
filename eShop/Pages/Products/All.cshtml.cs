using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace eShop.Pages
{
    public class AllModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? CurrentPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? PageSize { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }


        public Page<Product> Products;
        public Product Product;

        private readonly ILogger<AllModel> _logger;
        private readonly IRepo _repo;

        public AllModel(ILogger<AllModel> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }


        public void OnGet(int currentPage =1, int pageSize= 10, string? search = null)
        {
            Products = _repo.GetAllProducts(currentPage,pageSize,search);
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Products/All",new { currentPage = CurrentPage, pageSize = PageSize, search = Search});
        }
    }
}
