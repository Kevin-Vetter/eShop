using Bogus;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DAL
{
    public class eShopContext : DbContext
    {
        public eShopContext(DbContextOptions<eShopContext> dbOptions) : base(dbOptions) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .LogTo(message => Debug.WriteLine(message));

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderProducts>().HasKey(x => new
            {
                x.OrderId,
                x.ProductId
            });


            //seeding

            int brandId = 1;
            int catId = 1;
            int prodId = 1;
            int cusId = 1;

            Faker<Brand> brandFaker = new Faker<Brand>()
                .UseSeed(2)
                .RuleFor(x=> x.Id, () => brandId++)
                .RuleFor(x => x.BrandName, x => x.Company.CompanyName());

            modelBuilder.Entity<Brand>()
                .HasData(brandFaker.Generate(5));


            Faker<Category> categoryFaker = new Faker<Category>()
                .UseSeed(2)
                .RuleFor(x => x.Id, () => catId++)
                .RuleFor(x => x.CatName, x => x.Commerce.Categories(5).First());

            modelBuilder.Entity<Category>()
                .HasData(categoryFaker.Generate(5));


            Faker<Product> productFaker = new Faker<Product>()
                .UseSeed(2)
                .RuleFor(x => x.Id, () => prodId++)
                .RuleFor(x => x.Name, x => x.Commerce.ProductName())
                .RuleFor(x => x.Price, x => x.Commerce.Price().First())
                .RuleFor(x => x.BrandId, x => x.Random.Number(4) + 1)
                .RuleFor(x => x.CategoryId, x => x.Random.Number(4) + 1)
                .RuleFor(x => x.Popularity, x => x.Random.Number())
                .RuleFor(x=> x.ImgPath, "/comingSoon.jpg")
                .RuleFor(x=> x.Description, x=>x.Lorem.Paragraphs(2));
                  
            modelBuilder.Entity<Product>()
               .HasData(productFaker.Generate(300));


            Faker<Customer> customerFaker = new Faker<Customer>()
              .UseSeed(2)
              .RuleFor(x => x.Id, () => cusId++)
              .RuleFor(x => x.FirstName, x => x.Person.FirstName)
              .RuleFor(x => x.LastName, x => x.Person.LastName)
              .RuleFor(x => x.Address, x => x.Person.Address.Street)
              .RuleFor(x => x.Email, x => x.Person.Email);

            modelBuilder.Entity<Customer>()
               .HasData(customerFaker.Generate(1));
        }
    }
}