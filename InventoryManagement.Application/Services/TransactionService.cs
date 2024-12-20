using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Models;

namespace InventoryManagement.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionrepository;
    private readonly IProductRepository _productRepository;

    public TransactionService(ITransactionRepository transactionrepository, 
                                IProductRepository productRepository)
    {
        _transactionrepository = transactionrepository;
        _productRepository = productRepository;
    }

    public async Task<bool> AddTransactionAsync(Transaction transaction)
    {
        //validate transaction type
        if(transaction.Type != "IN" && transaction.Type != "OUT")
            throw new ArgumentException("Invalid transaction type");

        //validate stock for "OUT" transactions
        if(transaction.Type == "OUT")
        {
            var product = await _productRepository.GetByIdAsync(transaction.ProductId);
            
            if(product == null)
                throw new ArgumentException("Product not found");
            
            if(product.Stock < transaction.Quantity)
                throw new InvalidOperationException("Insufficient stock for the transactio");
        }

        //update stock product
        var productToUpdate = await _productRepository.GetByIdAsync(transaction.ProductId);
        
        if(productToUpdate != null)
        {
            //save the transaction
            await _transactionrepository.AddTransactionAsync(transaction);

            //update stock product
            productToUpdate.Stock += transaction.Type == "IN" ? transaction.Quantity : -transaction.Quantity;
            await _productRepository.UpdateAsync(productToUpdate);

            return true;
        }
        
        return false;
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByProductIdAyns(Guid productID)
    {
        return await _transactionrepository.GetTransactionsByProductIdAsync(productID);
    }

    public Task ValidateStockForTransaction()
    {
        throw new NotImplementedException();
    }
}
