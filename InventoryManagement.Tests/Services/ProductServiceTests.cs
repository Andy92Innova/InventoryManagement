using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Services;
using InventoryManagement.Domain.Models;
using Moq;

namespace InventoryManagement.Tests.Services;

[TestFixture]
public class ProductServiceTests
{
    private Mock<IProductRepository> _mockRepository;
    private ProductService _productService;

    [SetUp]
    public void SetUp()
    {
        _mockRepository =  new Mock<IProductRepository>();
        _productService = new ProductService(_mockRepository.Object);
    }

    [Test]
    public async Task GetProductByIdAsync_ValidId_ReturnsProduct()
    {
        var idProduct = Guid.NewGuid();
        //Arrange
        var mockProduct = new Product { Id=idProduct, Name="Product 1" };
        _mockRepository.Setup(repo => repo.GetByIdAsync(idProduct)).ReturnsAsync(mockProduct);

        //Act
        var result = await _productService.GetProductByIdAsync(idProduct);

        //Assert
        Assert.That(idProduct, Is.EqualTo(result.Id));
        Assert.That("Product 1", Is.EqualTo(result.Name));
    }

    [Test]
    public async Task CreateProductAsync_ValidProduct_ReturnsTrue()
    {
        var idProduct = Guid.NewGuid();

        //Arrange
        var mockProduct = new Product { Id = idProduct, Name = string.Empty } ;
        _mockRepository.Setup(repo => repo.AddAsync(mockProduct)).Returns(Task.CompletedTask);

        //Act
        await _productService.AddProductAsync(mockProduct);

        //Assert
        _mockRepository.Verify(repo => repo.AddAsync(mockProduct), Times.Once);

    }
}