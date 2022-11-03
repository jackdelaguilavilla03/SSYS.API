using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
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
    public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
    
    public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }//1
    public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }//2

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Relationships
        builder.Entity<Account>()
            .HasMany(u => u.Users)
            .WithOne(u => u.Account)
            .HasForeignKey(u => u.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        //Main User
        builder.Entity<Account>().ToTable("MainUsers");
        builder.Entity<Account>().HasKey(p => p.Id);
        builder.Entity<Account>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Account>().Property(p => p.Users).IsRequired().HasMaxLength(100);

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

    }

}