using Restaurant.Website.Models;

namespace Restaurant.Website.Service;
public interface ILocationService
{
    Task<Location?> CreateLocation(Location l);
    Task<Location?> GetLocation(int id);
    IEnumerable<Location> GetLocations();
    Task<bool> UpdateLocation(Location l);
    Task<bool> DeleteLocation(int id);
}