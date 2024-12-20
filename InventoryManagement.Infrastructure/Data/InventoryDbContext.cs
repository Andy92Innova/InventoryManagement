using InventoryManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InventoryManagement.Infrastructure.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext( DbContextOptions<InventoryDbContext> options ) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Transaction> Transactions {get;set;}
}