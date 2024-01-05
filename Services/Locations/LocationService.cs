using Microsoft.EntityFrameworkCore;
using Restaurant.Website.Models;
using Restaurant.Website.Shared;

namespace Restaurant.Website.Service;

public class LocationService : ILocationService
{
    private readonly RestaurantContext db;

    public LocationService(RestaurantContext db)
    {
        this.db = db;
    }

    public async Task<Location?> CreateLocation(Location l)
    {
        await db.locations.AddAsync(l);
        int modified = await db.SaveChangesAsync();

        if (modified == 1) 
        {
            return l;
        }

        return null;
    }

    public async Task<bool> DeleteLocation(int id)
    {
        Location? location = await db.locations.FirstOrDefaultAsync(l => l.Id == id);

        if(location == null) 
            return false;

        db.locations.Remove(location);
        int modified = await db.SaveChangesAsync();

        if (modified == 1) 
            return true;

        return false;
    }

    public async Task<Location?> GetLocation(int id)
    {
        Location? location = await db.locations.FirstOrDefaultAsync(location => location.Id == id);
        if (location is not null) return location;

        return null;
    }

    public IEnumerable<Location> GetLocations()
    {
        IEnumerable<Location> locations = db.locations;

        if (locations != null && locations.Any()) 
        {
            return locations;
        }

        return Enumerable.Empty<Location>();
    }

    public async Task<bool> UpdateLocation(Location l)
    {
        Location? foundLocation = await db.locations.FirstOrDefaultAsync(loc => loc.Id == l.Id);

        if (foundLocation == null) return false;

        db.Entry(foundLocation).CurrentValues.SetValues(l);
        int modified = await db.SaveChangesAsync();

        if (modified == 1) return true;

        return false;
    }
}