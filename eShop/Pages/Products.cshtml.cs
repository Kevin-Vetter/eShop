using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace eShop.Pages
{
    public class ProductsModel : PageModel
    {

        public List<Product> Products;
        public Product Product;

        private readonly ILogger<ProductsModel> _logger;
        private readonly IRepo _repo;

        public ProductsModel(ILogger<ProductsModel> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }


        public void OnGet()
        {
            Products = _repo.GetAllProducts();
        }
    }
}
