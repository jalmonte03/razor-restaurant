using Microsoft.EntityFrameworkCore;
using Restaurant.Website.Models;
using Restaurant.Website.Shared;

namespace Restaurant.Website.Service;

public class DishService : IDishService
{
    private RestaurantContext db;

    public DishService(RestaurantContext db) 
    {
        this.db = db;
    }

    public async Task<Dish?> CreateDish(Dish dish)
    {
        await db.dishes.AddAsync(dish);
        var modified = db.SaveChanges();

        if (modified == 1)
        {
            return dish;
        }

        return null;
    }

    public async Task<Dish?> GetDish(int id)
    {
        Dish? dish = await db.dishes.FirstOrDefaultAsync(d => d.Id == id);

        if (dish is not null)
            return dish;

        return null;
    }

    public Task<IEnumerable<Dish>> GetDishes()
    {
        IEnumerable<Dish> dishes = db.dishes;

        return Task.FromResult(dishes);
    }

    public async Task<bool> RemoveDish(int id)
    {
        Dish? foundDish = await db.dishes.FirstOrDefaultAsync(d => d.Id == id);

        if(foundDish is null) return false;

        db.dishes.Remove(foundDish);
        int modified = await db.SaveChangesAsync();
        
        if (modified == 1)
        {
            Console.WriteLine("Dish deleted successfully.");
            return true;
        }

        Console.WriteLine("An error occurred while deleting the dish.");
        return false;
    }

    public async Task<bool> UpdateDish(Dish dish)
    {
        Dish? foundDish = await db.dishes.FirstOrDefaultAsync(d => d.Id == dish.Id);

        if(foundDish is null) return false;

        db.Entry(foundDish).CurrentValues.SetValues(dish);
        await db.SaveChangesAsync();
        
        return true;
    }
}