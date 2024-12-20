using InventoryManagement.Domain.Models;

namespace InventoryManagement.Application.Interfaces;

public interface ITransactionService
{
    Task<bool> AddTransactionAsync(Transaction transaction);
    Task<IEnumerable<Transaction>> GetTransactionsByProductIdAyns(Guid productID);
    Task ValidateStockForTransaction();
}