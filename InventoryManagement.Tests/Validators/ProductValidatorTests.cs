using FluentValidation.TestHelper;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Validators;

namespace InventoryManagement.Tests.Validators;

[TestFixture]
public class ProductValidatorTests
{
    private ProductValidator _productoValidator;

    [SetUp]
    public void Setup()
    {
        _productoValidator = new ProductValidator();
    }

    [Test]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        var product = new Product { Name = string.Empty };
        var result = _productoValidator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p=>p.Name);
    }

    [Test]
    public void Should_Have_Error_When_Price_Is_Less_Than_Or_Equal_To_Zero()
    {
        var product = new Product { Price = -1 };
        var result = _productoValidator.TestValidate(product);
        result.ShouldHaveValidationErrorFor(p=>p.Price);
    }

    [Test]
    public void Should_Not_Have_Error_When_Product_Is_Valid()
    {
        var product = new Product { 
            Name = "Product Test",
            Description  ="new product",
            Price = 1,
            Stock = 1
        };

        var result = _productoValidator.TestValidate(product);
        result.ShouldNotHaveAnyValidationErrors();
    }
}