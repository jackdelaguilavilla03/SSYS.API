using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using SSYS.API.CRM.Domain.Models;
using SSYS.API.HCM.Domain.Models;
using SSYS.API.IAM.Domain.Models;
using SSYS.API.SCM.Domain.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace SSYS.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public Microsoft.EntityFrameworkCore.DbSet<Account> MainUsers { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<User?> Users { get; set; }
    
    public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }//1
    public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }//2
    
    public Microsoft.EntityFrameworkCore.DbSet<Employee> Employees { get; set; }//2
    
    public Microsoft.EntityFrameworkCore.DbSet<Customer> Customers { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<SaleOrder> SaleOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Relationships
        builder.Entity<Account>()
            .HasMany(u => u.Users)
            .WithOne(u => u.Account)
            .HasForeignKey(u => u.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        //User
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(100);

        //Product
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Title).IsRequired();
        builder.Entity<Product>().Property(p => p.Id).IsRequired();
        builder.Entity<Product>().Property(p => p.Amount);
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.Date).IsRequired();
        builder.Entity<Product>().Property(p => p.IdCategory);
        
        //Category
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(c=>c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired();
        builder.Entity<Category>().Property(c => c.Title).IsRequired();
        builder.Entity<Category>().Property(c => c.Description);
        
        //Employee
        builder.Entity<Employee>().ToTable("Employees");
        builder.Entity<Employee>().HasKey(p => p.Id);
        builder.Entity<Employee>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Employee>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Employee>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
        builder.Entity<Employee>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
        
        //Customer
        builder.Entity<Customer>().ToTable("Customers");
        builder.Entity<Customer>().HasKey(p => p.Id);
        builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Customer>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
        builder.Entity<Customer>().Property(p => p.Email).IsRequired().HasMaxLength(40);
        builder.Entity<Customer>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
        
        //SaleOrder
        builder.Entity<SaleOrder>().ToTable("SalesOrder");
        builder.Entity<SaleOrder>().HasKey(p => p.Id);
        builder.Entity<SaleOrder>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<SaleOrder>().Property(p => p.MethodOfPayment).IsRequired();
        builder.Entity<SaleOrder>().Property(p => p.Category).IsRequired();
        builder.Entity<SaleOrder>().Property(p => p.Product).IsRequired();
        builder.Entity<SaleOrder>().Property(p => p.Amount).IsRequired().HasMaxLength(4);
    }

}