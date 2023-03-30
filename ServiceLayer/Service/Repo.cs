using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Service
{
    public class Repo : IRepo
    {
        private readonly eShopContext _context;
        public Repo(eShopContext context) { _context = context; }

        #region Customer
        public void CreateNewCustomer(string firstName, string lastName, string adress, string email)
        {
            _context.Customers.Add(new Customer(firstName, lastName, adress, email, false));
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

        public void UpdateCustomer(int id, string firstName, string lastName, string adress, string email)
        {
            Customer updatedCustomer = new(id, firstName, lastName, adress, email, false);
            Customer customer;
            try
            {
                customer = _context.Customers.AsNoTracking().First(x => x.Id == updatedCustomer.Id);
            }
            catch (Exception)
            {
                Console.WriteLine("uh oh, stinky UwU - no uwser wit dis aidee cwould be fwound >.<' pwease tway again :3");

                throw;
            }
            customer = updatedCustomer;
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = GetCustomerById(id);

            customer.Disabled = true;
            _context.SaveChanges();
        }
        #endregion

        #region Product
        public void CreateNewProduct(string name, double price, int brandId, int categoryId)
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

        public void UpdateProduct(int id, string name, double price, int brandId, int categoryId)
        {
            Product updatedProduct = new Product { Id = id, Name = name, Price = price, BrandId = brandId, CategoryId = categoryId };
            Product product;
            try
            {
                product = GetProductById(id);
            }
            catch (Exception)
            {
                Console.WriteLine("uh oh, stinky UwU - no uwser wit dis aidee cwould be fwound >.<' pwease tway again :3");

                throw;
            }
            product = updatedProduct;
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProductById(id);

            product.Disabled = true;
            _context.SaveChanges();
        }

        public void UpdatePopularity(int id)
        {
            Product product = GetProductById(id);

        }
        #endregion

        #region Order
        public void CreateNewOrder(int customerId, int amount)
        {
            _context.Orders.Add(new Order { Created = DateTime.Now, CustomerId= customerId, Amount = amount});
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