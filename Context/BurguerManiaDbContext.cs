using burguermania_backend.Models;
using burguermania_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace burguermania_backend.Context;

public class BurguerManiaDbContext : DbContext {
    public BurguerManiaDbContext(DbContextOptions<BurguerManiaDbContext>options) : base(options) { }
    public required DbSet<Category> Categories { get; set; }
    public required DbSet<Status> Status {get; set; }
    public required DbSet<Product> Products { get; set; }
    public required DbSet<User> Users{ get; set; }
    public required DbSet<Order> Orders{ get; set; }
    public required DbSet<OrderProduct> OrderProducts{ get; set; }
    public required DbSet<UserOrder> UserOrders {get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        foreach(var category in Seed.Categories){
            modelBuilder.Entity<Category>().HasData(category);
        }

        foreach(var product in Seed.Products){
            modelBuilder.Entity<Product>().HasData(product);
        }

        foreach(var status in Seed.Status){
            modelBuilder.Entity<Status>().HasData(status);
        }

        foreach(var user in Seed.Users){
            modelBuilder.Entity<User>().HasData(user);
        }
    }
}