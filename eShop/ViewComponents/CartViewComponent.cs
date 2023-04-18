using Bogus.Bson;
using DAL.Model;
using eShop.Pages;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceLayer.Service;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace eShop.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IRepo _repo;

        public CartViewComponent(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.Request.Cookies["Cart"] == null)
            {
                HttpContext.Response.Cookies.Append("Cart","{ProduktId:[],Amount[]};");
                var coo2kies = HttpContext.Request.Cookies;
            }
            var cookies = HttpContext.Request.Cookies; 
            List<Product> products = new List<Product>();



            //products.Add(_repo.GetProductById(2));

            return View(products);
        }
    }
}
