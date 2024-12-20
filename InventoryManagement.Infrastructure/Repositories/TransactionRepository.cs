using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Models;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Repositories;
public class TransactionRepository : ITransactionRepository
{
    private readonly InventoryDbContext _inventoryDb;

    public TransactionRepository(InventoryDbContext inventoryDb)
    {
        _inventoryDb = inventoryDb;
    }
    public async Task AddTransactionAsync(Transaction transaction)
    {
        await _inventoryDb.AddAsync(transaction);
        await _inventoryDb.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByProductIdAsync(Guid productId)
    {
        var details = (await _inventoryDb.Transactions.ToListAsync()).Where(x=>x.ProductId.Equals(productId));
        return details;
    }
}