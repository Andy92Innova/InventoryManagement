using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Domain.Models;

#nullable disable
public class Product
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage ="El nombre del producto es obligatorio")]
    [StringLength(100, ErrorMessage ="El nombre del producto no puede superar los 100 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage ="La descripción es obligatoria")]
    [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
    public string Description { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage ="El precio debe ser mayor de 0")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage ="El stock no puede ser negativo")]
    public int Stock { get; set; }

}