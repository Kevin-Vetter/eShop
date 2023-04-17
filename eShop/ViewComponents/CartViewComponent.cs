using Microsoft.AspNetCore.Mvc;

namespace eShop.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View();
        }
    }
}
