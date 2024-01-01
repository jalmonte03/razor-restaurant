using Microsoft.EntityFrameworkCore;
using Restaurant.Website.Models;

namespace Restaurant.Website.Shared;
public class RestaurantContext : DbContext
{
    public DbSet<Dish> dishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(
            Environment.CurrentDirectory, "data.db"
        );

        string connection = $"Filename={path}";

        optionsBuilder.UseSqlite(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dish>()
            .Property(dish => dish.Price)
            .HasConversion(
                price => decimal.ToInt32(price * 100),
                price => ((decimal)(price))/100m
            );
    }
}