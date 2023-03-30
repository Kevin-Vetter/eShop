using Azure;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ServiceLayer.Service
{
    public class Repo : IRepo
    {
        private readonly eShopContext _context;
        public Repo(eShopContext context) { _context = context; }

        #region Customer
        public void CreateNewCustomer(string firstName, string lastName, string adress, string email)
        {
            _context.Customers.Add(new Customer { FirstName = firstName, LastName = lastName, Address = adress, Email = email });
            _context.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                return _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                Console.WriteLine("uh oh, stwinky UwU - no uwser wit dis aidee cwould be fwound >.<' pwease tway again :3");
                throw;
            }
        }

        public void UpdateCustomer(Customer newCustomer)
        {

            Customer oldCustomer = _context.Customers.First(x => x.Id == newCustomer.Id);
            oldCustomer = newCustomer;

            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = GetCustomerById(id);

            customer.Disabled = true;
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }
        #endregion

        #region Product
        public void CreateNewProduct(string name, decimal price, int brandId, int categoryId)
        {
            _context.Products.Add(new Product { Name = name, Price = price, BrandId = brandId, CategoryId = categoryId });
            _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            try
            {
                return _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                Console.WriteLine("uh oh, stwinky UwU - no uwser wit dis aidee cwould be fwound >.<' pwease tway again :3");
                throw;
            }
        }

        public void UpdateProduct(Product newProduct)
        {
            Product oldProduct = _context.Products.First(x => x.Id == newProduct.Id);
            oldProduct = newProduct;

            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var query = from products in _context.Products
                        where products.Id == id
                        select products;

            Product product = query.First();

            product.Disabled = true;
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdatePopularity(int id)
        {
            Product product = GetProductById(id);
            product.Popularity++;
            UpdateProduct(product);
        }
        public List<Product> Search(string searchQuery)
        {
            return _context.Products.Where(x => EF.Functions.Like(x.Name, $"%{searchQuery}%")).ToList();
        }
        #endregion

        #region Order
        // here i should really use somethin to connect productid & amount and also make it scaleable
        public void CreateNewOrder(int customerId, int productId, int amount)
        {
            ICollection<Product> products = new List<Product>
            {
                _context.Products.First(i => i.Id == productId)
            };
            Customer customer = _context.Customers.First(x=>x.Id == customerId);
            var order = new Order { Customer = customer, Created = DateTime.Now, Amount = amount };
            order.Products = products;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            try
            {
                return _context.Orders.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                Console.WriteLine("uh oh, stwinky UwU - no uwser wit dis aidee cwould be fwound >.<' pwease tway again :3");
                throw;
            }
        }

        #endregion
    }
}