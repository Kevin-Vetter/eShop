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
        public void UpdateCustomer(int id, string firstName, string lastName, string adress, string email);
        public void DeleteCustomer(int id);
        
        #endregion
    }
}
