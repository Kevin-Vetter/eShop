using Bogus;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Service;
using System.Collections.Immutable;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XUnitTest;

public class UnitTests
{
    private void CreateTestData(eShopContext _context)
    {
        Faker<Brand> brandFaker = new Faker<Brand>()
           .UseSeed(2)
           .RuleFor(x => x.BrandName, x => x.Company.CompanyName());
        brandFaker.Generate(5).ForEach(bf => _context.Brands.Add(bf));
        _context.SaveChanges();

        Faker<Category> categoryFaker = new Faker<Category>()
          .UseSeed(2)
          .RuleFor(x => x.CatName, x => x.Commerce.Categories(5).First());
        categoryFaker.Generate(5).ForEach(cf => _context.Categories.Add(cf));
        _context.SaveChanges();

        Faker<Product> productFaker = new Faker<Product>()
            .UseSeed(2)
            .RuleFor(x => x.Name, x => x.Commerce.ProductName())
            .RuleFor(x => x.Price, x => x.Commerce.Price().First())
            .RuleFor(x => x.BrandId, x => x.Random.Number(4) + 1)
            .RuleFor(x => x.CategoryId, x => x.Random.Number(4) + 1)
            .RuleFor(x => x.Description, x => x.Lorem.Text())
            .RuleFor(x => x.ImgPath, x => x.Lorem.Word())
            .RuleFor(x => x.Popularity, x => x.Random.Number());
        productFaker.Generate(10).ForEach(pf => _context.Products.Add(pf));
        _context.SaveChanges();

        Faker<Customer> customerFaker = new Faker<Customer>()
          .UseSeed(2)
          .RuleFor(x => x.FirstName, x => x.Person.FirstName)
          .RuleFor(x => x.LastName, x => x.Person.LastName)
          .RuleFor(x => x.Address, x => x.Person.Address.Street)
          .RuleFor(x => x.Email, x => x.Person.Email);
        customerFaker.Generate(1).ForEach(cf => _context.Customers.Add(cf));
        _context.SaveChanges();

    }

    [Fact]
    public void DeleteProductTest()
    {
        //Arrange
        var _context = ContextCreater.CreateContext();
        var _repo = new Repo(_context);
        CreateTestData(_context);

        //Act
        _repo.DeleteProduct(4);
        var product = _repo.GetProductById(4);

        //Assert
        Assert.True(product.Disabled);
    }

   

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void SearchProductTest(int id)
    {
        //Arrange
        var _context = ContextCreater.CreateContext();
        var _repo = new Repo(_context);
        CreateTestData(_context);

        //Act
        Product productToFind = _repo.GetProductById(id);
        Product productFound = _repo.Search(productToFind.Name).First();

        //Assert
        Assert.Equal(productToFind.Name, productFound.Name);
    }
    
    [Fact]
    public void PagingTest()
    {
        //Arrange
        var _context = ContextCreater.CreateContext();
        var _repo = new Repo(_context);
        CreateTestData(_context);

        //Act
        List<Product> products = _repo.GetProductsPaging(1, 2);

        //Assert
        Assert.Equal(2, products.Count);
    }
}