using InventoryManagement.Domain.Models;

namespace InventoryManagement.Application.Interfaces;

public interface ITransactionRepository
{
    Task AddTransactionAsync(Transaction transaction);
    Task<IEnumerable<Transaction>> GetTransactionsByProductIdAsync(Guid productId);
}