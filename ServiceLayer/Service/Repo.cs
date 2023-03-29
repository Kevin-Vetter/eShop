using DAL;
using DAL.Model;

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

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}