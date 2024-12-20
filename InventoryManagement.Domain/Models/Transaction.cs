namespace InventoryManagement.Domain.Models;

#nullable disable
public class Transaction
{
    public int Id { get; set; }
    public Guid ProductId { get; set; }
    public DateTime TransactionDate { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }
    public string Note { get; set; }

    public Product Product { get; set; }
}