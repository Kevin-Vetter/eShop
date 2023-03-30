using DAL;
using DAL.Model;
using ServiceLayer.Service;
using System.Collections.Immutable;
using Xunit;

namespace XUnitTest;

public class UnitTests
{
    [Fact]
    public async Task TestGetProductById()
    {
        //Arange
        var _context =  ContextCreater.CreateContext();
        var _repo = new Repo(_context);

        //Act
        Product product = _repo.GetProductById(2);



        //Assert
        Assert.Equal("Ductape 30m", $"{product.Name}");

    }
}