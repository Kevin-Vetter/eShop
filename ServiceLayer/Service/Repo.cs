﻿using Azure;
using DAL;
using DAL.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

        public Customer GetCustomerByEmail(string email)
        {
            try
            {
                return _context.Customers.AsNoTracking().FirstOrDefault(x => x.Email == email);
            }
            catch (Exception)
            {
                Console.WriteLine("uh oh, stwinky UwU - no uwser wit dis aidee cwould be fwound >.<' pwease tway again :3");
                throw;
            }
        }

        public void UpdateCustomer(int id, JsonPatchDocument<Customer> newCustomer)
        {
            Customer oldCustomer = GetCustomerById(id);
            newCustomer.ApplyTo(oldCustomer); ;
            _context.SaveChanges();

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

        public DAL.Model.Page<Product> GetAllProducts(int page, int count, string? search)
        {
            IQueryable<Product> query = _context.Products.Include(x => x.Brand).Include(x => x.Category);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{search}%") || EF.Functions.Like(x.Brand.BrandName, $"%{search}%"));
            }

            return new DAL.Model.Page<Product>() { Items = query.Page(page, count).ToList(), Total = query.Count(), CurrentPage = page, PageSize = count };
        }

        public void CreateNewProduct(string name, decimal price, int brandId, int categoryId, string desc, string path)
        {
            _context.Products.Add(new Product { Name = name, Price = price, BrandId = brandId, CategoryId = categoryId, Description = desc, ImgPath = path});
            _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            try
            {
                return _context.Products.Include(b => b.Brand).Include(c => c.Category).AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                Console.WriteLine("uh oh, stwinky UwU - no uwser wit dis aidee cwould be fwound >.<' pwease tway again :3");
                throw;
            }
        }

        public void UpdateProduct(int id, JsonPatchDocument<Product> newProduct)
        {
            Product oldProduct = GetProductById(id);
            newProduct.ApplyTo(oldProduct);
            _context.Products.Update(oldProduct);

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
            //Product product = GetProductById(id);
            //product.Popularity++;
            //UpdateProduct(product);
        }
        public List<Product> Search(string searchQuery)
        {
            return _context.Products.Include(b => b.Brand).Where(x => EF.Functions.Like(x.Name, $"%{searchQuery}%") || EF.Functions.Like(x.Brand.BrandName, $"%{searchQuery}%")).ToList();
        }
        public List<Product> GetProductsPaging(int page, int numberOfProducts)
        {
            IQueryable<Product> query = _context.Products;

            return query.Page(page, numberOfProducts).AsNoTracking().ToList();
        }

        #endregion

        #region Order
        // here i should really use somethin to connect productid & amount and also make it scaleable
        public void CreateNewOrder(int customerId, Cart cart)
        {
            List<OrderProducts> orders = new();
            for (int i = 0; i < cart.ProductsIds.Count; i++)
            {
                orders.Add(new OrderProducts { ProductId = cart.ProductsIds[i], Amount = cart.Amounts[i] });
            }

            Order order = new Order
            {
                Created = DateTime.Now,
                CustomerId = customerId,
                OrderProducts = orders
            };

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
                Console.WriteLine("uh oh, stwinky UwU - no owder wit dis aidee cwould be fwound >.<' pwease tway again :3");
                throw;
            }
        }

        #endregion
    }
}