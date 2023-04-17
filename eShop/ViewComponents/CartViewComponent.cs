using eShop.Pages;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service;

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
