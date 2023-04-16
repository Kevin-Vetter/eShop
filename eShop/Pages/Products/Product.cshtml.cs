using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace eShop.Pages.Products
{
    public class ProductModel : PageModel
    {
        public Product Product { get; set; }



        private readonly ILogger<ProductModel> _logger;
        private readonly IRepo _repo;

        public ProductModel(ILogger<ProductModel> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public void OnGet(int id)
        {
            Product = _repo.GetProductById(id);
        }
    }
}
