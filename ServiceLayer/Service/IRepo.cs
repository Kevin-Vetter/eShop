using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ServiceLayer.Service
{
    public interface IRepo
    {
        #region Customer
        //CRUD
        public void CreateNewCustomer(string firstName, string lastName, string adress, string email);
        public Customer GetCustomerById(int id);
        public void UpdateCustomer(Customer newCustomer);
        public void DeleteCustomer(int id);
        Customer GetCustomerByEmail(string email);
        #endregion

        #region Product
        //CRUD
        void CreateNewProduct(string name, decimal price, int brandId, int categoryId);
        Product GetProductById(int id);
        void UpdateProduct(Product newProduct);
        void DeleteProduct(int id);
        //MISC
        void UpdatePopularity(int id);
        public List<Product> Search(string searchQuery);
        public List<Product> GetProductsPaging(int page, int numberOfProducts);
        Page<Product> GetAllProducts(int page, int count, string? search);
        #endregion

        #region Order
        //CR
        void CreateNewOrder(int customerId, Cart cart);
        Order GetOrderById(int id);
        #endregion
    }
}
