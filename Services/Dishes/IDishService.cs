using Restaurant.Website.Models;

namespace Restaurant.Website.Service;

public interface IDishService 
{
    public Task<IEnumerable<Dish>> GetDishes();
    public Task<Dish?> GetDish (int id);
    public Task<Dish?> CreateDish(Dish dish);
    public Task<bool> UpdateDish(Dish dish);
    public Task<bool> RemoveDish(int id);
}