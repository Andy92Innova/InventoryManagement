using FluentValidation;
using InventoryManagement.Domain.Models;

namespace InventoryManagement.Domain.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p=>p.Name)
            .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
            .MaximumLength(100).WithMessage("El nombre del producto no puede superar los 100 caracteres.");
        
        RuleFor(p=>p.Description)
            .NotEmpty().WithMessage("La descripción es obligatoria.")
            .MaximumLength(500).WithMessage("La descripción no puede superar los 500 caracteres");

        RuleFor(p=>p.Price)
            .GreaterThan(0).WithMessage("El precio debe ser mayor a 0");

        RuleFor(p=>p.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo");
    }
}