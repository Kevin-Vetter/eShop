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
        public void CreateNewCustomer(string firstName, string lastName, string adress, string email, bool disabled)
        {
            _context.Customers.Add(new Customer(firstName, lastName, adress, email, disabled));
            _context.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                return _context.Customers.FirstOrDefault(x => x.Id == id);
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
    }
}