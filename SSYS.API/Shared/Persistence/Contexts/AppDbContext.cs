using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using SSYS.API.IAM.Domain.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace SSYS.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public Microsoft.EntityFrameworkCore.DbSet<MainUser> MainUsers { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Relationships
        builder.Entity<MainUser>()
            .HasMany(u => u.Users)
            .WithOne(u => u.MainUser)
            .HasForeignKey(u => u.MainUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        //Main User
        builder.Entity<MainUser>().ToTable("MainUsers");
        builder.Entity<MainUser>().HasKey(p => p.Id);
        builder.Entity<MainUser>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MainUser>().Property(p => p.Username).IsRequired().HasMaxLength(100);
        
        //User
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(100);
    }
    
    
}