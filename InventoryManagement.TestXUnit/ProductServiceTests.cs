using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Services;
using InventoryManagement.Domain.Models;
using Moq;

namespace InventoryManagement.TestXUnit;

public class ProductServiceTests
{

    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _productService = new ProductService(_mockProductRepository.Object);
    }

    [Fact]
    public async Task GetProductByIdAsync_ValidId_ReturnsProduct()
    {
        var idProduct = Guid.NewGuid();

        //Arrange
        var mockProduct = new Product { Id=idProduct, Name ="Product 1" };
        _mockProductRepository.Setup(repo=>repo.GetByIdAsync(idProduct)).ReturnsAsync(mockProduct);

        //Act
        var result = await _productService.GetProductByIdAsync(idProduct);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(idProduct, result.Id);
        Assert.Equal("Product 1", result.Name);
    }

    [Fact]
    public async Task CreateProductAsync_ValidProduct_ReturnsTrue()
    {
        var idProduct = Guid.NewGuid();;

        //Arrage
        var mockProduct = new Product { Id = idProduct, Name= string.Empty };
        _mockProductRepository.Setup(repo=>repo.AddAsync(mockProduct)).Returns(Task.CompletedTask);

        //Act
        await _productService.AddProductAsync(mockProduct);

        //Assert
        _mockProductRepository.Verify(repo=>repo.AddAsync(mockProduct), Times.Once);

    }

}