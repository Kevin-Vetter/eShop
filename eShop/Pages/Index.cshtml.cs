using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Service;

namespace eShop.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly IRepo _repo;

        public IndexModel(ILogger<IndexModel> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        
    }
}